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
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// A ToggleButton allows the user to change a setting between two or more states.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ToggleButton : Tizen.NUI.UIComponents.Button
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        /// <summary>
        /// Create an instance for toggleButton.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ToggleButton() : this(NDalicPINVOKE.ToggleButton_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ToggleButton(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.ToggleButton_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// Gets and Sets the state visual array of toggle button.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.PropertyArray StateVisuals
        {
            get
            {
                PropertyArray temp = new PropertyArray();
                Tizen.NUI.Object.GetProperty(swigCPtr, ToggleButton.Property.STATE_VISUALS).Get(temp);
                return temp;
            }
            set
            {
                if (value != null)
                {
                    Tizen.NUI.Object.SetProperty(swigCPtr, ToggleButton.Property.STATE_VISUALS, new PropertyValue((PropertyArray)value));
                }
            }
        }

        /// <summary>
        /// Gets and Sets the tooltips of toggle button.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.PropertyArray Tooltips
        {
            get
            {
                PropertyArray temp = new PropertyArray();
                Tizen.NUI.Object.GetProperty(swigCPtr, ToggleButton.Property.TOOLTIPS).Get(temp);
                return temp;
            }
            set
            {
                if (value != null)
                {
                    Tizen.NUI.Object.SetProperty(swigCPtr, ToggleButton.Property.TOOLTIPS, new PropertyValue((PropertyArray)value));
                }
            }
        }

        /// <summary>
        /// Gets and Sets the current state index of toggle button.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int CurrentStateIndex
        {
            get
            {
                int temp = 0;
                Tizen.NUI.Object.GetProperty(swigCPtr, ToggleButton.Property.CURRENT_STATE_INDEX).Get(out temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, ToggleButton.Property.CURRENT_STATE_INDEX, new PropertyValue(value));
            }
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ToggleButton obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="type">The dispose type</param>
        /// <since_tizen> 3 </since_tizen>
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
                    NDalicPINVOKE.delete_ToggleButton(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        /// <summary>
        /// This should be internal, please do not use.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be changed internal API after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new class Property
        {
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be changed internal API after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int STATE_VISUALS = NDalicPINVOKE.ToggleButton_Property_STATE_VISUALS_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be changed internal API after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int TOOLTIPS = NDalicPINVOKE.ToggleButton_Property_TOOLTIPS_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be changed internal API after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int CURRENT_STATE_INDEX = NDalicPINVOKE.ToggleButton_Property_CURRENT_STATE_INDEX_get();
        }
    }
}
