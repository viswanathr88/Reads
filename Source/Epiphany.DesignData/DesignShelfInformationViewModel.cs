using Epiphany.ViewModel.Items;
using System;
using System.IO;
using Windows.UI;

namespace Epiphany.View.DesignData
{
    public sealed class DesignShelfInformationViewModel : IShelfInformationViewModel
    {
        public DesignShelfInformationViewModel()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            Count = random.Next(1, 100);
            Name = Path.GetRandomFileName();

            Color = Color.FromArgb(255, (byte)random.Next(255), (byte)random.Next(255), (byte)random.Next(255));
            Foreground = GenerateForegroundColor(Color);
        }

        public Color Color
        {
            get;
            set;
        }

        public int Count
        {
            get;
            set;
        }

        public Color Foreground
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        private Color GenerateForegroundColor(Color color)
        {
            // Counting the perceptive luminance - human eye favors green color... 
            double luminance = 1 - (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;

            if (luminance < 0.5)
                return Color.FromArgb(255, 0, 0, 0); // bright colors - black font
            else
                return Color.FromArgb(255, 255, 255, 255); // dark colors - white font
        }
    }
}
