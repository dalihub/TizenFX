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
    /// Internal Layout class that all layout containers should derive from.
    /// Mirrors the native class LayoutGroup.
    /// </summary>
    internal class LayoutGroupWrapperImpl : LayoutItemWrapperImpl
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal LayoutGroupWrapperImpl(global::System.IntPtr cPtr, bool cMemoryOwn) : base(LayoutPINVOKE.LayoutGroupWrapperImpl_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(LayoutGroupWrapperImpl obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        public LayoutGroupWrapperImpl() : this(LayoutPINVOKE.new_LayoutGroupWrapperImpl(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            SwigDirectorConnect();
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

        public uint Add(LayoutItemWrapperImpl layoutChild)
        {
            uint ret = LayoutPINVOKE.LayoutGroupWrapperImpl_Add(swigCPtr, LayoutItemWrapperImpl.getCPtr(layoutChild));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Remove(uint childId)
        {
            LayoutPINVOKE.LayoutGroupWrapperImpl_Remove__SWIG_0(swigCPtr, childId);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Remove(LayoutItemWrapperImpl child)
        {
            LayoutPINVOKE.LayoutGroupWrapperImpl_Remove__SWIG_1(swigCPtr, LayoutItemWrapperImpl.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void RemoveAll()
        {
            LayoutPINVOKE.LayoutGroupWrapperImpl_RemoveAll(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public uint GetChildCount()
        {
            uint ret = LayoutPINVOKE.LayoutGroupWrapperImpl_GetChildCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /*public SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__Internal__LayoutItem_t GetChildAt(uint childIndex)
        {
            SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__Internal__LayoutItem_t ret = new SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__Internal__LayoutItem_t(LayoutPINVOKE.LayoutGroupWrapperImpl_GetChildAt(swigCPtr, childIndex), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }*/

        public uint GetChildId(LayoutItemWrapperImpl child)
        {
            uint ret = LayoutPINVOKE.LayoutGroupWrapperImpl_GetChildId(swigCPtr, LayoutItemWrapperImpl.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /*public SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__Internal__LayoutItem_t GetChild(uint childId)
        {
            SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__Internal__LayoutItem_t ret = new SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__Internal__LayoutItem_t(LayoutPINVOKE.LayoutGroupWrapperImpl_GetChild(swigCPtr, childId), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }*/

        public virtual void OnChildAdd(LayoutItemWrapperImpl child)
        {
            if (SwigDerivedClassHasMethod("OnChildAdd", swigMethodTypes7)) LayoutPINVOKE.LayoutGroupWrapperImpl_OnChildAddSwigExplicitLayoutGroupWrapperImpl(swigCPtr, LayoutItemWrapperImpl.getCPtr(child)); else LayoutPINVOKE.LayoutGroupWrapperImpl_OnChildAdd(swigCPtr, LayoutItemWrapperImpl.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual void OnChildRemove(LayoutItemWrapperImpl child)
        {
            if (SwigDerivedClassHasMethod("OnChildRemove", swigMethodTypes8)) LayoutPINVOKE.LayoutGroupWrapperImpl_OnChildRemoveSwigExplicitLayoutGroupWrapperImpl(swigCPtr, LayoutItemWrapperImpl.getCPtr(child)); else LayoutPINVOKE.LayoutGroupWrapperImpl_OnChildRemove(swigCPtr, LayoutItemWrapperImpl.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static LayoutMeasureSpec GetChildMeasureSpec(LayoutMeasureSpec measureSpec, LayoutLength padding, LayoutLength childDimension)
        {
            LayoutMeasureSpec ret = new LayoutMeasureSpec(LayoutPINVOKE.LayoutGroupWrapperImpl_GetChildMeasureSpec(LayoutMeasureSpec.getCPtr(measureSpec), LayoutLength.getCPtr(padding), LayoutLength.getCPtr(childDimension)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        protected virtual void DoInitialize()
        {
            if (SwigDerivedClassHasMethod("DoInitialize", swigMethodTypes9)) LayoutPINVOKE.LayoutGroupWrapperImpl_DoInitializeSwigExplicitLayoutGroupWrapperImpl(swigCPtr); else LayoutPINVOKE.LayoutGroupWrapperImpl_DoInitialize(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual void DoRegisterChildProperties(string containerType)
        {
            if (SwigDerivedClassHasMethod("DoRegisterChildProperties", swigMethodTypes10)) LayoutPINVOKE.LayoutGroupWrapperImpl_DoRegisterChildPropertiesSwigExplicitLayoutGroupWrapperImpl(swigCPtr, containerType); else LayoutPINVOKE.LayoutGroupWrapperImpl_DoRegisterChildProperties(swigCPtr, containerType);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /*protected virtual void GenerateDefaultChildPropertyValues(Handle child)
        {
            if (SwigDerivedClassHasMethod("GenerateDefaultChildPropertyValues", swigMethodTypes11)) LayoutPINVOKE.LayoutGroupWrapperImpl_GenerateDefaultChildPropertyValuesSwigExplicitLayoutGroupWrapperImpl(swigCPtr, Handle.getCPtr(child)); else LayoutPINVOKE.LayoutGroupWrapperImpl_GenerateDefaultChildPropertyValues(swigCPtr, Handle.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }*/

        protected virtual void MeasureChildren(LayoutMeasureSpec widthMeasureSpec, LayoutMeasureSpec heightMeasureSpec)
        {
            if (SwigDerivedClassHasMethod("MeasureChildren", swigMethodTypes12)) LayoutPINVOKE.LayoutGroupWrapperImpl_MeasureChildrenSwigExplicitLayoutGroupWrapperImpl(swigCPtr, LayoutMeasureSpec.getCPtr(widthMeasureSpec), LayoutMeasureSpec.getCPtr(heightMeasureSpec)); else LayoutPINVOKE.LayoutGroupWrapperImpl_MeasureChildren(swigCPtr, LayoutMeasureSpec.getCPtr(widthMeasureSpec), LayoutMeasureSpec.getCPtr(heightMeasureSpec));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /*protected virtual void MeasureChild(SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__Internal__LayoutItem_t child, LayoutMeasureSpec parentWidthMeasureSpec, LayoutMeasureSpec parentHeightMeasureSpec)
        {
            if (SwigDerivedClassHasMethod("MeasureChild", swigMethodTypes13)) LayoutPINVOKE.LayoutGroupWrapperImpl_MeasureChildSwigExplicitLayoutGroupWrapperImpl(swigCPtr, SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__Internal__LayoutItem_t.getCPtr(child), LayoutMeasureSpec.getCPtr(parentWidthMeasureSpec), LayoutMeasureSpec.getCPtr(parentHeightMeasureSpec)); else LayoutPINVOKE.LayoutGroupWrapperImpl_MeasureChild(swigCPtr, SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__Internal__LayoutItem_t.getCPtr(child), LayoutMeasureSpec.getCPtr(parentWidthMeasureSpec), LayoutMeasureSpec.getCPtr(parentHeightMeasureSpec));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual void MeasureChildWithMargins(SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__Internal__LayoutItem_t child, LayoutMeasureSpec parentWidthMeasureSpec, LayoutLength widthUsed, MeasureSpec parentHeightMeasureSpec, LayoutLength heightUsed)
        {
            if (SwigDerivedClassHasMethod("MeasureChildWithMargins", swigMethodTypes14)) LayoutPINVOKE.LayoutGroupWrapperImpl_MeasureChildWithMarginsSwigExplicitLayoutGroupWrapperImpl(swigCPtr, SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__Internal__LayoutItem_t.getCPtr(child), MeasureSpec.getCPtr(parentWidthMeasureSpec), LayoutLength.getCPtr(widthUsed), LayoutMeasureSpec.getCPtr(parentHeightMeasureSpec), LayoutLength.getCPtr(heightUsed)); else LayoutPINVOKE.LayoutGroupWrapperImpl_MeasureChildWithMargins(swigCPtr, SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__Internal__LayoutItem_t.getCPtr(child), LayoutMeasureSpec.getCPtr(parentWidthMeasureSpec), LayoutLength.getCPtr(widthUsed), LayoutMeasureSpec.getCPtr(parentHeightMeasureSpec), LayoutLength.getCPtr(heightUsed));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }*/

        private void SwigDirectorConnect()
        {
            //if (SwigDerivedClassHasMethod("GetParent", swigMethodTypes0))
                //swigDelegate0 = new SwigDelegateLayoutGroupWrapperImpl_0(SwigDirectorGetParent);
            if (SwigDerivedClassHasMethod("OnMeasure", swigMethodTypes3))
                swigDelegate3 = new SwigDelegateLayoutGroupWrapperImpl_3(SwigDirectorOnMeasure);
            if (SwigDerivedClassHasMethod("OnLayout", swigMethodTypes4))
                swigDelegate4 = new SwigDelegateLayoutGroupWrapperImpl_4(SwigDirectorOnLayout);
            if (SwigDerivedClassHasMethod("OnSizeChanged", swigMethodTypes5))
                swigDelegate5 = new SwigDelegateLayoutGroupWrapperImpl_5(SwigDirectorOnSizeChanged);
            if (SwigDerivedClassHasMethod("OnInitialize", swigMethodTypes6))
                swigDelegate6 = new SwigDelegateLayoutGroupWrapperImpl_6(SwigDirectorOnInitialize);
            if (SwigDerivedClassHasMethod("OnChildAdd", swigMethodTypes7))
                swigDelegate7 = new SwigDelegateLayoutGroupWrapperImpl_7(SwigDirectorOnChildAdd);
            if (SwigDerivedClassHasMethod("OnChildRemove", swigMethodTypes8))
                swigDelegate8 = new SwigDelegateLayoutGroupWrapperImpl_8(SwigDirectorOnChildRemove);
            if (SwigDerivedClassHasMethod("DoInitialize", swigMethodTypes9))
                swigDelegate9 = new SwigDelegateLayoutGroupWrapperImpl_9(SwigDirectorDoInitialize);
            if (SwigDerivedClassHasMethod("DoRegisterChildProperties", swigMethodTypes10))
                swigDelegate10 = new SwigDelegateLayoutGroupWrapperImpl_10(SwigDirectorDoRegisterChildProperties);
            //if (SwigDerivedClassHasMethod("GenerateDefaultChildPropertyValues", swigMethodTypes11))
                //swigDelegate11 = new SwigDelegateLayoutGroupWrapperImpl_11(SwigDirectorGenerateDefaultChildPropertyValues);
            if (SwigDerivedClassHasMethod("MeasureChildren", swigMethodTypes12))
                swigDelegate12 = new SwigDelegateLayoutGroupWrapperImpl_12(SwigDirectorMeasureChildren);
            //if (SwigDerivedClassHasMethod("MeasureChild", swigMethodTypes13))
                //swigDelegate13 = new SwigDelegateLayoutGroupWrapperImpl_13(SwigDirectorMeasureChild);
            //if (SwigDerivedClassHasMethod("MeasureChildWithMargins", swigMethodTypes14))
                //swigDelegate14 = new SwigDelegateLayoutGroupWrapperImpl_14(SwigDirectorMeasureChildWithMargins);

            LayoutPINVOKE.LayoutGroupWrapperImpl_director_connect(swigCPtr, swigDelegate0, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14);
        }

        private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes)
        {
            global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.Instance, null, methodTypes, null);
            bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(LayoutGroupWrapperImpl));
            return hasDerivedMethod;
        }

        /*private global::System.IntPtr SwigDirectorGetParent()
        {
            return LayoutParent.getCPtr(GetParent()).Handle;
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

        private void SwigDirectorOnChildAdd(global::System.IntPtr child)
        {
            OnChildAdd(new LayoutItemWrapperImpl(child, false));
        }

        private void SwigDirectorOnChildRemove(global::System.IntPtr child)
        {
            OnChildRemove(new LayoutItemWrapperImpl(child, false));
        }

        private void SwigDirectorDoInitialize()
        {
            DoInitialize();
        }

        private void SwigDirectorDoRegisterChildProperties(string containerType)
        {
            DoRegisterChildProperties(containerType);
        }

        private void SwigDirectorGenerateDefaultChildPropertyValues(global::System.IntPtr child)
        {
            //GenerateDefaultChildPropertyValues(new Handle(child, true));
        }

        private void SwigDirectorMeasureChildren(global::System.IntPtr widthMeasureSpec, global::System.IntPtr heightMeasureSpec)
        {
            MeasureChildren(new LayoutMeasureSpec(widthMeasureSpec, true), new LayoutMeasureSpec(heightMeasureSpec, true));
        }

        private void SwigDirectorMeasureChild(global::System.IntPtr child, global::System.IntPtr parentWidthMeasureSpec, global::System.IntPtr parentHeightMeasureSpec)
        {
            //MeasureChild(new SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__Internal__LayoutItem_t(child, true), new MeasureSpec(parentWidthMeasureSpec, true), new MeasureSpec(parentHeightMeasureSpec, true));
        }

        private void SwigDirectorMeasureChildWithMargins(global::System.IntPtr child, global::System.IntPtr parentWidthMeasureSpec, global::System.IntPtr widthUsed, global::System.IntPtr parentHeightMeasureSpec, global::System.IntPtr heightUsed)
        {
            //MeasureChildWithMargins(new SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__Internal__LayoutItem_t(child, true), new MeasureSpec(parentWidthMeasureSpec, true), new LayoutLength(widthUsed, true), new MeasureSpec(parentHeightMeasureSpec, true), new LayoutLength(heightUsed, true));
        }

        public delegate global::System.IntPtr SwigDelegateLayoutGroupWrapperImpl_0();
        public delegate void SwigDelegateLayoutGroupWrapperImpl_3(global::System.IntPtr widthMeasureSpec, global::System.IntPtr heightMeasureSpec);
        public delegate void SwigDelegateLayoutGroupWrapperImpl_4(bool changed, global::System.IntPtr left, global::System.IntPtr top, global::System.IntPtr right, global::System.IntPtr bottom);
        public delegate void SwigDelegateLayoutGroupWrapperImpl_5(global::System.IntPtr newSize, global::System.IntPtr oldSize);
        public delegate void SwigDelegateLayoutGroupWrapperImpl_6();
        public delegate void SwigDelegateLayoutGroupWrapperImpl_7(global::System.IntPtr child);
        public delegate void SwigDelegateLayoutGroupWrapperImpl_8(global::System.IntPtr child);
        public delegate void SwigDelegateLayoutGroupWrapperImpl_9();
        public delegate void SwigDelegateLayoutGroupWrapperImpl_10(string containerType);
        public delegate void SwigDelegateLayoutGroupWrapperImpl_11(global::System.IntPtr child);
        public delegate void SwigDelegateLayoutGroupWrapperImpl_12(global::System.IntPtr widthMeasureSpec, global::System.IntPtr heightMeasureSpec);
        public delegate void SwigDelegateLayoutGroupWrapperImpl_13(global::System.IntPtr child, global::System.IntPtr parentWidthMeasureSpec, global::System.IntPtr parentHeightMeasureSpec);
        public delegate void SwigDelegateLayoutGroupWrapperImpl_14(global::System.IntPtr child, global::System.IntPtr parentWidthMeasureSpec, global::System.IntPtr widthUsed, global::System.IntPtr parentHeightMeasureSpec, global::System.IntPtr heightUsed);

        private SwigDelegateLayoutGroupWrapperImpl_0 swigDelegate0;
        private SwigDelegateLayoutGroupWrapperImpl_3 swigDelegate3;
        private SwigDelegateLayoutGroupWrapperImpl_4 swigDelegate4;
        private SwigDelegateLayoutGroupWrapperImpl_5 swigDelegate5;
        private SwigDelegateLayoutGroupWrapperImpl_6 swigDelegate6;
        private SwigDelegateLayoutGroupWrapperImpl_7 swigDelegate7;
        private SwigDelegateLayoutGroupWrapperImpl_8 swigDelegate8;
        private SwigDelegateLayoutGroupWrapperImpl_9 swigDelegate9;
        private SwigDelegateLayoutGroupWrapperImpl_10 swigDelegate10;
        private SwigDelegateLayoutGroupWrapperImpl_11 swigDelegate11;
        private SwigDelegateLayoutGroupWrapperImpl_12 swigDelegate12;
        private SwigDelegateLayoutGroupWrapperImpl_13 swigDelegate13;
        private SwigDelegateLayoutGroupWrapperImpl_14 swigDelegate14;

        private static global::System.Type[] swigMethodTypes0 = new global::System.Type[] {  };
        private static global::System.Type[] swigMethodTypes3 = new global::System.Type[] { typeof(LayoutMeasureSpec), typeof(LayoutMeasureSpec) };
        private static global::System.Type[] swigMethodTypes4 = new global::System.Type[] { typeof(bool), typeof(LayoutLength), typeof(LayoutLength), typeof(LayoutLength), typeof(LayoutLength) };
        private static global::System.Type[] swigMethodTypes5 = new global::System.Type[] { typeof(LayoutSize), typeof(LayoutSize) };
        private static global::System.Type[] swigMethodTypes6 = new global::System.Type[] {  };
        private static global::System.Type[] swigMethodTypes7 = new global::System.Type[] { typeof(LayoutItemWrapperImpl) };
        private static global::System.Type[] swigMethodTypes8 = new global::System.Type[] { typeof(LayoutItemWrapperImpl) };
        private static global::System.Type[] swigMethodTypes9 = new global::System.Type[] {  };
        private static global::System.Type[] swigMethodTypes10 = new global::System.Type[] { typeof(string) };
        //private static global::System.Type[] swigMethodTypes11 = new global::System.Type[] { typeof(Handle) };
        private static global::System.Type[] swigMethodTypes12 = new global::System.Type[] { typeof(LayoutMeasureSpec), typeof(LayoutMeasureSpec) };
        //private static global::System.Type[] swigMethodTypes13 = new global::System.Type[] { typeof(SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__Internal__LayoutItem_t), typeof(LayoutMeasureSpec), typeof(LayoutMeasureSpec) };
        //private static global::System.Type[] swigMethodTypes14 = new global::System.Type[] { typeof(SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__Internal__LayoutItem_t), typeof(LayoutMeasureSpec), typeof(LayoutLength), typeof(LayoutMeasureSpec), typeof(LayoutLength) };
    }
} // namespace Tizen.NUI