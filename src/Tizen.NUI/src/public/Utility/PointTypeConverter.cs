/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System.Globalization;
using System.Diagnostics;

namespace Tizen.NUI
{
    /// <summary>
    /// Default PointTypeConverter class to convert point types.
    /// </summary>
    /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class PointTypeConverter : GraphicsTypeConverter
    {
        private volatile static PointTypeConverter ptTypeConverter;
        private const ushort pointDpi = 72;

        /// <summary>
        /// An unique Singleton Instance of PointTypeConverter.
        /// </summary>
        /// <value>Singleton instance of PointTypeConverter</value>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PointTypeConverter Instance
        {
            get
            {
                if (ptTypeConverter == null)
                {
                    ptTypeConverter = new PointTypeConverter();
                }

                return ptTypeConverter;
            }
        }

        /// <summary>
        /// Converts script to pixel.
        /// </summary>
        /// <returns>Pixel value that is converted from input string</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float ConvertScriptToPixel(string scriptValue)
        {
            float convertedValue = 0;
            if (scriptValue != null)
            {
                if (scriptValue.EndsWith("pt"))
                {
                    convertedValue = ConvertToPixel(float.Parse(scriptValue.Substring(0, scriptValue.LastIndexOf("pt")), CultureInfo.InvariantCulture));
                }
                else if (scriptValue.EndsWith("px"))
                {
                    convertedValue = float.Parse(scriptValue.Substring(0, scriptValue.LastIndexOf("px")), CultureInfo.InvariantCulture);
                }
                else
                {
                    if (!float.TryParse(scriptValue, NumberStyles.Any, CultureInfo.InvariantCulture, out convertedValue))
                    {
                        NUILog.Error("Cannot convert the script {scriptValue}\n");
                        convertedValue = 0;
                    }
                }
            }
            return convertedValue;
        }

        /// <summary>
        /// Converts script to pixel.
        /// </summary>
        /// <returns>Pixel value that is converted from input string</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ConvertScriptToPoint(string scriptValue)
        {
            float convertedValue = 0;
            if (scriptValue != null)
            {
                if (scriptValue.EndsWith("sp"))
                {
                    convertedValue = ConvertSpToPoint(float.Parse(scriptValue.Substring(0, scriptValue.LastIndexOf("sp")), CultureInfo.InvariantCulture));
                }
                else if (scriptValue.EndsWith("sdp"))
                {
                    convertedValue = ConvertSdpToPoint(float.Parse(scriptValue.Substring(0, scriptValue.LastIndexOf("sdp")), CultureInfo.InvariantCulture));
                }
                else if (scriptValue.EndsWith("dp"))
                {
                    convertedValue = ConvertDpToPoint(float.Parse(scriptValue.Substring(0, scriptValue.LastIndexOf("dp")), CultureInfo.InvariantCulture));
                }
                else if (scriptValue.EndsWith("pt"))
                {
                    convertedValue = float.Parse(scriptValue.Substring(0, scriptValue.LastIndexOf("px")), CultureInfo.InvariantCulture);
                }
                else
                {
                    if (!float.TryParse(scriptValue, NumberStyles.Any, CultureInfo.InvariantCulture, out convertedValue))
                    {
                        NUILog.Error("Cannot convert the script {scriptValue}\n");
                        convertedValue = 0;
                    }
                }
            }
            return convertedValue;
        }

        /// <summary>
        /// Converts point type to pixel.
        /// </summary>
        /// <returns>Pixel value that is converted by the the display matric</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float ConvertToPixel(float value)
        {
            return value * (GraphicsTypeManager.Instance.ScaledDpi / (float)pointDpi);
        }

        /// <summary>
        /// Converts pixel to point type.
        /// </summary>
        /// <returns>An converted value from pixel</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float ConvertFromPixel(float value)
        {
            return value * ((float)pointDpi / (float)GraphicsTypeManager.Instance.ScaledDpi);
        }

        /// <summary>
        /// Converts dp type to point type.
        /// </summary>
        /// <returns>Point value that is converted from dp.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ConvertDpToPoint(float value)
        {
            return value * ((float)pointDpi / (float)GraphicsTypeManager.Instance.BaselineDpi);
        }

        /// <summary>
        /// Converts point type to dp type.
        /// </summary>
        /// <returns>Dp value that is converted from point.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ConvertPointToDp(float value)
        {
            return value * ((float)GraphicsTypeManager.Instance.BaselineDpi / (float)pointDpi);
        }

        /// <summary>
        /// Converts sdp type to point type.
        /// </summary>
        /// <returns>Point value that is converted from sdp.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ConvertSdpToPoint(float value)
        {
            float scale = GraphicsTypeManager.Instance.ScalingFactor;
            if (scale <= 0) scale = 1;
            return value * ((float)pointDpi / (float)GraphicsTypeManager.Instance.BaselineDpi) * scale;
        }

        /// <summary>
        /// Converts point type to sdp type.
        /// </summary>
        /// <returns>Sdp value that is converted from point.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ConvertPointToSdp(float value)
        {
            float scale = GraphicsTypeManager.Instance.ScalingFactor;
            if (scale <= 0) scale = 1;
            return value * ((float)GraphicsTypeManager.Instance.BaselineDpi / (float)pointDpi) / scale;
        }

        /// <summary>
        /// Converts sp type to point type.
        /// </summary>
        /// <returns>Point value that is converted from dp.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API13")]
        public float ConvertSpToPoint(float value)
        {
            float scale = GraphicsTypeManager.Instance.ScalingFactor;
            if (scale <= 0) scale = 1;
            return value * ((float)pointDpi / (float)GraphicsTypeManager.Instance.BaselineDpi) * scale;
        }

        /// <summary>
        /// Converts point type to sp type.
        /// </summary>
        /// <returns>Sp value that is converted from point.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API13")]
        public float ConvertPointToSp(float value)
        {
            float scale = GraphicsTypeManager.Instance.ScalingFactor;
            if (scale <= 0) scale = 1;
            return value * ((float)GraphicsTypeManager.Instance.BaselineDpi / (float)pointDpi) / scale;
        }
    }
}
