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
using System;
using Tizen.NUI.BaseComponents;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] The class that initiates the Measuring and Layouting of the tree.
    /// </summary>
    internal class LayoutController : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;


        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        internal delegate int Callback(string text);


        event Callback mInstance;

        /// <summary>
        /// Constructs a LayoutController which controls the measuring and layouting.<br />
        /// </summary>
        public LayoutController()
        {
            Console.WriteLine("C# LayoutController constructor");

            global::System.IntPtr cPtr = NDalicManualPINVOKE.NewLayoutController();

            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);

            global::System.IntPtr cPtr2 = NDalicManualPINVOKE.Register_NewLayoutController(swigCPtr);

            mInstance = new Callback(Handler);
            Console.WriteLine("C# LayoutController SetCallback");
            NDalicManualPINVOKE.LayoutController_SetCallback(mInstance);
        }

        public void TestCallBack()
        {
          NDalicManualPINVOKE.LayoutController_TestCallback();
        }

        ~LayoutController()
        {
            Dispose();
        }
        public virtual void Dispose()
        {
        }

        private int Handler(string text)
        {
            // Do something...
            Console.WriteLine("LayoutController->" + text);
            return 42;
        }

    } // class LayoutController

} // namespace Tizen.NUI