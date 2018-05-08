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
    internal class LayoutItemWrapperImpl : BaseObject, ILayoutParent
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal LayoutItemWrapperImpl(global::System.IntPtr cPtr, bool cMemoryOwn) : base(LayoutPINVOKE.LayoutItemWrapperImpl_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(LayoutItemWrapperImpl obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

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

            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            base.Dispose();
        }

        public LayoutItemWrapperImpl() : this(LayoutPINVOKE.new_LayoutItemWrapperImpl(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            SwigDirectorConnect();
        }

        /*public static SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__Internal__LayoutItem_t New(Handle owner)
        {
            SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__Internal__LayoutItem_t ret = new SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__Internal__LayoutItem_t(LayoutPINVOKE.LayoutItemWrapperImpl_New(Handle.getCPtr(owner)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Initialize(Handle owner, string containerType)
        {
            LayoutPINVOKE.LayoutItemWrapperImpl_Initialize(swigCPtr, Handle.getCPtr(owner), containerType);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }*/

        public void Unparent()
        {
            LayoutPINVOKE.LayoutItemWrapperImpl_Unparent(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetAnimateLayout(bool animateLayout)
        {
            LayoutPINVOKE.LayoutItemWrapperImpl_SetAnimateLayout(swigCPtr, animateLayout);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool IsLayoutAnimated()
        {
            bool ret = LayoutPINVOKE.LayoutItemWrapperImpl_IsLayoutAnimated(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void RegisterChildProperties(string containerType)
        {
            LayoutPINVOKE.LayoutItemWrapperImpl_RegisterChildProperties(swigCPtr, containerType);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Measure(LayoutMeasureSpec widthMeasureSpec, LayoutMeasureSpec heightMeasureSpec)
        {
            LayoutPINVOKE.LayoutItemWrapperImpl_Measure(swigCPtr, LayoutMeasureSpec.getCPtr(widthMeasureSpec), LayoutMeasureSpec.getCPtr(heightMeasureSpec));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Layout(LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            LayoutPINVOKE.LayoutItemWrapperImpl_Layout(swigCPtr, LayoutLength.getCPtr(left), LayoutLength.getCPtr(top), LayoutLength.getCPtr(right), LayoutLength.getCPtr(bottom));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static LayoutLength GetDefaultSize(LayoutLength size, LayoutMeasureSpec measureSpec)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutItemWrapperImpl_GetDefaultSize(LayoutLength.getCPtr(size), LayoutMeasureSpec.getCPtr(measureSpec)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public ILayoutParent GetParent()
        {
            global::System.IntPtr cPtr = (SwigDerivedClassHasMethod("GetParent", swigMethodTypes0) ? LayoutPINVOKE.LayoutItemWrapperImpl_GetParentSwigExplicitLayoutItemWrapperImpl(swigCPtr) : LayoutPINVOKE.LayoutItemWrapperImpl_GetParent(swigCPtr));
            //ILayoutParent ret = (cPtr == global::System.IntPtr.Zero) ? null : new ILayoutParent(cPtr, false);
            ILayoutParent ret = (cPtr == global::System.IntPtr.Zero) ? null : new LayoutItemWrapperImpl(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void RequestLayout()
        {
            LayoutPINVOKE.LayoutItemWrapperImpl_RequestLayout(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool IsLayoutRequested()
        {
            bool ret = LayoutPINVOKE.LayoutItemWrapperImpl_IsLayoutRequested(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutLength GetMeasuredWidth()
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutItemWrapperImpl_GetMeasuredWidth(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutLength GetMeasuredHeight()
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutItemWrapperImpl_GetMeasuredHeight(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public MeasuredSize GetMeasuredWidthAndState()
        {
            MeasuredSize ret = new MeasuredSize(LayoutPINVOKE.LayoutItemWrapperImpl_GetMeasuredWidthAndState(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public MeasuredSize GetMeasuredHeightAndState()
        {
            MeasuredSize ret = new MeasuredSize(LayoutPINVOKE.LayoutItemWrapperImpl_GetMeasuredHeightAndState(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutLength GetSuggestedMinimumWidth()
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutItemWrapperImpl_GetSuggestedMinimumWidth(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutLength GetSuggestedMinimumHeight()
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutItemWrapperImpl_GetSuggestedMinimumHeight(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetMinimumWidth(LayoutLength minWidth)
        {
            LayoutPINVOKE.LayoutItemWrapperImpl_SetMinimumWidth(swigCPtr, LayoutLength.getCPtr(minWidth));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetMinimumHeight(LayoutLength minHeight)
        {
            LayoutPINVOKE.LayoutItemWrapperImpl_SetMinimumHeight(swigCPtr, LayoutLength.getCPtr(minHeight));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public LayoutLength GetMinimumWidth()
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutItemWrapperImpl_GetMinimumWidth(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutLength GetMinimumHeight()
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutItemWrapperImpl_GetMinimumHeight(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /*public SWIGTYPE_p_Dali__Extents GetPadding()
        {
            SWIGTYPE_p_Dali__Extents ret = new SWIGTYPE_p_Dali__Extents(LayoutPINVOKE.LayoutItemWrapperImpl_GetPadding(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }*/

        protected virtual void OnUnparent()
        {
            if (SwigDerivedClassHasMethod("OnUnparent", swigMethodTypes1)) LayoutPINVOKE.LayoutItemWrapperImpl_OnUnparentSwigExplicitLayoutItemWrapperImpl(swigCPtr); else LayoutPINVOKE.LayoutItemWrapperImpl_OnUnparent(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual void OnRegisterChildProperties(string containerType)
        {
            if (SwigDerivedClassHasMethod("OnRegisterChildProperties", swigMethodTypes2)) LayoutPINVOKE.LayoutItemWrapperImpl_OnRegisterChildPropertiesSwigExplicitLayoutItemWrapperImpl(swigCPtr, containerType); else LayoutPINVOKE.LayoutItemWrapperImpl_OnRegisterChildProperties(swigCPtr, containerType);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual void OnMeasure(LayoutMeasureSpec widthMeasureSpec, LayoutMeasureSpec heightMeasureSpec)
        {
            if (SwigDerivedClassHasMethod("OnMeasure", swigMethodTypes3)) LayoutPINVOKE.LayoutItemWrapperImpl_OnMeasureSwigExplicitLayoutItemWrapperImpl(swigCPtr, LayoutMeasureSpec.getCPtr(widthMeasureSpec), LayoutMeasureSpec.getCPtr(heightMeasureSpec)); else LayoutPINVOKE.LayoutItemWrapperImpl_OnMeasure(swigCPtr, LayoutMeasureSpec.getCPtr(widthMeasureSpec), LayoutMeasureSpec.getCPtr(heightMeasureSpec));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            if (SwigDerivedClassHasMethod("OnLayout", swigMethodTypes4)) LayoutPINVOKE.LayoutItemWrapperImpl_OnLayoutSwigExplicitLayoutItemWrapperImpl(swigCPtr, changed, LayoutLength.getCPtr(left), LayoutLength.getCPtr(top), LayoutLength.getCPtr(right), LayoutLength.getCPtr(bottom)); else LayoutPINVOKE.LayoutItemWrapperImpl_OnLayout(swigCPtr, changed, LayoutLength.getCPtr(left), LayoutLength.getCPtr(top), LayoutLength.getCPtr(right), LayoutLength.getCPtr(bottom));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual void OnSizeChanged(LayoutSize newSize, LayoutSize oldSize)
        {
            if (SwigDerivedClassHasMethod("OnSizeChanged", swigMethodTypes5)) LayoutPINVOKE.LayoutItemWrapperImpl_OnSizeChangedSwigExplicitLayoutItemWrapperImpl(swigCPtr, LayoutSize.getCPtr(newSize), LayoutSize.getCPtr(oldSize)); else LayoutPINVOKE.LayoutItemWrapperImpl_OnSizeChanged(swigCPtr, LayoutSize.getCPtr(newSize), LayoutSize.getCPtr(oldSize));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual void OnInitialize()
        {
            if (SwigDerivedClassHasMethod("OnInitialize", swigMethodTypes6)) LayoutPINVOKE.LayoutItemWrapperImpl_OnInitializeSwigExplicitLayoutItemWrapperImpl(swigCPtr); else LayoutPINVOKE.LayoutItemWrapperImpl_OnInitialize(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private void SwigDirectorConnect()
        {
            //if (SwigDerivedClassHasMethod("GetParent", swigMethodTypes0))
                //swigDelegate0 = new SwigDelegateLayoutItemWrapperImpl_0(SwigDirectorGetParent);
            if (SwigDerivedClassHasMethod("OnUnparent", swigMethodTypes1))
                swigDelegate1 = new SwigDelegateLayoutItemWrapperImpl_1(SwigDirectorOnUnparent);
            if (SwigDerivedClassHasMethod("OnRegisterChildProperties", swigMethodTypes2))
                swigDelegate2 = new SwigDelegateLayoutItemWrapperImpl_2(SwigDirectorOnRegisterChildProperties);
            if (SwigDerivedClassHasMethod("OnMeasure", swigMethodTypes3))
                swigDelegate3 = new SwigDelegateLayoutItemWrapperImpl_3(SwigDirectorOnMeasure);
            if (SwigDerivedClassHasMethod("OnLayout", swigMethodTypes4))
                swigDelegate4 = new SwigDelegateLayoutItemWrapperImpl_4(SwigDirectorOnLayout);
            if (SwigDerivedClassHasMethod("OnSizeChanged", swigMethodTypes5))
                swigDelegate5 = new SwigDelegateLayoutItemWrapperImpl_5(SwigDirectorOnSizeChanged);
            if (SwigDerivedClassHasMethod("OnInitialize", swigMethodTypes6))
                swigDelegate6 = new SwigDelegateLayoutItemWrapperImpl_6(SwigDirectorOnInitialize);

            LayoutPINVOKE.LayoutItemWrapperImpl_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
        }

        private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes)
        {
            global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.Instance, null, methodTypes, null);
            bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(LayoutItemWrapperImpl));
            return hasDerivedMethod;
        }

        /*private global::System.IntPtr SwigDirectorGetParent()
        {
            return ILayoutParent.getCPtr(GetParent()).Handle;
        }*/

        private void SwigDirectorOnUnparent()
        {
            OnUnparent();
        }

        private void SwigDirectorOnRegisterChildProperties(string containerType)
        {
            OnRegisterChildProperties(containerType);
        }

        private void SwigDirectorOnMeasure(global::System.IntPtr widthMeasureSpec, global::System.IntPtr heightMeasureSpec)
        {
            OnMeasure(new LayoutMeasureSpec(widthMeasureSpec, true), new LayoutMeasureSpec(heightMeasureSpec, true));
        }

        private void SwigDirectorOnLayout(bool changed, global::System.IntPtr left, global::System.IntPtr top, global::System.IntPtr right, global::System.IntPtr bottom)
        {
            OnLayout(changed, new LayoutLength(left, true), new LayoutLength(top, true), new LayoutLength(right, true), new LayoutLength(bottom, true));
        }

        private void SwigDirectorOnSizeChanged(global::System.IntPtr newSize, global::System.IntPtr oldSize)
        {
            OnSizeChanged(new LayoutSize(newSize, true), new LayoutSize(oldSize, true));
        }

        private void SwigDirectorOnInitialize()
        {
            OnInitialize();
        }

        public delegate global::System.IntPtr SwigDelegateLayoutItemWrapperImpl_0();
        public delegate void SwigDelegateLayoutItemWrapperImpl_1();
        public delegate void SwigDelegateLayoutItemWrapperImpl_2(string containerType);
        public delegate void SwigDelegateLayoutItemWrapperImpl_3(global::System.IntPtr widthMeasureSpec, global::System.IntPtr heightMeasureSpec);
        public delegate void SwigDelegateLayoutItemWrapperImpl_4(bool changed, global::System.IntPtr left, global::System.IntPtr top, global::System.IntPtr right, global::System.IntPtr bottom);
        public delegate void SwigDelegateLayoutItemWrapperImpl_5(global::System.IntPtr newSize, global::System.IntPtr oldSize);
        public delegate void SwigDelegateLayoutItemWrapperImpl_6();

        private SwigDelegateLayoutItemWrapperImpl_0 swigDelegate0;
        private SwigDelegateLayoutItemWrapperImpl_1 swigDelegate1;
        private SwigDelegateLayoutItemWrapperImpl_2 swigDelegate2;
        private SwigDelegateLayoutItemWrapperImpl_3 swigDelegate3;
        private SwigDelegateLayoutItemWrapperImpl_4 swigDelegate4;
        private SwigDelegateLayoutItemWrapperImpl_5 swigDelegate5;
        private SwigDelegateLayoutItemWrapperImpl_6 swigDelegate6;

        private static global::System.Type[] swigMethodTypes0 = new global::System.Type[] {  };
        private static global::System.Type[] swigMethodTypes1 = new global::System.Type[] {  };
        private static global::System.Type[] swigMethodTypes2 = new global::System.Type[] { typeof(string) };
        private static global::System.Type[] swigMethodTypes3 = new global::System.Type[] { typeof(LayoutMeasureSpec), typeof(LayoutMeasureSpec) };
        private static global::System.Type[] swigMethodTypes4 = new global::System.Type[] { typeof(bool), typeof(LayoutLength), typeof(LayoutLength), typeof(LayoutLength), typeof(LayoutLength) };
        private static global::System.Type[] swigMethodTypes5 = new global::System.Type[] { typeof(LayoutSize), typeof(LayoutSize) };
        private static global::System.Type[] swigMethodTypes6 = new global::System.Type[] {  };
    }
} // namespace Tizen.NUI