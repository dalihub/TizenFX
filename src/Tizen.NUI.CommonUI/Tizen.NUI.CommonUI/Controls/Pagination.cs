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
    public class Pagination : Control
    {
        protected VisualView container;
        protected ImageVisual selectIndicator;

        private int indicatorCount = 0;
        private int selectedIndex = -1;

        private List<ImageVisual> indicatorList = new List<ImageVisual>();

        private PaginationAttributes paginationAttributes;

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Pagination() : base()
        {
            Initialize();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Pagination(string style) : base(style)
        {
            Initialize();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Pagination(PaginationAttributes attributes) : base()
        {
            this.attributes = attributes.Clone() as PaginationAttributes;
            Initialize();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D IndicatorSize
        {
            get
            {
                return (Size2D)paginationAttributes?.IndicatorSize;
            }
            set
            {
                if (value == null || paginationAttributes == null)
                {
                    return;
                }
                paginationAttributes.IndicatorSize = value;
                RelayoutRequest();
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string IndicatorBackgroundURL
        {
            get
            {
                return (string)paginationAttributes?.IndicatorBackgroundURL;
            }
            set
            {
                if (value == null || paginationAttributes == null)
                {
                    return;
                }
                paginationAttributes.IndicatorBackgroundURL = value;
                RelayoutRequest();
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string IndicatorSelectURL
        {
            get
            {
                return (string)paginationAttributes?.IndicatorSelectURL;
            }
            set
            {
                if (value == null || paginationAttributes == null)
                {
                    return;
                }
                paginationAttributes.IndicatorSelectURL = value;
                RelayoutRequest();
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int IndicatorSpacing
        {
            get
            {
                return (int)paginationAttributes?.IndicatorSpacing;
            }
            set
            {
                if (paginationAttributes == null)
                {
                    return;
                }
                paginationAttributes.IndicatorSpacing = value;
                RelayoutRequest();
            }
        }


        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int IndicatorCount
        {
            get
            {
                return indicatorCount;
            }
            set
            {
                if (indicatorCount == value)
                {
                    return;
                }
                if (indicatorCount < value)
                {
                    for (int i = indicatorCount; i < value; i++)
                    {
                        CreateIndicator();
                    }
                }
                else
                {
                    for (int i = value; i < indicatorCount; i++)
                    {
                        ImageVisual indicator = indicatorList[i];
                        container.RemoveVisual("Indicator" + i);
                    }
                    indicatorList.RemoveRange(value, indicatorCount - value);
                }
                indicatorCount = value;

                UpdateContainer();
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                if (selectedIndex == value)
                {
                    return;
                }
                if (selectedIndex >= 0 && selectedIndex < indicatorCount)
                {
                    SelectOut(indicatorList[selectedIndex]);
                }
                selectedIndex = value;
                if (selectedIndex >= 0 && selectedIndex < indicatorCount)
                {
                    SelectIn(indicatorList[selectedIndex]);
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void SelectOut(VisualMap selectOutIndicator)
        {

        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void SelectIn(VisualMap selectInIndicator)
        {
            selectIndicator.Position = selectInIndicator.Position;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new PaginationAttributes();
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
                container.RemoveAll();
                indicatorList.Clear();

                this.Remove(container);
                container.Dispose();
                container = null;
            }

            base.Dispose(type);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate(Attributes attributtes)
        {
            paginationAttributes = attributes as PaginationAttributes;
            if (paginationAttributes == null)
            {
                return;
            }

            for (int i = 0; i < indicatorList.Count; i++)
            {
                ImageVisual indicator = indicatorList[i];
                indicator.URL = paginationAttributes.IndicatorBackgroundURL;
                indicator.Size = paginationAttributes.IndicatorSize;
                indicator.Position = new Position2D((int)(paginationAttributes.IndicatorSize.Width + paginationAttributes.IndicatorSpacing) * i, 0);
            }

            selectIndicator.URL = paginationAttributes.IndicatorSelectURL;
            selectIndicator.Size = paginationAttributes.IndicatorSize;

            //UpdateContainer();
        }

        private void Initialize()
        {
            container = new VisualView()
            {
                Name = "Container",
                ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                PositionUsesPivotPoint = true,
                //BackgroundColor = Color.Yellow
            };
            this.Add(container);

            selectIndicator = new ImageVisual()
            {
                URL = " "
            };
            container.AddVisual("SelectIndicator", selectIndicator);

            paginationAttributes = attributes as PaginationAttributes;
            if (paginationAttributes == null)
            {
                throw new Exception("Pagination attributes is null.");
            }
        }

        private void CreateIndicator()
        {
            if (paginationAttributes == null)
            {
                return;
            }
            ImageVisual indicator = new ImageVisual
            {
                URL = paginationAttributes.IndicatorBackgroundURL,
                Size = paginationAttributes.IndicatorSize
            };
            indicator.Position = new Position2D((int)(paginationAttributes.IndicatorSize.Width + paginationAttributes.IndicatorSpacing) * indicatorList.Count, 0);
            container.AddVisual("Indicator" + indicatorList.Count, indicator);
            indicatorList.Add(indicator);
        }

        private void UpdateContainer()
        {
            if (paginationAttributes == null)
            {
                return;
            }
            if (indicatorList.Count > 0)
            {
                container.SizeWidth = (paginationAttributes.IndicatorSize.Width + paginationAttributes.IndicatorSpacing) * indicatorList.Count - paginationAttributes.IndicatorSpacing;
            }
            else
            {
                container.SizeWidth = 0;
            }
            container.SizeHeight = paginationAttributes.IndicatorSize.Height;
            container.PositionX = (int)((this.SizeWidth - container.SizeWidth) / 2);
        }
    }
}
