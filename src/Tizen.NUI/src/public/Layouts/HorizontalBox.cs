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
    public class HorizontalBox : LayoutView
    {
        public HorizontalBox()
        {
        }

        protected override void OnMeasure( uint widthMeasureSpec, uint heightMeasureSpec )
        {
            Console.WriteLine("OnMeasure called in HorizontalBox");
        }

        public override void OnLayout( bool changed, int left, int top, int right, int bottom, bool animate )
        {

        }

        public override void OnSetLayoutData( uint layoutData )
        {

        }
    }
}