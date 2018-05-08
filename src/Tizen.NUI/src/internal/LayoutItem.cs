/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd.
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

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    public class LayoutItem : LayoutItemWrapper
    {
        internal LayoutItem(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        public LayoutItem() : base( new LayoutItemWrapperImpl() )
        {
            LayoutItemInitialize(layoutItemWrapperImpl);
        }

        // This should be protected though.
        internal void LayoutItemInitialize(LayoutItemWrapperImpl implementation)
        {
            layoutItemWrapperImpl = implementation;
            layoutItemWrapperImpl.OnUnparent = new LayoutItemWrapperImpl.OnUnparentDelegate(OnUnparent);
            layoutItemWrapperImpl.OnRegisterChildProperties = new LayoutItemWrapperImpl.OnRegisterChildPropertiesDelegate(OnRegisterChildProperties);
            layoutItemWrapperImpl.OnMeasure = new LayoutItemWrapperImpl.OnMeasureDelegate(OnMeasure);
            layoutItemWrapperImpl.OnLayout = new LayoutItemWrapperImpl.OnLayoutDelegate(OnLayout);
            layoutItemWrapperImpl.OnSizeChanged = new LayoutItemWrapperImpl.OnSizeChangedDelegate(OnSizeChanged);
            layoutItemWrapperImpl.OnInitialize = new LayoutItemWrapperImpl.OnInitializeDelegate(OnInitialize);
        }

        public void Unparent()
        {
            layoutItemWrapperImpl.Unparent();
        }
        public void RegisterChildProperties(string containerType)
        {
            layoutItemWrapperImpl.RegisterChildProperties(containerType);
        }

        public void Measure(LayoutMeasureSpec widthMeasureSpec, LayoutMeasureSpec heightMeasureSpec)
        {
            layoutItemWrapperImpl.Measure(widthMeasureSpec, heightMeasureSpec);
        }

        public void Layout(LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            layoutItemWrapperImpl.Layout(left, top, right, bottom);
        }

        public static LayoutLength GetDefaultSize(LayoutLength size, LayoutMeasureSpec measureSpec)
        {
            return LayoutItemWrapperImpl.GetDefaultSize(size, measureSpec);
        }

        public ILayoutParent GetParent()
        {
            return layoutItemWrapperImpl.GetParent();
        }

        public void RequestLayout()
        {
            layoutItemWrapperImpl.RequestLayout();
        }

        public bool IsLayoutRequested()
        {
            return layoutItemWrapperImpl.IsLayoutRequested();
        }

        public LayoutLength GetMeasuredWidth()
        {
            return layoutItemWrapperImpl.GetMeasuredWidth();
        }

        public LayoutLength GetMeasuredHeight()
        {
            return layoutItemWrapperImpl.GetMeasuredHeight();
        }

        public MeasuredSize GetMeasuredWidthAndState()
        {
            return layoutItemWrapperImpl.GetMeasuredWidthAndState();
        }

        public MeasuredSize GetMeasuredHeightAndState()
        {
            return layoutItemWrapperImpl.GetMeasuredHeightAndState();
        }

        public LayoutLength GetSuggestedMinimumWidth()
        {
            return layoutItemWrapperImpl.GetSuggestedMinimumWidth();
        }

        public LayoutLength GetSuggestedMinimumHeight()
        {
            return layoutItemWrapperImpl.GetSuggestedMinimumHeight();
        }

        public void SetMinimumWidth(LayoutLength minWidth)
        {
            layoutItemWrapperImpl.SetMinimumWidth(minWidth);
        }

        public void SetMinimumHeight(LayoutLength minHeight)
        {
            layoutItemWrapperImpl.SetMinimumHeight(minHeight);
        }

        public LayoutLength GetMinimumWidth()
        {
            return layoutItemWrapperImpl.GetMinimumWidth();
        }

        public LayoutLength GetMinimumHeight()
        {
            return layoutItemWrapperImpl.GetMinimumHeight();
        }

        protected virtual void OnUnparent()
        {
            layoutItemWrapperImpl.OnUnparentNative();
        }

        protected virtual void OnRegisterChildProperties(string containerType)
        {
            layoutItemWrapperImpl.OnRegisterChildPropertiesNative(containerType);
        }

        protected virtual void OnMeasure(LayoutMeasureSpec widthMeasureSpec, LayoutMeasureSpec heightMeasureSpec)
        {
            layoutItemWrapperImpl.OnMeasureNative(widthMeasureSpec, heightMeasureSpec);
        }

        protected virtual void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            layoutItemWrapperImpl.OnLayoutNative(changed, left, top, right, bottom);
        }

        protected virtual void OnSizeChanged(LayoutSize newSize, LayoutSize oldSize)
        {
            layoutItemWrapperImpl.OnSizeChangedNative(newSize, oldSize);
        }

        protected virtual void OnInitialize()
        {
            layoutItemWrapperImpl.OnInitializeNative();
        }
    }
}