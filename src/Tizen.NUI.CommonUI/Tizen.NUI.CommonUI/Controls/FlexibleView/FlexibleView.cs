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
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.CommonUI
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class FlexibleView : Control
    {
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int NO_POSITION = -1;
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int INVALID_TYPE = -1;

        private Adapter mAdapter;
        private LayoutManager mLayout;
        private Recycler mRecycler;
        private RecycledViewPool mRecyclerPool;
        private ChildHelper mChildHelper;

        private ViewState mState;

        private PanGestureDetector mPanGestureDetector;

        private int mFocusedItemIndex = NO_POSITION;

        private AdapterHelper mAdapteHelper;

        private Extents mPadding = new Extents(0, 0, 0, 0);

        private ScrollBar mScrollBar = null;
        private Timer mScrollBarShowTimer = null;

        private ClickEventHandler<ItemClickEventArgs> clickEventHandlers;
        private EventHandler<ItemTouchEventArgs> touchEventHandlers;

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FlexibleView()
        {
            mRecyclerPool = new RecycledViewPool(this);

            mRecycler = new Recycler(this);
            mRecycler.SetRecycledViewPool(mRecyclerPool);

            mChildHelper = new ChildHelper(this);

            mState = new ViewState(this);

            mPanGestureDetector = new PanGestureDetector();
            mPanGestureDetector.Attach(this);
            mPanGestureDetector.Detected += OnPanGestureDetected;

            mAdapteHelper = new AdapterHelper(this);

            ClippingMode = ClippingModeType.ClipToBoundingBox;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void ClickEventHandler<ClickEventArgs>(object sender, ClickEventArgs e);
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void EventHandler<TouchEventArgs>(object sender, TouchEventArgs e);


        /// <summary>
        /// Item click event.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event ClickEventHandler<ItemClickEventArgs> ItemClickEvent
        {
            add
            {
                clickEventHandlers += value;
            }

            remove
            {
                clickEventHandlers -= value;
            }
        }


        /// <summary>
        /// Item touch event.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ItemTouchEventArgs> ItemTouchEvent
        {
            add
            {
                touchEventHandlers += value;
            }

            remove
            {
                touchEventHandlers -= value;
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Extents Padding
        {
            get
            {
                return mPadding;
            }
            set
            {
                mPadding = value;
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int FocusedItemIndex
        {
            get
            {
                return mFocusedItemIndex;
            }
            set
            {
                if (value == mFocusedItemIndex)
                {
                    return;
                }

                if (mAdapter == null)
                {
                    return;
                }

                if (mLayout == null)
                {
                    return;
                }

                ViewHolder nextFocusView = FindViewHolderForAdapterPosition(value);
                if (nextFocusView == null)
                {
                    mLayout.ScrollToPosition(value);
                }
                else
                {
                    mLayout.RequestChildRectangleOnScreen(this, nextFocusView, mRecycler, mState, true);
                    DispatchFocusChanged(value);
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAdapter(Adapter adapter)
        {
            if (adapter == null)
            {
                return;
            }
            mAdapter = adapter;

            mAdapter.ItemEvent += OnItemEvent;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Adapter GetAdapter()
        {
            return mAdapter;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetLayoutManager(LayoutManager layoutManager)
        {
            mLayout = layoutManager;

            mLayout.SetRecyclerView(this);

            if (mLayout.CanScrollHorizontally())
            {
                mPanGestureDetector.AddDirection(PanGestureDetector.DirectionHorizontal);
            }
            else if (mLayout.CanScrollVertically())
            {
                mPanGestureDetector.AddDirection(PanGestureDetector.DirectionVertical);
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LayoutManager GetLayoutManager()
        {
            return mLayout;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollToPositionWithOffset(int position, int offset)
        {
            mLayout.ScrollToPositionWithOffset(position, offset);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void MoveFocus(string direction)
        {
            mLayout.MoveFocus(direction, mRecycler, mState);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AttachScrollBar(ScrollBar scrollBar)
        {
            if (scrollBar == null)
            {
                return;
            }
            mScrollBar = scrollBar;
            Add(mScrollBar);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DetachScrollBar()
        {
            if (mScrollBar == null)
            {
                return;
            }
            Remove(mScrollBar);
            mScrollBar = null;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewHolder FindViewHolderForLayoutPosition(int position)
        {
            int childCount = mChildHelper.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                if (mChildHelper.GetChildAt(i) is ViewHolder holder)
                {
                    if (holder.LayoutPosition == position)
                    {
                        return holder;
                    }
                }
            }

            return null;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewHolder FindViewHolderForAdapterPosition(int position)
        {
            int childCount = mChildHelper.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                if (mChildHelper.GetChildAt(i) is ViewHolder holder)
                {
                    if (holder.AdapterPosition == position)
                    {
                        return holder;
                    }
                }
            }

            return null;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (mAdapter != null)
                {
                    mAdapter.ItemEvent -= OnItemEvent;
                }

                if (mPanGestureDetector != null)
                {
                    mPanGestureDetector.Detected -= OnPanGestureDetected;
                    mPanGestureDetector.Dispose();
                    mPanGestureDetector = null;
                }

                if (mScrollBarShowTimer != null)
                {
                    mScrollBarShowTimer.Tick -= OnShowTimerTick;
                    mScrollBarShowTimer.Stop();
                    mScrollBarShowTimer.Dispose();
                    mScrollBarShowTimer = null;
                }

                if (mRecyclerPool != null)
                {
                    mRecyclerPool.Clear();
                    mRecyclerPool = null;
                }

                if (mChildHelper != null)
                {
                    mChildHelper.Clear();
                    mChildHelper = null;
                }
            }
            base.Dispose(type);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return null;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnRelayout(object sender, EventArgs e)
        {
            if (mAdapter == null)
            {
                return;
            }

            if (mLayout == null)
            {
                return;
            }

            DispatchLayoutStep1();

            mLayout.OnLayoutChildren(mRecycler, mState);

            RemoveAndRecycleScrapInt();
        }

        private void DispatchLayoutStep1()
        {
            ProcessAdapterUpdates();
            SaveOldPositions();
            ClearOldPositions();
        }

        private void ProcessAdapterUpdates()
        {
            mAdapteHelper.PreProcess();
        }

        private void OffsetPositionRecordsForInsert(int positionStart, int itemCount)
        {
            int childCount = mChildHelper.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                ViewHolder holder = mChildHelper.GetChildAt(i);
                if (holder != null && holder.AdapterPosition >= positionStart)
                {
                    holder.OffsetPosition(itemCount, false);
                }
            }

            if (positionStart <= mFocusedItemIndex)
            {
                mFocusedItemIndex += itemCount;
            }
        }

        private void OffsetPositionRecordsForRemove(int positionStart, int itemCount, bool applyToPreLayout)
        {
            int positionEnd = positionStart + itemCount;
            int childCount = mChildHelper.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                ViewHolder holder = mChildHelper.GetChildAt(i);
                if (holder != null)
                {
                    if (holder.AdapterPosition >= positionEnd)
                    {
                        holder.OffsetPosition(-itemCount, applyToPreLayout);
                    }
                    else if (holder.AdapterPosition >= positionStart)
                    {
                        holder.FlagRemovedAndOffsetPosition(positionStart - 1, -itemCount, applyToPreLayout);
                    }
                }
            }

            if (positionEnd <= mFocusedItemIndex)
            {
                mFocusedItemIndex -= itemCount;
            }
            else if (positionStart <= mFocusedItemIndex)
            {
                mFocusedItemIndex = positionStart;
                if (mFocusedItemIndex >= mAdapter.GetItemCount())
                {
                    mFocusedItemIndex = mAdapter.GetItemCount() - 1;
                }
            }
        }

        private void SaveOldPositions()
        {
            int childCount = mChildHelper.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                ViewHolder holder = mChildHelper.GetChildAt(i);
                holder.SaveOldPosition();
            }
        }

        private void ClearOldPositions()
        {
            int childCount = mChildHelper.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                ViewHolder holder = mChildHelper.GetChildAt(i);
                holder.ClearOldPosition();
            }
        }

        private void RemoveAndRecycleScrapInt()
        {
            int scrapCount = mRecycler.GetScrapCount();
            for (int i = 0; i < scrapCount; i++)
            {
                ViewHolder scrap = mRecycler.GetScrapViewAt(i);
                mChildHelper.RemoveView(scrap);
                mRecycler.RecycleView(scrap);
            }
            mRecycler.ClearScrap();
        }

        private void ShowScrollBar(uint millisecond = 700, bool flagAni = false)
        {
            if (mScrollBar == null || mLayout == null)
            {
                return;
            }

            float extent = mLayout.ComputeScrollExtent(mState);
            float range = mLayout.ComputeScrollRange(mState);
            float offset = mLayout.ComputeScrollOffset(mState);

            float size = mScrollBar.Direction == ScrollBar.DirectionType.Vertical ? mScrollBar.SizeHeight : mScrollBar.SizeWidth;
            float thickness = mScrollBar.Direction == ScrollBar.DirectionType.Vertical ? mScrollBar.SizeWidth : mScrollBar.SizeHeight;
            float length = (float)Math.Round(size * extent / range);

            // avoid the tiny thumb
            float minLength = thickness * 2;
            if (length < minLength)
            {
                length = minLength;
            }
            // avoid the too-big thumb
            if (offset > range - extent)
            {
                offset = range - extent;
            }
            if (mScrollBar.Direction == ScrollBar.DirectionType.Vertical)
            {
                mScrollBar.ThumbSize = new Size2D((int)thickness, (int)length);
            }
            else
            {
                mScrollBar.ThumbSize = new Size2D((int)length, (int)thickness);
            }
            mScrollBar.MinValue = 0;
            mScrollBar.MaxValue = (uint)(range - extent);
            mScrollBar.SetCurrentValue((uint)offset, flagAni);
            mScrollBar.Show();
            if (mScrollBarShowTimer == null)
            {
                mScrollBarShowTimer = new Timer(millisecond);
                mScrollBarShowTimer.Tick += OnShowTimerTick;
            }
            else
            {
                mScrollBarShowTimer.Interval = millisecond;
            }
            mScrollBarShowTimer.Start();
        }

        private bool OnShowTimerTick(object source, EventArgs e)
        {
            if (mScrollBar != null)
            {
                mScrollBar.Hide();
            }

            return false;
        }

        private void DispatchFocusChanged(int nextFocusPosition)
        {
            mAdapter.OnFocusChange(this, mFocusedItemIndex, nextFocusPosition);

            mFocusedItemIndex = nextFocusPosition;

            ShowScrollBar();
        }

        private void DispatchChildAttached(ViewHolder holder)
        {
            if (mAdapter != null && holder != null)
            {
                mAdapter.OnViewAttachedToWindow(holder);
            }
        }

        private void DispatchChildDetached(ViewHolder holder)
        {
            if (mAdapter != null && holder != null)
            {
                mAdapter.OnViewDetachedFromWindow(holder);
            }
        }

        private void DispatchChildDestroyed(ViewHolder holder)
        {
            if (mAdapter != null && holder != null)
            {
                mAdapter.OnDestroyViewHolder(holder);
            }
        }

        private void DispatchItemClicked(ViewHolder clickedHolder)
        {
            ItemClickEventArgs args = new ItemClickEventArgs();
            args.ClickedView = clickedHolder;
            OnClickEvent(this, args);
        }

        private void DispatchItemTouched(ViewHolder touchedHolder, Touch touchEvent)
        {
            ItemTouchEventArgs args = new ItemTouchEventArgs();
            args.TouchedView = touchedHolder;
            args.Touch = touchEvent;
            OnTouchEvent(this, args);
        }

        private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
        {
            if (e.PanGesture.State == Gesture.StateType.Started)
            {
                mLayout.StopScroll();
            }
            else if (e.PanGesture.State == Gesture.StateType.Continuing)
            {
                if (mLayout.CanScrollVertically())
                {
                    mLayout.ScrollVerticallyBy(e.PanGesture.Displacement.Y, mRecycler, mState, true);
                }
                else if (mLayout.CanScrollHorizontally())
                {
                    mLayout.ScrollHorizontallyBy(e.PanGesture.Displacement.X, mRecycler, mState, true);
                }

                ShowScrollBar();
            }
            else if (e.PanGesture.State == Gesture.StateType.Finished)
            {
                if (mLayout.CanScrollVertically())
                {
                    mLayout.ScrollVerticallyBy(e.PanGesture.Velocity.Y * 300, mRecycler, mState, false);
                }
                else if (mLayout.CanScrollHorizontally())
                {
                    mLayout.ScrollHorizontallyBy(e.PanGesture.Velocity.X * 300, mRecycler, mState, false);
                }
                ShowScrollBar(1200, true);
            }
        }


        private void OnItemEvent(object sender, Adapter.ItemEventArgs e)
        {
            switch (e.EventType)
            {
                case Adapter.ItemEventType.Insert:
                    mAdapteHelper.OnItemRangeInserted(e.param[0], e.param[1]);
                    ShowScrollBar();
                    break;
                case Adapter.ItemEventType.Remove:
                    mAdapteHelper.OnItemRangeRemoved(e.param[0], e.param[1]);
                    ShowScrollBar();
                    break;
                case Adapter.ItemEventType.Move:
                    break;
                case Adapter.ItemEventType.Change:
                    break;
                default:
                    return;
            }
            RelayoutRequest();
        }


        private void OnClickEvent(object sender, ItemClickEventArgs e)
        {
            clickEventHandlers?.Invoke(sender, e);
        }

        private void OnTouchEvent(object sender, ItemTouchEventArgs e)
        {
            touchEventHandlers?.Invoke(sender, e);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ItemClickEventArgs : EventArgs
        {
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ViewHolder ClickedView;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ItemTouchEventArgs : TouchEventArgs
        {
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ViewHolder TouchedView;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract class Adapter
        {
            private EventHandler<ItemEventArgs> itemEventHandlers;

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public delegate void EventHandler<ItemEventArgs>(object sender, ItemEventArgs e);
            /// <summary>
            /// Data changed event.
            /// </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public event EventHandler<ItemEventArgs> ItemEvent
            {
                add
                {
                    itemEventHandlers += value;
                }

                remove
                {
                    itemEventHandlers -= value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public enum ItemEventType
            {
                /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
                [EditorBrowsable(EditorBrowsableState.Never)]
                Insert = 0,
                /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
                [EditorBrowsable(EditorBrowsableState.Never)]
                Remove,
                /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
                [EditorBrowsable(EditorBrowsableState.Never)]
                Move,
                /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
                [EditorBrowsable(EditorBrowsableState.Never)]
                Change
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public abstract ViewHolder OnCreateViewHolder(int viewType);

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public abstract void OnBindViewHolder(ViewHolder holder, int position);

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public abstract void OnDestroyViewHolder(ViewHolder holder);

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public abstract int GetItemCount();

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual int GetItemViewType(int position)
            {
                return 0;
            }

            /**
             * Called by RecyclerView when it starts observing this Adapter.
             * <p>
             * Keep in mind that same adapter may be observed by multiple RecyclerViews.
             *
             * @param recyclerView The RecyclerView instance which started observing this adapter.
             */
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void OnAttachedToRecyclerView(FlexibleView recyclerView)
            {
            }

            /**
             * Called by RecyclerView when it stops observing this Adapter.
             *
             * @param recyclerView The RecyclerView instance which stopped observing this adapter.
             */
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void OnDetachedFromRecyclerView(FlexibleView recyclerView)
            {
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void OnFocusChange(FlexibleView flexibleView, int previousFocus, int currentFocus)
            {
            }

            /**
             * Called when a view created by this adapter has been recycled.
             * If an item view has large or expensive data bound to it such as large bitmaps, this may be a good place to release those resources
             */
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void OnViewRecycled(ViewHolder holder)
            {
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void OnViewAttachedToWindow(ViewHolder holder)
            {
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void OnViewDetachedFromWindow(ViewHolder holder)
            {
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void NotifyDataSetChanged()
            {
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void NotifyItemChanged(int index)
            {
                ItemEventArgs args = new ItemEventArgs
                {
                    EventType = ItemEventType.Change,
                };
                args.param[0] = index;
                args.param[1] = 1;
                OnItemEvent(this, args);
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void NotifyItemRangeChanged(int indexStart, int itemCount)
            {
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void NotifyItemInserted(int index)
            {
                NotifyItemRangeInserted(index, 1);
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void NotifyItemRangeInserted(int indexStart, int itemCount)
            {
                ItemEventArgs args = new ItemEventArgs
                {
                    EventType = ItemEventType.Insert,
                };
                args.param[0] = indexStart;
                args.param[1] = itemCount;
                OnItemEvent(this, args);
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void NotifyItemRemoved(int index)
            {
                NotifyItemRangeRemoved(index, 1);
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void NotifyItemRangeRemoved(int indexStart, int itemCount)
            {
                ItemEventArgs args = new ItemEventArgs
                {
                    EventType = ItemEventType.Remove,
                };
                args.param[0] = indexStart;
                args.param[1] = itemCount;
                OnItemEvent(this, args);
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void NotifyItemMoved(int fromIndex, int toIndex)
            {

            }

            private void OnItemEvent(object sender, ItemEventArgs e)
            {
                itemEventHandlers?.Invoke(sender, e);
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public class ItemEventArgs : EventArgs
            {
                /// <summary>
                /// Changed data.
                /// </summary>
                /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
                [EditorBrowsable(EditorBrowsableState.Never)]
                public object data;

                /// <summary>
                /// Data change event parameters.
                /// </summary>
                /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
                [EditorBrowsable(EditorBrowsableState.Never)]
                public int[] param = new int[4];

                /// <summary>
                /// Data changed event type.
                /// </summary>
                /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
                [EditorBrowsable(EditorBrowsableState.Never)]
                public ItemEventType EventType
                {
                    get { return mType; }
                    set { mType = value; }
                }

                private ItemEventType mType;
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract class LayoutManager
        {
            private FlexibleView mFlexibleView;
            private ChildHelper mChildHelper;

            private List<ViewHolder> mPendingRecycleViews = new List<ViewHolder>();

            private Animation mScrollAni;

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public abstract void OnLayoutChildren(Recycler recycler, ViewState state);

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void OnLayoutCompleted(ViewState state)
            {
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual bool CanScrollHorizontally()
            {
                return false;
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual bool CanScrollVertically()
            {
                return false;
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual float ScrollHorizontallyBy(float dy, Recycler recycler, ViewState state, bool immediate)
            {
                return 0;
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual float ScrollVerticallyBy(float dy, Recycler recycler, ViewState state, bool immediate)
            {
                return 0;
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual float ComputeScrollExtent(ViewState state)
            {
                return 0;
            }

            /**
             * <p>Override this method if you want to support scroll bars.</p>
             *
             * <p>Read {@link RecyclerView#computeHorizontalScrollOffset()} for details.</p>
             *
             * <p>Default implementation returns 0.</p>
             *
             * @param state Current State of RecyclerView where you can find total item count
             * @return The horizontal offset of the scrollbar's thumb
             * @see RecyclerView#computeHorizontalScrollOffset()
             */
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual float ComputeScrollOffset(ViewState state)
            {
                return 0;
            }

            /**
             * <p>Override this method if you want to support scroll bars.</p>
             *
             * <p>Read {@link RecyclerView#computeVerticalScrollRange()} for details.</p>
             *
             * <p>Default implementation returns 0.</p>
             *
             * @param state Current State of RecyclerView where you can find total item count
             * @return The total vertical range represented by the vertical scrollbar
             * @see RecyclerView#computeVerticalScrollRange()
             */
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual float ComputeScrollRange(ViewState state)
            {
                return 0;
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void ScrollToPosition(int position)
            {

            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void ScrollToPositionWithOffset(int position, int offset)
            {

            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void MoveFocus(string direction, Recycler recycler, ViewState state)
            {
                int prevFocusPosition = state.FocusPosition;
                int nextFocusPosition = GetNextPosition(state.FocusPosition, direction, state);
                if (nextFocusPosition == NO_POSITION)
                {
                    return;
                }

                FlexibleView.ViewHolder nextFocusChild = FindItemViewByPosition(nextFocusPosition);
                if (nextFocusChild == null)
                {
                    nextFocusChild = OnFocusSearchFailed(null, direction, recycler, state);
                }

                if (nextFocusChild != null)
                {
                    RequestChildRectangleOnScreen(mFlexibleView, nextFocusChild, recycler, state, false);

                    ChangeFocus(nextFocusPosition);
                }
            }

            /**
             * Requests that the given child of the RecyclerView be positioned onto the screen. This
             * method can be called for both unfocusable and focusable child views. For unfocusable
             * child views, focusedChildVisible is typically true in which case, layout manager
             * makes the child view visible only if the currently focused child stays in-bounds of RV.
             * @param parent The parent RecyclerView.
             * @param child The direct child making the request.
             * @param rect The rectangle in the child's coordinates the child
             *              wishes to be on the screen.
             * @param immediate True to forbid animated or delayed scrolling,
             *                  false otherwise
             * @param focusedChildVisible Whether the currently focused view must stay visible.
             * @return Whether the group scrolled to handle the operation
             */
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool RequestChildRectangleOnScreen(FlexibleView parent, FlexibleView.ViewHolder child, Recycler recycler, ViewState state, bool immediate)
            {
                Vector2 scrollAmount = GetChildRectangleOnScreenScrollAmount(parent, child);
                float dx = scrollAmount[0];
                float dy = scrollAmount[1];
                if (dx != 0 || dy != 0)
                {
                    if (dx != 0 && CanScrollHorizontally())
                    {
                        ScrollHorizontallyBy(dx, recycler, state, immediate);
                    }
                    else if (dy != 0 && CanScrollVertically())
                    {
                        ScrollVerticallyBy(dy, recycler, state, immediate);
                    }
                    return true;
                }
                return false;
            }

            /**
              * Calls {@code RecyclerView#RelayoutRequest} on the underlying RecyclerView
              */
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void RelayoutRequest()
            {
                if (mFlexibleView != null)
                {
                    mFlexibleView.RelayoutRequest();
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void LayoutChild(ViewHolder child, float left, float top, float width, float height)
            {
                View itemView = child.ItemView;
                itemView.SizeWidth = width - itemView.Margin.Start - itemView.Margin.End;
                itemView.SizeHeight = height - itemView.Margin.Top - itemView.Margin.Bottom;
                itemView.PositionX = left + itemView.Margin.Start;
                itemView.PositionY = top + itemView.Margin.Top;
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void ChangeFocus(int focusPosition)
            {
                if (mFlexibleView != null)
                {
                    mFlexibleView.DispatchFocusChanged(focusPosition);
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int GetChildCount()
            {
                return mChildHelper != null ? mChildHelper.GetChildCount() : 0;
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ViewHolder GetChildAt(int index)
            {
                return mChildHelper != null ? mChildHelper.GetChildAt(index) : null;
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ViewHolder FindItemViewByPosition(int position)
            {
                return mFlexibleView.FindViewHolderForLayoutPosition(position);
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void OffsetChildrenHorizontal(float dx, bool immediate)
            {
                if (mChildHelper == null)
                {
                    return;
                }

                if (mScrollAni == null)
                {
                    mScrollAni = new Animation(500);
                    mScrollAni.Finished += OnScrollAnimationFinished;
                }
                else if (mScrollAni.State == Animation.States.Playing)
                {
                    StopScroll();
                    mScrollAni.Duration = 100;
                    mScrollAni.DefaultAlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear);
                }
                else
                {
                    mScrollAni.Duration = 500;
                    mScrollAni.DefaultAlphaFunction = new AlphaFunction(new Vector2(0.3f, 0), new Vector2(0.15f, 1));
                }

                mScrollAni.Clear();

                int childCount = mChildHelper.GetChildCount();
                if (immediate == true)
                {
                    for (int i = childCount - 1; i >= 0; i--)
                    {
                        ViewHolder v = mChildHelper.GetChildAt(i);
                        v.ItemView.PositionX += dx;
                    }
                }
                else
                {
                    for (int i = childCount - 1; i >= 0; i--)
                    {
                        ViewHolder v = mChildHelper.GetChildAt(i);
                        mScrollAni.AnimateTo(v.ItemView, "PositionX", v.ItemView.PositionX + dx);
                    }
                    mScrollAni.Play();
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void OffsetChildrenVertical(float dy, bool immediate)
            {
                if (mChildHelper == null)
                {
                    return;
                }

                if (mScrollAni == null)
                {
                    mScrollAni = new Animation(500);
                    mScrollAni.Finished += OnScrollAnimationFinished;
                }
                else if (mScrollAni.State == Animation.States.Playing)
                {
                    StopScroll();
                    mScrollAni.Duration = 100;
                    mScrollAni.DefaultAlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear);
                }
                else
                {
                    mScrollAni.Duration = 500;
                    mScrollAni.DefaultAlphaFunction = new AlphaFunction(new Vector2(0.3f, 0), new Vector2(0.15f, 1));
                }

                mScrollAni.Clear();

                int childCount = mChildHelper.GetChildCount();
                if (immediate == true)
                {
                    for (int i = childCount - 1; i >= 0; i--)
                    {
                        ViewHolder v = mChildHelper.GetChildAt(i);
                        v.ItemView.PositionY += dy;
                    }
                }
                else
                {
                    for (int i = childCount - 1; i >= 0; i--)
                    {
                        ViewHolder v = mChildHelper.GetChildAt(i);
                        mScrollAni.AnimateTo(v.ItemView, "PositionY", v.ItemView.PositionY + dy);
                    }
                    mScrollAni.Play();
                }
            }

            /**
            * Return the width of the parent RecyclerView
            *
            * @return Width in pixels
            */
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float GetWidth()
            {
                return mFlexibleView != null ? mFlexibleView.SizeWidth : 0;
            }

            /**
             * Return the height of the parent RecyclerView
             *
             * @return Height in pixels
             */
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float GetHeight()
            {
                return mFlexibleView != null ? mFlexibleView.SizeHeight : 0;
            }

            /**
             * Return the left padding of the parent RecyclerView
             *
             * @return Padding in pixels
             */
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int GetPaddingLeft()
            {
                return mFlexibleView != null ? mFlexibleView.Padding.Start : 0;
            }

            /**
             * Return the top padding of the parent RecyclerView
             *
             * @return Padding in pixels
             */
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int GetPaddingTop()
            {
                return mFlexibleView != null ? mFlexibleView.Padding.Top : 0;
            }

            /**
             * Return the right padding of the parent RecyclerView
             *
             * @return Padding in pixels
             */
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int GetPaddingRight()
            {
                return mFlexibleView != null ? mFlexibleView.Padding.End : 0;
            }

            /**
             * Return the bottom padding of the parent RecyclerView
             *
             * @return Padding in pixels
             */
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int GetPaddingBottom()
            {
                return mFlexibleView != null ? mFlexibleView.Padding.Bottom : 0;
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void AddView(ViewHolder holder)
            {
                AddView(holder, -1);
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void AddView(ViewHolder holder, int index)
            {
                mChildHelper.AddView(holder, index);
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void ScrapAttachedViews(Recycler recycler)
            {
                if (mChildHelper == null)
                {
                    return;
                }

                recycler.ClearScrap();

                mChildHelper.ScrapViews(recycler);
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void RemoveAndRecycleViewAt(int index, Recycler recycler)
            {
                ViewHolder v = mChildHelper.GetChildAt(index);
                mChildHelper.RemoveViewAt(index);
                recycler.RecycleView(v);
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void RecycleChildren(FlexibleView.Recycler recycler, int startIndex, int endIndex, bool immediate)
            {
                if (startIndex == endIndex)
                {
                    return;
                }
                if (endIndex > startIndex)
                {
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        ViewHolder v = mChildHelper.GetChildAt(i);
                        mPendingRecycleViews.Add(v);
                    }
                }
                else
                {
                    for (int i = startIndex; i > endIndex; i--)
                    {
                        ViewHolder v = mChildHelper.GetChildAt(i);
                        mPendingRecycleViews.Add(v);
                    }
                }
                if (immediate == true)
                {
                    RecycleChildrenInt(recycler);
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            protected abstract int GetNextPosition(int position, string direction, FlexibleView.ViewState state);

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            protected virtual ViewHolder OnFocusSearchFailed(FlexibleView.ViewHolder focused, string direction, Recycler recycler, ViewState state)
            {
                return null;
            }

            internal void SetRecyclerView(FlexibleView recyclerView)
            {
                mFlexibleView = recyclerView;
                mChildHelper = recyclerView.mChildHelper;
            }

            internal void StopScroll()
            {
                if (mScrollAni != null && mScrollAni.State == Animation.States.Playing)
                {
                    mScrollAni.Stop();
                    mScrollAni.Clear();
                    OnScrollAnimationFinished(mScrollAni, null);
                }
            }

            /**
             * Returns the scroll amount that brings the given rect in child's coordinate system within
             * the padded area of RecyclerView.
             * @param parent The parent RecyclerView.
             * @param child The direct child making the request.
             * @param rect The rectangle in the child's coordinates the child
             *             wishes to be on the screen.
             * @param immediate True to forbid animated or delayed scrolling,
             *                  false otherwise
             * @return The array containing the scroll amount in x and y directions that brings the
             * given rect into RV's padded area.
             */
            private Vector2 GetChildRectangleOnScreenScrollAmount(FlexibleView parent, FlexibleView.ViewHolder child)
            {
                Vector2 ret = new Vector2(0, 0);
                int parentLeft = GetPaddingLeft();
                int parentTop = GetPaddingTop();
                int parentRight = (int)GetWidth() - GetPaddingRight();
                int parentBottom = (int)GetHeight() - GetPaddingBottom();
                int childLeft = (int)child.Left;
                int childTop = (int)child.Top;
                int childRight = (int)child.Right;
                int childBottom = (int)child.Bottom;

                int offScreenLeft = Math.Min(0, childLeft - parentLeft);
                int offScreenTop = Math.Min(0, childTop - parentTop);
                int offScreenRight = Math.Max(0, childRight - parentRight);
                int offScreenBottom = Math.Max(0, childBottom - parentBottom);

                // Favor the "start" layout direction over the end when bringing one side or the other
                // of a large rect into view. If we decide to bring in end because start is already
                // visible, limit the scroll such that start won't go out of bounds.
                int dx;
                if (false)
                {
                    dx = offScreenRight != 0 ? offScreenRight
                            : Math.Max(offScreenLeft, childRight - parentRight);
                }
                else
                {
                    dx = offScreenLeft != 0 ? offScreenLeft
                            : Math.Min(childLeft - parentLeft, offScreenRight);
                }

                // Favor bringing the top into view over the bottom. If top is already visible and
                // we should scroll to make bottom visible, make sure top does not go out of bounds.
                int dy = offScreenTop != 0 ? offScreenTop
                        : Math.Min(childTop - parentTop, offScreenBottom);

                ret.X = -dx;
                ret.Y = -dy;

                return ret;
            }

            private void OnScrollAnimationFinished(object sender, EventArgs e)
            {
                RecycleChildrenInt(mFlexibleView.mRecycler);
            }

            private void addViewInt(ViewHolder holder, int index, bool disappearing)
            {
                if (holder.IsScrap())
                {
                    holder.Unscrap();
                    mChildHelper.AttachView(holder, index);
                }
                else
                {
                    mChildHelper.AddView(holder, index);
                }
            }

            private void RecycleChildrenInt(FlexibleView.Recycler recycler)
            {
                foreach (ViewHolder holder in mPendingRecycleViews)
                {
                    recycler.RecycleView(holder);
                    mChildHelper.RemoveView(holder);
                }
                mPendingRecycleViews.Clear();
            }

            private void ScrapOrRecycleView(Recycler recycler, int index, ViewHolder itemView)
            {
                recycler.ScrapView(itemView);
            }


        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ViewHolder
        {
            /**
             * This ViewHolder has been bound to a position; mPosition, mItemId and mItemViewType
             * are all valid.
             */
            //static readonly int FLAG_BOUND = 1 << 0;

            /**
             * The data this ViewHolder's view reflects is stale and needs to be rebound
             * by the adapter. mPosition and mItemId are consistent.
             */
            //static readonly int FLAG_UPDATE = 1 << 1;

            /**
             * This ViewHolder's data is invalid. The identity implied by mPosition and mItemId
             * are not to be trusted and may no longer match the item view type.
             * This ViewHolder must be fully rebound to different data.
             */
            //static readonly int FLAG_INVALID = 1 << 2;

            /**
             * This ViewHolder points at data that represents an item previously removed from the
             * data set. Its view may still be used for things like outgoing animations.
             */
            //static readonly int FLAG_REMOVED = 1 << 3;

            /**
             * This ViewHolder should not be recycled. This flag is set via setIsRecyclable()
             * and is intended to keep views around during animations.
             */
            //static readonly int FLAG_NOT_RECYCLABLE = 1 << 4;

            /**
             * This ViewHolder is returned from scrap which means we are expecting an addView call
             * for this itemView. When returned from scrap, ViewHolder stays in the scrap list until
             * the end of the layout pass and then recycled by RecyclerView if it is not added back to
             * the RecyclerView.
             */
            //static readonly int FLAG_RETURNED_FROM_SCRAP = 1 << 5;

            /**
             * This ViewHolder is fully managed by the LayoutManager. We do not scrap, recycle or remove
             * it unless LayoutManager is replaced.
             * It is still fully visible to the LayoutManager.
             */
            //static readonly int FLAG_IGNORE = 1 << 7;

            private int mFlags;

            private View mItemView;

            private int mPosition = NO_POSITION;
            private int mOldPosition = NO_POSITION;
            private int mItemViewType = INVALID_TYPE;
            private int mPreLayoutPosition = NO_POSITION;


            private FlexibleView.Recycler mScrapContainer;

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ViewHolder(View itemView)
            {
                if (itemView == null)
                {
                    throw new ArgumentNullException("itemView may not be null");
                }
                this.mItemView = itemView;
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public View ItemView
            {
                get
                {
                    return mItemView;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float Left
            {
                get
                {
                    return mItemView.PositionX - mItemView.Margin.Start;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float Right
            {
                get
                {
                    return mItemView.PositionX + mItemView.SizeWidth + mItemView.Margin.End;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float Top
            {
                get
                {
                    return mItemView.PositionY - mItemView.Margin.Top;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float Bottom
            {
                get
                {
                    return mItemView.PositionY + mItemView.SizeHeight + mItemView.Margin.Bottom;
                }
            }

            /// <summary>
            /// Get layout position of item view.
            /// </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int LayoutPosition
            {
                get
                {
                    return mPreLayoutPosition == NO_POSITION ? mPosition : mPreLayoutPosition;
                }
                //internal set
                //{
                //    mPreLayoutPosition = value;
                //}
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int AdapterPosition
            {
                get
                {
                    return mPosition;
                }
                internal set
                {
                    mPosition = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int OldPosition
            {
                get
                {
                    return mOldPosition;
                }
                //internal set
                //{
                //    mOldPosition = value;
                //}
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int ItemViewType
            {
                get
                {
                    return mItemViewType;
                }
                set
                {
                    mItemViewType = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool IsBound
            {
                get;
                set;
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Recycler ScrapContainer
            {
                get
                {
                    return mScrapContainer;
                }
                set
                {
                    mScrapContainer = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool IsScrap()
            {
                return mScrapContainer != null;
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void Unscrap()
            {
                mScrapContainer.UnscrapView(this);
            }


            internal void FlagRemovedAndOffsetPosition(int mNewPosition, int offset, bool applyToPreLayout)
            {
                //AddFlags(ViewHolder.FLAG_REMOVED);
                OffsetPosition(offset, applyToPreLayout);
                mPosition = mNewPosition;
            }

            internal void OffsetPosition(int offset, bool applyToPreLayout)
            {
                if (mOldPosition == NO_POSITION)
                {
                    mOldPosition = mPosition;
                }
                if (mPreLayoutPosition == NO_POSITION)
                {
                    mPreLayoutPosition = mPosition;
                }
                if (applyToPreLayout)
                {
                    mPreLayoutPosition += offset;
                }
                mPosition += offset;
            }

            internal void ClearOldPosition()
            {
                mOldPosition = NO_POSITION;
                mPreLayoutPosition = NO_POSITION;
            }

            internal void SaveOldPosition()
            {
                if (mOldPosition == NO_POSITION)
                {
                    mOldPosition = mPosition;
                }
            }

            private void SetFlags(int flags, int mask)
            {
                mFlags = (mFlags & ~mask) | (flags & mask);
            }

            private void AddFlags(int flags)
            {
                mFlags |= flags;
            }

        }

        /**
         * <p>Contains useful information about the current RecyclerView state like target scroll
         * position or view focus. State object can also keep arbitrary data, identified by resource
         * ids.</p>
         * <p>Often times, RecyclerView components will need to pass information between each other.
         * To provide a well defined data bus between components, RecyclerView passes the same State
         * object to component callbacks and these components can use it to exchange data.</p>
         * <p>If you implement custom components, you can use State's put/get/remove methods to pass
         * data between your components without needing to manage their lifecycles.</p>
         */
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ViewState
        {
            //static readonly int STEP_START = 1;
            //static readonly int STEP_LAYOUT = 1 << 1;
            //static readonly int STEP_ANIMATIONS = 1 << 2;

            //public int mLayoutStep = STEP_START;
            /**
            * Number of items adapter had in the previous layout.
            */
            //public int mPreviousLayoutItemCount = 0;
            /**
             * Number of items adapter has.
             */
            //public int mItemCount = 0;
            /**
             * This data is saved before a layout calculation happens. After the layout is finished,
             * if the previously focused view has been replaced with another view for the same item, we
             * move the focus to the new item automatically.
             */

            private FlexibleView mFlexibleView;

            private bool mInPreLayout = false;

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ViewState(FlexibleView flexibleView)
            {
                mFlexibleView = flexibleView;
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int FocusPosition
            {
                get
                {
                    return mFlexibleView.mFocusedItemIndex;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int ItemCount
            {
                get
                {
                    Adapter b = mFlexibleView != null ? mFlexibleView.mAdapter : null;

                    return b != null ? b.GetItemCount() : 0;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool IsPreLayout()
            {
                return mInPreLayout;
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class Recycler
        {
            private FlexibleView mFlexibleView;
            private RecycledViewPool mRecyclerPool;

            private List<ViewHolder> mAttachedScrap = new List<ViewHolder>();
            private List<ViewHolder> mChangedScrap = null;
            //private List<ItemView> mCachedViews = new List<ItemView>();

            private List<ViewHolder> mUnmodifiableAttachedScrap;

            private int mCacheSizeMax = 2;

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Recycler(FlexibleView recyclerView)
            {
                mFlexibleView = recyclerView;
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void SetViewCacheSize(int viewCount)
            {
                mCacheSizeMax = viewCount;
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ViewHolder GetViewForPosition(int position)
            {
                Adapter b = mFlexibleView != null ? mFlexibleView.mAdapter : null;
                if (b == null)
                {
                    return null;
                }
                if (position < 0 || position >= b.GetItemCount())
                {
                    return null;
                }

                int type = b.GetItemViewType(position);
                ViewHolder itemView = null;
                for (int i = 0; i < mAttachedScrap.Count; i++)
                {
                    if (mAttachedScrap[i].LayoutPosition == position && mAttachedScrap[i].ItemViewType == type)
                    {
                        itemView = mAttachedScrap[i];
                        break;
                    }
                }
                if (itemView == null)
                {
                    itemView = mRecyclerPool.GetRecycledView(type);
                    if (itemView == null)
                    {
                        itemView = b.OnCreateViewHolder(type);
                    }

                    if (!itemView.IsBound)
                    {
                        b.OnBindViewHolder(itemView, position);
                        itemView.IsBound = true;
                    }

                    itemView.AdapterPosition = position;
                    itemView.ItemViewType = type;
                }

                return itemView;
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void ScrapView(ViewHolder itemView)
            {
                mAttachedScrap.Add(itemView);
                itemView.ScrapContainer = this;
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void UnscrapView(ViewHolder itemView)
            {
                mAttachedScrap.Remove(itemView);
                itemView.ScrapContainer = null;
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void RecycleView(ViewHolder itemView)
            {
                itemView.ScrapContainer = null;
                mRecyclerPool.PutRecycledView(itemView);
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int GetScrapCount()
            {
                return mAttachedScrap.Count;
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ViewHolder GetScrapViewAt(int index)
            {
                return mAttachedScrap[index];
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void ClearScrap()
            {
                mAttachedScrap.Clear();
                if (mChangedScrap != null)
                {
                    mChangedScrap.Clear();
                }
            }

            internal void SetRecycledViewPool(RecycledViewPool pool)
            {
                mRecyclerPool = pool;
            }
        }

        internal class RecycledViewPool
        {
            private FlexibleView mFlexibleView;

            private int mMaxTypeCount = 10;
            private List<ViewHolder>[] mScrap;

            public RecycledViewPool(FlexibleView flexibleView)
            {
                mFlexibleView = flexibleView;
                mScrap = new List<ViewHolder>[mMaxTypeCount];
            }

            //public void SetViewTypeCount(int typeCount)
            //{
            //}

            public ViewHolder GetRecycledView(int viewType)
            {
                if (viewType >= mMaxTypeCount || mScrap[viewType] == null)
                {
                    return null;
                }

                int index = mScrap[viewType].Count - 1;
                if (index < 0)
                {
                    return null;
                }
                ViewHolder recycledView = mScrap[viewType][index];
                mScrap[viewType].RemoveAt(index);

                return recycledView;
            }

            public void PutRecycledView(ViewHolder view)
            {
                int viewType = view.ItemViewType;
                if (mScrap[viewType] == null)
                {
                    mScrap[viewType] = new List<ViewHolder>();
                }
                view.IsBound = false;
                mScrap[viewType].Add(view);
            }

            public void Clear()
            {
                for (int i = 0; i < mMaxTypeCount; i++)
                {
                    if (mScrap[i] == null)
                    {
                        continue;
                    }
                    for (int j = 0; j < mScrap[i].Count; j++)
                    {
                        mFlexibleView.DispatchChildDestroyed(mScrap[i][j]);
                    }
                    mScrap[i].Clear();
                }
            }
        }

        private class ChildHelper
        {
            private FlexibleView mFlexibleView;

            private List<ViewHolder> mViewList = new List<ViewHolder>();

            //private List<ViewHolder> mRemovePendingViews;

            private Dictionary<uint, ViewHolder> itemViewTable = new Dictionary<uint, ViewHolder>();
            private TapGestureDetector mTapGestureDetector;

            public ChildHelper(FlexibleView owner)
            {
                mFlexibleView = owner;

                mTapGestureDetector = new TapGestureDetector();
                mTapGestureDetector.Detected += OnTapGestureDetected;
            }

            public void Clear()
            {
                foreach (ViewHolder holder in mViewList)
                {
                    mFlexibleView.Remove(holder.ItemView);

                    mFlexibleView.DispatchChildDestroyed(holder);
                }
                mViewList.Clear();
            }

            public void ScrapViews(Recycler recycler)
            {
                recycler.ClearScrap();
                foreach (ViewHolder itemView in mViewList)
                {
                    recycler.ScrapView(itemView);
                }

                mViewList.Clear();
            }

            public void AttachView(ViewHolder holder, int index)
            {
                if (index == -1)
                {
                    index = mViewList.Count;
                }
                mViewList.Insert(index, holder);

                if (itemViewTable.ContainsKey(holder.ItemView.ID))
                {
                    itemViewTable[holder.ItemView.ID] = holder;
                }
                else
                {
                    itemViewTable.Add(holder.ItemView.ID, holder);
                    mTapGestureDetector.Attach(holder.ItemView);
                    holder.ItemView.TouchEvent += OnTouchEvent;
                    //holder.ItemView.LeaveRequired = true;
                }
            }

            public void AddView(ViewHolder holder, int index)
            {
                mFlexibleView.Add(holder.ItemView);

                mFlexibleView.DispatchChildAttached(holder);

                AttachView(holder, index);
            }

            public bool RemoveView(ViewHolder holder)
            {
                mFlexibleView.Remove(holder.ItemView);

                mFlexibleView.DispatchChildDetached(holder);

                return mViewList.Remove(holder);
            }

            public bool RemoveViewAt(int index)
            {
                ViewHolder itemView = mViewList[index];
                return RemoveView(itemView);
            }

            public bool RemoveViewsRange(int index, int count)
            {
                for (int i = index; i < index + count; i++)
                {
                    ViewHolder holder = mViewList[i];
                    mFlexibleView.Remove(holder.ItemView);
                }
                mViewList.RemoveRange(index, count);
                return false;
            }

            public int GetChildCount()
            {
                return mViewList.Count;
            }

            public ViewHolder GetChildAt(int index)
            {
                if (index < 0 || index >= mViewList.Count)
                {
                    return null;
                }
                return mViewList[index];
            }

            private void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
            {
                View itemView = e.View as View;
                if (itemView == null)
                {
                    return;
                }
                if (itemViewTable.ContainsKey(itemView.ID))
                {
                    ViewHolder holder = itemViewTable[itemView.ID];
                    mFlexibleView.FocusedItemIndex = holder.AdapterPosition;

                    mFlexibleView.DispatchItemClicked(holder);
                }
            }

            private bool OnTouchEvent(object source, TouchEventArgs e)
            {
                View itemView = source as View;
                if (itemView != null && itemViewTable.ContainsKey(itemView.ID))
                {
                    ViewHolder holder = itemViewTable[itemView.ID];
                    if (e.Touch.GetState(0) != PointStateType.Motion)
                    {
                    }

                    mFlexibleView.DispatchItemTouched(holder, e.Touch);
                    return true;
                }
                return false;
            }
        }

        private class AdapterHelper
        {
            private FlexibleView mFlexibleView;

            private List<UpdateOp> mPendingUpdates = new List<UpdateOp>();

            private int mExistingUpdateTypes = 0;

            public AdapterHelper(FlexibleView flexibleView)
            {
                mFlexibleView = flexibleView;
            }

            /**
             * @return True if updates should be processed.
             */
            public bool OnItemRangeInserted(int positionStart, int itemCount)
            {
                if (itemCount < 1)
                {
                    return false;
                }
                mPendingUpdates.Add(new UpdateOp(UpdateOp.ADD, positionStart, itemCount));
                mExistingUpdateTypes |= UpdateOp.ADD;
                return mPendingUpdates.Count == 1;
            }

            /**
             * @return True if updates should be processed.
             */
            public bool OnItemRangeRemoved(int positionStart, int itemCount)
            {
                if (itemCount < 1)
                {
                    return false;
                }
                mPendingUpdates.Add(new UpdateOp(UpdateOp.REMOVE, positionStart, itemCount));
                mExistingUpdateTypes |= UpdateOp.REMOVE;
                return mPendingUpdates.Count == 1;
            }

            public void PreProcess()
            {
                int count = mPendingUpdates.Count;
                for (int i = 0; i < count; i++)
                {
                    UpdateOp op = mPendingUpdates[i];
                    switch (op.cmd)
                    {
                        case UpdateOp.ADD:
                            mFlexibleView.OffsetPositionRecordsForInsert(op.positionStart, op.itemCount);
                            break;
                        case UpdateOp.REMOVE:
                            mFlexibleView.OffsetPositionRecordsForRemove(op.positionStart, op.itemCount, false);
                            break;
                        case UpdateOp.UPDATE:
                            break;
                        case UpdateOp.MOVE:
                            break;
                    }
                }
                mPendingUpdates.Clear();
            }

        }

        /**
         * Queued operation to happen when child views are updated.
         */
        private class UpdateOp
        {

            public const int ADD = 1;

            public const int REMOVE = 1 << 1;

            public const int UPDATE = 1 << 2;

            public const int MOVE = 1 << 3;

            public const int POOL_SIZE = 30;

            public int cmd;

            public int positionStart;

            // holds the target position if this is a MOVE
            public int itemCount;

            public UpdateOp(int cmd, int positionStart, int itemCount)
            {
                this.cmd = cmd;
                this.positionStart = positionStart;
                this.itemCount = itemCount;
            }

            public bool Equals(UpdateOp op)
            {
                if (cmd != op.cmd)
                {
                    return false;
                }
                if (cmd == MOVE && Math.Abs(itemCount - positionStart) == 1)
                {
                    // reverse of this is also true
                    if (itemCount == op.positionStart && positionStart == op.itemCount)
                    {
                        return true;
                    }
                }
                if (itemCount != op.itemCount)
                {
                    return false;
                }
                if (positionStart != op.positionStart)
                {
                    return false;
                }

                return true;
            }

            public int HashCode()
            {
                int result = cmd;
                result = 31 * result + positionStart;
                result = 31 * result + itemCount;
                return result;
            }

        }

        //private class ViewInfoStore
        //{
        //}
        private class InfoRecord
        {
            public static readonly int FLAG_DISAPPEARED = 1;
            public static readonly int FLAG_APPEAR = 1 << 1;


            public ItemViewInfo preInfo;
            public ItemViewInfo postInfo;
        }

        private class ItemViewInfo
        {
            public float Left
            {
                get;
                set;
            }
            public float Top
            {
                get;
                set;
            }
            public float Right
            {
                get;
                set;
            }
            public float Bottom
            {
                get;
                set;
            }
        }

    }
}
