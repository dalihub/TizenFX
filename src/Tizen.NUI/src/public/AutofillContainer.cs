/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// AutofillContainer controls several text input boxes.
    /// </summary>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AutofillContainer : BaseHandle
    {
        private UIComponents.Popup popup;
        private UIComponents.PushButton pushButton;

        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        private AuthenticationEventCallbackType _authenticationCallback;
        private ListEventCallbackType _listCallback;

        private event EventHandler<AuthenticationEventArgs> _authenticationEventHandler;
        private event EventHandler<ListEventArgs> _listEventHandler;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool AuthenticationEventCallbackType(IntPtr control);
        private delegate void ListEventCallbackType(IntPtr autofillContainer);
        

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name"> The AutofillContainer name</param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AutofillContainer(string name) : this(Interop.AutofillContainer.AutofillContainer_New( name ), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        internal AutofillContainer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.AutofillContainer.AutofillContainer_SWIGUpcast(cPtr), cMemoryOwn)
        {
            if(_authenticationEventHandler == null)
            {
                _authenticationCallback = OnServiceShown;
                AutofillServiceShownSignal().Connect(_authenticationCallback);
            }

            if(_listEventHandler == null)
            {
                _listCallback = OnListShown;
                AutofillListShownSignal().Connect(_listCallback);
            }

            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }


        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(AutofillContainer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal AutofillContainer(AutofillContainer autofillContainer) : this(Interop.AutofillContainer.new_AutofillContainer__SWIG_1(AutofillContainer.getCPtr(autofillContainer)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal AutofillContainer Assign(AutofillContainer autofillContainer)
        {
            AutofillContainer ret = new AutofillContainer(Interop.AutofillContainer.AutofillContainer_Assign(swigCPtr, AutofillContainer.getCPtr(autofillContainer)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static AutofillContainer DownCast(BaseHandle handle)
        {
            AutofillContainer ret = new AutofillContainer(Interop.AutofillContainer.AutofillContainer_DownCast(BaseHandle.getCPtr(handle)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void AddAutofillItem(BaseComponents.View control)
        {
            Interop.AutofillContainer.AutofillContainer_AddAutofillItem(swigCPtr, BaseComponents.View.getCPtr(control));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public string GetAutofillServiceName()
        {
            string ret = Interop.AutofillContainer.AutofillContainer_GetAutofillServiceName(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public string GetAutofillServiceMessage()
        {
            string ret = Interop.AutofillContainer.AutofillContainer_GetAutofillServiceMessage(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public string GetAutofillServiceImagePath()
        {
            string ret = Interop.AutofillContainer.AutofillContainer_GetAutofillServiceImagePath(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AuthenticationSignalType AutofillServiceShownSignal()
        {

            AuthenticationSignalType ret = new AuthenticationSignalType(Interop.AutofillContainer.AutofillContainer_AutofillServiceShownSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ListSignalType AutofillListShownSignal()
        {
            ListSignalType ret = new ListSignalType(Interop.AutofillContainer.AutofillContainer_AutofillListShownSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        /// <summary>
        /// Dispose.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (this != null && _authenticationCallback != null)
            {
                AutofillServiceShownSignal().Disconnect(_authenticationCallback);
            }

            if( this != null && _listCallback != null)
            {
                AutofillListShownSignal().Disconnect(_listCallback);
            }

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
                    Interop.Texture.delete_Texture(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        private bool OnServiceShown(IntPtr container)
        {
            AuthenticationEventArgs e = new AuthenticationEventArgs();
            if( container != null )
            {
                e.AutofillContainer  = Registry.GetManagedBaseHandleFromNativePtr(container) as AutofillContainer;
            }

            int popupWidth = Window.GetCurrent().Size.Width * 3 / 4;
            bool returnValue = false;

            popup =  new UIComponents.Popup();
            popup.PositionUsesPivotPoint = true;
            popup.ParentOrigin = ParentOrigin.Center;
            popup.PivotPoint = PivotPoint.Center;
            popup.Size2D = new Size2D( popupWidth, 0 );
            popup.TailVisibility = false;
            //popup.TouchedOutside += OnPopupOutsideTouched;
            Window.Instance.Add( popup );
          
            string serviceImage = e.AutofillContainer.GetAutofillServiceImagePath();

            PropertyMap map = new PropertyMap();
            map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image));
            map.Add(ImageVisualProperty.URL, new PropertyValue(serviceImage));

            pushButton = new UIComponents.PushButton();
            pushButton.UnselectedBackgroundVisual = map;
            pushButton.SelectedBackgroundVisual = map;
            pushButton.WidthResizePolicy = ResizePolicyType.FillToParent;
            pushButton.KeyEvent += (obj, ee) =>
            {
                if("Return" == ee.Key.KeyPressedName)
                {
                    // If the button is pressed, send fill request to fill out the data.
                    returnValue = true;
                    popup.DisplayState = UIComponents.Popup.DisplayStateType.Hidden;
                    popup.Reset();
                }
                return false;
            };
            popup.Add( pushButton );
            popup.DisplayState = UIComponents.Popup.DisplayStateType.Shown;

            return returnValue;
        }

        private void OnListShown( IntPtr container )
        {
            ListEventArgs e = new ListEventArgs();
            if( container != null )
            {
                e.AutofillContainer  = Registry.GetManagedBaseHandleFromNativePtr(container) as AutofillContainer;
            }

// TODO
            // Using TableView, make the list of presentation
        }

        internal void OnPopupOutsideTouched()
        {
            popup.DisplayState = UIComponents.Popup.DisplayStateType.Hidden;
            popup.Reset();
        }
        
        /// <summary>
        /// Event arguments that passed via the Authentication event.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]

        public class AuthenticationEventArgs : EventArgs
        {
            /// <summary>
            /// The instance of AutofillContainer
            /// </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public AutofillContainer AutofillContainer
            {
                get;
                set;
            }
        }

        /// <summary>
        /// AutofillContainer list shown event arguments.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ListEventArgs : EventArgs
        {
            /// <summary>
            /// The instance of AutofillContainer
            /// </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public AutofillContainer AutofillContainer
            {
                get;
                set;
            }
        }


    }

}