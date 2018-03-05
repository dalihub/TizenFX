/*
 * Copyright(c) 2018 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// LayoutGroup is the base class for all layouts.
    /// </summary>
    public class LayoutGroup : View
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal View(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.View_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            if (HasBody())
            {
                PositionUsesPivotPoint = false;
            }
        }

        public LayoutId Add( LayoutBase& layoutData )
        {

        }

        public void Remove( LayoutId childId )
        {

        }

        LayoutBase GetChild( LayoutId childId )
        {

        }

        public MeasureSpec GetChildMeasureSpec( MeasureSpec measureSpec, int padding, Dali::Dimension::Type dimension )
        {

        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(View obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

    } // class LayoutGroup
}
