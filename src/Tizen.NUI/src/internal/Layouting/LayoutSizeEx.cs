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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] This class represents a layout size (width and height), non mutable.
    /// </summary>
    internal struct LayoutSizeEx
    {
        /// <summary>
        /// [Draft] Constructor from width and height
        /// </summary>
        /// <param name="width">Int to initialize with.</param>
        /// <param name="height">Int to initialize with.</param>
        public LayoutSizeEx(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// [Draft] Check if LayoutSize objects are equal
        /// </summary>
        /// <param name="target">The LayoutSize object to compare against.</param>
        /// <returns>true if equal LayoutSize objects, else false.</returns>
        public bool IsEqualTo(LayoutSizeEx target)
        {
            if (Width == target.Width && Height == target.Height)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// [Draft] Get the width value of this layout
        /// </summary>
        public int Width{ get; private set; }

        /// <summary>
        /// [Draft] Get the height value of this layout
        /// </summary>
        public int Height{ get; private set; }

    }
}
