﻿/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.Samples
{
    internal static partial class Interop
    {
        internal static partial class Item
        {
            [global::System.Runtime.InteropServices.DllImport(SamplesNDalicPINVOKE.ToolkitDemoLib, EntryPoint = "CSharp_Dali_new_Item__SWIG_0")]
            public static extern global::System.IntPtr NewItem();

            [global::System.Runtime.InteropServices.DllImport(SamplesNDalicPINVOKE.ToolkitDemoLib, EntryPoint = "CSharp_Dali_new_Item__SWIG_1")]
            public static extern global::System.IntPtr NewItem(uint jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(SamplesNDalicPINVOKE.ToolkitDemoLib, EntryPoint = "CSharp_Dali_new_Item__SWIG_2")]
            public static extern global::System.IntPtr NewItem(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(SamplesNDalicPINVOKE.ToolkitDemoLib, EntryPoint = "CSharp_Dali_Item_first_set")]
            public static extern void FirstSet(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(SamplesNDalicPINVOKE.ToolkitDemoLib, EntryPoint = "CSharp_Dali_Item_first_get")]
            public static extern uint FirstGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(SamplesNDalicPINVOKE.ToolkitDemoLib, EntryPoint = "CSharp_Dali_Item_second_set")]
            public static extern void SecondSet(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(SamplesNDalicPINVOKE.ToolkitDemoLib, EntryPoint = "CSharp_Dali_Item_second_get")]
            public static extern global::System.IntPtr SecondGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(SamplesNDalicPINVOKE.ToolkitDemoLib, EntryPoint = "CSharp_Dali_delete_Item")]
            public static extern void DeleteItem(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
