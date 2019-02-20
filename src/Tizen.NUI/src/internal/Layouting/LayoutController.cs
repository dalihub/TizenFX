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
using System;
using Tizen.NUI.BaseComponents;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] The class that initiates the Measuring and Layouting of the tree,
    ///         It sets a callback that becomes the entry point into the C# Layouting.
    /// </summary>
    internal class LayoutController : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef unmanagedLayoutController;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        internal delegate void Callback(int id);

        event Callback mInstance;

        //A Flat to check if it is already disposed.
        protected bool disposed = false;

        View root;

        /// <summary>
        /// Constructs a LayoutController which controls the measuring and layouting.<br />
        /// </summary>

        public LayoutController()
        {
            global::System.IntPtr cPtr = LayoutPINVOKE.LayoutController_New();

            // Wrap cPtr in a managed handle.
            unmanagedLayoutController = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);

            mInstance = new Callback(Process);
            LayoutPINVOKE.LayoutController_SetCallback(unmanagedLayoutController, mInstance);
        }

        /// <summary>
        /// Get the unique id of the LayoutController
        /// </summary>
        public int GetId()
        {
            return LayoutPINVOKE.LayoutController_GetId(unmanagedLayoutController);
        }

        /// <summary>
        /// Destructor which adds LayoutController to the Dispose queue.
        /// </summary>
        ~LayoutController()
        {
            Dispose(DisposeTypes.Explicit);
        }

        /// <summary>
        /// Explict Dispose.
        /// </summary>
        public void Dispose()
        {
           Dispose(DisposeTypes.Explicit);
           System.GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose Explict or Implicit
        /// </summary>
        protected virtual void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User code
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (unmanagedLayoutController.Handle != global::System.IntPtr.Zero)
            {
                LayoutPINVOKE.delete_LayoutController(unmanagedLayoutController);
                unmanagedLayoutController = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            disposed = true;
        }

        /// <summary>
        /// Entry point into the C# Layouting that starts the Processing
        /// </summary>
        private void Process(int id)
        {
            NUILog.Debug("layoutController Process id:" + id );
            // root, currently is the Window, needs to be View or derive from a class that
            // is implemented by View, Layer and Window.

            // Start at root with it's widthSpec and heightSpec
            MeasureHierarchy( root, root.MeasureSpecificationWidth, root.MeasureSpecificationHeight );

            // Start at root with it's widthSpec and heightSpec
            PerformLayout( root, new LayoutLengthEx(0), new LayoutLengthEx(0),
                           root.MeasureSpecificationWidth.Size, root.MeasureSpecificationHeight.Size );
        }

        /// <summary>
        /// Starts measuring the tree, starting from the root layout.
        /// </summary>
        private void MeasureHierarchy(View root, MeasureSpecification widthSpec, MeasureSpecification heightSpec)
        {
            // Does this View have a layout?
            // Yes - measure the layout. It will call this method again for each of it's children.
            // No -  reached leaf or no layouts set
            //
            // If in a leaf View with no layout, it's natural size is bubbled back up.

            if(root.LayoutEx != null)
            {
                root.LayoutEx.Measure(widthSpec, heightSpec);
            }
        }

        ///<summary>
        /// Performs the layouting positioning
        ///</summary>
        private void PerformLayout(View root, LayoutLengthEx left, LayoutLengthEx top, LayoutLengthEx right, LayoutLengthEx bottom)
        {
            if(root.LayoutEx != null)
            {
                root.LayoutEx.Layout(left, top, right, bottom);
            }
        }

        public void RequestLayout(LayoutItemEx layoutItem)
        {
            // Go up the tree and mark all parents to relayout
            ILayoutParentEx layoutParent = layoutItem.GetParent();
            if( layoutParent != null )
            {
                //todo
                //  LayourGroupEx layoutGroup =  layoutParent as LayoutGroupEx
                //  if( ! layoutGroup?.LayoutRequested  )
                //  {
                //      layoutGroup.RequestLayout();
                //  }
            }
        }

    } // class LayoutController

} // namespace Tizen.NUI