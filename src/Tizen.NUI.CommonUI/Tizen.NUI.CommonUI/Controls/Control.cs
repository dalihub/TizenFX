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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.CommonUI
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class Control : VisualView
    {
        private static Dictionary<string, Type> styleToAttributes = new Dictionary<string, Type>();
        private TapGestureDetector tapGestureDetector = new TapGestureDetector();
        private ControlStates state;
        private bool isFocused = false;
        protected string style;

        public Control() : base()
        {
            Initialize(null);
        }
        public Control(string style) : base()
        {
            Initialize(style);
        }

        public new ControlStates State
        {
            get;
            set;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool StateFocusableOnTouchMode
        {
            get;
            set;
        }

        internal bool IsFocused
        {
            get
            {
                return isFocused || HasFocus();
            }
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void ApplyAttributes(View view, ViewAttributes attrs)
        {
            if (view == null || attrs == null)
            {
                return;
            }

            if (attrs.Position2D != null)
            {
                view.Position2D = attrs.Position2D;
            }
            if (attrs.Size2D != null)
            {
                view.Size2D = attrs.Size2D;
            }
            if (attrs.MinimumSize != null)
            {
                view.MinimumSize = attrs.MinimumSize;
            }
            if (attrs.BackgroundColor?.GetValue(State) != null)
            {
                view.BackgroundColor = attrs.BackgroundColor.GetValue(State);
            }
            if (attrs.PositionUsesPivotPoint != null)
            {
                view.PositionUsesPivotPoint = attrs.PositionUsesPivotPoint.Value;
            }
            if (attrs.ParentOrigin != null)
            {
                view.ParentOrigin = attrs.ParentOrigin;
            }
            if (attrs.PivotPoint != null)
            {
                view.PivotPoint = attrs.PivotPoint;
            }
            if (attrs.WidthResizePolicy != null)
            {
                view.WidthResizePolicy = attrs.WidthResizePolicy.Value;
            }
            if (attrs.HeightResizePolicy != null)
            {
                view.HeightResizePolicy = attrs.HeightResizePolicy.Value;
            }
            if (attrs.SizeModeFactor != null)
            {
                view.SizeModeFactor = attrs.SizeModeFactor;
            }
            if (attrs.Opacity?.GetValue(State) != null)
            {
                view.Opacity = attrs.Opacity.GetValue(State).Value;
            }

            ImageView image = view as ImageView;
            ImageAttributes imageAttrs = attrs as ImageAttributes;
            if (image != null && imageAttrs != null)
            {
                if (imageAttrs.ResourceURL?.GetValue(State) != null)
                {
                    image.ResourceUrl = imageAttrs.ResourceURL.GetValue(State);
                }
                if (imageAttrs.Border?.GetValue(State) != null)
                {
                    image.Border = imageAttrs.Border.GetValue(State);
                }

            }

            TextLabel text = view as TextLabel;
            TextAttributes textAttrs = attrs as TextAttributes;
            if (text != null && textAttrs != null)
            {
                if (textAttrs.Text?.GetValue(State) != null)
                {
                    text.Text = textAttrs.Text.GetValue(State);
                }
                if (textAttrs.TranslatableText?.GetValue(State) != null)
                {
                    text.TranslatableText = textAttrs.TranslatableText.GetValue(State);
                }
                if (textAttrs.MultiLine != null)
                {
                    text.MultiLine = textAttrs.MultiLine.Value;
                }
                if (textAttrs.HorizontalAlignment != null)
                {
                    text.HorizontalAlignment = textAttrs.HorizontalAlignment.Value;
                }
                if (textAttrs.VerticalAlignment != null)
                {
                    text.VerticalAlignment = textAttrs.VerticalAlignment.Value;
                }
                if (textAttrs.EnableMarkup != null)
                {
                    text.EnableMarkup = textAttrs.EnableMarkup.Value;
                }
                if (textAttrs.AutoScrollLoopCount != null)
                {
                    text.AutoScrollLoopCount = textAttrs.AutoScrollLoopCount.Value;
                }
                if (textAttrs.AutoScrollSpeed != null)
                {
                    text.AutoScrollSpeed = textAttrs.AutoScrollSpeed.Value;
                }
                if (textAttrs.AutoScrollGap != null)
                {
                    text.AutoScrollGap = textAttrs.AutoScrollGap.Value;
                }
                if (textAttrs.AutoScrollLoopDelay != null)
                {
                    text.AutoScrollLoopDelay = textAttrs.AutoScrollLoopDelay.Value;
                }
                if (textAttrs.AutoScrollStopMode != null)
                {
                    text.AutoScrollStopMode = textAttrs.AutoScrollStopMode.Value;
                }
                if (textAttrs.LineSpacing != null)
                {
                    text.LineSpacing = textAttrs.LineSpacing.Value;
                }
                if (textAttrs.TextColor?.GetValue(State) != null)
                {
                    text.TextColor = textAttrs.TextColor.GetValue(State);
                }
                if (textAttrs.FontFamily != null)
                {
                    text.FontFamily = textAttrs.FontFamily;
                }
                if (textAttrs.PointSize?.GetValue(State) != null)
                {
                    text.PointSize = textAttrs.PointSize.GetValue(State).Value;
                }

                int thickness = 0;

                if (textAttrs.OutstrokeThickness?.GetValue(State) != null)
                {
                    thickness = textAttrs.OutstrokeThickness.GetValue(State).Value;
                }
                if (textAttrs.OutstrokeColor?.GetValue(State) != null)
                {
                    Color outstrokeColor = textAttrs.OutstrokeColor.GetValue(State);
                    PropertyMap outlineMap = new PropertyMap();
                    outlineMap.Add("color", new PropertyValue(new Color(outstrokeColor.R, outstrokeColor.G, outstrokeColor.B, outstrokeColor.R)));
                    outlineMap.Add("width", new PropertyValue(thickness));
                    text.Outline = outlineMap;
                }
                else
                {
                    text.Outline = new PropertyMap();
                }
            }

            TextField textField = view as TextField;
            TextFieldAttributes textFieldAttrs = attrs as TextFieldAttributes;
            if (textField != null && textFieldAttrs != null)
            {
                if (textFieldAttrs.Text?.GetValue(State) != null)
                {
                    textField.Text = textFieldAttrs.Text.GetValue(State);
                }
                if (textFieldAttrs.PlaceholderText?.GetValue(State) != null)
                {
                    textField.PlaceholderText = textFieldAttrs.PlaceholderText.GetValue(State);
                }
                if (textFieldAttrs.TranslatablePlaceholderText?.GetValue(State) != null)
                {
                    textField.TranslatablePlaceholderText = textFieldAttrs.TranslatablePlaceholderText.GetValue(State);
                }
                if (textFieldAttrs.HorizontalAlignment != null)
                {
                    textField.HorizontalAlignment = textFieldAttrs.HorizontalAlignment.Value;
                }
                if (textFieldAttrs.VerticalAlignment != null)
                {
                    textField.VerticalAlignment = textFieldAttrs.VerticalAlignment.Value;
                }
                if (textFieldAttrs.EnableMarkup != null)
                {
                    textField.EnableMarkup = textFieldAttrs.EnableMarkup.Value;
                }
                if (textFieldAttrs.TextColor?.GetValue(State) != null)
                {
                    textField.TextColor = textFieldAttrs.TextColor.GetValue(State);
                }
                if (textFieldAttrs.PlaceholderTextColor?.GetValue(State) != null)
                {
                    textField.TextColor = textFieldAttrs.PlaceholderTextColor.GetValue(State);
                }
                if (textFieldAttrs.PrimaryCursorColor?.GetValue(State) != null)
                {
                    textField.PrimaryCursorColor = textFieldAttrs.PrimaryCursorColor.GetValue(State);
                }
                if (textFieldAttrs.SecondaryCursorColor?.GetValue(State) != null)
                {
                    textField.SecondaryCursorColor = textFieldAttrs.SecondaryCursorColor.GetValue(State);
                }
                if (textFieldAttrs.FontFamily != null)
                {
                    textField.FontFamily = textFieldAttrs.FontFamily;
                }
                if (textFieldAttrs.PointSize?.GetValue(State) != null)
                {
                    textField.PointSize = textFieldAttrs.PointSize.GetValue(State).Value;
                }
                if (textFieldAttrs.EnableCursorBlink != null)
                {
                    textField.EnableCursorBlink = textFieldAttrs.EnableCursorBlink.Value;
                }
                if (textFieldAttrs.EnableSelection != null)
                {
                    textField.EnableSelection = textFieldAttrs.EnableSelection.Value;
                }
                if (textFieldAttrs.CursorWidth != null)
                {
                    textField.CursorWidth = textFieldAttrs.CursorWidth.Value;
                }
                if (textFieldAttrs.EnableEllipsis != null)
                {
                    textField.Ellipsis = textFieldAttrs.EnableEllipsis.Value;
                }
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
                StyleManager.Instance.ThemeChangedEvent -= OnThemeChangedEvent;
                KeyEvent -= OnKey;
                Relayout -= OnRelayout;
                FocusGained -= OnFocusGained;
                FocusLost -= OnFocusLost;
                TouchEvent -= OnTouch;
                tapGestureDetector.Detected -= OnTapGestureDetected;
                tapGestureDetector.Detach(this);
            }
            base.Dispose(type);
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Attributes attributes;
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected abstract Attributes GetAttributes();
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool OnKey(object source, KeyEventArgs e)
        {
            return false;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnRelayout(object sender, EventArgs e)
        {
            OnUpdate(attributes);
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnFocusGained(object sender, EventArgs e)
        {
            isFocused = true;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnFocusLost(object sender, EventArgs e)
        {
            isFocused = false;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool OnTouch(object source, TouchEventArgs e)
        {
            return false;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnUpdate(Attributes attributtes)
        {
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
        }

        private void Initialize(string style)
        {
            attributes = (style == null) ? GetAttributes() : GetAttributes(style);
            State = ControlStates.Normal;

            KeyEvent += OnKey;
            Relayout += OnRelayout;
            FocusGained += OnFocusGained;
            FocusLost += OnFocusLost;

            LeaveRequired = true;
            TouchEvent += OnTouch;

            StateFocusableOnTouchMode = false;

            tapGestureDetector.Attach(this);
            tapGestureDetector.Detected += OnTapGestureDetected;

            StyleManager.Instance.ThemeChangedEvent += OnThemeChangedEvent;
        }

        private Attributes GetAttributes(string style)
        {
            Attributes attributes = StyleManager.Instance.GetAttributes(style);
            if (attributes == null)
            {
                throw new InvalidOperationException($"There is no style {style}");
            }
            this.style = style;
            return attributes;
        }

    }
}
