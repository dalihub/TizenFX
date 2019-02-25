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
using System.Collections.Generic;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] This class implements a linear box layout, automatically handling right to left or left to right direction change.
    /// </summary>
    internal class LinearLayoutEx : LayoutGroupEx
    {
        /// <summary>
        /// [Draft] Enumeration for the direction in which the content is laid out
        /// </summary>
        public enum Orientation
        {
            /// <summary>
            /// Horizontal (row)
            /// </summary>
            Horizontal,
            /// <summary>
            /// Vertical (column)
            /// </summary>
            Vertical
        }

        /// <summary>
        /// [Draft] Enumeration for the alignment of the linear layout items
        /// </summary>
        public enum Alignment
        {
            /// <summary>
            /// At the left/right edge of the container (maps to LTR/RTL direction for horizontal orientation)
            /// </summary>
            Begin              = 0x1,
            /// <summary>
            /// At the right/left edge of the container (maps to LTR/RTL direction for horizontal orientation)
            /// </summary>
            End                = 0x2,
            /// <summary>
            /// At the horizontal center of the container
            /// </summary>
            CenterHorizontal   = 0x4,
            /// <summary>
            /// At the top edge of the container
            /// </summary>
            Top                = 0x8,
            /// <summary>
            /// At the bottom edge of the container
            /// </summary>
            Bottom             = 0x10,
            /// <summary>
            /// At the vertical center of the container
            /// </summary>
            CenterVertical     = 0x20
        }

        struct HeightAndWidthState
        {
            public MeasuredSizeEx.StateType widthState;
            public MeasuredSizeEx.StateType heightState;

            public HeightAndWidthState( MeasuredSizeEx.StateType width, MeasuredSizeEx.StateType height)
            {
                widthState = width;
                heightState = height;
            }
        }

        // internal static new class ChildProperty
        // {
        //     internal static readonly int WEIGHT = 0;
        // }

        /// <summary>
        /// [Draft] Get/Set the orientation in the layout
        /// </summary>
        public LinearLayoutEx.Orientation LinearOrientation{ get; set; } = Orientation.Horizontal;

        /// <summary>
        /// [Draft] Get/Set the padding between cells in the layout
        /// </summary>
        public Size2D CellPadding{ get; set; } = new Size2D(0,0);

        /// <summary>
        /// [Draft] Get/Set the alignment in the layout
        /// </summary>
        public LinearLayoutEx.Alignment LinearAlignment{ get; set; } = Alignment.CenterVertical;

        /// <summary>
        /// [Draft] Constructor
        /// </summary>
        public LinearLayoutEx()
        {
        }

        protected override void OnMeasure( MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec )
        {
            if( LinearOrientation == Orientation.Horizontal )
            {
              MeasureHorizontal( widthMeasureSpec, heightMeasureSpec );
            }
            //else
            //{
              //MeasureVertical( widthMeasureSpec, heightMeasureSpec );
            //}
        }

        protected override void OnLayout( bool changed, LayoutLengthEx left, LayoutLengthEx top, LayoutLengthEx right, LayoutLengthEx bottom )
        {
            if( LinearOrientation == Orientation.Horizontal )
            {
              //LayoutHorizontal( left, top, right, bottom );
            }
            else
            {
              //LayoutVertical( left, top, right, bottom );
            }
        }

        private void MeasureHorizontal( MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec )
        {
            var widthMode = widthMeasureSpec.Mode;
            var heightMode = heightMeasureSpec.Mode;
            bool isExactly = ( widthMode == MeasureSpecification.ModeType.Exactly );
            bool matchHeight = false;
            bool allFillParent = true;
            LayoutLengthEx maxHeight = new LayoutLengthEx(0);
            LayoutLengthEx alternativeMaxHeight = new LayoutLengthEx(0);
            LayoutLengthEx weightedMaxHeight = new LayoutLengthEx(0);
            float totalWeight = 0.0f;
            float totalLength = 0.0f;
            LayoutLengthEx usedExcessSpace = new LayoutLengthEx(0);

            HeightAndWidthState childState = new HeightAndWidthState(MeasuredSizeEx.StateType.MeasuredSizeOK, MeasuredSizeEx.StateType.MeasuredSizeTooSmall);

            // measure children, and determine if further resolution is required

            // 1st phase:
            // We cycle through all children and measure children with weight 0 (non weighted children) according to their specs
            // to accumulate total used space in totalLength based on measured sizes and margins.
            // Weighted children are not measured at this phase.
            // Available space for weighted children will be calculated in the phase 2 based on totalLength value.

          foreach( LayoutItemEx childLayout in _children )
          {
              LayoutLengthEx childDesiredHeight = new LayoutLengthEx(childLayout.Owner.MeasureSpecificationHeight.Size);
              LayoutLengthEx childDesiredWidth = new LayoutLengthEx(childLayout.Owner.MeasureSpecificationWidth.Size);
              float childWeight = childLayout.Owner.Weight;
              Extents childMargin = new Extents(); // childLayout->GetMargin();

              totalWeight += childWeight;

              bool useExcessSpace = ( ( childDesiredWidth.AsRoundedValue() == 0 ) && (childWeight > 0 ) );
              if( isExactly && useExcessSpace )
              {
                totalLength += childMargin.Start + childMargin.End;
              }
              else
              {
                  LayoutLengthEx childWidth = new LayoutLengthEx(childLayout.MeasuredWidth);
                  if( useExcessSpace )
                  {
                    // The widthMode is either UNSPECIFIED or AT_MOST, and
                    // this child is only laid out using excess space. Measure
                    // using WRAP_CONTENT so that we can find out the view's
                    // optimal width.
                    MeasureSpecification childWidthMeasureSpec = GetChildMeasureSpecification( widthMeasureSpec, new LayoutLengthEx(childLayout.Owner.Padding.Start + childLayout.Owner.Padding.End),
                                                                 new LayoutLengthEx( (int)ChildLayoutData.WrapContent) );
                    MeasureSpecification childHeightMeasureSpec = GetChildMeasureSpecification( heightMeasureSpec, new LayoutLengthEx(childLayout.Owner.Padding.Top + childLayout.Owner.Padding.Bottom),
                                                                  childDesiredHeight );
                    childLayout.Measure( childWidthMeasureSpec, childHeightMeasureSpec );
                    usedExcessSpace += childWidth;
                  }
                  else
                  {
                    MeasureChild( childLayout, widthMeasureSpec, heightMeasureSpec );
                  }

                  LayoutLengthEx length = childWidth + childMargin.Start + childMargin.End;
                  if( isExactly )
                  {
                    totalLength += length.AsDecimal();
                  }
                  else
                  {
                    totalLength = Math.Max( totalLength, totalLength + length.AsDecimal() + CellPadding.Width );
                  }
              }

              bool matchHeightLocally = false;
              if( heightMode != MeasureSpecification.ModeType.Exactly && (ChildLayoutData)childDesiredHeight.AsRoundedValue() == ChildLayoutData.WrapContent )
              {
                   // Will have to re-measure at least this child when we know exact height.
                   matchHeight = true;
                   matchHeightLocally = true;
              }

              LayoutLengthEx marginHeight = new LayoutLengthEx(childMargin.Top + childMargin.Bottom);
              LayoutLengthEx childHeight = childLayout.MeasuredHeight + marginHeight;

              // if( childLayout->GetMeasuredWidthAndState().GetState() == MeasuredSize::State::MEASURED_SIZE_TOO_SMALL )
              // {
              //   childState.widthState = MeasuredSize::State::MEASURED_SIZE_TOO_SMALL;
              // }
              // if( childLayout->GetMeasuredHeightAndState().GetState() == MeasuredSize::State::MEASURED_SIZE_TOO_SMALL )
              // {
              //   childState.heightState = MeasuredSize::State::MEASURED_SIZE_TOO_SMALL;
              // }

              // maxHeight = std::max( maxHeight, childHeight );
              // allFillParent = ( allFillParent && desiredHeight == Toolkit::ChildLayoutData::MATCH_PARENT );
              // if( childWeight > 0 )
              // {
              //   /*
              //   * Heights of weighted Views are bogus if we end up
              //   * remeasuring, so keep them separate.
              //   */
              //   weightedMaxHeight = std::max( weightedMaxHeight, matchHeightLocally ? marginHeight : childHeight );
              // }
              // else
              // {
              //   alternativeMaxHeight = std::max( alternativeMaxHeight, matchHeightLocally ? marginHeight : childHeight );
              // }
          } // foreach

          Extents padding = new Extents();
          totalLength += padding.Start + padding.End;
          LayoutLengthEx widthSize = new LayoutLengthEx(totalLength);
          widthSize = new LayoutLengthEx( Math.Max( widthSize.AsDecimal(), SuggestedMinimumWidth.AsDecimal() ) );
          MeasuredSizeEx widthSizeAndState = ResolveSizeAndState( widthSize, widthMeasureSpec, MeasuredSizeEx.StateType.MeasuredSizeOK );
          widthSize = widthSizeAndState.Size;

          if( !allFillParent && heightMode != MeasureSpecification.ModeType.Exactly)
          {
              maxHeight = alternativeMaxHeight;
          }
          maxHeight += padding.Top + padding.Bottom;
          maxHeight = new LayoutLengthEx( Math.Max( maxHeight.AsRoundedValue(), SuggestedMinimumHeight.AsRoundedValue() ) );

          widthSizeAndState.State = childState.widthState;

          SetMeasuredDimensions( widthSizeAndState,
                                 ResolveSizeAndState( maxHeight, heightMeasureSpec, childState.heightState ) );

          // if( matchHeight )
          // {
          //   ForceUniformHeight( GetChildCount(), widthMeasureSpec );
          // }
        } // MeasureHorizontally

    } //LinearLayoutEx

} // namespace
