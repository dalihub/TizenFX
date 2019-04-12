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
{    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Progress : Control
    {
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected ProgressBarAttributes progressBarAttrs = null;
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected ImageView trackObj = null;
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected ImageView progressObj = null;
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected ImageView bufferObj = null;
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected ImageView loadingObj = null;

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected ProgressStatusType? state = null;

        /// <summary>
        /// The constructor of ProgressBar
        /// </summary>
        /// <version> 5.5.0 </version>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Progress() : base()
        {
            progressBarAttrs = attributes as ProgressBarAttributes;
            Initialize();
        }

        /// <summary>
        /// The constructor of the ProgressBar class with specific Attributes.
        /// </summary>
        /// <param name="attrs">The Attributes object to initialize the ProgressBar.</param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Progress(string style) : base(style)
        {
            if (attributes != null)
            {
                progressBarAttrs = attributes as ProgressBarAttributes;
            }

            Initialize();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Progress(ProgressBarAttributes attributes) : base()
        {
            this.attributes = progressBarAttrs = attributes.Clone() as ProgressBarAttributes;
            Initialize();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ProgressStatusType
        {
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Buffering,   //TrackImage
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Determinate, //ProgressImage
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Indeterminate//loading
        }

        /// <summary>
        /// The direction type of the ProgressBar.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum DirectionType
        {
            /// <summary> The progress moving follow horizontal direction. </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)] Horizontal,
            /// <summary> The progress moving follow vertical direction. </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)] Vertical
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual string ProgressImageURLPre
        {
            get
            {
                if (progressBarAttrs.ProgressImageURLPrefix == null)
                {
                    progressBarAttrs.ProgressImageURLPrefix = new StringSelector();
                }
                return progressBarAttrs.ProgressImageURLPrefix.All;
            }
            set
            {
                if (progressBarAttrs.ProgressImageURLPrefix == null)
                {
                    progressBarAttrs.ProgressImageURLPrefix = new StringSelector();
                }
                progressBarAttrs.ProgressImageURLPrefix.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property to get/set Track image object URL of the ProgressBar.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string TrackImageURL
        {
            get
            {
                if (progressBarAttrs.TrackImageAttributes.ResourceURL == null)
                {
                    progressBarAttrs.TrackImageAttributes.ResourceURL = new StringSelector();
                }
                return progressBarAttrs.TrackImageAttributes.ResourceURL.All;
            }
            set
            {
                if (progressBarAttrs.TrackImageAttributes.ResourceURL == null)
                {
                    progressBarAttrs.TrackImageAttributes.ResourceURL = new StringSelector();
                }
                progressBarAttrs.TrackImageAttributes.ResourceURL.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property to get/set Progress object image URL of the ProgressBar.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ProgressImageURL
        {
            get
            {
                if (progressBarAttrs.ProgressImageAttributes.ResourceURL == null)
                {
                    progressBarAttrs.ProgressImageAttributes.ResourceURL = new StringSelector();
                }
                return progressBarAttrs.ProgressImageAttributes.ResourceURL.All;
            }
            set
            {
                if (progressBarAttrs.ProgressImageAttributes.ResourceURL == null)
                {
                    progressBarAttrs.ProgressImageAttributes.ResourceURL = new StringSelector();
                }
                progressBarAttrs.ProgressImageAttributes.ResourceURL.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property to get/set Buffer object image URL of the ProgressBar.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BufferImageURL
        {
            get
            {
                if (progressBarAttrs.BufferImageAttributes.ResourceURL == null)
                {
                    progressBarAttrs.BufferImageAttributes.ResourceURL = new StringSelector();
                }
                return progressBarAttrs.BufferImageAttributes.ResourceURL.All;
            }
            set
            {
                if (progressBarAttrs.BufferImageAttributes.ResourceURL == null)
                {
                    progressBarAttrs.BufferImageAttributes.ResourceURL = new StringSelector();
                }
                progressBarAttrs.BufferImageAttributes.ResourceURL.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property to get/set Track object color of the ProgressBar.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color TrackColor
        {
            get
            {
                if (progressBarAttrs.TrackImageAttributes.BackgroundColor == null)
                {
                    progressBarAttrs.TrackImageAttributes.BackgroundColor = new ColorSelector();
                }
                return progressBarAttrs.TrackImageAttributes.BackgroundColor.All;
            }
            set
            {
                if (progressBarAttrs.TrackImageAttributes.BackgroundColor == null)
                {
                    progressBarAttrs.TrackImageAttributes.BackgroundColor = new ColorSelector();
                }
                progressBarAttrs.TrackImageAttributes.BackgroundColor.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property to get/set Progress object color of the ProgressBar.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color ProgressColor
        {
            get
            {
                if (progressBarAttrs.ProgressImageAttributes.BackgroundColor == null)
                {
                    progressBarAttrs.ProgressImageAttributes.BackgroundColor = new ColorSelector();
                }
                return progressBarAttrs.ProgressImageAttributes.BackgroundColor.All;
            }
            set
            {
                if (progressBarAttrs.ProgressImageAttributes.BackgroundColor == null)
                {
                    progressBarAttrs.ProgressImageAttributes.BackgroundColor = new ColorSelector();
                }
                progressBarAttrs.ProgressImageAttributes.BackgroundColor.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property to get/set Buffer object color of the ProgressBar.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color BufferColor
        {
            get
            {
                if (progressBarAttrs.BufferImageAttributes.BackgroundColor == null)
                {
                    progressBarAttrs.BufferImageAttributes.BackgroundColor = new ColorSelector();
                }
                return progressBarAttrs.BufferImageAttributes.BackgroundColor.All;
            }
            set
            {
                if (progressBarAttrs.BufferImageAttributes.BackgroundColor == null)
                {
                    progressBarAttrs.BufferImageAttributes.BackgroundColor = new ColorSelector();
                }
                progressBarAttrs.BufferImageAttributes.BackgroundColor.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property to get/set the max value of the ProgressBar.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint? MaxValue
        {
            get
            {
                if (progressBarAttrs.MaxValue == null)
                {
                    progressBarAttrs.MaxValue = new uint();
                }
                return progressBarAttrs.MaxValue.Value;
            }
            set
            {
                if (progressBarAttrs.MaxValue == null)
                {
                    progressBarAttrs.MaxValue = new uint();
                }
                progressBarAttrs.MaxValue = value;
                UpdateValue();
            }
        }

        /// <summary>
        /// The property to get/set the min value of the ProgressBar.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint MinValue
        {
            get
            {
                if (progressBarAttrs.MinValue == null)
                {
                    progressBarAttrs.MinValue = new uint();
                }
                return progressBarAttrs.MinValue.Value;
            }
            set
            {
                if (progressBarAttrs.MinValue == null)
                {
                    progressBarAttrs.MinValue = new uint();
                }
                progressBarAttrs.MinValue = value;
                UpdateValue();
            }
        }

        /// <summary>
        /// The property to get/set the current value of the ProgressBar.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Throw when Current value is less than Min value, or greater than Max value.</exception>
        /// <example>
        /// <code>
        /// ProgressBar progress;
        /// progress.MaxValue = 100;
        /// progress.MinValue = 0;
        /// try
        /// {
        ///     progress.CurrentValue = 50;
        /// }
        /// catch(ArgumentOutOfRangeException e)
        /// {
        ///     Tizen.Log.Error(LogTag, "Failed to set Current value : " + e.Message);
        /// }
        /// </code>
        /// </example>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint? CurrentValue
        {
            get
            {
                if (progressBarAttrs.CurValue == null)
                {
                    progressBarAttrs.CurValue = new uint();
                }
                return progressBarAttrs.CurValue.Value;
            }
            set
            {
                if (progressBarAttrs.CurValue == null)
                {
                    progressBarAttrs.CurValue = new uint();
                }
                if (value > progressBarAttrs.MaxValue || value < progressBarAttrs.MinValue)
                {
                    return;
                }
                progressBarAttrs.CurValue = value;
                UpdateValue();
            }
        }

        /// <summary>
        /// The property to get/set the buffer value of the ProgressBar.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Throw when Buffer value is less than Min value, or greater than Max value.</exception>
        /// <example>
        /// <code>
        /// ProgressBar progress;
        /// progress.MaxValue = 100;
        /// progress.MinValue = 0;
        /// try
        /// {
        ///     progress.BufferValue = 50;
        /// }
        /// catch(ArgumentOutOfRangeException e)
        /// {
        ///     Tizen.Log.Error(LogTag, "Failed to set Buffer value : " + e.Message);
        /// }
        /// </code>
        /// </example>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint BufferValue
        {
            get
            {
                if (progressBarAttrs.BufferValue == null)
                {
                    progressBarAttrs.BufferValue = new uint();
                }
                return progressBarAttrs.BufferValue.Value;
            }
            set
            {
                if (progressBarAttrs.BufferValue == null)
                {
                    progressBarAttrs.BufferValue = new uint();
                }
                if (value > progressBarAttrs.MaxValue || value < progressBarAttrs.MinValue)
                {
                    return;
                }
                progressBarAttrs.BufferValue = value;
                UpdateValue();
            }
        }

        /// <summary>
        /// The property to get/set Direction of the ProgressBar.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ProgressStatusType? ProgressState
        {
            get
            {
                if (state != null)
                    return state.Value;
                else
                    return null;
            }
            set
            {
                state = value;
                UpdateStates();
            }
        }

        /// <summary>
        /// Dispose ProgressBar.
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
                if (trackObj != null)
                {
                    Remove(trackObj);
                    trackObj.Dispose();
                    trackObj = null;
                }

                if (progressObj != null)
                {
                    Remove(progressObj);
                    progressObj.Dispose();
                    progressObj = null;
                }

                if (bufferObj != null)
                {
                    Remove(bufferObj);
                    bufferObj.Dispose();
                    bufferObj = null;
                }

                if (loadingObj != null)
                {
                    Remove(loadingObj);
                    loadingObj.Dispose();
                    loadingObj = null;
                }

                ///if (aniForLoading != null)
                ///{
                ///    aniForLoading.Stop();
                ///    aniForLoading.Clear();
                ///    aniForLoading.Dispose();
                ///    aniForLoading = null;
                ///}

                ///if (aniForOpacity != null)
                ///{
                ///    aniForOpacity.Stop();
                ///    aniForOpacity.Clear();
                ///    aniForOpacity.Dispose();
                ///    aniForOpacity = null;
                ///}
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
            if (progressBarAttrs == null)
            {
                return;
            }

            ApplyAttributes(this, progressBarAttrs);
            ApplyAttributes(trackObj, progressBarAttrs.TrackImageAttributes);
            ApplyAttributes(progressObj, progressBarAttrs.ProgressImageAttributes);
            ApplyAttributes(loadingObj, progressBarAttrs.LoadingImageAttributes);
            ApplyAttributes(bufferObj, progressBarAttrs.BufferImageAttributes);
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            ProgressBarAttributes tempAttributes = StyleManager.Instance.GetAttributes(style) as ProgressBarAttributes;
            if (tempAttributes != null)
            {
                attributes = progressBarAttrs = tempAttributes;
                RelayoutRequest();
            }
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void UpdateStates()
        {
            if (state == ProgressStatusType.Buffering)
            {
                bufferObj.Show();
                loadingObj.Hide();
                progressObj.Hide();
            }
            else if (state == ProgressStatusType.Determinate)
            {
                bufferObj.Hide();
                loadingObj.Hide();
                progressObj.Show();
                UpdateValue();
            }
            else
            {
                bufferObj.Hide();
                loadingObj.Show();
                progressObj.Hide();
            }
            //if (aniForLoading != null)
            //{
            //    aniForLoading.Stop();
            //    aniForLoading.Clear();
            //}
            //if (aniForOpacity != null)
            //{
            //    aniForOpacity.Stop();
            //    aniForOpacity.Clear();
            //}
            //PlayLoadingAnimation();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void UpdateValue()
        {
            if (trackObj == null || progressObj == null ||
                (progressBarAttrs.MaxValue == null ||
                progressBarAttrs.MinValue == null ||
                progressBarAttrs.CurValue == null))
            {
                return;
            }

            int minVal = 0;
            if (progressBarAttrs.MinValue != null)
            {
                minVal = (int)progressBarAttrs.MinValue;
            }
            else
            {
                if (progressBarAttrs.MinValue != null)
                {
                    minVal = (int)progressBarAttrs.MinValue;
                }

            }
            int maxVal = 0;
            if (progressBarAttrs.MaxValue != null)
            {
                maxVal = (int)progressBarAttrs.MaxValue;
            }
            else
            {
                if (progressBarAttrs.MaxValue != null)
                {
                    maxVal = (int)progressBarAttrs.MaxValue;
                }
            }
            int curVal = 0;
            if (progressBarAttrs.CurValue != null)
            {
                curVal = (int)progressBarAttrs.CurValue;
            }
            else
            {
                if (progressBarAttrs.CurValue != null)
                {
                    curVal = (int)progressBarAttrs.CurValue;
                }
            }

            if (minVal >= maxVal || curVal < minVal || curVal > maxVal)
            {
                if (minVal >= maxVal)
                {
                    //TNLog.E("Min value >= Max value;");
                }
                if (curVal < minVal || curVal > maxVal)
                {
                    //TNLog.E("Current value < Min value || Current value > Max value;");
                }
                return;
            }

            float width = SizeWidth;
            float height = SizeHeight;

            float progressRatio = (float)curVal / (float)(maxVal - minVal);
            DirectionType dir = DirectionType.Horizontal;
            //if (progressBarAttrs.Direction != null)
            //{
            //    dir = direction.Value;
            //}
            //else
            //{
            //    if (direction != null)
            //    {
            //        dir = direction.Value;
            //    }
            //}

            if (dir == DirectionType.Horizontal)
            {
                float progressWidth = width * progressRatio;
                progressObj.Size2D = new Size2D((int)progressWidth, (int)height);
            }
            else
            {
                float progressHeight = height * progressRatio;
                progressObj.Size2D = new Size2D((int)width, (int)progressHeight);
            }

            if (bufferObj != null && (progressBarAttrs.BufferValue != null))
            {
                int bufVal = 0;
                if (progressBarAttrs.BufferValue != null)
                {
                    bufVal = (int)progressBarAttrs.BufferValue;
                }
                else
                {
                    bufVal = (int)progressBarAttrs.BufferValue;
                }
                if (bufVal < minVal || bufVal > maxVal)
                {
                    //TNLog.E("Buffer value < Min value || Buffer value > Max value;");
                    return;
                }

                float bufferRatio = (float)bufVal / (float)(maxVal - minVal);
                if (dir == DirectionType.Horizontal)
                {
                    float bufferWidth = width * bufferRatio;
                    bufferObj.Size2D = new Size2D((int)bufferWidth, (int)height);
                    //TNLog.I("bufferWidth = " + bufferWidth + ";");
                }
                else
                {
                    float bufferHeight = height * bufferRatio;
                    bufferObj.Size2D = new Size2D((int)width, (int)bufferHeight);
                    //TNLog.I("bufferHeight = " + bufferHeight + ";");
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new ProgressBarAttributes
            {
                TrackImageAttributes = new ImageAttributes
                {
                },
                ProgressImageAttributes = new ImageAttributes
                {
                },
                BufferImageAttributes = new ImageAttributes
                {
                },
                LoadingImageAttributes = new ImageAttributes
                {
                }

            };
        }
        private void Initialize()
        {
            // create necessary components
            InitializeTrack();
            InitializeBuffer();
            InitializeProgress();
            InitializeLoading();
        }

        private void InitializeTrack()
        {
            trackObj = new ImageView
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft
            };
            Add(trackObj);
        }

        private void InitializeProgress()
        {
            //TNLog.I("create progress object");
            progressObj = new ImageView
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft
            };
            Add(progressObj);
        }

        private void InitializeBuffer()
        {

            bufferObj = new ImageView
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft
            };
            Add(bufferObj);

        }

        private void InitializeLoading()
        {
            if (loadingObj == null)
            {
                loadingObj = new ImageView
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft
                };
                Add(loadingObj);
            }
        }

        private void InitializeAnimation()
        {
            //if (progressBarAttrs.style == ProgressStyle.WhiteBuffering || progressBarAttrs.style == ProgressStyle.BlackBuffering)
            //{
            //    if (aniForLoading == null)
            //    {
            //        //TNLog.I("create animation for loading");
            //        aniForLoading = new AnimationPlayer();
            //        aniForLoading.Looping = true;
            //    }
            //    if (aniForOpacity == null)
            //    {
            //        //TNLog.I("create animation for opacity");
            //        aniForOpacity = new AnimationPlayer();
            //    }
            //}
        }

        private void ApplyLoadingAnimation()
        {
            //InitializeLoading();
            InitializeAnimation();
            if (loadingObj == null)// || aniForLoading == null || aniForOpacity == null)
            {
                return;
            }

        }
    }
}
