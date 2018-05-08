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
    /// <summary>
    /// LayoutGroup class providing container functionality.
    /// </summary>
    public class LayoutGroup : LayoutGroupWrapper
    {
        public LayoutGroup() : base( new LayoutGroupWrapperImpl() )
        {
            // Initialize delegates of LayoutItem
            LayoutItemInitialize(layoutGroupWrapperImpl);

            layoutGroupWrapperImpl.OnMeasure = new LayoutGroupWrapperImpl.OnMeasureDelegate(OnMeasure);
            layoutGroupWrapperImpl.OnLayout = new LayoutGroupWrapperImpl.OnLayoutDelegate(OnLayout);
            layoutGroupWrapperImpl.OnSizeChanged = new LayoutGroupWrapperImpl.OnSizeChangedDelegate(OnSizeChanged);
            layoutGroupWrapperImpl.OnInitialize = new LayoutGroupWrapperImpl.OnInitializeDelegate(OnInitialize);
            //layoutGroupWrapperImpl.OnChildAdd = new LayoutGroupWrapperImpl.OnChildAddDelegate(OnChildAdd);
            //layoutGroupWrapperImpl.OnChildRemove = new LayoutGroupWrapperImpl.OnChildRemoveDelegate(OnChildRemove);
            layoutGroupWrapperImpl.DoInitialize = new LayoutGroupWrapperImpl.DoInitializeDelegate(DoInitialize);
            layoutGroupWrapperImpl.DoRegisterChildProperties = new LayoutGroupWrapperImpl.DoRegisterChildPropertiesDelegate(DoRegisterChildProperties);
            layoutGroupWrapperImpl.MeasureChildren  = new LayoutGroupWrapperImpl.MeasureChildrenDelegate(MeasureChildren);
            layoutGroupWrapperImpl.MeasureChild  = new LayoutGroupWrapperImpl.MeasureChildDelegate(MeasureChild);
            layoutGroupWrapperImpl.MeasureChildWithMargins  = new LayoutGroupWrapperImpl.MeasureChildWithMarginsDelegate(MeasureChildWithMargins);
        }

        public void RemoveAll()
        {
            layoutGroupWrapperImpl.RemoveAll();
        }

        /*public uint GetChildId(LayoutItemWrapperImpl child)
        {
            uint ret = LayoutPINVOKE.LayoutGroupWrapperImpl_GetChildId(swigCPtr, LayoutItemWrapperImpl.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }*/

        public static LayoutMeasureSpec GetChildMeasureSpec(LayoutMeasureSpec measureSpec, LayoutLength padding, LayoutLength childDimension)
        {
            return LayoutGroupWrapperImpl.GetChildMeasureSpec(measureSpec, padding, childDimension);
        }

        protected virtual void OnMeasure(LayoutMeasureSpec widthMeasureSpec, LayoutMeasureSpec heightMeasureSpec)
        {

        }
        protected virtual void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {

        }
        protected virtual void OnSizeChanged(LayoutSize newSize, LayoutSize oldSize)
        {

        }
        protected virtual void OnInitialize()
        {

        }
        internal virtual void OnChildAdd(LayoutItemWrapperImpl child)
        {
            layoutGroupWrapperImpl.OnChildAddNative(child);
        }
        internal virtual void OnChildRemove(LayoutItemWrapperImpl child)
        {
            layoutGroupWrapperImpl.OnChildRemoveNative(child);
        }

        /// <summary>
        /// Second stage initialization method for deriving classes to override.<br />
        /// </summary>
        protected virtual void DoInitialize()
        {
            layoutGroupWrapperImpl.DoInitializeNative();
        }

        /// <summary>
        /// Method for derived classes to implement in order to register child property types with the container.<br />
        /// </summary>
        /// <param name="containerType">The fully qualified typename of the container.</param>
        protected virtual void DoRegisterChildProperties(string containerType)
        {
            layoutGroupWrapperImpl.DoRegisterChildPropertiesNative(containerType);
        }

        /// <summary>
        /// Ask all of the children of this view to measure themselves, taking into
        /// account both the MeasureSpec requirements for this view and its padding.<br />
        /// The heavy lifting is done in GetChildMeasureSpec.<br />
        /// </summary>
        /// <param name="widthMeasureSpec">The width requirements for this view.</param>
        /// <param name="heightMeasureSpec">The height requirements for this view.</param>
        protected virtual void MeasureChildren(LayoutMeasureSpec widthMeasureSpec, LayoutMeasureSpec heightMeasureSpec)
        {
            layoutGroupWrapperImpl.MeasureChildrenNative(widthMeasureSpec, heightMeasureSpec);
        }

        /// <summary>
        /// Ask one of the children of this view to measure itself, taking into
        /// account both the MeasureSpec requirements for this view and its padding.<br />
        /// The heavy lifting is done in GetChildMeasureSpec.<br />
        /// </summary>
        /// <param name="child">The child to measure.</param>
        /// <param name="parentWidthMeasureSpec">The width requirements for this view.</param>
        /// <param name="parentHeightMeasureSpec">The height requirements for this view.</param>
        protected virtual void MeasureChild(LayoutItem child, LayoutMeasureSpec parentWidthMeasureSpec, LayoutMeasureSpec parentHeightMeasureSpec)
        {
            layoutGroupWrapperImpl.MeasureChildNative(child, parentWidthMeasureSpec, parentHeightMeasureSpec);
        }

        /// <summary>
        /// Ask one of the children of this view to measure itself, taking into
        /// account both the MeasureSpec requirements for this view and its padding.<br />
        /// and margins. The child must have MarginLayoutParams The heavy lifting is
        /// done in GetChildMeasureSpec.<br />
        /// </summary>
        /// <param name="child">The child to measure.</param>
        /// <param name="parentWidthMeasureSpec">The width requirements for this view.</param>
        /// <param name="widthUsed">Extra space that has been used up by the parent horizontally (possibly by other children of the parent).</param>
        /// <param name="parentHeightMeasureSpec">The height requirements for this view.</param>
        /// <param name="heightUsed">Extra space that has been used up by the parent vertically (possibly by other children of the parent).</param>
        protected virtual void MeasureChildWithMargins(LayoutItem child, LayoutMeasureSpec parentWidthMeasureSpec, LayoutLength widthUsed, LayoutMeasureSpec parentHeightMeasureSpec, LayoutLength heightUsed)
        {
            layoutGroupWrapperImpl.MeasureChildWithMarginsNative(child, parentWidthMeasureSpec, widthUsed, parentHeightMeasureSpec, heightUsed);
        }
    }
}