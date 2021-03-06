﻿using Epiphany.Model;
using Epiphany.ViewModel.Items;
using Epiphany.ViewModel.Services;

namespace Epiphany.ViewModel.Commands
{
    sealed class ShowBookCommand : Command<BookModel>
    {
        private readonly INavigationService navService;

        public ShowBookCommand(INavigationService navService)
        {
            this.navService = navService;
        }

        public override bool CanExecute(BookModel book)
        {
            return book.Id >= 0;
        }

        protected override void Run(BookModel book)
        {
            /*this.navService.CreateFor<BookViewModel>()
                .AddParam<int>((x) => x.Id, book.Id)
                .AddParam<string>((x) => x.Title, book.Title)
                .Navigate();*/
        }
    }

    sealed class ShowBookFromItemCommand : Command<IBookItemViewModel>
    {
        private readonly INavigationService navService;

        public ShowBookFromItemCommand(INavigationService navService)
        {
            this.navService = navService;
        }

        public override bool CanExecute(IBookItemViewModel book)
        {
            return book.Id >= 0;
        }

        protected override void Run(IBookItemViewModel book)
        {
            /*this.navService.CreateFor<BookViewModel>()
                .AddParam<int>((x) => x.Id, book.Id)
                .AddParam<string>((x) => x.Title, book.Title)
                .Navigate();*/
        }
    }

}
