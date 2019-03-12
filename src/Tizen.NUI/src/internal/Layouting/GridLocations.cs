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

using System;
using System.Collections.Generic;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] This internal class houses the algorithm for computing the locations and size of cells.
    /// A Grid layout uses two instances of this class
    /// distinguished by the "horizontal" flag which is true for the horizontal axis and false
    /// for the vertical one.
    /// </summary>
    internal class GridLocations
    {
        const uint Horizontal = 0;
        const uint Vertical = 1;

        public struct Cell
        {
            public int Start;
            public int End;
            public int Top;
            public int Bottom;

            public Cell( int x1, int x2, int y1, int y2)
            {
              Start = x1;
              End = x2;
              Top = y1;
              Bottom = y2;
            }
        };

        private  List<Cell>_locationsVector;

        /// <summary>
        /// [Draft]Constructor
        /// </summary>
        public GridLocations()
        {
            _locationsVector = new List<Cell>();
        }

        /// <summary>
        /// Get locations vector with position of each cell and cell size.
        /// </summary>
        public List<Cell> GetLocations()
        {
            return _locationsVector;
        }


        /// <summary>
        /// [Draft] Uses the given parameters to calculate the x,y coordinates of each cell and cell size.
        /// </summary>
        public void CalculateLocations( int numberOfColumns, int availableWidth,
                                        int availableHeight, int numberOfCells)
        {
            numberOfColumns = Math.Max( numberOfColumns, 1 );
            _locationsVector.Clear();

            // Calculate width and height of columns and rows.

            // Calculate numbers of rows, round down result as later check for remainder.
            int remainder = 0;
            int numberOfRows = Math.DivRem(numberOfCells,numberOfColumns, out remainder);
            // If number of cells not cleanly dividable by columns, add another row to house remainder cells.
            numberOfRows += (remainder > 0) ? 1:0;

            // Rounding on column widths performed here, if noticable can divide the space expliclty between columns.
            int columnWidth = availableWidth / numberOfColumns;

            int rowHeight = availableHeight;

            if( numberOfRows > 0 )
            {
                // Column height supplied so use this unless exceeds available height.
                rowHeight = (availableHeight / numberOfRows);
            }

            Log.Info("NUI", "ColumnWidth[" + columnWidth + "] RowHeight[" +rowHeight + "] NumberOfRows["
                            + numberOfRows + "] NumberOfColumns[" + numberOfColumns +"]\n");

            int  y1 = 0;
            int  y2 = y1 + rowHeight;

            // Calculate start, end, top and bottom coordinate of each cell.

            // Iterate rows
            for( var i = 0u; i < numberOfRows; i++ )
            {
                int x1 = 0;
                int x2 = x1 + columnWidth;

                // Iterate columns
                for( var j = 0; j < numberOfColumns; j++ )
                {
                    Cell cell = new Cell( x1, x2, y1, y2 );
                    _locationsVector.Add( cell );
                    // Calculate starting x and ending x position of each column
                    x1 = x2;
                    x2 = x2 + columnWidth;
                }

                // Calculate top y and bottom y position of each row.
                y1 = y2;
                y2 = y2 + rowHeight;
            }
        }


    }
}
