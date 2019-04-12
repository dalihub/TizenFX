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
    public class SelectButton : Button
    {
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected SelectGroup itemGroup = null;

        private ImageView checkShadowImage;
        private ImageView checkBackgroundImage;
        private ImageView checkImage;

        private SelectButtonAttributes selectButtonAttributes;

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SelectButton() : base()
        {
            selectButtonAttributes = attributes as SelectButtonAttributes;
            if (selectButtonAttributes == null)
            {
                throw new Exception("SelectButton attribute parse error.");
            }
            Initialize();
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SelectButton(string style) : base(style)
        {
            selectButtonAttributes = attributes as SelectButtonAttributes;
            if (selectButtonAttributes == null)
            {
                throw new Exception("SelectButton attribute parse error.");
            }
            Initialize();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SelectButton(SelectButtonAttributes attributes) : base()
        {
            this.attributes = selectButtonAttributes = attributes.Clone() as SelectButtonAttributes;
            Initialize();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<SelectEventArgs> SelectedEvent;

        /// <summary>
        /// Index of selection in selection group. If selection is not in the group, return -1;
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Index
        {
            get
            {
                if (itemGroup != null)
                {
                    return itemGroup.GetIndex(this);
                }

                return -1;
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CheckImageURL
        {
            get
            {
                return selectButtonAttributes?.CheckImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckImageAttributes();
                    if (selectButtonAttributes.CheckImageAttributes.ResourceURL == null)
                    {
                        selectButtonAttributes.CheckImageAttributes.ResourceURL = new StringSelector();
                    }
                    selectButtonAttributes.CheckImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector CheckImageURLSelector
        {
            get
            {
                return selectButtonAttributes?.CheckImageAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckImageAttributes();
                    selectButtonAttributes.CheckImageAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float CheckImageOpacity
        {
            get
            {
                return selectButtonAttributes?.CheckImageAttributes?.Opacity?.All ?? 0;
            }
            set
            {
                CreateCheckImageAttributes();
                if (selectButtonAttributes.CheckImageAttributes.Opacity == null)
                {
                    selectButtonAttributes.CheckImageAttributes.Opacity = new FloatSelector();
                }
                selectButtonAttributes.CheckImageAttributes.Opacity.All = value;
                RelayoutRequest();
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FloatSelector CheckImageOpacitySelector
        {
            get
            {
                return selectButtonAttributes?.CheckImageAttributes?.Opacity;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckImageAttributes();
                    selectButtonAttributes.CheckImageAttributes.Opacity = value.Clone() as FloatSelector;
                    RelayoutRequest();
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D CheckImageSize2D
        {
            get
            {
                return selectButtonAttributes?.CheckImageAttributes?.Size2D ?? new Size2D(0, 0);
            }
            set
            {
                CreateCheckImageAttributes();
                selectButtonAttributes.CheckImageAttributes.Size2D = value;
                RelayoutRequest();
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position2D CheckImagePosition2D
        {
            get
            {
                return selectButtonAttributes?.CheckImageAttributes?.Position2D ?? new Position2D(0, 0);
            }
            set
            {
                CreateCheckImageAttributes();
                selectButtonAttributes.CheckImageAttributes.Position2D = value;
                RelayoutRequest();
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CheckBackgroundImageURL
        {
            get
            {
                return selectButtonAttributes?.CheckBackgroundImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckBackgroundImageAttributes();
                    if (selectButtonAttributes.CheckBackgroundImageAttributes.ResourceURL == null)
                    {
                        selectButtonAttributes.CheckBackgroundImageAttributes.ResourceURL = new StringSelector();
                    }
                    selectButtonAttributes.CheckBackgroundImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector CheckBackgroundImageURLSelector
        {
            get
            {
                return selectButtonAttributes?.CheckBackgroundImageAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckBackgroundImageAttributes();
                    selectButtonAttributes.CheckBackgroundImageAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float CheckBackgroundImageOpacity
        {
            get
            {
                return selectButtonAttributes?.CheckBackgroundImageAttributes?.Opacity?.All ?? 0;
            }
            set
            {
                CreateCheckBackgroundImageAttributes();
                if (selectButtonAttributes.CheckBackgroundImageAttributes.Opacity == null)
                {
                    selectButtonAttributes.CheckBackgroundImageAttributes.Opacity = new FloatSelector();
                }
                selectButtonAttributes.CheckBackgroundImageAttributes.Opacity.All = value;
                RelayoutRequest();
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FloatSelector CheckBackgroundImageOpacitySelector
        {
            get
            {
                return selectButtonAttributes?.CheckBackgroundImageAttributes?.Opacity;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckBackgroundImageAttributes();
                    selectButtonAttributes.CheckBackgroundImageAttributes.Opacity = value.Clone() as FloatSelector;
                    RelayoutRequest();
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D CheckBackgroundImageSize2D
        {
            get
            {
                return selectButtonAttributes?.CheckBackgroundImageAttributes?.Size2D ?? new Size2D(0, 0);
            }
            set
            {
                CreateCheckBackgroundImageAttributes();
                selectButtonAttributes.CheckBackgroundImageAttributes.Size2D = value;
                RelayoutRequest();
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position2D CheckBackgroundImagePosition2D
        {
            get
            {
                return selectButtonAttributes?.CheckBackgroundImageAttributes?.Position2D ?? new Position2D(0, 0);
            }
            set
            {
                CreateCheckBackgroundImageAttributes();
                selectButtonAttributes.CheckBackgroundImageAttributes.Position2D = value;
                RelayoutRequest();
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CheckShadowImageURL
        {
            get
            {
                return selectButtonAttributes?.CheckShadowImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckShadowImageAttributes();
                    if (selectButtonAttributes.CheckShadowImageAttributes.ResourceURL == null)
                    {
                        selectButtonAttributes.CheckShadowImageAttributes.ResourceURL = new StringSelector();
                    }
                    selectButtonAttributes.CheckShadowImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector CheckShadowImageURLSelector
        {
            get
            {
                return selectButtonAttributes?.CheckShadowImageAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckShadowImageAttributes();
                    selectButtonAttributes.CheckShadowImageAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float CheckShadowImageOpacity
        {
            get
            {
                return selectButtonAttributes?.CheckShadowImageAttributes?.Opacity?.All ?? 0;
            }
            set
            {
                CreateCheckShadowImageAttributes();
                if (selectButtonAttributes.CheckShadowImageAttributes.Opacity == null)
                {
                    selectButtonAttributes.CheckShadowImageAttributes.Opacity = new FloatSelector();
                }
                selectButtonAttributes.CheckShadowImageAttributes.Opacity.All = value;
                RelayoutRequest();
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FloatSelector CheckShadowImageOpacitySelector
        {
            get
            {
                return selectButtonAttributes?.CheckShadowImageAttributes?.Opacity;
            }
            set
            {
                if (value != null)
                {
                    CreateCheckShadowImageAttributes();
                    selectButtonAttributes.CheckShadowImageAttributes.Opacity = value.Clone() as FloatSelector;
                    RelayoutRequest();
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D CheckShadowImageSize2D
        {
            get
            {
                return selectButtonAttributes?.CheckShadowImageAttributes?.Size2D ?? new Size2D(0, 0);
            }
            set
            {
                CreateCheckShadowImageAttributes();
                selectButtonAttributes.CheckShadowImageAttributes.Size2D = value;
                RelayoutRequest();
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position2D CheckShadowImagePosition2D
        {
            get
            {
                return selectButtonAttributes?.CheckShadowImageAttributes?.Position2D ?? new Position2D(0, 0);
            }
            set
            {
                selectButtonAttributes.CheckShadowImageAttributes.Position2D = value;
                RelayoutRequest();
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            SelectButtonAttributes tempAttributes = StyleManager.Instance.GetAttributes(style) as SelectButtonAttributes;
            if (tempAttributes != null)
            {
                attributes = selectButtonAttributes = tempAttributes;
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
                if (checkShadowImage != null)
                {
                    Remove(checkShadowImage);
                    checkShadowImage.Dispose();
                    checkShadowImage = null;
                }
                if (checkBackgroundImage != null)
                {
                    Remove(checkBackgroundImage);
                    checkBackgroundImage.Dispose();
                    checkBackgroundImage = null;
                }
                if (checkImage != null)
                {
                    Remove(checkImage);
                    checkImage.Dispose();
                    checkImage = null;
                }
            }

            base.Dispose(type);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate(Attributes attributtes)
        {
            selectButtonAttributes = attributes as SelectButtonAttributes;
            if (selectButtonAttributes == null)
            {
                return;
            }

            if (selectButtonAttributes.CheckImageAttributes != null)
            {
                if (checkImage == null)
                {
                    checkImage = new ImageView();
                    checkImage.Name = "CheckImage";
                    Add(checkImage);
                }
                ApplyAttributes(checkImage, selectButtonAttributes.CheckImageAttributes);
            }
            else
            {
                if (checkImage != null)
                {
                    Remove(checkImage);
                    checkImage.Dispose();
                    checkImage = null;
                }
            }


            if (selectButtonAttributes.CheckShadowImageAttributes != null)
            {
                if (checkShadowImage == null)
                {
                    checkShadowImage = new ImageView();
                    checkShadowImage.Name = "CheckShadowImage";
                    Add(checkShadowImage);
                }
                selectButtonAttributes.CheckShadowImageAttributes.Position2D = checkImage?.Position2D;
                ApplyAttributes(checkShadowImage, selectButtonAttributes.CheckShadowImageAttributes);
            }
            else
            {
                if (checkShadowImage != null)
                {
                    Remove(checkShadowImage);
                    checkShadowImage.Dispose();
                    checkShadowImage = null;
                }
            }

            if (selectButtonAttributes.CheckBackgroundImageAttributes != null)
            {
                if (checkBackgroundImage == null)
                {
                    checkBackgroundImage = new ImageView();
                    checkBackgroundImage.Name = "CheckBackgroundImage";
                    Add(checkBackgroundImage);
                }
                selectButtonAttributes.CheckBackgroundImageAttributes.Position2D = checkImage?.Position2D;
                ApplyAttributes(checkBackgroundImage, selectButtonAttributes.CheckBackgroundImageAttributes);
            }
            else
            {
                if (checkBackgroundImage != null)
                {
                    Remove(checkBackgroundImage);
                    checkBackgroundImage.Dispose();
                    checkBackgroundImage = null;
                }
            }

            UpdateTextAttributes();
            base.OnUpdate(attributtes);

            checkShadowImage?.RaiseToTop();
            checkBackgroundImage?.RaiseToTop();
            checkImage?.RaiseToTop();
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
            return new SelectButtonAttributes();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior after pressing return key by user.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnSelected()
        {
        }

        private new void Initialize()
        {
            selectButtonAttributes.IsSelectable = true;
            LayoutDirectionChanged += SelectButtonLayoutDirectionChanged;
        }

        private void UpdateTextAttributes()
        {
            if (selectButtonAttributes.TextAttributes != null)
            {
                selectButtonAttributes.TextAttributes.PositionUsesPivotPoint = true;
                selectButtonAttributes.TextAttributes.ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft;
                selectButtonAttributes.TextAttributes.PivotPoint = Tizen.NUI.PivotPoint.TopLeft;
                selectButtonAttributes.TextAttributes.WidthResizePolicy = ResizePolicyType.Fixed;
                selectButtonAttributes.TextAttributes.HeightResizePolicy = ResizePolicyType.Fixed;

                if (selectButtonAttributes.TextAttributes.Size2D == null)
                {
                    selectButtonAttributes.TextAttributes.Size2D = new Size2D(Size2D.Width - selectButtonAttributes.TextAttributes.PaddingLeft - selectButtonAttributes.TextAttributes.PaddingRight, Size2D.Height);
                }

                if (selectButtonAttributes.TextAttributes.Position2D == null)
                {
                    selectButtonAttributes.TextAttributes.Position2D = new Position2D(selectButtonAttributes.TextAttributes.PaddingLeft, 0);
                }
                selectButtonAttributes.TextAttributes.VerticalAlignment = VerticalAlignment.Center;
            }
        }

        private void SelectButtonLayoutDirectionChanged(object sender, LayoutDirectionChangedEventArgs e)
        {
            if (selectButtonAttributes == null || selectButtonAttributes.TextAttributes == null)
            {
                return;
            }

            UpdateTextAttributes();

            if (LayoutDirection == ViewLayoutDirectionType.RTL)
            {
                selectButtonAttributes.TextAttributes.HorizontalAlignment = HorizontalAlignment.End;
                selectButtonAttributes.TextAttributes.Position2D.X = Size2D.Width - selectButtonAttributes.TextAttributes.Size2D.Width - selectButtonAttributes.TextAttributes.PaddingLeft;

            }
            else if (LayoutDirection == ViewLayoutDirectionType.LTR)
            {
                selectButtonAttributes.TextAttributes.HorizontalAlignment = HorizontalAlignment.Begin;
                selectButtonAttributes.TextAttributes.Position2D.X = selectButtonAttributes.TextAttributes.PaddingLeft;
            }

            if (selectButtonAttributes.CheckImageAttributes != null && selectButtonAttributes.CheckImageAttributes.Position2D != null)
            {
                selectButtonAttributes.CheckImageAttributes.Position2D.X = Size2D.Width - selectButtonAttributes.CheckImageAttributes.Position2D.X - selectButtonAttributes.CheckImageAttributes.Size2D.Width;
            }
        }

        private void OnSelect()
        {
            OnSelected();

            if (SelectedEvent != null)
            {
                SelectEventArgs eventArgs = new SelectEventArgs();
                eventArgs.IsSelected = IsSelected;
                SelectedEvent(this, eventArgs);
            }
        }

        private void CreateCheckImageAttributes()
        {
            if (selectButtonAttributes.CheckImageAttributes == null)
            {
                selectButtonAttributes.CheckImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                };
            }
        }

        private void CreateCheckBackgroundImageAttributes()
        {
            if (selectButtonAttributes.CheckBackgroundImageAttributes == null)
            {
                selectButtonAttributes.CheckBackgroundImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                };
            }
        }

        private void CreateCheckShadowImageAttributes()
        {
            if (selectButtonAttributes.CheckShadowImageAttributes == null)
            {
                selectButtonAttributes.CheckShadowImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                };
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
