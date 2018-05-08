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
            layoutGroupWrapperImpl.OnMeasure = new LayoutGroupWrapperImpl.OnMeasureDelegate(OnMeasure);
            layoutGroupWrapperImpl.OnLayout = new LayoutGroupWrapperImpl.OnLayoutDelegate(OnLayout);
            layoutGroupWrapperImpl.OnSizeChanged = new LayoutGroupWrapperImpl.OnSizeChangedDelegate(OnSizeChanged);
            layoutGroupWrapperImpl.OnInitialize = new LayoutGroupWrapperImpl.OnInitializeDelegate(OnInitialize);
            //layoutGroupWrapperImpl.OnChildAdd = new LayoutGroupWrapperImpl.OnChildAddDelegate(OnChildAdd);
            //layoutGroupWrapperImpl.OnChildRemove = new LayoutGroupWrapperImpl.OnChildRemoveDelegate(OnChildRemove);
            layoutGroupWrapperImpl.DoInitialize = new LayoutGroupWrapperImpl.DoInitializeDelegate(DoInitialize);
            layoutGroupWrapperImpl.DoRegisterChildProperties = new LayoutGroupWrapperImpl.DoRegisterChildPropertiesDelegate(DoRegisterChildProperties);
            layoutGroupWrapperImpl.MeasureChildren  = new LayoutGroupWrapperImpl.MeasureChildrenDelegate(MeasureChildren);
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

        public virtual void OnMeasure(LayoutMeasureSpec widthMeasureSpec, LayoutMeasureSpec heightMeasureSpec)
        {

        }
        public virtual void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {

        }
        public virtual void OnSizeChanged(LayoutSize newSize, LayoutSize oldSize)
        {

        }
        public virtual void OnInitialize()
        {

        }
        /*public virtual void OnChildAdd(LayoutItemWrapperImpl child)
        {
            layoutGroupWrapperImpl.OnChildAddNative(child);
        }
        public virtual void OnChildRemove(LayoutItemWrapperImpl child)
        {
            layoutGroupWrapperImpl.OnChildRemoveNative(child);
        }*/
        protected virtual void DoInitialize()
        {
            layoutGroupWrapperImpl.DoInitializeNative();
        }
        protected virtual void DoRegisterChildProperties(string containerType)
        {
            layoutGroupWrapperImpl.DoRegisterChildPropertiesNative(containerType);
        }
        protected virtual void MeasureChildren(LayoutMeasureSpec widthMeasureSpec, LayoutMeasureSpec heightMeasureSpec)
        {
            layoutGroupWrapperImpl.MeasureChildrenNative(widthMeasureSpec, heightMeasureSpec);
        }
    }
}