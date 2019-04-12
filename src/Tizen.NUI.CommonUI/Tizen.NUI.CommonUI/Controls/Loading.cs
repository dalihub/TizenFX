/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI.CommonUI
{    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Loading : Control
    {    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<string> ImageArray = null;
        private LoadingAttributes loadingAttrs = null;  // Loading Attributes

        private ImageView imageView = null;             // ImageView object
        private AnimatedImageVisual imageVisual = null;
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Loading() : base()
        {
            loadingAttrs = this.attributes as LoadingAttributes;
            Initialize();
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Loading(string style) : base(style)
        {
            if (attributes != null)
                loadingAttrs = attributes as LoadingAttributes;
            Initialize();
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Loading(LoadingAttributes attributes) : base()
        {
            this.attributes = loadingAttrs = attributes.Clone() as LoadingAttributes;
            Initialize();
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string LoadingImageURLPrefix
        {
            get
            {
                return loadingAttrs.LoadingImageURLPrefix.All;
            }
            set
            {
                loadingAttrs.LoadingImageURLPrefix.All = value;

                UpdateList();

            }
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int FPS
        {
            get
            {
                if (loadingAttrs.FPS == null)
                {
                    loadingAttrs.FPS = new IntSelector();
                    loadingAttrs.FPS.All = (int)(1000.0f / imageVisual.FrameDelay);
                }
                return loadingAttrs.FPS.All.Value;
            }
            set
            {
                if (loadingAttrs.FPS == null)
                {
                    loadingAttrs.FPS = new IntSelector();
                    loadingAttrs.FPS.All = (int)(1000.0f / imageVisual.FrameDelay);
                }
                loadingAttrs.FPS.All = value;
                imageVisual.FrameDelay = 1000.0f / (float)value;

            }
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new LoadingAttributes
            {
                LoadingImageURLPrefix = new StringSelector(),
            };
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
                //frameAni.Stop();
                //frameAni.Detach();
                //frameAni = null;

                // According to FrameAnimation spec, image source should be Disposed later than FrameAnimation.
                RemoveVisual("imageVisual");

            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            //Unreference this from if a static instance refer to this. 

            //You must call base.Dispose(type) just before exit.
            base.Dispose(type);
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate(Attributes attrs)
        {
            if (loadingAttrs == null)
            {
                return;
            }
            ApplyAttributes(this, loadingAttrs);
        }

        private void Initialize()
        {
            ImageArray = new List<string>();
            imageVisual = new AnimatedImageVisual()
            {
                URLS = ImageArray,
                FrameDelay = 16.6f,
                LoopCount = -1,
                Size = new Size2D(100, 100),
                Position = new Vector2(0, 0),
                Origin = Visual.AlignType.TopEnd,
                AnchorPoint = Visual.AlignType.TopEnd
            };

            UpdateList();

            this.AddVisual("imageVisual", imageVisual);
        }

        private void UpdateList()
        {

            if (ImageArray != null)
            {
                ImageArray.Clear();
                if (loadingAttrs != null)
                {
                    if (loadingAttrs.LoadingImageURLPrefix != null)
                    {
                        for (int i = 0; i <= 35; i++)
                        {
                            string pre = loadingAttrs.LoadingImageURLPrefix.All;
                            if (i < 10)
                            {

                                ImageArray.Add(pre + "0" + i.ToString() + ".png");
                            }
                            else
                            {
                                ImageArray.Add(pre + i.ToString() + ".png");
                            }

                        }
                    }
                }
                imageVisual.URLS = ImageArray;
            }

        }
    }
}
