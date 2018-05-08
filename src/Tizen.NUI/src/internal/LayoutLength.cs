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

    public class LayoutLength : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal LayoutLength(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(LayoutLength obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        ~LayoutLength()
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
                        LayoutPINVOKE.delete_LayoutLength(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                global::System.GC.SuppressFinalize(this);
            }
        }

        public LayoutLength(int value) : this(LayoutPINVOKE.new_LayoutLength__SWIG_0(value), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public LayoutLength(LayoutLength layoutLength) : this(LayoutPINVOKE.new_LayoutLength__SWIG_1(LayoutLength.getCPtr(layoutLength)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public LayoutLength Assign(LayoutLength rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_Assign(swigCPtr, LayoutLength.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool EqualTo(LayoutLength rhs)
        {
            bool ret = LayoutPINVOKE.LayoutLength_EqualTo__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool EqualTo(int rhs)
        {
            bool ret = LayoutPINVOKE.LayoutLength_EqualTo__SWIG_1(swigCPtr, rhs);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool NotEqualTo(LayoutLength rhs)
        {
            bool ret = LayoutPINVOKE.LayoutLength_NotEqualTo(swigCPtr, LayoutLength.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool LessThan(LayoutLength rhs)
        {
            bool ret = LayoutPINVOKE.LayoutLength_LessThan__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool GreaterThan(LayoutLength rhs)
        {
            bool ret = LayoutPINVOKE.LayoutLength_GreaterThan__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutLength Add(LayoutLength rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_Add__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutLength Add(int rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_Add__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutLength Subtract(LayoutLength rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_Subtract__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutLength Subtract(int rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_Subtract__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutLength AddAssign(LayoutLength rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_AddAssign__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutLength AddAssign(int rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_AddAssign__SWIG_1(swigCPtr, rhs), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutLength SubtractAssign(LayoutLength rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_SubtractAssign__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutLength SubtractAssign(int rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_SubtractAssign__SWIG_1(swigCPtr, rhs), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutLength Divide(LayoutLength rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_Divide__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutLength Divide(int rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_Divide__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutLength Multiply(LayoutLength rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_Multiply__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutLength Multiply(int rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_Multiply__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LayoutLength Multiply(float rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_Multiply__SWIG_2(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public float ConvertToFloat()
        {
            float ret = LayoutPINVOKE.LayoutLength_ConvertToFloat(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public int mValue
        {
            set
            {
                LayoutPINVOKE.LayoutLength_mValue_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = LayoutPINVOKE.LayoutLength_mValue_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
    }
}
