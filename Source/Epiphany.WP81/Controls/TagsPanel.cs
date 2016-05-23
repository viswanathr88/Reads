using Epiphany.Logging;
using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Epiphany.View.Controls
{
    public class TagsPanel : Panel
    {
        private IList<UIElement> rowList;

        public TagsPanel()
        {
            this.rowList = new List<UIElement>();
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            if (Children.Count == 0)
            {
                return base.MeasureOverride(availableSize);
            }

            var finalSize = new Size { Width = availableSize.Width };

            double width = 0;
            double height = 0;
            double rowHeight = 0;

            foreach (var child in Children)
            {
                child.Measure(availableSize);

                if (width + child.DesiredSize.Width > availableSize.Width)
                {
                    height += rowHeight;
                    rowHeight = child.DesiredSize.Height;
                    width = child.DesiredSize.Width;
                }
                else
                {
                    rowHeight = Math.Max(child.DesiredSize.Height, rowHeight);
                    width += child.DesiredSize.Width;
                }
            }

            if (rowHeight != 0)
            {
                height += rowHeight;
            }

            finalSize.Height = height;

            return finalSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            if (Children.Count == 0)
            {
                return base.ArrangeOverride(finalSize);
            }

            Rect rect = new Rect(0, 0, finalSize.Width, finalSize.Height);

            double width = 0;
            double height = 0;

            foreach (var child in Children)
            {
                if (width + child.DesiredSize.Width <= finalSize.Width)
                {
                    rowList.Add(child);
                    width += child.DesiredSize.Width;
                    height = Math.Max(height, child.DesiredSize.Height);
                }
                else
                {
                    // Space that needs to be distributed equally to children in row
                    double spaceAvailableInRow = finalSize.Width - width;
                    ArrangeRow(spaceAvailableInRow, ref rect, ref height);

                    // Add the new child
                    rowList.Add(child);
                    width = child.DesiredSize.Width;
                    height = child.DesiredSize.Height;
                }
            }

            // Arrange the last row if any
            ArrangeRow(finalSize.Width - width, ref rect, ref height);

            return finalSize;
        }

        private void ArrangeRow(double spaceAvailableInRow, ref Rect rect, ref double height)
        {
            if (rowList.Count == 0)
            {
                // Nothing to arrange
                return;
            }

            double spacePerChildInRow = spaceAvailableInRow / rowList.Count;
            
            // Arrange all children in the row
            foreach (var child in rowList)
            {
                rect.Width = child.DesiredSize.Width + spacePerChildInRow;
                rect.Height = height;

                child.Arrange(rect);

                rect.X += rect.Width;
            }

            rowList.Clear();
            rect.X = 0;
            rect.Y += height;
        }
    }
}
