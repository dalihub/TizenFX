using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class AutofillContainer
        {

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_SWIGUpcast")]
            public static extern global::System.IntPtr AutofillContainer_SWIGUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_AutofillContainer_New")]
            public static extern global::System.IntPtr AutofillContainer_New(string jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AutofillContainer__SWIG_1")]
            public static extern global::System.IntPtr new_AutofillContainer__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AutofillContainer__SWIG_0")]
            public static extern global::System.IntPtr new_AutofillContainer__SWIG_0();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_Assign")]
            public static extern global::System.IntPtr AutofillContainer_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_AutofillContainer")]
            public static extern void delete_AutofillContainer(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_DownCast")]
            public static extern global::System.IntPtr AutofillContainer_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_AutofillContainer_AddAutofillItem")]
            public static extern void AutofillContainer_AddAutofillItem(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_GetAutofillGroup")]
            public static extern global::System.IntPtr AutofillContainer_GetAutofillGroup(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_GetAutofillServiceName")]
            public static extern string AutofillContainer_GetAutofillServiceName(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_GetAutofillServiceMessage")]
            public static extern string AutofillContainer_GetAutofillServiceMessage(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_GetAutofillServiceImagePath")]
            public static extern string AutofillContainer_GetAutofillServiceImagePath(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_AutofillServiceShownSignal")]
            public static extern global::System.IntPtr AutofillContainer_AutofillServiceShownSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AutofillContainer_AutofillListShownSignal")]
            public static extern global::System.IntPtr AutofillContainer_AutofillListShownSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        }
    }
}
