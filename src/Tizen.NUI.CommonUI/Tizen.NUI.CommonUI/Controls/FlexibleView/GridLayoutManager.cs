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

using System.ComponentModel;

namespace Tizen.NUI.CommonUI
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class GridLayoutManager : LinearLayoutManager
    {
        private static readonly int DEFAULT_SPAN_COUNT = -1;

        private int mSpanCount = DEFAULT_SPAN_COUNT;
        /**
         * @param spanCount The number of columns or rows in the grid
         * @param orientation Layout orientation. Should be {@link #HORIZONTAL} or {@link
         *                      #VERTICAL}.
         */
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GridLayoutManager(int spanCount, int orientation) : base(orientation)
        {
            mSpanCount = spanCount;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void LayoutChunk(FlexibleView.Recycler recycler, FlexibleView.ViewState state,
            LayoutState layoutState, LayoutChunkResult result)
        {
            bool layingOutInPrimaryDirection =
                layoutState.mItemDirection == LayoutState.ITEM_DIRECTION_TAIL;

            int count = mSpanCount;
            for (int i = 0; i < count; i++)
            {
                FlexibleView.ViewHolder holder = layoutState.Next(recycler);
                if (holder == null)
                {
                    result.mFinished = true;
                    return;
                }

                if (layingOutInPrimaryDirection)
                    AddView(holder);
                else
                    AddView(holder, 0);

                result.mConsumed = mOrientationHelper.GetViewHolderMeasurement(holder);

                float left, top, width, height;
                if (mOrientation == VERTICAL)
                {
                    width = (GetWidth() - GetPaddingLeft() - GetPaddingRight()) / count;
                    height = result.mConsumed;
                    if (layoutState.mLayoutDirection == LayoutState.LAYOUT_END)
                    {
                        left = GetPaddingLeft() + width * i;
                        top = layoutState.mOffset;
                    }
                    else
                    {
                        left = GetPaddingLeft() + width * (count - 1 - i);
                        top = layoutState.mOffset - height;
                    }
                    LayoutChild(holder, left, top, width, height);
                }
                else
                {
                    width = result.mConsumed;
                    height = (GetHeight() - GetPaddingTop() - GetPaddingBottom()) / count;
                    if (layoutState.mLayoutDirection == LayoutState.LAYOUT_END)
                    {
                        top = GetPaddingTop() + height * i;
                        left = layoutState.mOffset;
                    }
                    else
                    {
                        top = GetPaddingTop() + height * (count - 1 - i);
                        left = layoutState.mOffset - width;
                    }
                    LayoutChild(holder, left, top, width, height);
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override int GetNextPosition(int position, string direction, FlexibleView.ViewState state)
        {
            if (mOrientation == HORIZONTAL)
            {
                switch (direction)
                {
                    case "Left":
                        if (position >= mSpanCount)
                        {
                            return position - mSpanCount;
                        }
                        break;
                    case "Right":
                        if (position < state.ItemCount - mSpanCount)
                        {
                            return position + mSpanCount;
                        }
                        break;
                    case "Up":
                        if (position % mSpanCount > 0)
                        {
                            return position - 1;
                        }
                        break;
                    case "Down":
                        if (position < state.ItemCount - 1 && (position % mSpanCount < mSpanCount - 1))
                        {
                            return position + 1;
                        }
                        break;
                }
            }
            else
            {
                switch (direction)
                {
                    case "Left":
                        if (position % mSpanCount > 0)
                        {
                            return position - 1;
                        }
                        break;
                    case "Right":
                        if (position < state.ItemCount - 1 && (position % mSpanCount < mSpanCount - 1))
                        {
                            return position + 1;
                        }
                        break;
                    case "Up":
                        if (position >= mSpanCount)
                        {
                            return position - mSpanCount;
                        }
                        break;
                    case "Down":
                        if (position < state.ItemCount - mSpanCount)
                        {
                            return position + mSpanCount;
                        }
                        break;
                }
            }

            return NO_POSITION;
        }



        private void AssignSpans(FlexibleView.Recycler recycler, FlexibleView.ViewState state, int count,
            int consumedSpanCount, bool layingOutInPrimaryDirection)
        {
            // spans are always assigned from 0 to N no matter if it is RTL or not.
            // RTL is used only when positioning the view.
            int span, start, end, diff;
            // make sure we traverse from min position to max position
            if (layingOutInPrimaryDirection)
            {
                start = 0;
                end = count;
                diff = 1;
            }
            else
            {
                start = count - 1;
                end = -1;
                diff = -1;
            }
            span = 0;
            for (int i = start; i != end; i += diff)
            {
            }
        }

    }
}
