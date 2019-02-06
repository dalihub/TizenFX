/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] A type that represents a layout length. Currently, this implies pixels, but could be extended to handle device dependant sizes, etc.
    /// </summary>
    internal class LayoutLengthEx
    {
        private int Size { get; set; }

        public LayoutLengthEx(int value)
        {
        }

        public LayoutLengthEx(LayoutLength layoutLength)
        {
            //if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The addition operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The LayoutLength containing the result of the addition.</returns>
        public static LayoutLengthEx operator +(LayoutLengthEx arg1, LayoutLengthEx arg2)
        {
            return arg1.Add(arg2);
        }

        /// <summary>
        /// The addition operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The LayoutLength containing the result of the addition.</returns>
        public static LayoutLengthEx operator +(LayoutLengthEx arg1, int arg2)
        {
            return arg1.Add(arg2);
        }

        /// <summary>
        /// The subtraction operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The LayoutLength containing the result of the subtraction.</returns>
        public static LayoutLengthEx operator -(LayoutLengthEx arg1, LayoutLengthEx arg2)
        {
            return arg1.Subtract(arg2);
        }

        /// <summary>
        /// The subtraction operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The LayoutLength containing the result of the subtraction.</returns>
        public static LayoutLengthEx operator -(LayoutLengthEx arg1, int arg2)
        {
            return arg1.Subtract(arg2);
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The LayoutLength containing the result of the multiplication.</returns>
        public static LayoutLengthEx operator *(LayoutLengthEx arg1, LayoutLengthEx arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// Th multiplication operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The int value to scale the LayoutLength.</param>
        /// <returns>The LayoutLength containing the result of the scaling.</returns>
        public static LayoutLengthEx operator *(LayoutLengthEx arg1, int arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The LayoutLength containing the result of the division.</returns>
        public static LayoutLengthEx operator /(LayoutLengthEx arg1, LayoutLengthEx arg2)
        {
            return arg1.Divide(arg2);
        }

        /// <summary>
        /// Th division operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The int value to scale the vector by.</param>
        /// <returns>The LayoutLength containing the result of the scaling.</returns>
        public static LayoutLengthEx operator /(LayoutLengthEx arg1, int arg2)
        {
            return arg1.Divide(arg2);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        // public override bool Equals(System.Object obj)
        // {
        //     LayoutLengthEx layoutLength = obj as LayoutLengthEx;
        //     bool equal = false;
        //     if (Value == layoutLength?.Value)
        //     {
        //         equal = true;
        //     }
        //     return equal;
        // }

        private bool NotEqualTo(LayoutLengthEx rhs)
        {
            bool ret = LayoutPINVOKE.LayoutLength_NotEqualTo(swigCPtr, LayoutLength.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool LessThan(LayoutLengthEx rhs)
        {
            bool ret = LayoutPINVOKE.LayoutLength_LessThan__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool GreaterThan(LayoutLengthEx rhs)
        {
            bool ret = LayoutPINVOKE.LayoutLength_GreaterThan__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLength Add(LayoutLengthEx rhs)
        {
            LayoutLengthEx ret = new LayoutLengthEx(LayoutPINVOKE.LayoutLength_Add__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLengthEx Add(int rhs)
        {
            LayoutLengthEx ret = new LayoutLengthEx(LayoutPINVOKE.LayoutLength_Add__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLengthEx Subtract(LayoutLengthEx rhs)
        {
            LayoutLengthEx ret = new LayoutLengthEx(LayoutPINVOKE.LayoutLength_Subtract__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLengthEx Subtract(int rhs)
        {
            LayoutLengthEx ret = new LayoutLengthEx(LayoutPINVOKE.LayoutLength_Subtract__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLengthEx AddAssign(LayoutLengthEx rhs)
        {
            LayoutLengthEx ret = new LayoutLengthEx(LayoutPINVOKE.LayoutLength_AddAssign__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLengthEx AddAssign(int rhs)
        {
            LayoutLengthEx ret = new LayoutLengthEx(LayoutPINVOKE.LayoutLength_AddAssign__SWIG_1(swigCPtr, rhs), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLengthEx SubtractAssign(LayoutLengthEx rhs)
        {
            LayoutLengthEx ret = new LayoutLengthEx(LayoutPINVOKE.LayoutLength_SubtractAssign__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLengthEx SubtractAssign(int rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_SubtractAssign__SWIG_1(swigCPtr, rhs), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLengthEx Divide(LayoutLengthEx rhs)
        {
            LayoutLengthEx ret = new LayoutLengthEx(LayoutPINVOKE.LayoutLength_Divide__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLengthEx Divide(int rhs)
        {
            LayoutLengthEx ret = new LayoutLengthEx(LayoutPINVOKE.LayoutLength_Divide__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLengthEx Multiply(LayoutLengthEx rhs)
        {
            LayoutLengthEx ret = new LayoutLengthEx(LayoutPINVOKE.LayoutLength_Multiply__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLengthEx Multiply(int rhs)
        {
            LayoutLengthEx ret = new LayoutLengthEx(LayoutPINVOKE.LayoutLength_Multiply__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLengthEx Multiply(float rhs)
        {
            LayoutLengthEx ret = new LayoutLengthEx(LayoutPINVOKE.LayoutLength_Multiply__SWIG_2(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
