using Epiphany.ViewModel.Services;
using System.Collections.ObjectModel;

namespace Epiphany.ViewModel
{
    public sealed class SpotlightViewModel : ViewModelBase
    {
        private readonly ObservableCollection<SpotlightItemViewModel> items;
        private readonly ITimer timer;
        private int selectedIndex = 0;

        public SpotlightViewModel(ITimerService timerService)
        {
            this.items = new ObservableCollection<SpotlightItemViewModel>();

            LoadItems();

            this.timer = timerService.CreateTimer(OnTimeout);
            this.timer.Interval = new System.TimeSpan(0, 0, 4);
            this.timer.Start();
        }

        public ObservableCollection<SpotlightItemViewModel> Items
        {
            get
            {
                return this.items;
            }
        }

        public int SelectedIndex
        {
            get
            {
                return this.selectedIndex;
            }
            set
            {
                SetProperty(ref this.selectedIndex, value);
            }
        }

        private void LoadItems()
        {
            Items.Add(new SpotlightItemViewModel()
            {
                Image = "http://d.gr-assets.com/photos/1409121298p8/1048053.jpg",
                Name = "J.K. Rowling",
                Quote = "If you want to know what a man's like, take a good look at how he treats his inferiors, not his equals."
            });

            Items.Add(new SpotlightItemViewModel()
            {
                Image = "http://d.gr-assets.com/authors/1183232004p8/7715.jpg",
                Name = "Robert Frost",
                Quote = "In three words I can sum up everything I've learned about life: it goes on."
            });

            Items.Add(new SpotlightItemViewModel()
            {
                Image = "http://d.gr-assets.com/authors/1356810912p8/5810891.jpg",
                Name = "Mahatma Gandhi",
                Quote = "Be the change that you wish to see in the world."
            });

            Items.Add(new SpotlightItemViewModel()
            {
                Image = "http://d.gr-assets.com/authors/1429114964p8/9810.jpg",
                Name = "Albert Einstein",
                Quote = "Two things are infinite: the universe and human stupidity; and I'm not sure about the universe."
            });

            Items.Add(new SpotlightItemViewModel()
            {
                Image = "http://d.gr-assets.com/authors/1357460488p8/3565.jpg",
                Name = "Oscar Wilde",
                Quote = "Be yourself; everyone else is already taken."
            });

            Items.Add(new SpotlightItemViewModel()
            {
                Image = "http://d.gr-assets.com/authors/1436929110p8/82952.jpg",
                Name = "Marilyn Monroe",
                Quote = "I'm selfish, impatient and a little insecure. I make mistakes, I am out of control and at times hard to handle. But if you can't handle me at my worst, then you sure as hell don't deserve me at my best."
            });

            Items.Add(new SpotlightItemViewModel()
            {
                Image = "http://d.gr-assets.com/authors/1322103868p8/1244.jpg",
                Name = "Mark Twain",
                Quote = "If you tell the truth, you don't have to remember anything."
            });
        }

        private void OnTimeout()
        {
            int currentIndex = SelectedIndex;
            SelectedIndex = ++currentIndex % Items.Count;
        }
    }
}
