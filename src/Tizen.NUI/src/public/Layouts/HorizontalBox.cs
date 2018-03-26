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
using System.Runtime.InteropServices;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;

// A layout for displaying children horizontally
// Implements the ILayout interface.

namespace Tizen.NUI
{
    ///<summary>
    /// Horizontal box layout, child Views are added to this View and laid out automatically.
    /// </summary>
    public class HorizontalBox : Layout
    {
       // static constructor registers the control type (only runs once)
        static HorizontalBox()
        {
            // ViewRegistry registers control type with DALi type registery
            // also uses introspection to find any properties that need to be registered with type registry
            CustomViewRegistry.Instance.Register(CreateInstance, typeof(HorizontalBox));
        }

        /// <summary>
        /// Creates an initialized spin.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public HorizontalBox() : base(typeof(HorizontalBox).FullName, CustomViewBehaviour.RequiresKeyboardNavigationSupport)
        {
        }

        public override void OnInitialize()
        {
            //1 Create LayoutGroup, explictly here first using control-devel, in
            // future an intermediate class like LayoutGroup, hence user doesn't need to.

            //2 Set created LayoutGroup to control-data-impl.cpp

            //3 How will layout-group native connect up to interface calls.
        }

        public void OnMeasure( uint widthMeasureSpec, uint heightMeasureSpec )
        {

        }

        public void OnLayout( bool changed, int left, int top, int right, int bottom, bool animate )
        {

        }

        public void OnSetLayoutData( /*ChildLayoutData*/ uint layoutData )
        {

        }

// HboxView native has AddChild( ... )
        public uint Add(View child)
        {
            // Add child to View tree exclusively
            child.Unparent();
            Self().Add( child );

            // Add child to layout group so will be positioned and sized.
            layout-group->Native::Add( child.GetNative() )
            return 0;
        }

        public void Remove( uint childId )
        {
            // todo
        }

        public View GetChild( uint childId )
        {
            // todo
            return new View();
        }
    }
}