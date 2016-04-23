using Epiphany.Logging;
using System;
using System.Diagnostics;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace Epiphany.View.Controls
{
    public class HorizontalStretchPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            Logger.LogDebug("Available Size = " + availableSize);

            if (Children.Count == 0)
            {
                return base.MeasureOverride(availableSize);
            }

            var finalSize = new Size { Width = availableSize.Width };
            availableSize.Width = availableSize.Width / Children.Count;

            foreach (var child in Children)
            {
                Logger.LogDebug("Child size = " + availableSize);
                child.Measure(availableSize);
                finalSize.Height = Math.Max(child.DesiredSize.Height, finalSize.Height);
                Logger.LogDebug("Final Size = " + finalSize);
            }

            if (double.IsPositiveInfinity(finalSize.Height) || double.IsPositiveInfinity(finalSize.Width))
            {
                return Size.Empty;
            }

            return finalSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            Logger.LogDebug("Final Size = " + finalSize);
            var rect = new Rect(0, 0, finalSize.Width, finalSize.Height);
            var width = finalSize.Width / Children.Count;

            foreach (var child in Children)
            {
                rect.Width = width;
                rect.Height = Math.Max(child.DesiredSize.Height, finalSize.Height);

                Logger.LogDebug("Child rect = " + rect);
                child.Arrange(rect);
                rect.X += width;
            }

            return finalSize;
        }
    }
}
