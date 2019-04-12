/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;

namespace Tizen.NUI.CommonUI
{
    /**
    * Helper class for LayoutManagers to abstract measurements depending on the View's orientation.
    * <p>
    * It is developed to easily support vertical and horizontal orientations in a LayoutManager but
    * can also be used to abstract calls around view bounds and child measurements with margins and
    * decorations.
    *
    * @see #createHorizontalHelper(RecyclerView.LayoutManager)
    * @see #createVerticalHelper(RecyclerView.LayoutManager)
    */
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class OrientationHelper
    {
        public static readonly int HORIZONTAL = 0;
        public static readonly int VERTICAL = 1;

        private static readonly int INVALID_SIZE = -1;

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected FlexibleView.LayoutManager mLayoutManager;

        private float mLastTotalSpace = INVALID_SIZE;

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OrientationHelper(FlexibleView.LayoutManager layoutManager)
        {
            mLayoutManager = layoutManager;
        }

        /**
         * Call this method after onLayout method is complete if state is NOT pre-layout.
         * This method records information like layout bounds that might be useful in the next layout
         * calculations.
         */
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void OnLayoutComplete()
        {
            mLastTotalSpace = GetTotalSpace();
        }

        /**
         * Returns the layout space change between the previous layout pass and current layout pass.
         * <p>
         * Make sure you call {@link #onLayoutComplete()} at the end of your LayoutManager's
         * {@link RecyclerView.LayoutManager#onLayoutChildren(RecyclerView.Recycler,
         * RecyclerView.State)} method.
         *
         * @return The difference between the current total space and previous layout's total space.
         * @see #onLayoutComplete()
         */
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetTotalSpaceChange()
        {
            return INVALID_SIZE == mLastTotalSpace ? 0 : GetTotalSpace() - mLastTotalSpace;
        }

        /**
         * Returns the start of the view including its decoration and margin.
         * <p>
         * For example, for the horizontal helper, if a View's left is at pixel 20, has 2px left
         * decoration and 3px left margin, returned value will be 15px.
         *
         * @param view The view element to check
         * @return The first pixel of the element
         * @see #getDecoratedEnd(android.view.View)
         */
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract float GetViewHolderStart(FlexibleView.ViewHolder holder);

        /**
         * Returns the end of the view including its decoration and margin.
         * <p>
         * For example, for the horizontal helper, if a View's right is at pixel 200, has 2px right
         * decoration and 3px right margin, returned value will be 205.
         *
         * @param view The view element to check
         * @return The last pixel of the element
         * @see #getDecoratedStart(android.view.View)
         */
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract float GetViewHolderEnd(FlexibleView.ViewHolder holder);

        /**
         * Returns the space occupied by this View in the current orientation including decorations and
         * margins.
         *
         * @param view The view element to check
         * @return Total space occupied by this view
         * @see #getDecoratedMeasurementInOther(View)
         */
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract float GetViewHolderMeasurement(FlexibleView.ViewHolder holder);

        /**
         * Returns the space occupied by this View in the perpendicular orientation including
         * decorations and margins.
         *
         * @param view The view element to check
         * @return Total space occupied by this view in the perpendicular orientation to current one
         * @see #getDecoratedMeasurement(View)
         */
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract float GetViewHolderMeasurementInOther(FlexibleView.ViewHolder holder);

        /**
         * Returns the start position of the layout after the start padding is added.
         *
         * @return The very first pixel we can draw.
         */
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract float GetStartAfterPadding();

        /**
         * Returns the end position of the layout after the end padding is removed.
         *
         * @return The end boundary for this layout.
         */
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract float GetEndAfterPadding();

        /**
         * Returns the end position of the layout without taking padding into account.
         *
         * @return The end boundary for this layout without considering padding.
         */
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract float GetEnd();

        /**
         * Offsets all children's positions by the given amount.
         *
         * @param amount Value to add to each child's layout parameters
         */
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract void OffsetChildren(float amount, bool immediate);

        /**
         * Returns the total space to layout. This number is the difference between
         * {@link #getEndAfterPadding()} and {@link #getStartAfterPadding()}.
         *
         * @return Total space to layout children
         */
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract float GetTotalSpace();

        /**
         * Offsets the child in this orientation.
         *
         * @param view   View to offset
         * @param offset offset amount
         */
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract void OffsetChild(FlexibleView.ViewHolder holder, int offset);

        /**
         * Returns the padding at the end of the layout. For horizontal helper, this is the right
         * padding and for vertical helper, this is the bottom padding. This method does not check
         * whether the layout is RTL or not.
         *
         * @return The padding at the end of the layout.
         */
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract float GetEndPadding();

        /**
         * Creates an OrientationHelper for the given LayoutManager and orientation.
         *
         * @param layoutManager LayoutManager to attach to
         * @param orientation   Desired orientation. Should be {@link #HORIZONTAL} or {@link #VERTICAL}
         * @return A new OrientationHelper
         */
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OrientationHelper createOrientationHelper(
                FlexibleView.LayoutManager layoutManager, int orientation)
        {
            if (orientation == HORIZONTAL)
            {
                return CreateHorizontalHelper(layoutManager);
            }
            else if (orientation == VERTICAL)
            {
                return CreateVerticalHelper(layoutManager);
            }

            throw new ArgumentException("invalid orientation");
        }


        /**
         * Creates a horizontal OrientationHelper for the given LayoutManager.
         *
         * @param layoutManager The LayoutManager to attach to.
         * @return A new OrientationHelper
         */
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OrientationHelper CreateHorizontalHelper(FlexibleView.LayoutManager layoutManager)
        {
            return new HorizontalHelper(layoutManager);

        }
        /**
        * Creates a vertical OrientationHelper for the given LayoutManager.
        *
        * @param layoutManager The LayoutManager to attach to.
        * @return A new OrientationHelper
        */
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OrientationHelper CreateVerticalHelper(FlexibleView.LayoutManager layoutManager)
        {
            return new VerticalHelper(layoutManager);
        }
    }

    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class HorizontalHelper : OrientationHelper
    {
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HorizontalHelper(FlexibleView.LayoutManager layoutManager) : base(layoutManager)
        {

        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float GetEndAfterPadding()
        {
            return mLayoutManager.GetWidth() - mLayoutManager.GetPaddingRight();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float GetEnd()
        {
            return mLayoutManager.GetWidth();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OffsetChildren(float amount, bool immediate)
        {
            mLayoutManager.OffsetChildrenHorizontal(amount, immediate);
        }


        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float GetStartAfterPadding()
        {
            return mLayoutManager.GetPaddingLeft();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float GetViewHolderMeasurement(FlexibleView.ViewHolder holder)
        {
            return holder.Right - holder.Left;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float GetViewHolderMeasurementInOther(FlexibleView.ViewHolder holder)
        {
            return holder.Bottom - holder.Top;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float GetViewHolderEnd(FlexibleView.ViewHolder holder)
        {
            return holder.Right;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float GetViewHolderStart(FlexibleView.ViewHolder holder)
        {
            return holder.Left;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float GetTotalSpace()
        {
            return mLayoutManager.GetWidth() - mLayoutManager.GetPaddingLeft()
                    - mLayoutManager.GetPaddingRight();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OffsetChild(FlexibleView.ViewHolder holder, int offset)
        {
            //holder.offsetLeftAndRight(offset);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float GetEndPadding()
        {
            return mLayoutManager.GetPaddingRight();
        }

    }

    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class VerticalHelper : OrientationHelper
    {
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VerticalHelper(FlexibleView.LayoutManager layoutManager) : base(layoutManager)
        {

        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float GetEndAfterPadding()
        {
            return mLayoutManager.GetHeight() - mLayoutManager.GetPaddingBottom();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float GetEnd()
        {
            return mLayoutManager.GetHeight();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OffsetChildren(float amount, bool immediate)
        {
            mLayoutManager.OffsetChildrenVertical(amount, immediate);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float GetStartAfterPadding()
        {
            return mLayoutManager.GetPaddingTop();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float GetViewHolderMeasurement(FlexibleView.ViewHolder holder)
        {
            return holder.Bottom - holder.Top;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float GetViewHolderMeasurementInOther(FlexibleView.ViewHolder holder)
        {
            return holder.Right - holder.Left;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float GetViewHolderEnd(FlexibleView.ViewHolder holder)
        {
            return holder.Bottom;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float GetViewHolderStart(FlexibleView.ViewHolder holder)
        {
            return holder.Top;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float GetTotalSpace()
        {
            return mLayoutManager.GetHeight() - mLayoutManager.GetPaddingTop()
                    - mLayoutManager.GetPaddingBottom();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OffsetChild(FlexibleView.ViewHolder holder, int offset)
        {
            //holder.offsetTopAndBottom(offset);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float GetEndPadding()
        {
            return mLayoutManager.GetPaddingBottom();
        }

    }

}
