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
    /// Layout class that all layout containers should derive from.
    /// </summary>
    public class Layout : BaseHandle
    {

        /// <summary>
        /// Create an instance of Layout.
        /// </summary>
        public Layout() : this(NDalicPINVOKE.Handle_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// Measure the view and its content to determine the measured width and height.
        /// </summary>
        /// <param name="widthMeasureSpec">Horizontal space requirements as imposed by the parent.</param>
        /// <param name="heightMeasureSpec">Vertical space requirements as imposed by the parent.</param>
        virtual void OnMeasure( uint widthMeasureSpec, uint heightMeasureSpec );

        /// <summary>
        /// Called when a layout should assign a size and position to each of its children.
        /// </summary>
        /// <param name="changed">Flag indicating there is a new or changed size/position for this layout.</param>
        /// <param name="left">Left position, relative to parent.</param>
        /// <param name="top">Top position, relative to parent.</param>
        /// <param name="right">Right position, relative to parent.</param>
        /// <param name="bottom">Bottom position, relative to parent.</param>
        /// <param name="animate">Flag indicating whether the layout is about to animate into place</param>
        virtual void OnLayout( bool changed, int left, int top, int right, int bottom, bool animate );

        /// <summary>
        /// Called after new layout data has been set on this layout.
        /// </summary>
        /// <param name="layoutData">Data structure storing properties on a child.</param>
        virtual void OnSetLayoutData( /*ChildLayoutData*/ uint layoutData );

        /// todo Check if this is needed
        //public virtual void OnSizeChanged();
        // todo check if needed
        //public virtual void GetChildMeasureSpec

        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal Layout(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.Handle_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Animatable obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }
    } // class Layout

} // namespace Tizen.NUI.BaseComponents