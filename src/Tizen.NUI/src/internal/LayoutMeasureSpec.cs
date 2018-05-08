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

    public class LayoutMeasureSpec : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal LayoutMeasureSpec(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(LayoutMeasureSpec obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        ~LayoutMeasureSpec()
        {
            Dispose();
        }

        public virtual void Dispose()
        {
            lock(this)
            {
                if (swigCPtr.Handle != global::System.IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        LayoutPINVOKE.delete_MeasureSpec(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
            }
        }

        public LayoutMeasureSpec(LayoutLength measureSpec, LayoutMeasureSpec.Mode mode) : this(LayoutPINVOKE.new_MeasureSpec__SWIG_0(LayoutLength.getCPtr(measureSpec), (int)mode), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public LayoutMeasureSpec(int measureSpec) : this(LayoutPINVOKE.new_MeasureSpec__SWIG_1(measureSpec), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool EqualTo(LayoutMeasureSpec value)
        {
            bool ret = LayoutPINVOKE.MeasureSpec_EqualTo(swigCPtr, LayoutMeasureSpec.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool NotEqualTo(LayoutMeasureSpec value)
        {
            bool ret = LayoutPINVOKE.MeasureSpec_NotEqualTo(swigCPtr, LayoutMeasureSpec.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutMeasureSpec.Mode GetMode()
        {
            LayoutMeasureSpec.Mode ret = (LayoutMeasureSpec.Mode)LayoutPINVOKE.MeasureSpec_GetMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public int GetSize()
        {
            int ret = LayoutPINVOKE.MeasureSpec_GetSize(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static LayoutMeasureSpec Adjust(LayoutMeasureSpec measureSpec, int delta)
        {
            LayoutMeasureSpec ret = new LayoutMeasureSpec(LayoutPINVOKE.MeasureSpec_Adjust(LayoutMeasureSpec.getCPtr(measureSpec), delta), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public int mSize
        {
            set
            {
                LayoutPINVOKE.MeasureSpec_mSize_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = LayoutPINVOKE.MeasureSpec_mSize_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public LayoutMeasureSpec.Mode mMode
        {
            set
            {
                LayoutPINVOKE.MeasureSpec_mMode_set(swigCPtr, (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                LayoutMeasureSpec.Mode ret = (LayoutMeasureSpec.Mode)LayoutPINVOKE.MeasureSpec_mMode_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public enum Mode
        {
            UNSPECIFIED,
            EXACTLY,
            AT_MOST
        }
    }
}
