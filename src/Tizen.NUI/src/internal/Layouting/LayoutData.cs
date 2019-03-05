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

using System.Collections.Generic;

namespace Tizen.NUI
{

    /// <summary>
    /// [Draft] Class to hold layout position data
    /// </summary>
    struct LayoutPositionData
    {
      public LayoutPositionData( float left, float top, float right, float bottom, bool animated )
      {
          _left = left;
          _top = top;
          _right = right;
          _bottom = bottom;
          _animated = animated;
          _updateWithCurrentSize = false;
      }

      private float _left;
      private float _top;
      private float _right;
      private float _bottom;
      private bool _animated;
      private bool _updateWithCurrentSize;
    };

    /// <summary>
    /// [Draft] Class to hold Layout data for each entity being laid out.
    /// </summary>
    internal class LayoutData
    {
        /// <summary>
        /// [Draft] Constructor
        /// </summary>
        public LayoutData()
        {
            layoutPositionDataList = new List<LayoutPositionData>();
        }

//        bool speculativeLayout;
//        bool updateMeasuredSize;
//        LayoutTransition layoutTransition;
        public List<LayoutPositionData> layoutPositionDataList;
        // LayoutAnimatorArray layoutAnimatorArray;
        // LayoutDataArray layoutDataArray;
        // LayoutDataArray childrenLayoutDataArray;

    } // LayoutData

} // namespace Tizen.NUI
