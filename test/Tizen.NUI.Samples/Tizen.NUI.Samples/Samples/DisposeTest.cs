﻿using System;
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Samples
{
    // Make custom view to ignore Layout features so we can use Depth information
    public class Custom3DView : CustomView
    {
        // Default View Enabled SizeNegotiations, and It is Breakdown the depth values.
        // So we need to create CustomView whitch CustomViewBehavior.DisableSizeNegotiation.
        public Custom3DView() : base("Custom3DView", CustomViewBehaviour.DisableSizeNegotiation)
        {
            // Make this object use centered.
            PositionUsesPivotPoint = true;
            ParentOrigin = Position.ParentOriginCenter;
            PivotPoint = Position.PivotPointCenter;
        }

        public override void OnInitialize()
        {
        }
    }

    // copied from https://github.com/hinohie/nui-demo/blob/geotest/Mesh/Mesh.cs
    public class DisposeTest : IExample
    {
        public struct Vec2
        {
            float x;
            float y;
            public Vec2(float xIn, float yIn)
            {
                x = xIn;
                y = yIn;
            }
        }
        public struct Vec3
        {
            float x;
            float y;
            float z;
            public Vec3(float xIn, float yIn, float zIn)
            {
                x = xIn;
                y = yIn;
                z = zIn;
            }
        }

        struct TexturedQuadVertex
        {
            public Vec3 position;
            public Vec3 normal;
            public Vec2 texcoord;
        }

        static readonly string VERTEX_SHADER =
        "//@name DisposeTest.vert\n" +
        "\n" +
        "//@version 100\n" +
        "\n" +
        "precision mediump float;\n"+
        "INPUT highp vec3 aPosition;\n" +
        "INPUT highp vec3 aNormal;\n" +
        "INPUT highp vec2 aTexCoord;\n" +
        "\n" +
        "OUTPUT highp vec3 vNormal;\n" +
        "OUTPUT highp vec2 vTexCoord;\n" +
        "OUTPUT highp vec3 vPosition;\n" +
        "\n" +
        "UNIFORM_BLOCK VertBlock\n" +
        "{\n" +
        "  UNIFORM highp mat4 uMvpMatrix;\n" +
        "  UNIFORM highp mat3 uNormalMatrix;\n" +
        "  UNIFORM highp vec3 uSize;\n" +
        "};\n" +
        "void main()\n" +
        "{\n" +
        "    vec4 pos = vec4(aPosition, 1.0)*vec4(uSize,1.0);\n"+
        "    gl_Position = uMvpMatrix*pos;\n" +
        "    vPosition = aPosition;\n" +
        "    vNormal   = normalize(uNormalMatrix * aNormal);\n" +
        "    vTexCoord = aTexCoord;\n" +
        "}\n";

        static readonly string FRAGMENT_SHADER =
        "//@name DisposeTest.frag\n" +
        "\n" +
        "//@version 100\n" +
        "\n" +
        "precision mediump float;\n"+
        "INPUT highp vec3 vNormal;\n" +
        "INPUT highp vec2 vTexCoord;\n" +
        "INPUT highp vec3 vPosition;\n" +
        "\n" +
        "UNIFORM_BLOCK FragBlock\n" +
        "{\n" +
        "  UNIFORM lowp vec4 uColor;\n" +
        "};\n" +
        "UNIFORM sampler2D sTexture;\n" +
        "\n" +
        "mediump vec3 uLightDir = vec3(2.0, 0.5, 1.0);\n" + // constant light dir
        "mediump vec3 uViewDir  = vec3(0.0, 0.0, 1.0);\n" + // constant view dir.
        "mediump vec3 uAmbientColor = vec3(0.2, 0.2, 0.2);\n" +
        "mediump vec3 uDiffuseColor = vec3(0.8, 0.8, 0.8);\n" +
        "mediump vec3 uSpecularColor = vec3(0.5, 0.5, 0.5);\n" +
        "void main()\n" +
        "{\n" +
        "    mediump vec3 lightdir = normalize(uLightDir);\n" +
        "    mediump vec3 eyedir   = normalize(uViewDir);\n" +
        "    mediump vec4 texColor = texture2D( sTexture, vTexCoord ) * uColor;\n" +
        "    mediump float diffuse = min(max(-dot(vNormal, lightdir) + 0.1, 0.0), 1.0);\n" +
        "    mediump vec3 reflectdir = reflect(-lightdir, vNormal);\n" +
        "    mediump float specular = pow(max(0.0, dot(reflectdir, eyedir)), 50.0);\n" +
        "    mediump vec4 color = texColor * vec4(uAmbientColor + uDiffuseColor * diffuse, 1.0) + vec4(uSpecularColor, 0.0) * specular;\n" +
        "    gl_FragColor = color;\n" +
        "}\n";

        // Copy from dali-toolkit/internal/visuals/primitive/primitive-visual.cpp
        // NOTE. I add one more slices for texture coordinate
        private TexturedQuadVertex[] SphereVertexData()
        {
            TexturedQuadVertex[] vertices = new TexturedQuadVertex[SPHERE_VERTEX_NUMBER];

            const int slices = SPHERE_SLICES;
            const int stacks = SPHERE_STACKS;
            // Build start.
            {
                int vertexIndex = 0; //Track progress through vertices.
                float x;
                float y;
                float z;

                //Top stack.
                vertices[vertexIndex].position = new Vec3(0.0f, 0.5f, 0.0f);
                vertices[vertexIndex].normal = new Vec3(0.0f, 1.0f, 0.0f);
                vertices[vertexIndex].texcoord = new Vec2(0.5f, 1.0f);
                vertexIndex++;

                //Middle stacks.
                for (int i = 1; i < stacks; i++)
                {
                    //Note. This vertex method is not common.
                    //We set one more vertexes for correct texture coordinate. at j == slices
                    //j==0 and j==slices have equal position, normal, but there texcoord.x is different
                    for (int j = 0; j <= slices; j++, vertexIndex++)
                    {
                        float cos_j = (float)Math.Cos(2.0f * (float)Math.PI * j / (float)slices);
                        float sin_j = (float)Math.Sin(2.0f * (float)Math.PI * j / (float)slices);
                        float cos_i = (float)Math.Cos((float)Math.PI * i / (float)stacks);
                        float sin_i = (float)Math.Sin((float)Math.PI * i / (float)stacks);
                        x = cos_j * sin_i;
                        y = cos_i;
                        z = sin_j * sin_i;

                        vertices[vertexIndex].position = new Vec3(x / 2.0f, y / 2.0f, z / 2.0f);
                        vertices[vertexIndex].normal = new Vec3(x, y, z);
                        vertices[vertexIndex].texcoord = new Vec2((float)j / (float)slices, 1.0f - (float)i / (float)stacks);
                    }
                }

                //Bottom stack.
                vertices[vertexIndex].position = new Vec3(0.0f, -0.5f, 0.0f);
                vertices[vertexIndex].normal = new Vec3(0.0f, -1.0f, 0.0f);
                vertices[vertexIndex].texcoord = new Vec2(0.5f, 0.0f);
            }
            // Build done.

            return vertices;
        }

        private ushort[] SphereIndexData()
        {
            ushort[] indices = new ushort[SPHERE_INDEX_NUMBER];
            const int slices = SPHERE_SLICES;
            const int stacks = SPHERE_STACKS;

            // Build start.
            {
                int indiceIndex = 0; //Used to keep track of progress through indices.
                int previousCycleBeginning = 1; //Stores the index of the vertex that started the cycle of the previous stack.
                int currentCycleBeginning = 1 + slices + 1;

                //Top stack. Loop from index 1 to index slices, as not counting the very first vertex.
                for (int i = 1; i <= slices; i++, indiceIndex += 3)
                {
                    indices[indiceIndex] = 0;
                    indices[indiceIndex + 1] = (ushort)(i + 1);
                    indices[indiceIndex + 2] = (ushort)i;
                }

                //Middle Stacks. Want to form triangles between the top and bottom stacks, so loop up to the number of stacks - 2.
                //Note. This index method is not common.
                //We increase Beginning indexes slices+1 cause we add one more vertexes for correct texture coordinate.
                for (int i = 0; i < stacks - 2; i++, previousCycleBeginning += slices + 1, currentCycleBeginning += slices + 1)
                {
                    for (int j = 0; j < slices; j++, indiceIndex += 6)
                    {
                        indices[indiceIndex] = (ushort)(previousCycleBeginning + j);
                        indices[indiceIndex + 1] = (ushort)(previousCycleBeginning + 1 + j);
                        indices[indiceIndex + 2] = (ushort)(currentCycleBeginning + j);
                        indices[indiceIndex + 3] = (ushort)(currentCycleBeginning + j);
                        indices[indiceIndex + 4] = (ushort)(previousCycleBeginning + 1 + j);
                        indices[indiceIndex + 5] = (ushort)(currentCycleBeginning + 1 + j);
                    }
                }

                //Bottom stack. Loop around the last stack from the previous loop, and go up to the penultimate vertex.
                for (int i = 0; i < slices; i++, indiceIndex += 3)
                {
                    indices[indiceIndex] = (ushort)(previousCycleBeginning + slices + 1);
                    indices[indiceIndex + 1] = (ushort)(previousCycleBeginning + i);
                    indices[indiceIndex + 2] = (ushort)(previousCycleBeginning + i + 1);
                }
            }
            // Build done.

            return indices;
        }
        const int SPHERE_SLICES = 30; // >= 3
        const int SPHERE_STACKS = 20; // >= 1
        const int SPHERE_VERTEX_NUMBER = (SPHERE_SLICES + 1) * (SPHERE_STACKS - 1) + 2;
        const int SPHERE_INDEX_NUMBER = 6 * SPHERE_SLICES * (SPHERE_STACKS - 1);

        private const int AutoDisposedObjectCount = 10;
        private const int ManualDisposedObjectCount = 10;
        private const int RecuvelyDisposedObjectCount = 10;
        private Window win;
        private View root;
        private Timer timer;
        private bool toggle = false;
        private string resource;
        private List<Custom3DView> views;
        private List<Custom3DView> depthViews; // List of tree-formed views. 0 indexes view is root.
        private List<Renderable> renderables;
        private Animation rotateAnimation;

        private Dictionary<string, Texture> textureDictionary = new();

        public void Activate()
        {
            win = NUIApplication.GetDefaultWindow();
            resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
            // Set layer behavior as Layer3D. without this, Rendering will be broken
            win.GetDefaultLayer().Behavior = Layer.LayerBehavior.Layer3D;
            root = new View()
            {
                Name = "root",
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };
            win.Add(root);

            views = new List<Custom3DView>();
            depthViews = new List<Custom3DView>();
            renderables = new List<Renderable>();
            rotateAnimation = new Animation(1500); //1.5s

            AddManyViews();
            toggle = true;

            timer = new Timer(3000); //3s
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        private bool OnTimerTick(object source, Timer.TickEventArgs e)
        {
            toggle = !toggle;
            if (toggle)
            {
                Tizen.Log.Error("NUI", $"View Creation Start\n");
                AddManyViews();
                Tizen.Log.Error("NUI", $"View Creation Finish\n");
            }
            else
            {
                Tizen.Log.Error("NUI", $"Manual Dispose Start\n");
                RemoveAllViews();
                Tizen.Log.Error("NUI", $"Manual Dispose Finish\n");
                FullGC();
            }
            return true;
        }

        private Geometry GenerateGeometry()
        {
            using PropertyMap vertexFormat = new PropertyMap();
            vertexFormat.Add("aPosition", new PropertyValue((int)PropertyType.Vector3));
            vertexFormat.Add("aNormal", new PropertyValue((int)PropertyType.Vector3));
            vertexFormat.Add("aTexCoord", new PropertyValue((int)PropertyType.Vector2));
            using PropertyBuffer vertexBuffer = new PropertyBuffer(vertexFormat);

            TexturedQuadVertex[] vertices = SphereVertexData();

            int length = Marshal.SizeOf(vertices[0]);
            global::System.IntPtr pA = Marshal.AllocHGlobal(checked(length * SPHERE_VERTEX_NUMBER));

            try
            {
                for (int i = 0; i < SPHERE_VERTEX_NUMBER; i++)
                {
                    Marshal.StructureToPtr(vertices[i], pA + i * length, true);
                }

                vertexBuffer.SetData(pA, SPHERE_VERTEX_NUMBER);
            }
            finally
            {
                // We can free raw data after SetData call finished.
                Marshal.FreeHGlobal(pA);
            }

            ushort[] indexBuffer = SphereIndexData();

            Geometry geometry = new Geometry();
            geometry.AddVertexBuffer(vertexBuffer);
            geometry.SetIndexBuffer(indexBuffer, SPHERE_INDEX_NUMBER);
            geometry.SetType(Geometry.Type.TRIANGLES);

            return geometry;
        }

        private Shader GenerateShader()
        {
            Shader shader = new Shader(VERTEX_SHADER, FRAGMENT_SHADER, "DisposeTestShader");
            return shader;
        }

        private Renderable GenerateRenderable(string textureUrl)
        {
            Texture texture;
            if (!textureDictionary.TryGetValue(textureUrl, out texture))
            {
                // Let we load image only 1 times per each objects
                using PixelData pixelData = PixelBuffer.Convert(ImageLoader.LoadImageFromFile(
                    textureUrl,
                    new Size2D(),
                    FittingModeType.ScaleToFill
                ));

                texture = new Texture(
                    TextureType.TEXTURE_2D,
                    pixelData.GetPixelFormat(),
                    pixelData.GetWidth(),
                    pixelData.GetHeight()
                );
                texture.Upload(pixelData);
                if (!textureDictionary.TryAdd(textureUrl, texture))
                {
                    Tizen.Log.Error("NUI", "Something wrong when we try to add Texture into dictionary\n");
                }
            }
            TextureSet textureSet = new TextureSet();
            textureSet.SetTexture(0u, texture);

            Renderable renderable = new Renderable()
            {
                Geometry = GenerateGeometry(),
                Shader = GenerateShader(),
            };
            renderable.TextureSet = textureSet;

            renderables.Add(renderable);

            return renderable;
        }

        private void AddManyViews()
        {
            Random rand = new Random();

            for (int i = 0; i < AutoDisposedObjectCount; i++)
            {
                int viewSize = 150;
                var view = new Custom3DView()
                {
                    Size = new Size(viewSize, viewSize, viewSize),
                    Position = new Position(
                        rand.Next(10, win.WindowSize.Width - 10) - win.WindowSize.Width / 2,
                        rand.Next(10, win.WindowSize.Height - 10) - win.WindowSize.Height / 2,
                        rand.Next(-3 * viewSize, 3 * viewSize)
                    ),
                    Name = "Auto_" + i.ToString(),
                };
                root.Add(view);
                view.AddRenderable(GenerateRenderable(resource + "/images/PopupTest/circle.jpg"));

                rotateAnimation.AnimateBy(view, "Orientation", new Rotation(new Radian(new Degree(360.0f)), Vector3.YAxis));
            }

            for (int i = 0; i < ManualDisposedObjectCount; i++)
            {
                int viewSize = 150;
                var view = new Custom3DView()
                {
                    Size = new Size(viewSize, viewSize, viewSize),
                    Position = new Position(
                        rand.Next(10, win.WindowSize.Width - 10) - win.WindowSize.Width / 2,
                        rand.Next(10, win.WindowSize.Height - 10) - win.WindowSize.Height / 2,
                        rand.Next(-3 * viewSize, 3 * viewSize)
                    ),
                    Name = "Manual_" + i.ToString(),
                };
                root.Add(view);
                views.Add(view);

                view.AddRenderable(GenerateRenderable(resource + "/images/PaletteTest/red2.jpg"));

                rotateAnimation.AnimateBy(view, "Orientation", new Rotation(new Radian(new Degree(-360.0f)), Vector3.YAxis));
            }

            for (int i = 0; i < RecuvelyDisposedObjectCount; i++)
            {
                int viewSize = 150;
                var view = new Custom3DView()
                {
                    // Note that we need to disconnect inherit to make this view shows well.
                    InheritPosition = false,
                    InheritOrientation = false,

                    Size = new Size(viewSize, viewSize, viewSize),

                    Position = new Position(
                        rand.Next(10, win.WindowSize.Width - 10) - win.WindowSize.Width / 2,
                        rand.Next(10, win.WindowSize.Height - 10) - win.WindowSize.Height / 2,
                        rand.Next(-3 * viewSize, 3 * viewSize)
                    ),
                    Name = "Recursive_" + i.ToString(),
                };

                // Add view recursively.
                if(i == 0)
                {
                    root.Add(view);
                }
                else
                {
                    int parentIndex = rand.Next(i);
                    var parent = depthViews[parentIndex];
                    parent.Add(view);
                }
                depthViews.Add(view);

                view.AddRenderable(GenerateRenderable(resource + "/images/PaletteTest/rock.jpg"));

                //rotateAnimation.AnimateBy(view, "Orientation", new Rotation(new Radian(new Degree(360.0f)), Vector3.ZAxis));
            }
            rotateAnimation.Looping = true;
            rotateAnimation.Play();
        }
        private void RemoveAllViews()
        {
            uint cnt = root.ChildCount;
            for (int i = (int)(cnt - 1); i >= 0; i--)
            {
                root.Remove(root.GetChildAt((uint)i));
            }
            foreach (var view in views)
            {
                view?.Dispose();
            }
            foreach (var renderable in renderables)
            {
                renderable?.Geometry?.Dispose();
                renderable?.Shader?.Dispose();
                renderable?.TextureSet?.Dispose();
                renderable?.Dispose();
            }
            if (depthViews?.Count > 0)
            {
                depthViews[0]?.DisposeRecursively();
            }

            views.Clear();
            depthViews.Clear();
            renderables.Clear();

            rotateAnimation.Clear();
        }

        private void FullGC()
        {
            global::System.GC.Collect();
            global::System.GC.WaitForPendingFinalizers();
            global::System.GC.Collect();
        }

        public void Deactivate()
        {
            timer.Stop();
            RemoveAllViews();
            rotateAnimation?.Dispose();
            root.Unparent();
            root.Dispose();

            textureDictionary.Clear();

            // Revert default layer behavior as LayerUI
            win.GetDefaultLayer().Behavior = Layer.LayerBehavior.LayerUI;
        }
    }
}
