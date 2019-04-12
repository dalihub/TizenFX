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
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI.CommonUI
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Switch : Button
    {
        private const int aniTime = 100; // will be defined in const file later
        private ImageView switchBackgroundImage;
        private ImageView switchHandlerImage;
        private Animation handlerAni = null;
        private SwitchAttributes switchAttributes;

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Switch() : base()
        {
            Initialize();
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Switch(string style) : base(style)
        {
            Initialize();
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Switch(SwitchAttributes attrs) : base(attrs)
        {
            Initialize();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<SelectEventArgs> SelectedEvent;

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SwitchBackgroundImageURL
        {
            get
            {
                return switchAttributes?.SwitchBackgroundImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateSwitchBackgroundImageAttributes();
                    if (switchAttributes.SwitchBackgroundImageAttributes.ResourceURL == null)
                    {
                        switchAttributes.SwitchBackgroundImageAttributes.ResourceURL = new StringSelector();
                    }
                    switchAttributes.SwitchBackgroundImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector SwitchBackgroundImageURLSelector
        {
            get
            {
                return switchAttributes?.SwitchBackgroundImageAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateSwitchBackgroundImageAttributes();
                    switchAttributes.SwitchBackgroundImageAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SwitchHandlerImageURL
        {
            get
            {
                return switchAttributes?.SwitchHandlerImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateSwitchHandlerImageAttributes();
                    if (switchAttributes.SwitchHandlerImageAttributes.ResourceURL == null)
                    {
                        switchAttributes.SwitchHandlerImageAttributes.ResourceURL = new StringSelector();
                    }
                    switchAttributes.SwitchHandlerImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector SwitchHandlerImageURLSelector
        {
            get
            {
                return switchAttributes?.SwitchHandlerImageAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateSwitchHandlerImageAttributes();
                    switchAttributes.SwitchHandlerImageAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position SwitchHandlerParentOrigin
        {
            get
            {
                return switchAttributes?.SwitchHandlerImageAttributes?.ParentOrigin;
            }
            set
            {
                if (value != null)
                {
                    CreateSwitchHandlerImageAttributes();
                    switchAttributes.SwitchHandlerImageAttributes.ParentOrigin = value;
                    RelayoutRequest();
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position SwitchHandlerPivotPoint
        {
            get
            {
                return switchAttributes?.SwitchHandlerImageAttributes?.PivotPoint;
            }
            set
            {
                if (value != null)
                {
                    CreateSwitchHandlerImageAttributes();
                    switchAttributes.SwitchHandlerImageAttributes.PivotPoint = value;
                    RelayoutRequest();
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D SwitchBackgroundImageSize2D
        {
            get
            {
                return switchAttributes?.SwitchBackgroundImageAttributes?.Size2D ?? new Size2D(0, 0);
            }
            set
            {
                CreateSwitchBackgroundImageAttributes();
                switchAttributes.SwitchBackgroundImageAttributes.Size2D = value;
                RelayoutRequest();
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D SwitchHandlerImageSize2D
        {
            get
            {
                return switchAttributes?.SwitchHandlerImageAttributes?.Size2D ?? new Size2D(0, 0);
            }
            set
            {
                CreateSwitchHandlerImageAttributes();
                switchAttributes.SwitchHandlerImageAttributes.Size2D = value;
                RelayoutRequest();
            }
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
                if (handlerAni != null)
                {
                    if (handlerAni.State == Animation.States.Playing)
                    {
                        handlerAni.Stop();
                    }
                    handlerAni.Dispose();
                    handlerAni = null;
                }

                if (switchHandlerImage != null)
                {
                    switchBackgroundImage.Remove(switchHandlerImage);
                    switchHandlerImage.Dispose();
                    switchHandlerImage = null;
                }
                if (switchBackgroundImage != null)
                {
                    Remove(switchBackgroundImage);
                    switchBackgroundImage.Dispose();
                    switchBackgroundImage = null;
                }
            }

            base.Dispose(type);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate(Attributes attributtes)
        {
            switchAttributes = attributes as SwitchAttributes;
            if (switchAttributes == null)
            {
                return;
            }
            base.OnUpdate(attributtes);

            if (switchAttributes.SwitchBackgroundImageAttributes != null)
            {
                if (switchBackgroundImage == null)
                {
                    switchBackgroundImage = new ImageView()
                    {
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                        PositionUsesPivotPoint = true,
                    };
                    switchBackgroundImage.Name = "SwitchBackgroundImage";
                    Add(switchBackgroundImage);
                }
                ApplyAttributes(switchBackgroundImage, switchAttributes.SwitchBackgroundImageAttributes);

                if (switchAttributes.SwitchHandlerImageAttributes != null)
                {
                    if (switchHandlerImage == null)
                    {
                        switchHandlerImage = new ImageView()
                        {
                            ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                            PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                            PositionUsesPivotPoint = true,
                        };
                        switchHandlerImage.Name = "SwitchHandlerImage";
                        switchBackgroundImage.Add(switchHandlerImage);
                    }
                    ApplyAttributes(switchHandlerImage, switchAttributes.SwitchHandlerImageAttributes);
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override bool OnKey(object source, KeyEventArgs e)
        {
            if (IsEnabled == false)
            {
                return false;
            }
            bool ret = base.OnKey(source, e);
            if (e.Key.State == Key.StateType.Up)
            {
                if (e.Key.KeyPressedName == "Return")
                {
                    OnSelect();
                }
            }

            return ret;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override bool OnTouch(object source, TouchEventArgs e)
        {
            if (IsEnabled == false)
            {
                return false;
            }
            PointStateType state = e.Touch.GetState(0);
            bool ret = base.OnTouch(source, e);
            switch (state)
            {
                case PointStateType.Up:
                    OnSelect();
                    break;
                default:
                    break;
            }
            return ret;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new SwitchAttributes();
        }

        private void Initialize()
        {
            switchAttributes = attributes as SwitchAttributes;
            if (switchAttributes == null)
            {
                throw new Exception("Switch attribute parse error.");
            }

            switchAttributes.IsSelectable = true;
            CreateHandlerAnimation();
        }

        private void CreateSwitchBackgroundImageAttributes()
        {
            if (switchAttributes.SwitchBackgroundImageAttributes == null)
            {
                switchAttributes.SwitchBackgroundImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                };
            }
        }

        private void CreateSwitchHandlerImageAttributes()
        {
            if (switchAttributes.SwitchHandlerImageAttributes == null)
            {
                switchAttributes.SwitchHandlerImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                };
            }
        }

        private void CreateHandlerAnimation()
        {
            if (handlerAni == null)
            {
                handlerAni = new Animation(aniTime);
            }
        }

        private void OnSelect()
        {
            if (handlerAni.State == Animation.States.Playing)
            {
                handlerAni.Stop();
            }
            handlerAni.Clear();
            if (switchHandlerImage != null)
            {
                handlerAni.AnimateTo(switchHandlerImage, "PositionX", Size2D.Width - switchHandlerImage.Size2D.Width - switchHandlerImage.Position2D.X);
            }
            if (switchBackgroundImage != null)
            {
                switchBackgroundImage.Opacity = 0.5f; ///////need defined by UX
                handlerAni.AnimateTo(switchBackgroundImage, "Opacity", 1);
            }
            handlerAni.Play();

            if (SelectedEvent != null)
            {
                SelectEventArgs eventArgs = new SelectEventArgs();
                eventArgs.IsSelected = IsSelected;
                SelectedEvent(this, eventArgs);
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class SelectEventArgs : EventArgs
        {
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool IsSelected;
        }
    }
}
