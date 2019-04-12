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

using System.ComponentModel;

namespace Tizen.NUI.CommonUI
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DropDownAttributes : ViewAttributes
    {
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DropDownAttributes() : base()
        {
            SpaceBetweenButtonTextAndIcon = 0;
            Space = new Vector4(0, 0, 0, 0);
            ListRelativeOrientation = DropDown.ListOrientation.Left;
            ListMargin = new Vector4(0, 0, 0, 0);
            FocusedItemIndex = 0;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DropDownAttributes(DropDownAttributes attributes) : base(attributes)
        {
            if (attributes.ButtonAttributes != null)
            {
                ButtonAttributes = attributes.ButtonAttributes.Clone() as ButtonAttributes;
            }

            if (attributes.HeaderTextAttributes != null)
            {
                HeaderTextAttributes = attributes.HeaderTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.ListBackgroundImageAttributes != null)
            {
                ListBackgroundImageAttributes = attributes.ListBackgroundImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.Space != null)
            {
                Space = new Vector4(attributes.Space.X, attributes.Space.Y, attributes.Space.Z, attributes.Space.W);
            }

            if (attributes.ListMargin != null)
            {
                ListMargin = new Vector4(attributes.ListMargin.X, attributes.ListMargin.Y, attributes.ListMargin.Z, attributes.ListMargin.W);
            }

            if (attributes.ListSize2D != null)
            {
                ListSize2D = new Size2D(attributes.ListSize2D.Width, attributes.ListSize2D.Height);
            }

            if (attributes.ListPadding != null)
            {
                ListPadding = attributes.ListPadding;
            }

            SpaceBetweenButtonTextAndIcon = attributes.SpaceBetweenButtonTextAndIcon;
            ListRelativeOrientation = attributes.ListRelativeOrientation;
            FocusedItemIndex = attributes.FocusedItemIndex;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ButtonAttributes ButtonAttributes
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes HeaderTextAttributes
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int SpaceBetweenButtonTextAndIcon
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes ListBackgroundImageAttributes
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 Space
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DropDown.ListOrientation ListRelativeOrientation
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 ListMargin
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int FocusedItemIndex
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D ListSize2D
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents ListPadding
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Attributes Clone()
        {
            return new DropDownAttributes(this);
        }
    }

    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DropDownItemAttributes : ViewAttributes
    {
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DropDownItemAttributes() : base() { }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DropDownItemAttributes(DropDownItemAttributes attributes) : base(attributes)
        {
            if (attributes.TextAttributes != null)
            {
                TextAttributes = attributes.TextAttributes.Clone() as TextAttributes;
            }

            if (attributes.IconAttributes != null)
            {
                IconAttributes = attributes.IconAttributes.Clone() as ImageAttributes;
            }

            if (attributes.CheckImageAttributes != null)
            {
                CheckImageAttributes = attributes.CheckImageAttributes.Clone() as ImageAttributes;
            }

            CheckImageRightSpace = attributes.CheckImageRightSpace;
            IsSelected = attributes.IsSelected;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes TextAttributes
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes IconAttributes
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes CheckImageAttributes
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CheckImageRightSpace
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsSelected
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Attributes Clone()
        {
            return new DropDownItemAttributes(this);
        }
    }
}
