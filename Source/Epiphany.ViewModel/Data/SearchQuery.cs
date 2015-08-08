using Epiphany.Model.Services;
using System;
using System.ComponentModel;

namespace Epiphany.ViewModel
{
    public class SearchQuery : INotifyPropertyChanged, IEquatable<SearchQuery>
    {
        private string term;
        private BookSearchType type;
        
        public event PropertyChangedEventHandler PropertyChanged;

        public SearchQuery(string term, BookSearchType type)
        {
            this.term = term;
            this.type = type;
        }

        public string Term
        {
            get { return this.term; }

        }

        public BookSearchType Type
        {
            get { return this.type; }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool Equals(SearchQuery other)
        {
            if (this.term == other.term && this.type == other.type)
                return true;
            else
                return false;
        }
    }
}
