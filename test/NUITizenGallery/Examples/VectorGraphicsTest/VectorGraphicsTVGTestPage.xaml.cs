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

using System.Drawing;
using System.Threading;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents.VectorGraphics;

namespace NUITizenGallery
{
    public partial class VectorGraphicsTVGTestPage : ContentPage
    {
        public static readonly string ImagePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/test.tvg";

        public VectorGraphicsTVGTestPage()
        {
            InitializeComponent();

            imageView.SetImage(ImagePath);
        }
    }
}
