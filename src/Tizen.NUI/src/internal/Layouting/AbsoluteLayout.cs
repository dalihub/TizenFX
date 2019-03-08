/* Copyright (c) 2019 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] This class implements a absolute layout, allowing explicit positioning of children.
    ///  Positions are from the top left of the layout and can be set using the Actor::Property::POSITION and alike.
    /// </summary>
    internal class AbsoluteLayout : LayoutGroupEx
    {
        /// <summary>
        /// Struct to store Measured states of height and width.
        private struct HeightAndWidthState
        {
            public MeasuredSizeEx.StateType widthState;
            public MeasuredSizeEx.StateType heightState;

            public HeightAndWidthState( MeasuredSizeEx.StateType width, MeasuredSizeEx.StateType height)
            {
                widthState = width;
                heightState = height;
            }
        }

        /// <summary>
        /// [Draft] Constructor
        /// </summary>
        public AbsoluteLayout()
        {
        }

        protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            float totalHeight = 0.0f;
            float totalWidth = 0.0f;

            HeightAndWidthState childState = new HeightAndWidthState(MeasuredSizeEx.StateType.MeasuredSizeOK,
                                                                     MeasuredSizeEx.StateType.MeasuredSizeOK);

            float minPositionX = 0.0f;
            float minPositionY = 0.0f;
            float maxPositionX = 0.0f;
            float maxPositionY = 0.0f;

            // measure children
            foreach( LayoutItemEx childLayout in _children )
            {
                if (childLayout != null)
                {
                    // Get size of child
                    MeasureChild( childLayout, widthMeasureSpec, heightMeasureSpec );
                    float childWidth = childLayout.MeasuredWidth.Size.AsDecimal();
                    float childHeight = childLayout.MeasuredHeight.Size.AsDecimal();

                    // Determine the width and height needed by the children using their given position and size.
                    // Children could overlap so find the left most and right most child.
                    Position2D childPosition = childLayout.Owner.Position2D;
                    float childLeft = childPosition.X;
                    float childTop = childPosition.Y;

                    minPositionX = Math.Min( minPositionX, childLeft );
                    maxPositionX = Math.Max( maxPositionX, childLeft + childWidth );
                    // Children could overlap so find the highest and lowest child.
                    minPositionY = Math.Min( minPositionY, childTop );
                    maxPositionY = Math.Max( maxPositionY, childTop + childHeight );

                    // Store current width and height needed to contain all children.
                    totalWidth = maxPositionX - minPositionX;
                    totalHeight = maxPositionY - minPositionY;
                    Log.Info( "NUI" , "AbsoluteLayout::OnMeasure child width(" + totalWidth + ") height(" + totalHeight + ")\n" );

                    if (childLayout.MeasuredWidthAndState.State == MeasuredSizeEx.StateType.MeasuredSizeTooSmall)
                    {
                        childState.widthState = MeasuredSizeEx.StateType.MeasuredSizeTooSmall;
                    }
                    if (childLayout.MeasuredWidthAndState.State == MeasuredSizeEx.StateType.MeasuredSizeTooSmall)
                    {
                        childState.heightState = MeasuredSizeEx.StateType.MeasuredSizeTooSmall;
                    }
                }
            }

            MeasuredSizeEx widthSizeAndState = ResolveSizeAndState(new LayoutLengthEx(totalWidth), widthMeasureSpec, MeasuredSizeEx.StateType.MeasuredSizeOK);
            MeasuredSizeEx heightSizeAndState = ResolveSizeAndState(new LayoutLengthEx(totalHeight), heightMeasureSpec, MeasuredSizeEx.StateType.MeasuredSizeOK);
            totalWidth = widthSizeAndState.Size.AsDecimal();
            totalHeight = heightSizeAndState.Size.AsDecimal();

            // Ensure layout respects it's given minimum size
            totalWidth = Math.Max( totalWidth, SuggestedMinimumWidth.AsDecimal() );
            totalHeight = Math.Max( totalHeight, SuggestedMinimumHeight.AsDecimal() );

            widthSizeAndState.State = childState.widthState;
            heightSizeAndState.State = childState.heightState;

            SetMeasuredDimensions( ResolveSizeAndState( new LayoutLengthEx(totalWidth), widthMeasureSpec, childState.widthState ),
                                   ResolveSizeAndState( new LayoutLengthEx(totalHeight), heightMeasureSpec, childState.heightState ) );
        }

        protected override void OnLayout(bool changed, LayoutLengthEx left, LayoutLengthEx top, LayoutLengthEx right, LayoutLengthEx bottom)
        {
            // Absolute layout positions it's children at their Actor positions.
            // Children could overlap or spill outside the parent, as is the nature of absolute positions.
            foreach( LayoutItemEx childLayout in _children )
            {
                if( childLayout != null )
                {
                    LayoutLengthEx childWidth = childLayout.MeasuredWidth.Size;
                    LayoutLengthEx childHeight = childLayout.MeasuredHeight.Size;

                    Position2D childPosition = childLayout.Owner.Position2D;

                    LayoutLengthEx childLeft = new LayoutLengthEx(childPosition.X);
                    LayoutLengthEx childTop = new LayoutLengthEx(childPosition.Y);

                    Log.Info("NUI", "Child View:" + childLayout.Owner.Name + "position(" + childLeft + "," + childTop + ") width:"
                                    + childWidth + " height:" + childHeight + "\n");

                    childLayout.Layout( childLeft, childTop, childLeft + childWidth, childTop + childHeight );
                }
            }
        }
    }

} // namespace
