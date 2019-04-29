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

namespace Tizen.NUI
{
    class LayoutPINVOKE
    {
        // LayoutController

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_LayoutController")]
        public static extern global::System.IntPtr LayoutController_New();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_LayoutController")]
        public static extern global::System.IntPtr delete_LayoutController(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LayoutController_SetCallback")]
        public static extern void LayoutController_SetCallback(global::System.Runtime.InteropServices.HandleRef jarg1, LayoutController.Callback jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LayoutController_GetId")]
        public static extern int LayoutController_GetId(global::System.Runtime.InteropServices.HandleRef jarg1);


        // FlexLayout

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_SWIGUpcast")]
        public static extern global::System.IntPtr FlexLayout_SWIGUpcast(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_ChildProperty_FLEX_get")]
        public static extern int FlexLayout_ChildProperty_FLEX_get();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_ChildProperty_ALIGN_SELF_get")]
        public static extern int FlexLayout_ChildProperty_ALIGN_SELF_get();


        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_FlexLayout__SWIG_0")]
        public static extern global::System.IntPtr new_FlexLayout__SWIG_0();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_New")]
        public static extern global::System.IntPtr FlexLayout_New();

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_SetContext")]
        public static extern global::System.IntPtr FlexLayout_SetContext( global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_SetMeasureFunction")]
        public static extern global::System.IntPtr FlexLayout_SetMeasureFunction( global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_AddChild")]
        public static extern global::System.IntPtr FlexLayout_AddChild( global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, FlexLayout.ChildMeasureCallback jarg3, int jarg4);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_RemoveChildAt")]
        public static extern global::System.IntPtr FlexLayout_RemoveChildAt( global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_CalculateLayout")]
        public static extern global::System.IntPtr FlexLayout_CalculateLayout( global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, bool jarg4);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_GetWidth")]
        public static extern global::System.IntPtr FlexLayout_GetWidth(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_GetHeight")]
        public static extern global::System.IntPtr FlexLayout_GetHeight(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_GetNodeFrame")]
        public static extern global::System.IntPtr FlexLayout_GetNodeFrame(global::System.Runtime.InteropServices.HandleRef jarg1, int index);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_MarkDirty")]
        public static extern global::System.IntPtr FlexLayout_MarkDirty (global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_SetMargin")]
        public static extern global::System.IntPtr FlexLayout_SetMargin( global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_SetPadding")]
        public static extern global::System.IntPtr FlexLayout_SetPadding( global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_DownCast")]
        public static extern global::System.IntPtr FlexLayout_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_FlexLayout__SWIG_1")]
        public static extern global::System.IntPtr new_FlexLayout__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_Assign")]
        public static extern global::System.IntPtr FlexLayout_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_FlexLayout")]
        public static extern void delete_FlexLayout(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_SetFlexDirection")]
        public static extern void FlexLayout_SetFlexDirection(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_GetFlexDirection")]
        public static extern int FlexLayout_GetFlexDirection(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_SetFlexJustification")]
        public static extern void FlexLayout_SetFlexJustification(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_GetFlexJustification")]
        public static extern int FlexLayout_GetFlexJustification(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_SetFlexWrap")]
        public static extern void FlexLayout_SetFlexWrap(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_GetFlexWrap")]
        public static extern int FlexLayout_GetFlexWrap(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_SetFlexAlignment")]
        public static extern void FlexLayout_SetFlexAlignment(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_GetFlexAlignment")]
        public static extern int FlexLayout_GetFlexAlignment(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_SetFlexItemsAlignment")]
        public static extern void FlexLayout_SetFlexItemsAlignment(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_GetFlexItemsAlignment")]
        public static extern int FlexLayout_GetFlexItemsAlignment(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_SetMaximumWidth")]
        public static extern void FlexLayout_SetFlexMaximumWidth(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_SetMaximumHeight")]
        public static extern void FlexLayout_SetFlexMaximumHeight(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_SetMinimumWidth")]
        public static extern void FlexLayout_SetFlexMinimumWidth(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

        [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FlexLayout_SetMinimumHeight")]
        public static extern void FlexLayout_SetFlexMinimumHeight(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);
    }
}
