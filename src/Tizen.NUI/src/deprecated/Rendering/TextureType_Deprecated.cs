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

namespace Tizen.NUI
{
    /// <summary>
    /// The TextureType enumeration defines the types of textures.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum TextureType
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores
        /// <summary>
        /// One 2D image
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        TEXTURE_2D,
        /// <summary>
        /// Six 2D images arranged in a cube-shape
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        TEXTURE_CUBE
#pragma warning restore CA1707 // Identifiers should not contain underscores
    }
}
