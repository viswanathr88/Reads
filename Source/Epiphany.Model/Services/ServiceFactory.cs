using Epiphany.Model.Messaging;
using Epiphany.Model.Web;
using System;

namespace Epiphany.Model.Services
{
    public sealed class ServiceFactory
    {
        private readonly IWebClient webClient;
        private readonly IMessenger messenger;
        private readonly IAuthService authService;

        private ILogonService logonService;
        private IAuthorService authorService;
        private IBookService bookService;
        private IBookshelfService bookshelfService;
        private IReviewService reviewService;
        private IGroupService groupService;
        private IEventService eventService;
        private INotificationService notificationService;
        private IUserService userService;
        private IStatusService statusService;

        public ServiceFactory(IAuthService authService)
        {
            if (authService == null)
            {
                throw new ArgumentNullException();
            }

            this.authService = authService;

            if ((this.webClient = authService.GetAuthCapableWebClient()) == null)
            {
                throw new ArgumentNullException("webClient");
            }

            this.messenger = Messenger.Instance;
            //
            // set up all the services
            //
            this.logonService = new LogonService(this.authService, this.messenger);
            
            IAuthorService authorService = new AuthorService(this.webClient, this.messenger);
            this.authorService = new CachedAuthorService(authorService, this.messenger);
            
            IBookService bookService = new BookService(this.webClient, messenger);
            this.bookService = new CachedBookService(bookService, messenger);
            
            IBookshelfService bookshelfService = new BookshelfService(this.webClient, this.messenger);
            this.bookshelfService = new CachedBookshelfService(bookshelfService, messenger);
            
            IReviewService reviewService = new ReviewService(this.webClient, this.messenger);
            this.reviewService = new CachedReviewService(reviewService, messenger);
            
            IUserService userService = new UserService(this.webClient, this.messenger);
            this.userService = new CachedUserService(userService, messenger);

            this.groupService = new GroupService(this.webClient);
            this.eventService = new EventService(this.webClient);
            this.notificationService = new NotificationService(this.webClient);
            this.statusService = new StatusService(this.webClient);
        }

        public ILogonService GetLogonService()
        {
            return this.logonService;
        }

        public IAuthorService GetAuthorService()
        {
            return this.authorService;
        }

        public IBookService GetBookService()
        {
            return this.bookService;
        }

        public IBookshelfService GetBookshelfService()
        {
            return this.bookshelfService;
        }

        public IEventService GetEventService()
        {
            return this.eventService;
        }

        public IGroupService GetGroupService()
        {
            return this.groupService;
        }

        public INotificationService GetNotificationService()
        {
            return this.notificationService;
        }

        public IReviewService GetReviewService()
        {
            return this.reviewService;
        }

        public IStatusService GetStatusService()
        {
            return this.statusService;
        }

        public IUserService GetUserService()
        {
            return this.userService;
        }
    }
}
