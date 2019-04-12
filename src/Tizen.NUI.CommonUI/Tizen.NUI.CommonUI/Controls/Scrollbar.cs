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
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI.CommonUI
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ScrollBar : Control
    {
        private ScrollBarAttributes scrollBarAttrs;

        private ImageView trackObj;// = null;
        private ImageView thumbObj;// = null;

        private PanGestureDetector panGestureDetector;
        private EventHandler<PanGestureEventArgs> panGestureEventHandler;
        private Animation scrollAniPlayer = null;
        private float thumbObjPosX;
        private float thumbObjPosY;
        private bool enableAni = false;
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollBar() : base()
        {
            scrollBarAttrs = this.attributes as ScrollBarAttributes;
            Initialize();
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollBar(string style) : base(style)
        {
            if (attributes != null)
                scrollBarAttrs = attributes as ScrollBarAttributes;
            Initialize();
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollBar(ScrollBarAttributes attributes) : base()
        {
            this.attributes = scrollBarAttrs = attributes.Clone() as ScrollBarAttributes;
            Initialize();
        }

        ///// <summary>
        ///// The constructor of the ScrollBar with specific Attributes.
        ///// </summary>
        ///// <param name="attrs">The Attributes object to initialize the ScrollBar.</param>
        //public ScrollBar(Attributes attrs = null) : base(attrs, "ScrollBar")
        //{
        //    //TNLog.D("ScrollBar(Attributes);");
        //    if (scrollBarAttrs == null)
        //    {
        //        scrollBarAttrs = new Attributes();
        //    }
        //    Initialize();
        //}

        ///// <summary>
        ///// The constructor of the ScrollBar with specific style.
        ///// </summary>
        ///// <param name="style">The string to initialize the ScrollBar.</param>
        //public ScrollBar(string style) : base(style, "ScrollBar")
        //{
        //    //TNLog.D("ScrollBar(style);");
        //    if (scrollBarAttrs == null)
        //    {
        //        scrollBarAttrs = new Attributes();
        //    }
        //    Initialize();
        //}

        /// <summary>
        /// The PanGesture event handler.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<PanGestureEventArgs> PanGestureEvent
        {
            add
            {
                panGestureEventHandler += value;
            }
            remove
            {
                panGestureEventHandler -= value;
            }
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum DirectionType
        {
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Horizontal,
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Vertical
        }

        #region public property 

        /// <summary>
        /// The property to get/set the direction of the ScrollBar.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DirectionType Direction
        {
            get
            {
                return scrollBarAttrs.Direction.Value;
            }
            set
            {
                scrollBarAttrs.Direction = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property to get/set the size of the thumb object.
        /// </summary>
        /// <exception cref="InvalidOperationException">Throw when ThumbSize is null.</exception>
        /// <example>
        /// <code>
        /// ScrollBar scroll;
        /// try
        /// {
        ///     scroll.ThumbSize = new Size(500, 10, 0);
        /// }
        /// catch(InvalidOperationException e)
        /// {
        ///     Tizen.Log.Error(LogTag, "Failed to set ThumbSize value : " + e.Message);
        /// }
        /// </code>
        /// </example>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D ThumbSize
        {
            get
            {
                if (scrollBarAttrs.ThumbImageAttributes.Size2D == null)
                {
                    scrollBarAttrs.ThumbImageAttributes.Size2D = new Size2D();
                }
                return scrollBarAttrs.ThumbImageAttributes.Size2D;
            }
            set
            {
                if (scrollBarAttrs.ThumbImageAttributes.Size2D == null)
                {
                    scrollBarAttrs.ThumbImageAttributes.Size2D = new Size2D();
                }
                if (thumbObj != null)
                {
                    scrollBarAttrs.ThumbImageAttributes.Size2D.Width = value.Width;
                    scrollBarAttrs.ThumbImageAttributes.Size2D.Height = value.Height;
                    RelayoutRequest();
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string TrackImageURL
        {
            get
            {
                return scrollBarAttrs.TrackImageAttributes.ResourceURL.All;
            }
            set
            {
                if (trackObj != null)
                {
                    if (scrollBarAttrs.TrackImageAttributes.ResourceURL == null)
                    {
                        scrollBarAttrs.TrackImageAttributes.ResourceURL = new StringSelector();
                    }
                    scrollBarAttrs.TrackImageAttributes.ResourceURL.All = value;
                }
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property to get/set the color of the track object.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color TrackColor
        {
            get
            {
                //if (trackColor != null)
                //{
                //    return trackColor;
                //}
                //return scrollBarAttrs.TrackColor;
                return trackObj?.BackgroundColor;
            }
            set
            {
                //TNLog.D("trackColor, r = " + value.R + ", g = " + value.G + ", b = " + value.B + ", a = " + value.A + ";");
                // trackColor = new Color(value.R, value.G, value.B, value.A);
                if (trackObj != null)
                {
                    trackObj.BackgroundColor = value;
                }
            }
        }

        /// <summary>
        /// The property to get/set the color of the thumb object.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color ThumbColor
        {
            get
            {
                return thumbObj?.BackgroundColor;
            }
            set
            {
                if (thumbObj != null)
                {
                    thumbObj.BackgroundColor = value;
                }
            }
        }

        /// <summary>
        /// The property to get/set the max value of the ScrollBar.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint MaxValue
        {
            get
            {
                return scrollBarAttrs.MaxValue;
            }
            set
            {
                if (scrollBarAttrs.MaxValue == value)
                {
                    return;
                }
                scrollBarAttrs.MaxValue = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property to get/set the min value of the ScrollBar.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint MinValue
        {
            get
            {
                return scrollBarAttrs.MinValue;
            }
            set
            {
                if (scrollBarAttrs.MinValue == value)
                {
                    return;
                }
                scrollBarAttrs.MinValue = value;
                RelayoutRequest();
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint CurrentValue
        {
            get
            {
                return scrollBarAttrs.CurValue;
            }
            set
            {
                if (value < scrollBarAttrs.MinValue || value > scrollBarAttrs.MaxValue)
                {
                    return;
                    //throw new ArgumentOutOfRangeException("Wrong Current value. It shoud be greater than the Min value, and less than the Max value!");
                }
                scrollBarAttrs.CurValue = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Property to set/get animation duration.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint Duration
        {
            get
            {
                return scrollBarAttrs.Duration;
            }
            set
            {
                scrollBarAttrs.Duration = value;
                if (scrollAniPlayer != null)
                {
                    scrollAniPlayer.Duration = (int)value;
                }
            }
        }
        #endregion

        /// <summary>
        /// Method to set current value. The thumb object would move to the corresponding position with animation or not.
        /// </summary>
        /// <param name="currentValue">The special current value.</param>
        /// <param name="enableAni">Enable move with animation or not, the default value is true.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throw when current size is less than the min value, or greater than the max value.</exception>
        /// <example>
        /// <code>
        /// ScrollBar scroll;
        /// scroll.MinValue = 0;
        /// scroll.MaxValue = 100;
        /// try
        /// {
        ///     scroll.SetCurrentValue(50);
        /// }
        /// catch(ArgumentOutOfRangeException e)
        /// {
        ///     Tizen.Log.Error(LogTag, "Failed to set current value : " + e.Message);
        /// }
        /// </code>
        /// </example>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetCurrentValue(uint currentValue, bool isEnableAni = true)
        {
            if (currentValue < scrollBarAttrs.MinValue || currentValue > scrollBarAttrs.MaxValue)
            {
                //TNLog.E("Current value is less than the Min value, or greater than the Max value. currentValue = " + currentValue + ";");
                throw new ArgumentOutOfRangeException("Wrong Current value. It shoud be greater than the Min value, and less than the Max value!");
            }

            scrollBarAttrs.CurValue = currentValue;
            enableAni = isEnableAni;
            RelayoutRequest();
        }

        /// <summary>
        /// Dispose ScrollBar.
        /// </summary>
        /// <param name="type">The DisposeTypes value.</param>
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
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
                if (thumbObj != null)
                {
                    panGestureDetector.Detach(thumbObj);
                }
                panGestureDetector.Detected -= OnPanGestureDetected;
                panGestureDetector.Dispose();

                if (trackObj != null)
                {
                    trackObj.TouchEvent -= OnTouchEvent;
                    Remove(trackObj);
                    trackObj.Dispose();
                    trackObj = null;
                }

                if (thumbObj != null)
                {
                    Remove(thumbObj);
                    thumbObj.Dispose();
                    thumbObj = null;
                }

                if (scrollAniPlayer != null)
                {
                    scrollAniPlayer.Stop();
                    scrollAniPlayer.Clear();
                    scrollAniPlayer.Dispose();
                    scrollAniPlayer = null;
                }
                /// UIDirectionChangedEvent -= OnUIDirectionChangedEvent;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            //Unreference this from if a static instance refer to this. 

            //You must call base.Dispose(type) just before exit.
            base.Dispose(type);
        }

        /// <summary>
        /// The method to update Attributes.
        /// </summary>
        /// <param name="attrs">The specified attributes object.</param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate(Attributes attrs)
        {
            if (scrollBarAttrs == null)
            {
                return;
            }

            ApplyAttributes(this, scrollBarAttrs);
            ApplyAttributes(trackObj, scrollBarAttrs.TrackImageAttributes);
            ApplyAttributes(thumbObj, scrollBarAttrs.ThumbImageAttributes);
            if (enableAni)
            {
                UpdateValue(true);
                enableAni = false;
            }
            else
            {
                UpdateValue();
            }
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new ScrollBarAttributes()
            {
                ThumbImageAttributes = new ImageAttributes
                {

                },
                TrackImageAttributes = new ImageAttributes
                {

                }

            };
        }

        private void Initialize()
        {
            this.Focusable = false;

            trackObj = new ImageView
            {
                Focusable = false,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft

            };
            trackObj.TouchEvent += OnTouchEvent;
            thumbObj = new ImageView
            {
                Focusable = false,
                WidthResizePolicy = ResizePolicyType.Fixed,
                HeightResizePolicy = ResizePolicyType.Fixed,
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft
            };

            Add(trackObj);
            Add(thumbObj);

            scrollAniPlayer = new Animation(334);
            scrollAniPlayer.DefaultAlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear);

            InitializePanGestureDetector();
            LayoutDirectionChanged += OnLayoutDirectionChanged;
        }

        private void OnLayoutDirectionChanged(object sender, LayoutDirectionChangedEventArgs e)
        {
            RelayoutRequest();
        }

        private void UpdateValue(bool enableAni = false)
        {
            if (trackObj == null || thumbObj == null || scrollBarAttrs.Direction == null || scrollBarAttrs.MaxValue == null || scrollBarAttrs.MinValue == null || scrollBarAttrs.CurValue == null)
            {
                return;
            }

            if (scrollBarAttrs.MinValue >= scrollBarAttrs.MaxValue || scrollBarAttrs.CurValue < scrollBarAttrs.MinValue || scrollBarAttrs.CurValue > scrollBarAttrs.MaxValue)
            {
                if (scrollBarAttrs.MinValue >= scrollBarAttrs.MaxValue)
                {
                    //Console.WriteLine("[Scrollbar] Min value>= Max value");//gwfdebug
                }
                if (scrollBarAttrs.CurValue < scrollBarAttrs.MinValue || scrollBarAttrs.CurValue > scrollBarAttrs.MaxValue)
                {
                    //Console.WriteLine("[Scrollbar] Current value error");//gwfdebug
                }
                return;
            }
            float width = (float)Size2D.Width;
            float height = (float)Size2D.Height;
            float thumbW = scrollBarAttrs.ThumbImageAttributes.Size2D.Width;
            float thumbH = scrollBarAttrs.ThumbImageAttributes.Size2D.Height;
            float ratio = (float)(scrollBarAttrs.CurValue - scrollBarAttrs.MinValue) / (float)(scrollBarAttrs.MaxValue - scrollBarAttrs.MinValue);

            if (scrollBarAttrs.Direction == DirectionType.Horizontal)
            {
                if (LayoutDirection == ViewLayoutDirectionType.RTL)
                {
                    ratio = 1.0f - ratio;
                }

                float posX = ratio * (width - thumbW);
                float posY = (height - thumbH) / 2.0f;

                thumbObjPosX = posX;
                if (scrollAniPlayer != null)
                {
                    scrollAniPlayer.Stop();
                }

                if (!enableAni)
                {
                    thumbObj.Position = new Position(posX, posY, 0);
                }
                else
                {
                    if (scrollAniPlayer != null)
                    {
                        scrollAniPlayer.Clear();
                        scrollAniPlayer.AnimateTo(thumbObj, "PositionX", posX);
                        scrollAniPlayer.Play();
                    }
                }
            }
            else
            {
                float posX = (width - thumbW) / 2.0f;
                float posY = ratio * (height - thumbH);

                thumbObjPosY = posY;
                if (scrollAniPlayer != null)
                {
                    scrollAniPlayer.Stop();
                }

                if (!enableAni)
                {
                    thumbObj.Position = new Position(posX, posY, 0);
                }
                else
                {
                    if (scrollAniPlayer != null)
                    {
                        scrollAniPlayer.Clear();
                        scrollAniPlayer.AnimateTo(thumbObj, "PositionY", posY);
                        scrollAniPlayer.Play();
                    }
                }
            }
        }

        private void InitializePanGestureDetector()
        {
            panGestureDetector = new PanGestureDetector();
            //panGestureDetector.AddDirection(PanGestureDetector.DirectionHorizontal);
            panGestureDetector.Attach(thumbObj);
            panGestureDetector.Detected += OnPanGestureDetected;
            thumbObjPosX = 0;
            thumbObjPosY = 0;
        }

        private void ApplyPanGestureDetectorDirection()
        {
            DirectionType dir = CurrentDirection();
            if (dir == DirectionType.Horizontal)
            {
                panGestureDetector.AddDirection(PanGestureDetector.DirectionHorizontal);
            }
            else
            {
                panGestureDetector.AddDirection(PanGestureDetector.DirectionVertical);
            }
        }

        private DirectionType CurrentDirection()
        {
            DirectionType dir = DirectionType.Horizontal;
            if (scrollBarAttrs != null)
            {
                if (scrollBarAttrs.Direction != null)
                {
                    dir = scrollBarAttrs.Direction.Value;
                }
            }
            return dir;
        }

        private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
        {
            DirectionType dir = CurrentDirection();
            if (e.PanGesture.State == Gesture.StateType.Continuing)
            {
                PanGestureEventArgs eventArgs = null;
                eventArgs = new PanGestureEventArgs();
                if (dir == DirectionType.Horizontal)
                {
                    eventArgs.currentValue = CalculateCurrentValue(e.PanGesture.Displacement.X, dir);
                }
                else
                {
                    eventArgs.currentValue = CalculateCurrentValue(e.PanGesture.Displacement.Y, dir);
                }
                OnPanGestureEvent(this, eventArgs);
            }
            if (e.PanGesture.State == Gesture.StateType.Started)
            {
                PanGestureEventArgs eventArgs = null;
                eventArgs = new PanGestureEventArgs();
                if (dir == DirectionType.Horizontal)
                {
                    thumbObjPosX = thumbObj.PositionX;
                    eventArgs.currentValue = CalculateCurrentValue(e.PanGesture.Displacement.X, dir);
                }
                else
                {
                    thumbObjPosY = thumbObj.PositionY;
                    eventArgs.currentValue = CalculateCurrentValue(e.PanGesture.Displacement.Y, dir);
                }
                OnPanGestureEvent(this, eventArgs);
            }
        }

        private int CalculateCurrentValue(float offset, DirectionType dir)
        {
            if (dir == DirectionType.Horizontal)
            {
                thumbObjPosX += offset;
                if (thumbObjPosX < 0)
                {
                    thumbObj.PositionX = 0;
                    scrollBarAttrs.CurValue = scrollBarAttrs.MinValue;
                }
                else if (thumbObjPosX > Size2D.Width - thumbObj.Size2D.Width)
                {
                    thumbObj.PositionX = Size2D.Width - thumbObj.Size2D.Width;
                    scrollBarAttrs.CurValue = scrollBarAttrs.MaxValue;
                }
                else
                {
                    thumbObj.PositionX = thumbObjPosX;
                    scrollBarAttrs.CurValue = (uint)((thumbObjPosX / (float)(Size2D.Width - thumbObj.Size2D.Width)) * (float)(scrollBarAttrs.MaxValue - scrollBarAttrs.MinValue) + 0.5f);
                }
            }
            else
            {
                thumbObjPosY += offset;
                if (thumbObjPosY < 0)
                {
                    thumbObj.PositionY = 0;
                    scrollBarAttrs.CurValue = scrollBarAttrs.MinValue;
                }
                else if (thumbObjPosY > Size2D.Height - thumbObj.Size2D.Height)
                {
                    thumbObj.PositionY = Size2D.Height - thumbObj.Size2D.Height;
                    scrollBarAttrs.CurValue = scrollBarAttrs.MaxValue;
                }
                else
                {
                    thumbObj.PositionY = thumbObjPosY;
                    scrollBarAttrs.CurValue = (uint)((thumbObjPosY / (float)(Size2D.Height - thumbObj.Size2D.Height)) * (float)(scrollBarAttrs.MaxValue - scrollBarAttrs.MinValue) + 0.5f);
                }
            }

            return (int)scrollBarAttrs.CurValue;
        }

        private void OnPanGestureEvent(object sender, PanGestureEventArgs e)
        {
            panGestureEventHandler?.Invoke(sender, e);
        }

        private bool OnTouchEvent(object source, TouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                Vector2 pos = e.Touch.GetLocalPosition(0);
                ChangeValueByTouch(pos);
            }
            return false;
        }

        private void ChangeValueByTouch(Vector2 pos)
        {
            if (thumbObj == null)
            {
                return;
            }
            Size2D thumbSize = thumbObj.Size2D;
            Size2D trackSize = trackObj.Size2D;
            DirectionType direction = CurrentDirection();
            //TNLog.I("pos.X = " + pos.X + ", pos.Y = " + pos.Y + ", direction = " + direction);

            if (direction == DirectionType.Horizontal)
            {
                if (pos.X > trackSize.Width - thumbSize.Width)
                {
                    thumbObjPosX = trackSize.Width - thumbSize.Width;
                }
                else
                {
                    thumbObjPosX = pos.X;
                }

                thumbObj.PositionX = thumbObjPosX;
                scrollBarAttrs.CurValue = (uint)((thumbObjPosX) / (float)(trackSize.Width - thumbSize.Width) * (float)(scrollBarAttrs.MaxValue - scrollBarAttrs.MinValue) + 0.5f);
            }
            else
            {
                if (pos.Y > trackSize.Height - thumbSize.Height)
                {
                    thumbObjPosY = trackSize.Height - thumbSize.Height;
                }
                else
                {
                    thumbObjPosY = pos.Y;
                }

                thumbObj.PositionY = thumbObjPosY;
                scrollBarAttrs.CurValue = (uint)((thumbObjPosY) / (float)(trackSize.Height - thumbSize.Height) * (float)(scrollBarAttrs.MaxValue - scrollBarAttrs.MinValue) + 0.5f);
            }
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class PanGestureEventArgs : EventArgs
        {
            public int currentValue;
        }
    }
}
