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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI.CommonUI
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Toast : Control
    {
        private ToastAttributes toastAttributes;
        private ImageView toastBackground;
        private TextLabel toastText;
        private Timer timer;
        private Animation showAnimation;
        private Animation hideAnimation;
        private int leftSpace;
        private int downSpace;
        private bool autoDestroy = false;
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Toast() : base()
        {
            SetAttribute();

            Initialize();
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Toast(ToastAttributes attributes)
        {
            this.attributes = toastAttributes = attributes.Clone() as ToastAttributes;
            Initialize();
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Toast(string style) : base(style)
        {
            if (attributes != null)
                toastAttributes = attributes as ToastAttributes;
            if (toastAttributes == null)
            {
                throw new Exception("Toast attribute parse error.");
            }
            Initialize();
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Text
        {
            get
            {
                return toastText?.Text;
            }
            set
            {
                toastText.Text = value;
            }

        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BackgroundImageURL
        {
            get
            {
                if (toastAttributes.BackgroundImageAttributes.ResourceURL == null)
                    toastAttributes.BackgroundImageAttributes.ResourceURL = new StringSelector();
                return toastAttributes.BackgroundImageAttributes.ResourceURL.All;
            }
            set
            {
                if (toastAttributes.BackgroundImageAttributes.ResourceURL == null)
                {
                    toastAttributes.BackgroundImageAttributes.ResourceURL = new StringSelector();
                }

                toastAttributes.BackgroundImageAttributes.ResourceURL.All = value;
                RelayoutRequest();
            }
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int LeftSpace
        {
            get
            {
                return leftSpace;
            }
            set
            {
                leftSpace = value;
                RelayoutRequest();
            }
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int UpSpace
        {
            get
            {
                if (toastAttributes.UpSpace == null)
                {
                    toastAttributes.UpSpace = new int();
                }
                return toastAttributes.UpSpace.Value;
            }
            set
            {
                if (toastAttributes.UpSpace == null)
                {
                    toastAttributes.UpSpace = new int();
                }
                toastAttributes.UpSpace = value;
                downSpace = value;
            }
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int DownSpace
        {
            get
            {
                return downSpace;
            }
            set
            {
                downSpace = value;
            }
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle BackgroundBorder
        {
            get
            {
                return toastAttributes?.BackgroundImageAttributes?.Border.All;
            }
            set
            {
                if (toastAttributes.BackgroundImageAttributes.Border == null)
                {
                    toastAttributes.BackgroundImageAttributes.Border = new RectangleSelector();
                }
                toastAttributes.BackgroundImageAttributes.Border.All = value;
            }

        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D TextSize2D
        {
            get
            {
                return toastAttributes?.TextAttributes?.Size2D;
            }
            set
            {
                toastText.Size2D = toastAttributes.TextAttributes.Size2D = value;
            }

        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position2D TextPosition2D
        {
            set
            {
                toastText.Position2D = toastAttributes.TextAttributes.Position2D = value;
            }
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Show(uint millisecond, bool autoDestroy = false)
        {
            ShowWithAnimation(opacityDuration: 700, opacityStart: 0.5f, scaleDuration: 700, scaleStart: 0.97f);
            CreateTimer(millisecond);
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
                if (toastBackground != null)
                {
                    this.Remove(toastBackground);
                    toastBackground.Dispose();
                    toastBackground = null;
                }

                if (toastText != null)
                {
                    this.Remove(toastText);
                    toastText.Dispose();
                    toastText = null;
                }
            }

            base.Dispose(type);
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate(Attributes attributes)
        {
            if (toastAttributes == null)
            {
                return;
            }

            LayoutChild();

            /////////////////////////////////////////////////////
            ApplyAttributes(this, toastAttributes);

            ///////////////////// Background ///////////////////////////////
            ApplyAttributes(toastBackground, toastAttributes.BackgroundImageAttributes);
            ////////////////////// Text //////////////////////////////
            ApplyAttributes(toastText, toastAttributes.TextAttributes);
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnRelayout(object sender, EventArgs e)
        {
            OnUpdate(attributes);
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new ToastAttributes
            {
                TextAttributes = new TextAttributes
                {

                },

                BackgroundImageAttributes = new ImageAttributes
                {

                }

            };
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void LayoutChild()
        {
            if (toastAttributes.TextAttributes.Size2D == null)
            {
                toastAttributes.TextAttributes.Size2D = new Size2D();
            }
            if (toastAttributes.TextAttributes.Position2D == null)
            {
                toastAttributes.TextAttributes.Position2D = new Position2D();
            }
            toastAttributes.TextAttributes.Size2D.Width = this.Size2D.Width - 2 * LeftSpace;
            toastAttributes.TextAttributes.Size2D.Height = this.Size2D.Height - UpSpace - downSpace;
            toastAttributes.TextAttributes.Position2D.X = LeftSpace;
            toastAttributes.TextAttributes.Position2D.Y = UpSpace;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void SetAttribute()
        {
            toastAttributes = this.attributes as ToastAttributes;
        }

        private void Initialize()
        {
            toastBackground = new ImageView()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };
            this.Add(toastBackground);

            toastText = new TextLabel()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            this.Add(toastText);
        }

        private void ShowWithAnimation(float opacityStart = 0.5f,
                                        float opacityEnd = 1.0f,
                                        int opacityStartTime = 0,
                                        int opacityDuration = 700,
                                        string opacityMotionCurve = "Basic",
                                        float scaleStart = 0.98f,
                                        float scaleEnd = 1.0f,
                                        int scaleStartTime = 0,
                                        int scaleDuration = 700,
                                        string scaleMotionCurve = "Elastic"
                                                                    )
        {
            if (hideAnimation != null && hideAnimation.State == Animation.States.Playing)
            {
                hideAnimation.Finished -= HideAnimationFinished;
                hideAnimation.Stop();
            }
            else if (Visibility == true)
            {
                //return;
            }

            if (showAnimation == null)
            {
                showAnimation = new Animation();
            }
            else if (showAnimation.State == Animation.States.Playing)
            {
                return;
            }

            //set start value
            Opacity = opacityStart;
            float scaleStartVal = scaleStart;
            float scaleEndVal = scaleEnd;
            showAnimation.Clear();
            Scale = new Vector3(scaleStartVal, scaleStartVal, 1);
            Show();

            showAnimation.Clear();

            int opacityEndTime = opacityStartTime + opacityDuration;
            int scaleEndTime = scaleStartTime + scaleDuration;
            showAnimation.Duration = opacityEndTime > scaleEndTime ? opacityEndTime : scaleEndTime;
            showAnimation.AnimateTo(this, "Opacity", opacityEnd, opacityStartTime, opacityEndTime);
            showAnimation.AnimateTo(this, "Scale", new Vector3(scaleEndVal, scaleEndVal, 1), scaleStartTime, scaleEndTime);

            showAnimation.Play();

        }

        private void HideWithAnimation(float opacityStart = 1.0f,
                                        float opacityEnd = 0.0f,
                                        int opacityStartTime = 0,
                                        int opacityDuration = 200,
                                        string opacityMotionCurve = "Basic",
                                        float scaleStart = 1.0f,
                                        float scaleEnd = 0.99f,
                                        int scaleStartTime = 0,
                                        int scaleDuration = 200,
                                        string scaleMotionCurve = "Elastic",
                                        bool autoDestroy = false
                                        )
        {
            if (showAnimation != null && showAnimation.State == Animation.States.Playing)
            {
                showAnimation.Stop();
            }
            if (Visibility == false)
            {
                return;
            }

            if (hideAnimation == null)
            {
                hideAnimation = new Animation();
            }
            else if (hideAnimation.State == Animation.States.Playing)
            {
                return;
            }

            hideAnimation.Finished += HideAnimationFinished;

            Opacity = opacityStart;
            float scaleStartVal = scaleStart;

            Scale = new Vector3(scaleStartVal, scaleStartVal, 1);

            hideAnimation.Clear();

            int opacityEndTime = opacityStartTime + opacityDuration;
            int scaleEndTime = scaleStartTime + scaleDuration;
            hideAnimation.Duration = opacityEndTime > scaleEndTime ? opacityEndTime : scaleEndTime;
            hideAnimation.AnimateTo(this, "Opacity", opacityEnd, opacityStartTime, opacityEndTime);
            float scaleEndVal = scaleEnd;
            hideAnimation.AnimateTo(this, "Scale", new Vector3(scaleEndVal, scaleEndVal, 1), scaleStartTime, scaleEndTime);

            hideAnimation.Play();
        }

        private void HideAnimationFinished(object sender, EventArgs e)
        {
            hideAnimation.Finished -= HideAnimationFinished;
            if (autoDestroy == true)
            {
                if (this.GetParent() != null)
                {
                    this.GetParent().Remove(this);
                }
                this.Dispose();
            }
            else
            {
                Hide();
                Opacity = 1.0f;
                Scale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }

        private void CreateTimer(uint millisecond)
        {
            if (timer != null)
            {
                timer.Dispose();
                timer = null;
            }

            timer = new Timer(millisecond);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private bool TimerTick(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Tick -= TimerTick;
            timer.Dispose();

            timer = null;
            HideWithAnimation(opacityDuration: 200, opacityEnd: 0.5f, scaleDuration: 200, scaleEnd: 0.95f);

            return false;
        }
    }
}
