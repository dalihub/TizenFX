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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] This class implements a flex layout.
    /// The flex layout implementation is based on open source Facebook Yoga layout engine.
    /// For more information about the flex layout API and how to use it please refer to https://yogalayout.com/docs/
    /// We implement the subset of the API in the class below.
    /// </summary>
    internal class FlexLayout : LayoutGroup
    {
        float Flex{ get; set;}
        int AlignSelf{get; set;}

        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        private bool disposed;
        private IntPtr _yogaRoot;  // Pointer to the unmanged Yoga class.

        internal delegate (float width, float height) ChildMeasureCallback(global::System.IntPtr child, float width, int measureModeWidth, float height, int measureModeHeight );

        internal FlexLayout(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr); // not this but _yogaRoot
            _yogaRoot =  LayoutPINVOKE.FlexLayout_New();
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FlexLayout obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        // protected override void Dispose(DisposeTypes type)
        // {
        //     if (disposed)
        //     {
        //         return;
        //     }

        //     if (type == DisposeTypes.Explicit)
        //     {
        //         //Called by User
        //         //Release your own managed resources here.
        //         //You should release all of your own disposable objects here.

        //     }

        //     //Release your own unmanaged resources here.
        //     //You should not access any managed member here except static instance.
        //     //because the execution order of Finalizes is non-deterministic.
        //     if (swigCPtr.Handle != global::System.IntPtr.Zero)
        //     {
        //         if (swigCMemOwn)
        //         {
        //             swigCMemOwn = false;
        //             LayoutPINVOKE.delete_FlexLayout(swigCPtr);
        //         }
        //         swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
        //     }
        //     base.Dispose(type);
        // }

        /// <summary>
        /// [Draft] Creates a FlexLayout object.
        /// </summary>
        public FlexLayout() : this(LayoutPINVOKE.FlexLayout_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static FlexLayout DownCast(BaseHandle handle)
        {
            FlexLayout ret = new FlexLayout(LayoutPINVOKE.FlexLayout_DownCast(BaseHandle.getCPtr(handle)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal FlexLayout(FlexLayout other) : this(LayoutPINVOKE.new_FlexLayout__SWIG_1(FlexLayout.getCPtr(other)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal FlexLayout Assign(FlexLayout other)
        {
            FlexLayout ret = new FlexLayout(LayoutPINVOKE.FlexLayout_Assign(swigCPtr, FlexLayout.getCPtr(other)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetFlexDirection(FlexLayout.FlexDirection flexDirection)
        {
            LayoutPINVOKE.FlexLayout_SetFlexDirection(swigCPtr, (int)flexDirection);
        }

        internal FlexLayout.FlexDirection GetFlexDirection()
        {
            FlexLayout.FlexDirection ret = (FlexLayout.FlexDirection)LayoutPINVOKE.FlexLayout_GetFlexDirection(swigCPtr);
            return ret;

        }

        internal void SetFlexJustification(FlexLayout.FlexJustification flexJustification)
        {
            LayoutPINVOKE.FlexLayout_SetFlexJustification(swigCPtr, (int)flexJustification);
        }

        internal FlexLayout.FlexJustification GetFlexJustification()
        {
            FlexLayout.FlexJustification ret = (FlexLayout.FlexJustification)LayoutPINVOKE.FlexLayout_GetFlexJustification(swigCPtr);
            return ret;
        }

        internal void SetFlexWrap(FlexLayout.FlexWrapType flexWrap)
        {
            LayoutPINVOKE.FlexLayout_SetFlexWrap(swigCPtr, (int)flexWrap);
        }

        internal FlexLayout.FlexWrapType GetFlexWrap()
        {
            FlexLayout.FlexWrapType ret = (FlexLayout.FlexWrapType)LayoutPINVOKE.FlexLayout_GetFlexWrap(swigCPtr);
            return ret;
        }

        internal void SetFlexAlignment(FlexLayout.AlignmentType flexAlignment)
        {
            LayoutPINVOKE.FlexLayout_SetFlexAlignment(swigCPtr, (int)flexAlignment);
        }

        internal FlexLayout.AlignmentType GetFlexAlignment()
        {
            FlexLayout.AlignmentType ret = (FlexLayout.AlignmentType)LayoutPINVOKE.FlexLayout_GetFlexAlignment(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetFlexItemsAlignment(FlexLayout.AlignmentType flexAlignment)
        {
            LayoutPINVOKE.FlexLayout_SetFlexItemsAlignment(swigCPtr, (int)flexAlignment);
        }

        internal FlexLayout.AlignmentType GetFlexItemsAlignment()
        {
            FlexLayout.AlignmentType ret = (FlexLayout.AlignmentType)LayoutPINVOKE.FlexLayout_GetFlexItemsAlignment(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal enum PropertyRange
        {
            CHILD_PROPERTY_START_INDEX = PropertyRanges.CHILD_PROPERTY_REGISTRATION_START_INDEX,
            CHILD_PROPERTY_END_INDEX = PropertyRanges.CHILD_PROPERTY_REGISTRATION_START_INDEX + 1000
        }

        internal class ChildProperty
        {
            internal static readonly int FLEX = LayoutPINVOKE.FlexLayout_ChildProperty_FLEX_get();
            internal static readonly int ALIGN_SELF = LayoutPINVOKE.FlexLayout_ChildProperty_ALIGN_SELF_get();
        }

        /// <summary>
        /// [Draft] Get/Set the flex direction in the layout.
        /// The direction of the main-axis which determines the direction that flex items are laid out.
        /// </summary>
        public FlexDirection Direction
        {
            get
            {
                return GetFlexDirection();
            }
            set
            {
                SetFlexDirection(value);
            }
        }

        /// <summary>
        /// [Draft] Get/Set the justification in the layout.
        /// </summary>
        public FlexJustification Justification
        {
            get
            {
                return GetFlexJustification();
            }
            set
            {
                SetFlexJustification(value);
            }
        }

        /// <summary>
        /// [Draft] Get/Set the wrap in the layout.
        /// </summary>
        public FlexWrapType WrapType
        {
            get
            {
                return GetFlexWrap();
            }
            set
            {
                SetFlexWrap(value);
            }
        }

        /// <summary>
        /// [Draft] Get/Set the alignment of the layout content.
        /// </summary>
        public AlignmentType Alignment
        {
            get
            {
                return GetFlexAlignment();
            }
            set
            {
                SetFlexAlignment(value);
            }
        }

        /// <summary>
        /// [Draft] Get/Set the alignment of the layout items.
        /// </summary>
        public AlignmentType ItemsAlignment
        {
            get
            {
                return GetFlexItemsAlignment();
            }
            set
            {
                SetFlexItemsAlignment(value);
            }
        }

        /// <summary>
        /// [Draft] Enumeration for the direction of the main axis in the flex container.
        /// This determines the direction that flex items are laid out in the flex container.
        /// </summary>
        public enum FlexDirection
        {
            /// <summary>
            /// The flexible items are displayed vertically as a column
            /// </summary>
            Column,
            /// <summary>
            /// The flexible items are displayed vertically as a column, but in reverse order
            /// </summary>
            ColumnReverse,
            /// <summary>
            /// The flexible items are displayed horizontally as a row
            /// </summary>
            Row,
            /// <summary>
            /// The flexible items are displayed horizontally as a row, but in reverse order
            /// </summary>
            RowReverse
        }

        /// <summary>
        /// [Draft] Enumeration for the alignment of the flex items when the items do not use all available space on the main-axis.
        /// </summary>
        public enum FlexJustification
        {
            /// <summary>
            /// Items are positioned at the beginning of the container
            /// </summary>
            FlexStart,
            /// <summary>
            /// Items are positioned at the center of the container
            /// </summary>
            Center,
            /// <summary>
            /// Items are positioned at the end of the container
            /// </summary>
            FlexEnd,
            /// <summary>
            /// Items are positioned with equal space between the lines
            /// </summary>
            SpaceBetween,
            /// <summary>
            /// Items are positioned with equal space before, between, and after the lines
            /// </summary>
            SpaceAround
        }

        /// <summary>
        /// [Draft] Enumeration for the wrap type of the flex container when there is no enough room for all the items on one flex line.
        /// </summary>
        public enum FlexWrapType
        {
            /// <summary>
            /// Flex items laid out in single line (shrunk to fit the flex container along the main axis)
            /// </summary>
            NoWrap,
            /// <summary>
            /// Flex items laid out in multiple lines if needed
            /// </summary>
            Wrap
        }

        /// <summary>
        /// [Draft] Enumeration for the alignment of the flex items or lines when the items or lines do not use all the available space on the cross-axis.
        /// </summary>
        public enum AlignmentType
        {
            /// <summary>
            /// Inherits the same alignment from the parent (only valid for "alignSelf" property)
            /// </summary>
            Auto,
            /// <summary>
            /// At the beginning of the container
            /// </summary>
            FlexStart,
            /// <summary>
            /// At the center of the container
            /// </summary>
            Center,
            /// <summary>
            /// At the end of the container
            /// </summary>
            FlexEnd,
            /// <summary>
            /// Stretch to fit the container
            /// </summary>
            Stretch
        }

        /**
         * @brief Struct to hold the left, right, top and bottom coordinates of a Frame.
         */
        private struct Frame
        {
          float left;
          float top;
          float right;
          float bottom;
        };


//        internal delegate (float width, float height) ChildMeasureCallback(global::System.IntPtr child, float width, int measureModeWidth, float height, int measureModeHeight )

        private (float width, float height) measureChild(global::System.IntPtr child, float width, int measureModeWidth, float height, int measureModeHeight)
        {
            return (120.0f,210.0f);
        }

        void InsertChild( LayoutItem child )
        {
            global::System.IntPtr node = LayoutPINVOKE.FlexLayout_New();

            ChildMeasureCallback measureChildDelegate = new ChildMeasureCallback(measureChild);

            //LayoutPINVOKE.FlexLayout_AddChild(swigCPtr,  new global::System.Runtime.InteropServices.HandleRef(this, node), measureChildDelegate, _children.Count-1);
        }

        protected override void OnChildAdd(LayoutItem child)
        {
            InsertChild(child);
        }

        protected override void OnChildRemove(LayoutItem child)
        {
        //     var count = _children.Count;
        //     for( int childIndex = 0; childIndex < count; childIndex++)
        //     {
        //         LayoutItem childLayout = _children[childIndex];
        //         if( child == childLayout )
        //         {
        //             LayoutPINVOKE.FlexLayout_RemoveChildAt( _yogaRoot, childIndex );
        //             break;
        //         }
        //     }
        }

        protected override void OnMeasure( MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec )
        {
            bool isLayoutRtl = Owner.LayoutDirection == ViewLayoutDirectionType.RTL;
    //     Extents padding = Owner.Padding;
    //     Extents margin = Owner.Margin;

    //     LayoutPINVOKE.FlexLayout_SetMargin(node, margin);

    //     YGNodeStyleSetPadding( _yogaRoot, YGEdgeLeft, padding.Start );
    //     YGNodeStyleSetPadding( _yogaRoot, YGEdgeTop, padding.Top );
    //     YGNodeStyleSetPadding( _yogaRoot, YGEdgeRight, padding.End );
    //     YGNodeStyleSetPadding( _yogaRoot, YGEdgeBottom, padding.Bottom );

            float width = 0.0f;
            float height = 0.0f;

    //     YGNodeStyleSetWidth( _yogaRoot, YGUndefined );
    //     YGNodeStyleSetHeight( _yogaRoot, YGUndefined );
    //     YGNodeStyleSetMinWidth( _yogaRoot, YGUndefined );
    //     YGNodeStyleSetMinHeight( _yogaRoot, YGUndefined );
    //     YGNodeStyleSetMaxWidth( _yogaRoot, YGUndefined );
    //     YGNodeStyleSetMaxHeight( _yogaRoot, YGUndefined );

    //     if( widthMeasureSpec.Mode == MeasureSpecification.ModeType.Exactly )
    //     {
    //         width = widthMeasureSpec.Size.AsDecimal();
    //         YGNodeStyleSetWidth( _yogaRoot, width );
    //     }
    //     else if( widthMeasureSpec.Mode == MeasureSpecification.ModeType.AtMost )
    //     {
    //         width = widthMeasureSpec.Size.AsDecimal();
    //         YGNodeStyleSetMaxWidth( _yogaRoot, width );
    //     }

    //     if ( heightMeasureSpec.Mode == MeasureSpecification.ModeType.Exactly )
    //     {
    //         height = heightMeasureSpec.Size.AsDecimal();
    //         YGNodeStyleSetHeight( _yogaRoot, height );
    //     }
    //     else if ( heightMeasureSpec.Mode == MeasureSpecification.ModeType.AtMost )
    //     {
    //         height = heightMeasureSpec.Size.AsDecimal();
    //         YGNodeStyleSetMaxHeight( _yogaRoot, height );
    //     }

    //     SetChildrenStyle();
        LayoutPINVOKE.FlexLayout_CalculateLayout( swigCPtr, width, height, isLayoutRtl );

        SetMeasuredDimensions( GetDefaultSize( new LayoutLength( (float)LayoutPINVOKE.FlexLayout_GetWidth(swigCPtr) ), widthMeasureSpec ),
                               GetDefaultSize( new LayoutLength( (float)LayoutPINVOKE.FlexLayout_GetHeight(swigCPtr) ), heightMeasureSpec ) );
        }

        // YGSize OnChildMeasure( YGNodeRef node, float innerWidth, YGMeasureMode widthMode, float innerHeight, YGMeasureMode heightMode )
        // {
        //     LayoutItem childLayout = static_cast<LayoutItem*>(node->getContext());
        //     int desiredWidth = childLayout.Owner.WidthSpecification;
        //     int desiredHeight = childLayout.Owner.HeightSpecification;
        //     MeasureSpecification parentWidthMeasureSpec = new MeasureSpecification();
        //     if ( innerWidth != YGUndefined )
        //     {
        //         parentWidthMeasureSpec = new MeasureSpecification( new LayoutLength(innerWidth), static_cast<MeasureSpec::Mode>(widthMode) );
        //     }
        //     MeasureSpecification parentHeightMeasureSpec = new MeasureSpecification();
        //     if (innerHeight != YGUndefined)
        //     {
        //         parentHeightMeasureSpec = new MeasureSpecification( new LayoutLength(innerHeight), static_cast<MeasureSpec::Mode>(heightMode) );
        //     }
        //     MeasureSpecification childWidthMeasureSpec = LayoutGroupEx.GetChildMeasureSpecification( parentWidthMeasureSpec,
        //                                                                new LayoutLength(0), new LayoutLength(desiredWidth));
        //     MeasureSpecification childHeightMeasureSpec = LayoutGroupEx.GetChildMeasureSpecification( parentHeightMeasureSpec,
        //                                                                 new LayoutLength(0), new LayoutLength(desiredHeight));

        //     // Force to fill parent if a child wants to match parent even if GetChildMeasureSpec sets otherwise
        //     if( desiredWidth == LayoutParamPolicies.MatchParent && innerWidth != YGUndefined )
        //     {
        //         childWidthMeasureSpec = new MeasureSpecification( new LayoutLength(innerWidth), MeasureSpecification.ModeType.Exactly );
        //     }
        //     if( desiredHeight == LayoutParamPolicies.MatchParent && innerHeight != YGUndefined )
        //     {
        //         childHeightMeasureSpec = new MeasureSpecification( new LayoutLength(innerHeight), MeasureSpecification.ModeType.Exactly);
        //     }

        //     childLayout.Measure( childWidthMeasureSpec, childHeightMeasureSpec );

        //     // Remove padding here since Yoga doesn't consider it as a part of the node size
        //     Extents padding = childLayout.Owner.Padding;
        //     LayoutLength measuredWidth = new LayoutLength(childLayout.MeasuredWidth.Size.AsDecimal() - padding.End - padding.Start);
        //     LayoutLength measuredHeight = new LayoutLength(childLayout.MeasuredHeight.Size.AsDecimal() - padding.Bottom - padding.Top);

        //     return YGSize{
        //         .width = measuredWidth.AsDecimal(),
        //         .height = measuredHeight.AsDecimal(),
        //     };
        // }

        // void SetChildrenStyle()
        // {
        //     if( _yogaRoot )
        //     {
        //         int count = _children.Count;
        //         for( int childIndex = 0; childIndex < count; childIndex++)
        //         {
        //             LayoutItem childLayout = _children[childIndex];
        //             if( childLayout != null )
        //             {
        //                 Extents padding = childLayout.Owner.Padding;
        //                 Extents margin = childLayout.Owner.Margin;
        //                 var childOwner = childLayout.Owner;

        //                 var flex = childOwner.GetProperty<float>( Toolkit::FlexLayout::ChildProperty::FLEX );
        //                 var alignSelf = static_cast<YGAlign>( childOwner.GetProperty<int>( Toolkit::FlexLayout::ChildProperty::ALIGN_SELF ));

        //                 YGNodeRef childNode = YGNodeGetChild( _yogaRoot, childIndex );
        //                 // Initialise the style of the child.

        //                 LayoutPINVOKE.FlexLayout_SetMargin(node, margin);
        //                 LayoutPINVOKE.FlexLayout_SetPadding(node, margin);

        //                 YGNodeStyleSetWidth( childNode, YGUndefined );
        //                 YGNodeStyleSetHeight( childNode, YGUndefined );
        //                 // TODO: check if we are supposed to use actor properties here, max/min is needed for stretch
        //                 YGNodeStyleSetMinWidth( childNode, childLayout.Owner.MinimumSize.Width);
        //                 YGNodeStyleSetMinHeight( childNode, childLayout.Owner.MinimumSize.Height);
        //                 if( childActor.GetMaximumSize().x == FLT_MAX )
        //                 {
        //                 YGNodeStyleSetMaxWidth( childNode, YGUndefined );
        //                 }
        //                 else
        //                 {
        //                 YGNodeStyleSetMaxWidth( childNode, childLayout.Owner.MaximumSize.Width);
        //                 }
        //                 if( childActor.GetMaximumSize().y == FLT_MAX )
        //                 {
        //                 YGNodeStyleSetMaxHeight( childNode, YGUndefined );
        //                 }
        //                 else
        //                 {
        //                 YGNodeStyleSetMaxHeight( childNode, childLayout.Owner.MaximumSize.Height);
        //                 }

        //                 YGNodeStyleSetFlex( childNode, flex );
        //                 YGNodeStyleSetAlignSelf( childNode, alignSelf );

        //                 // Have to do manually for nodes with custom measure function
        //                 // TODO: check the style is changed before marking the node
        //                 LayoutPINVOKE.FlexLayout_MarkDirty( childNode );
        //             }
        //         }
        //     }
        // }
        protected override void OnLayout( bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom )
        {

            bool isLayoutRtl = Owner.LayoutDirection == ViewLayoutDirectionType.RTL;
            LayoutLength width = right - left;
            LayoutLength height = bottom - top;


            LayoutPINVOKE.FlexLayout_CalculateLayout( swigCPtr, width.AsDecimal(), height.AsDecimal(), isLayoutRtl );

            int count = _children.Count;
            for( int childIndex = 0; childIndex < count; childIndex++)
            {
                LayoutItem childLayout = _children[childIndex];
                if( childLayout != null )
                {
                    IntPtr pointerToFrame = LayoutPINVOKE.FlexLayout_GetNodeFrame( swigCPtr, childIndex );
                    //Frame frame = pointerToFrame;

                // YGNodeRef node = YGNodeGetChild(_yogaRoot, childIndex);
                 LayoutLength childLeft;// = LayoutLength( YGNodeLayoutGetLeft( node ) )+ left;
                 LayoutLength childTop;// = LayoutLength( YGNodeLayoutGetTop( node ) ) + top;
                 LayoutLength childWidth;// = LayoutLengthLayoutLength( YGNodeLayoutGetWidth( node ) );
                 LayoutLength childHeight;// = LayoutLength( YGNodeLayoutGetHeight( node ) );
                 //childLayout.Layout( childLeft, childTop, childLeft + childWidth, childTop + childHeight );
                }
            }
        }

    } // FLexlayout
} // namesspace Tizen.NUI