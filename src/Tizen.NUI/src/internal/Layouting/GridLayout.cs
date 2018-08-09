/** Copyright (c) 2018 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] This class implements a grid layout
    /// </summary>
    internal class GridLayout : LayoutGroupWrapper
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal GridLayout(global::System.IntPtr cPtr, bool cMemoryOwn) : base(LayoutPINVOKE.GridLayout_SWIGUpcast(cPtr), cMemoryOwn)
        {
                        System.Console.WriteLine("GridLayout\n");

            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(GridLayout obj)
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
                    LayoutPINVOKE.delete_GridLayout(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            base.Dispose(type);
        }

        public GridLayout() : this(LayoutPINVOKE.GridLayout_New(), true)
        {
            System.Console.WriteLine("GridLayout_New\n");

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public new static GridLayout DownCast(BaseHandle handle)
        {
            System.Console.WriteLine("DownCast new\n");

            GridLayout ret = new GridLayout(LayoutPINVOKE.GridLayout_DownCast(BaseHandle.getCPtr(handle)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal GridLayout(GridLayout other) : this(LayoutPINVOKE.new_GridLayout_SWIG_1(GridLayout.getCPtr(other)), true)
        {
            System.Console.WriteLine("GridLayout new\n");

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal GridLayout Assign(GridLayout other)
        {
            GridLayout ret = new GridLayout(LayoutPINVOKE.GridLayout_Assign(swigCPtr, GridLayout.getCPtr(other)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetColumns(int columns)
        {
            LayoutPINVOKE.GridLayout_SetColumns(swigCPtr, columns);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal int GetColumns()
        {
            int ret = (int)LayoutPINVOKE.GridLayout_GetColumns(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        // <summary>
        // [Draft] Get/Set the number of columns in the grid
        // </summary>
        public int Columns
        {
            get
            {
                return GetColumns();
            }
            set
            {
                SetColumns(value);
            }
        }
    }

}
