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

using System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// LayoutGroup class providing container functionality.
    /// </summary>
    public class LayoutGroup : LayoutGroupWrapper
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal LayoutGroupImpl layoutGroupImpl;

        // callback
        public new OnMeasureDelegate OnMeasure;

        // delegate declarations
        public delegate void OnMeasureDelegate( uint width, uint height);

        public LayoutGroup() : base( new LayoutGroupImpl() )
        {
            Console.WriteLine("LayoutGroup public constructor");
        }

        internal LayoutGroup(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicManualPINVOKE.LayoutGroup_SWIGUpcast(cPtr), cMemoryOwn)
        {
            Console.WriteLine("LayoutGroup internal constructor");
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            layoutGroupImpl = new LayoutGroupImpl( cPtr, true );
            //OnMeasure = layoutGroupImpl.OnMeasureDelegate(OnMeasure);

        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(LayoutGroup obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Measure the view and its content to determine the measured width and height.
        /// </summary>
        /// <param name="widthMeasureSpec">Horizontal space requirements as imposed by the parent.</param>
        /// <param name="heightMeasureSpec">Vertical space requirements as imposed by the parent.</param>
        //public virtual void OnMeasure( uint widthMeasureSpec, uint heightMeasureSpec )
        //{
        //}

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <param name="type">The dispose type</param>
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
                    NDalicPINVOKE.delete_Handle(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }
    } // class LayoutGroup
}