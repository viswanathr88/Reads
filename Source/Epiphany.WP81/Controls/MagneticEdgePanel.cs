using Epiphany.Logging;
using System;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace Epiphany.View.Controls
{
    public sealed class MagneticEdgePanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            if (Children.Count == 0)
            {
                base.MeasureOverride(availableSize);
            }

            double sumX = 0.0;
            double maxY = 0.0;

            Logger.LogDebug("Children Count = " + Children.Count);

            foreach (var child in Children)
            {
                if (child.Visibility == Windows.UI.Xaml.Visibility.Visible)
                {
                    child.Measure(new Size(Math.Max(availableSize.Width - sumX, 0.0), availableSize.Height));
                    sumX += child.DesiredSize.Width;
                    maxY = Math.Max(maxY, child.DesiredSize.Height);
                }
            }

            Size finalSize = new Size(availableSize.Width, maxY);
            Logger.LogDebug("Final Size = " + finalSize);

            return finalSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            if (Children.Count == 0)
            {
                return base.MeasureOverride(finalSize);
            }

            // Count the total size needed for all children
            double childrenSize = 0.0;
            int visibleChildren = 0;
            foreach (var child in Children)
            {
                if (child.Visibility == Windows.UI.Xaml.Visibility.Visible)
                {
                    childrenSize += child.DesiredSize.Width;
                    visibleChildren++;
                }
            }

            double totalEmptySpace = Math.Max(0.0, finalSize.Width - childrenSize);
            double spaceBetweenChildren = totalEmptySpace / Math.Max(1, visibleChildren - 1);

            double x = 0;
            foreach (var child in Children)
            {
                if (child.Visibility == Windows.UI.Xaml.Visibility.Visible)
                {
                    double width = child.DesiredSize.Width;
                    double height = Math.Max(child.DesiredSize.Height, finalSize.Height);
                    child.Arrange(new Rect(x, 0.0, width, height));
                    x += width + spaceBetweenChildren;
                }
            }

            return finalSize;
        }
    }
}
