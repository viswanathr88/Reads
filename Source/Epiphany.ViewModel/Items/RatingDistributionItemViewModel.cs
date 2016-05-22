namespace Epiphany.ViewModel.Items
{
    sealed class RatingDistributionItemViewModel : ViewModelBase, IRatingDistributionItemViewModel
    {
        private string header;
        private int value;

        public RatingDistributionItemViewModel(string header, int value)
        {
            Header = header;
            Value = value;
        }

        public string Header
        {
            get
            {
                return header;
            }
            private set
            {
                SetProperty(ref this.header, value);
            }
        }

        public int Value
        {
            get
            {
                return this.value;
            }
            private set
            {
                SetProperty(ref this.value, value);
            }
        }
    }
}
