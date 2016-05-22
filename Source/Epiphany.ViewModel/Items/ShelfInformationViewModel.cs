using System;
using Epiphany.Model;
using Windows.UI;

namespace Epiphany.ViewModel.Items
{
    sealed class ShelfInformationViewModel : ItemViewModel<ShelfInformation>, IShelfInformationViewModel
    {
        private Color background;
        private Color foreground;

        public ShelfInformationViewModel(ShelfInformation item) : base(item)
        {

        }

        public Color Color
        {
            get
            {
                return this.background;
            }

            set
            {
                SetProperty(ref this.background, value);
                Foreground = GenerateForegroundColor(this.background);
            }
        }

        public int Count
        {
            get
            {
                return Item.Count;
            }
        }

        public Color Foreground
        {
            get
            {
                return this.foreground;
            }
            private set
            {
                SetProperty(ref this.foreground, value);
            }
        }

        public string Name
        {
            get
            {
                return Item.Name;
            }
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
