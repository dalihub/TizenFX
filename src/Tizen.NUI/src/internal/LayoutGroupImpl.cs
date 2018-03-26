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

using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;
namespace Tizen.NUI
{
    /// <summary>
    /// Internal Layout class that all layout containers should derive from.
    /// Mirrors the native class LayoutGroup.
    /// </summary>
    internal class LayoutGroupImpl : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        public delegate void OnMeasureDelegate(int depth);

        public new OnMeasureDelegate OnStageConnection;

        internal LayoutGroupImpl(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.Handle_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(LayoutGroupImpl obj)
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
                //Release your own managed resources here.LayoutGroup
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

            base.Dispose(type);
        }

        private void DirectorConnect()
        {
            Delegate0 = new DelegateLayoutGroupImpl_0(DirectorOnMeasure);

            NDalicManualPINVOKE.LayoutGroupImpl_director_connect(swigCPtr, Delegate0 );
        }

        private void DirectorOnMeasure( uint widthMeasureSpec, uint heightMeasureSpec )
        {
            NDalicManualPINVOKE.LayoutGroupImpl_OnMeasure( widthMeasureSpec, heightMeasureSpec );
        }

        public delegate void DelegateLayoutGroupImpl_0( uint widthMeasureSpec, uint heightMeasureSpec );

        private DelegateLayoutGroupImpl_0 Delegate0;


    } // class LayoutGroupImpl

} // namespace Tizen.NUI