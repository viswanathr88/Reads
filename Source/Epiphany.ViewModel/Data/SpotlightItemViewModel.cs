using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public sealed class SpotlightItemViewModel : ViewModelBase
    {
        private string authorName;
        private string authorImage;
        private string quote;

        public string Name
        {
            get
            {
                return this.authorName;
            }
            set
            {
                SetProperty<string>(ref this.authorName, value);
            }
        }

        public string Image
        {
            get
            {
                return this.authorImage;
            }
            set
            {
                SetProperty<string>(ref this.authorImage, value);
            }
        }

        public string Quote
        {
            get
            {
                return this.quote;
            }
            set
            {
                SetProperty<string>(ref this.quote, value);
            }
        }
    }
}
