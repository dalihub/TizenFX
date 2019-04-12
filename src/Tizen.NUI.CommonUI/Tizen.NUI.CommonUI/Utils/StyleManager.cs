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

namespace Tizen.NUI.CommonUI
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class StyleManager
    {
        private string theme = "default";
        private Dictionary<string, Dictionary<string, Type>> ThemeStyleSet = new Dictionary<string, Dictionary<string, Type>>();
        private Dictionary<string, Type> DefaultStyleSet = new Dictionary<string, Type>();
        private EventHandler<ThemeChangeEventArgs> themeChangeHander;

        private StyleManager()
        {
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ThemeChangeEventArgs> ThemeChangedEvent
        {
            add
            {
                themeChangeHander += value;
            }
            remove
            {
                themeChangeHander -= value;
            }
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StyleManager Instance { get; } = new StyleManager();
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Theme
        {
            get
            {
                return theme;
            }

            set
            {
                if (theme != value)
                {
                    theme = value;
                    themeChangeHander?.Invoke(null, new ThemeChangeEventArgs { CurrentTheme = theme });
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterStyle(string style, string theme, Type styleType, bool bDefault = false)
        {
            if (style == null)
            {
                throw new InvalidOperationException($"style can't be null");
            }

            if (theme == null || bDefault == true)
            {
                if (DefaultStyleSet.ContainsKey(style))
                {
                    throw new InvalidOperationException($"{style}] already be used");
                }
                else
                {
                    DefaultStyleSet.Add(style, styleType);
                }
                return;
            }

            if (ThemeStyleSet.ContainsKey(style) && ThemeStyleSet[style].ContainsKey(theme))
            {
                throw new InvalidOperationException($"{style}] already be used");
            }
            if (!ThemeStyleSet.ContainsKey(style))
            {
                ThemeStyleSet.Add(style, new Dictionary<string, Type>());
            }
            ThemeStyleSet[style].Add(theme, styleType);
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Attributes GetAttributes(string style)
        {
            if (style == null)
            {
                return null;
            }
            object obj = null;

            if (ThemeStyleSet.ContainsKey(style) && ThemeStyleSet[style].ContainsKey(Theme))
            {
                obj = Activator.CreateInstance(ThemeStyleSet[style][Theme]);
            }
            else if (DefaultStyleSet.ContainsKey(style))
            {
                obj = Activator.CreateInstance(DefaultStyleSet[style]);
            }

            return (obj as StyleBase)?.GetAttributes();
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ThemeChangeEventArgs : EventArgs
        {
            public string CurrentTheme;
        }
    }
}
