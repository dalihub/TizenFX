/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.BaseComponents
{

    /// <summary>
    /// Interface to be implemented by all layout containers.
    /// </summary>
    public interface ILayout
    {
        /// <summary>
        /// Measure the view and its content to determine the measured width and height.
        /// </summary>
        /// <param name="widthMeasureSpec">Horizontal space requirements as imposed by the parent.</param>
        /// <param name="heightMeasureSpec">Vertical space requirements as imposed by the parent.</param>
        void OnMeasure( uint widthMeasureSpec, uint heightMeasureSpec );

        /// <summary>
        /// Called when a layout should assign a size and position to each of its children.
        /// </summary>
        /// <param name="changed">Flag indicating there is a new or changed size/position for this layout.</param>
        /// <param name="left">Left position, relative to parent.</param>
        /// <param name="top">Top position, relative to parent.</param>
        /// <param name="right">Right position, relative to parent.</param>
        /// <param name="bottom">Bottom position, relative to parent.</param>
        /// <param name="animate">Flag indicating whether the layout is about to animate into place</param>
        void OnLayout( bool changed, int left, int top, int right, int bottom, bool animate );

        /// <summary>
        /// Called after new layout data has been set on this layout.
        /// </summary>
        /// <param name="layoutData">Data structure storing properties on a child.</param>
        void OnSetLayoutData( /*ChildLayoutData*/ uint layoutData );

        /// todo Check if this is needed
        //public virtual void OnSizeChanged();

        /// <summary>
        /// Used to add a View or other layout container to this layout container.
        /// Will add child to the scene and to layout.
        /// </summary>
        /// <param name="child">The view or layout container to add.</param>
        //uint Add(View child);

        /// <summary>
        /// Used to remove a View or layout container from this layout container.
        /// </summary>
        /// <param name="child">The id of the child to remove,
        /// ids were returned by the Add(View child) API.</param>
        void Remove( uint childId );

        /// <summary>
        /// Used to retreive a handle to the View or layout container added to this layout container.
        /// </summary>
        /// <param name="childId">The id of the child to retreive, ids were returned by the Add(View child) API.</param>
        View GetChild(uint childId);

        // todo check if needed
        //public virtual void GetChildMeasureSpec

    } // interface ILayout

} // namespace Tizen.NUI.BaseComponents