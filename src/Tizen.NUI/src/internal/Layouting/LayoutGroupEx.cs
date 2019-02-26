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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] LayoutGroup class providing container functionality.
    /// </summary>
    internal class LayoutGroupEx : LayoutItemEx
    {
        protected List<LayoutItemEx> _children{ get;} // Children of this LayoutGroup

        public LayoutGroupEx()
        {
            _children = new List<LayoutItemEx>();
        }


        /// <summary>
        /// Add a layout child to this group.<br />
        /// </summary>
        public void Add(LayoutItemEx childLayout)
        {
            _children.Add(childLayout);
        }

        /// <summary>
        /// Remove all layout children.<br />
        /// </summary>
        public void RemoveAll()
        {
            foreach( LayoutItemEx childLayout in _children )
            {
                childLayout.Owner = null;
            }
            _children.Clear();
            // todo ensure child LayoutItems are still not parented to this group.
        }

        /// <summary>
        /// Calculate the right measure spec for this child.
        /// Does the hard part of MeasureChildren: figuring out the MeasureSpec to
        /// pass to a particular child. This method figures out the right MeasureSpec
        /// for one dimension (height or width) of one child view.<br />
        /// </summary>
        /// <param name="measureSpec">The requirements for this view. MeasureSpecification.</param>
        /// <param name="padding">The padding of this view for the current dimension and margins, if applicable. LayoutLength.</param>
        /// <param name="childDimension"> How big the child wants to be in the current dimension. LayoutLength.</param>
        /// <returns>a MeasureSpec for the child.</returns>
        public static MeasureSpecification GetChildMeasureSpecification(MeasureSpecification measureSpec, LayoutLengthEx padding, LayoutLengthEx childDimension)
        {
            MeasureSpecification.ModeType specMode = measureSpec.Mode;
            MeasureSpecification.ModeType resultMode = MeasureSpecification.ModeType.Unspecified;
            LayoutLengthEx resultSize = new LayoutLengthEx(Math.Max( 0.0f, (measureSpec.Size.AsDecimal() - padding.AsDecimal() ) )); // reduce available size by the owners padding

            switch( specMode )
            {
                // Parent has imposed an exact size on us
                case MeasureSpecification.ModeType.Exactly:
                {
                if ((int)childDimension.AsRoundedValue() == (int)ChildLayoutData.MatchParent)
                {
                    // Child wants to be our size. So be it.
                    resultMode = MeasureSpecification.ModeType.Exactly;
                }
                else if ((int)childDimension.AsRoundedValue() == (int)ChildLayoutData.WrapContent)
                {
                    // Child wants to determine its own size. It can't be
                    // bigger than us.
                    resultMode = MeasureSpecification.ModeType.AtMost;
                }
                else
                {
                    resultSize = childDimension;
                    resultMode = MeasureSpecification.ModeType.Exactly;
                }

                break;
                }

                // Parent has imposed a maximum size on us
                case MeasureSpecification.ModeType.AtMost:
                {
                if (childDimension.AsRoundedValue() == (int)ChildLayoutData.MatchParent)
                {
                    // Child wants to be our size, but our size is not fixed.
                    // Constrain child to not be bigger than us.
                    resultMode = MeasureSpecification.ModeType.AtMost;
                }
                else if (childDimension.AsRoundedValue() == (int)ChildLayoutData.WrapContent)
                {
                    // Child wants to determine its own size. It can't be
                    // bigger than us.
                    resultMode = MeasureSpecification.ModeType.AtMost;
                }
                else
                {
                    // Child wants a specific size... so be it
                    resultSize = childDimension + padding;
                    resultMode = MeasureSpecification.ModeType.Exactly;
                }

                break;
                }

                // Parent asked to see how big we want to be
                case MeasureSpecification.ModeType.Unspecified:
                {

                if ((childDimension.AsRoundedValue() == (int)ChildLayoutData.MatchParent))
                {
                    // Child wants to be our size... find out how big it should be
                    resultMode = MeasureSpecification.ModeType.Unspecified;
                }
                else if (childDimension.AsRoundedValue() == ((int)ChildLayoutData.WrapContent))
                {
                    // Child wants to determine its own size.... find out how big
                    // it should be
                    resultMode = MeasureSpecification.ModeType.Unspecified;
                }
                else
                {
                    // Child wants a specific size... let him have it
                    resultSize = childDimension + padding;
                    resultMode = MeasureSpecification.ModeType.Exactly;
                }
                break;
                }
            } // switch

            return new MeasureSpecification( resultSize, resultMode );
        }

        /// <summary>
        /// Measure the layout and its content to determine the measured width and the measured height.<br />
        /// If this method is overridden, it is the subclass's responsibility to make
        /// sure the measured height and width are at least the layout's minimum height
        /// and width. <br />
        /// </summary>
        /// <param name="widthMeasureSpec">horizontal space requirements as imposed by the parent.</param>
        /// <param name="heightMeasureSpec">vertical space requirements as imposed by the parent.</param>
        protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            Log.Info("NUI", "OnMeasure\n");
            LayoutLengthEx childWidth  = new LayoutLengthEx( 0 );
            LayoutLengthEx childHeight =  new LayoutLengthEx( 0 );

            LayoutLengthEx measuredWidth = childWidth;
            LayoutLengthEx measuredHeight = childHeight;

            foreach( LayoutItemEx childLayout in _children )
            {
                if( childLayout != null )
                {
                    MeasureChild( childLayout, widthMeasureSpec, heightMeasureSpec );
                    childWidth = childLayout.MeasuredWidth;
                    childHeight = childLayout.MeasuredHeight;
                    // Layout takes size of largest width and height dimension of children
                    measuredWidth = new LayoutLengthEx(Math.Max( measuredWidth.AsDecimal(), childWidth.AsDecimal() ));
                    measuredHeight = new LayoutLengthEx(Math.Max( measuredHeight.AsDecimal(), childHeight.AsDecimal() ));
                }
            }

            if( 0 == _children.Count )
            {
                // Must be a leaf as has no children
                measuredWidth = GetDefaultSize( SuggestedMinimumWidth, widthMeasureSpec );
                measuredHeight = GetDefaultSize( SuggestedMinimumHeight, heightMeasureSpec );
            }

            SetMeasuredDimensions( new MeasuredSizeEx( measuredWidth, MeasuredSizeEx.StateType.MeasuredSizeOK ),
                                   new MeasuredSizeEx( measuredHeight, MeasuredSizeEx.StateType.MeasuredSizeOK ) );
        }

        /// <summary>
        /// Called from Layout() when this layout should assign a size and position to each of its children.<br />
        /// Derived classes with children should override this method and call Layout() on each of their children.<br />
        /// </summary>
        /// <param name="changed">This is a new size or position for this layout.</param>
        /// <param name="left">Left position, relative to parent.</param>
        /// <param name="top"> Top position, relative to parent.</param>
        /// <param name="right">Right position, relative to parent.</param>
        /// <param name="bottom">Bottom position, relative to parent.</param>
        protected override void OnLayout(bool changed, LayoutLengthEx left, LayoutLengthEx top, LayoutLengthEx right, LayoutLengthEx bottom)
        {
            Log.Info("NUI", "OnLayout\n");
            foreach( LayoutItemEx childLayout in _children )
            {
                if( childLayout !=null )
                {
                    // Use position if explicitly set to child otherwise will be top left.
                    var childLeft = new LayoutLengthEx( childLayout.Owner.Position2D.X );
                    var childTop = new LayoutLengthEx( childLayout.Owner.Position2D.Y );

                    View owner = Owner;

                    if ( owner )
                    {
                        // Margin and Padding only supported when child anchor point is TOP_LEFT.
                        if ( owner.PivotPoint == PivotPoint.TopLeft || ( owner.PositionUsesPivotPoint == false ) )
                        {
                          childLeft = childLeft + owner.Padding.Start + childLayout.Owner.Margin.Start;
                          childTop = childTop + owner.Padding.Top + childLayout.Owner.Margin.Top;
                        }
                    }
                    childLayout.Layout( childLeft, childTop, childLeft + childLayout.MeasuredWidth, childTop + childLayout.MeasuredHeight );
                }
            }
        }

        /// <summary>
        /// Virtual method to inform derived classes when the layout size changed.<br />
        /// </summary>
        /// <param name="newSize">The new size of the layout.</param>
        /// <param name="oldSize">The old size of the layout.</param>
        protected override void OnSizeChanged(LayoutSizeEx newSize, LayoutSizeEx oldSize)
        {
            //Do nothing
        }

        /// <summary>
        /// Callback when child is added to container.<br />
        /// Derived classes can use this to set their own child properties on the child layout's owner.<br />
        /// </summary>
        /// <param name="child">The Layout child.</param>
        internal virtual void OnChildAdd(LayoutItemEx child)
        {
        }

        /// <summary>
        /// Callback when child is removed from container.<br />
        /// </summary>
        /// <param name="child">The Layout child.</param>
        internal virtual void OnChildRemove(LayoutItemEx child)
        {
        }

        /// <summary>
        /// Ask all of the children of this view to measure themselves, taking into
        /// account both the MeasureSpec requirements for this view and its padding.<br />
        /// The heavy lifting is done in GetChildMeasureSpec.<br />
        /// </summary>
        /// <param name="widthMeasureSpec">The width requirements for this view.</param>
        /// <param name="heightMeasureSpec">The height requirements for this view.</param>
        protected virtual void MeasureChildren(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            foreach( LayoutItemEx childLayout in _children )
            {
                MeasureChild( childLayout, widthMeasureSpec, heightMeasureSpec );
            }
        }

        /// <summary>
        /// Ask one of the children of this view to measure itself, taking into
        /// account both the MeasureSpec requirements for this view and its padding.<br />
        /// The heavy lifting is done in GetChildMeasureSpec.<br />
        /// </summary>
        /// <param name="child">The child to measure.</param>
        /// <param name="parentWidthMeasureSpec">The width requirements for this view.</param>
        /// <param name="parentHeightMeasureSpec">The height requirements for this view.</param>
        protected virtual void MeasureChild(LayoutItemEx child, MeasureSpecification parentWidthMeasureSpec, MeasureSpecification parentHeightMeasureSpec)
        {
            View childOwner = child.Owner;

            // Get last stored width and height specifications for the child
            int desiredWidth = childOwner.WidthSpecification;
            int desiredHeight = childOwner.HeightSpecification;

            Extents padding = childOwner.Padding; // Padding of this layout's owner, not of the child being measured.

            MeasureSpecification childWidthMeasureSpec = GetChildMeasureSpecification( parentWidthMeasureSpec,
                                                                                       new LayoutLengthEx(padding.Start + padding.End ),
                                                                                       new LayoutLengthEx(desiredWidth) );
            MeasureSpecification childHeightMeasureSpec = GetChildMeasureSpecification( parentHeightMeasureSpec,
                                                                                       new LayoutLengthEx(padding.Top + padding.Bottom),
                                                                                       new LayoutLengthEx(desiredHeight) );

            child.Measure( childWidthMeasureSpec, childHeightMeasureSpec );
        }

        /// <summary>
        /// Ask one of the children of this view to measure itself, taking into
        /// account both the MeasureSpec requirements for this view and its padding.<br />
        /// and margins. The child must have MarginLayoutParams The heavy lifting is
        /// done in GetChildMeasureSpecification.<br />
        /// </summary>
        /// <param name="child">The child to measure.</param>
        /// <param name="parentWidthMeasureSpec">The width requirements for this view.</param>
        /// <param name="widthUsed">Extra space that has been used up by the parent horizontally (possibly by other children of the parent).</param>
        /// <param name="parentHeightMeasureSpec">The height requirements for this view.</param>
        /// <param name="heightUsed">Extra space that has been used up by the parent vertically (possibly by other children of the parent).</param>
        protected virtual void MeasureChildWithMargins(LayoutItemEx child, MeasureSpecification parentWidthMeasureSpec, LayoutLengthEx widthUsed, MeasureSpecification parentHeightMeasureSpec, LayoutLengthEx heightUsed)
        {
            View childOwner = child.Owner;
            int desiredWidth = childOwner.WidthSpecification;
            int desiredHeight = childOwner.HeightSpecification;

            Extents padding = childOwner.Padding; // Padding of this layout's owner, not of the child being measured.

            MeasureSpecification childWidthMeasureSpec = GetChildMeasureSpecification( parentWidthMeasureSpec,
                                                                                       new LayoutLengthEx( padding.Start + padding.End ) +
                                                                                       widthUsed, new LayoutLengthEx(desiredWidth) );


            MeasureSpecification childHeightMeasureSpec = GetChildMeasureSpecification( parentHeightMeasureSpec,
                                                                                        new LayoutLengthEx( padding.Top + padding.Bottom )+
                                                                                        heightUsed, new LayoutLengthEx(desiredHeight) );

            child.Measure( childWidthMeasureSpec, childHeightMeasureSpec );
        }
    }
}
