using  System;
using  System.Runtime.CompilerServices;
using  Etg.SimpleStubs;
using System.Threading.Tasks;
using Epiphany.Model.Authentication;
using Epiphany.Web;
using Epiphany.Model.Collections;
using System.Collections.Generic;

namespace Epiphany.Model.Collections
{
    [CompilerGenerated]
    public class StubIAsyncEnumerable<T> : IAsyncEnumerable<T>
    {
        private readonly StubContainer<StubIAsyncEnumerable<T>> _stubs = new StubContainer<StubIAsyncEnumerable<T>>();

        public MockBehavior MockBehavior { get; set; }

        global::Epiphany.Model.Collections.IAsyncEnumerator<T> global::Epiphany.Model.Collections.IAsyncEnumerable<T>.GetEnumerator()
        {
            GetEnumerator_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetEnumerator_Delegate>("GetEnumerator");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetEnumerator_Delegate>("GetEnumerator", out del))
                {
                    return default(global::Epiphany.Model.Collections.IAsyncEnumerator<T>);
                }
            }

            return del.Invoke();
        }

        public delegate global::Epiphany.Model.Collections.IAsyncEnumerator<T> GetEnumerator_Delegate();

        public StubIAsyncEnumerable<T> GetEnumerator(GetEnumerator_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public event global::System.EventHandler<global::System.EventArgs> Reset;

        protected void On_Reset(object sender, global::System.EventArgs args)
        {
            global::System.EventHandler<global::System.EventArgs> handler = Reset;
            if (handler != null) { handler(sender, args); }
        }

        public void Reset_Raise(object sender, global::System.EventArgs args)
        {
            On_Reset(sender, args);
        }

        public StubIAsyncEnumerable(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}

namespace Epiphany.Model.Collections
{
    [CompilerGenerated]
    public class StubIAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly StubContainer<StubIAsyncEnumerator<T>> _stubs = new StubContainer<StubIAsyncEnumerator<T>>();

        public MockBehavior MockBehavior { get; set; }

        T global::Epiphany.Model.Collections.IAsyncEnumerator<T>.Current
        {
            get
            {
                {
                    Current_Get_Delegate del;
                    if (MockBehavior == MockBehavior.Strict)
                    {
                        del = _stubs.GetMethodStub<Current_Get_Delegate>("get_Current");
                    }
                    else
                    {
                        if (!_stubs.TryGetMethodStub<Current_Get_Delegate>("get_Current", out del))
                        {
                            return default(T);
                        }
                    }

                    return del.Invoke();
                }
            }
        }

        public delegate T Current_Get_Delegate();

        public StubIAsyncEnumerator<T> Current_Get(Current_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task<bool> global::Epiphany.Model.Collections.IAsyncEnumerator<T>.MoveNext()
        {
            MoveNext_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<MoveNext_Delegate>("MoveNext");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<MoveNext_Delegate>("MoveNext", out del))
                {
                    return Task.FromResult(default(bool));
                }
            }

            return del.Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<bool> MoveNext_Delegate();

        public StubIAsyncEnumerator<T> MoveNext(MoveNext_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        void global::Epiphany.Model.Collections.IAsyncEnumerator<T>.Reset()
        {
            Reset_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<Reset_Delegate>("Reset");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<Reset_Delegate>("Reset", out del))
                {
                    return;
                }
            }

            del.Invoke();
        }

        public delegate void Reset_Delegate();

        public StubIAsyncEnumerator<T> Reset(Reset_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public StubIAsyncEnumerator(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}

namespace Epiphany.Model.Collections
{
    [CompilerGenerated]
    public class StubINotifyCollectionReset : INotifyCollectionReset
    {
        private readonly StubContainer<StubINotifyCollectionReset> _stubs = new StubContainer<StubINotifyCollectionReset>();

        public MockBehavior MockBehavior { get; set; }

        public event global::System.EventHandler<global::System.EventArgs> Reset;

        protected void On_Reset(object sender, global::System.EventArgs args)
        {
            global::System.EventHandler<global::System.EventArgs> handler = Reset;
            if (handler != null) { handler(sender, args); }
        }

        public void Reset_Raise(object sender, global::System.EventArgs args)
        {
            On_Reset(sender, args);
        }

        public StubINotifyCollectionReset(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}

namespace Epiphany.Model.Collections
{
    [CompilerGenerated]
    public class StubIPagedCollection<T> : IPagedCollection<T>
    {
        private readonly StubContainer<StubIPagedCollection<T>> _stubs = new StubContainer<StubIPagedCollection<T>>();

        public MockBehavior MockBehavior { get; set; }

        int global::Epiphany.Model.Collections.IPagedCollection<T>.Count
        {
            get
            {
                {
                    Count_Get_Delegate del;
                    if (MockBehavior == MockBehavior.Strict)
                    {
                        del = _stubs.GetMethodStub<Count_Get_Delegate>("get_Count");
                    }
                    else
                    {
                        if (!_stubs.TryGetMethodStub<Count_Get_Delegate>("get_Count", out del))
                        {
                            return default(int);
                        }
                    }

                    return del.Invoke();
                }
            }
        }

        int global::Epiphany.Model.Collections.IPagedCollection<T>.Size
        {
            get
            {
                {
                    Size_Get_Delegate del;
                    if (MockBehavior == MockBehavior.Strict)
                    {
                        del = _stubs.GetMethodStub<Size_Get_Delegate>("get_Size");
                    }
                    else
                    {
                        if (!_stubs.TryGetMethodStub<Size_Get_Delegate>("get_Size", out del))
                        {
                            return default(int);
                        }
                    }

                    return del.Invoke();
                }
            }
        }

        int global::Epiphany.Model.Collections.IPagedCollection<T>.CurrentPage
        {
            get
            {
                {
                    CurrentPage_Get_Delegate del;
                    if (MockBehavior == MockBehavior.Strict)
                    {
                        del = _stubs.GetMethodStub<CurrentPage_Get_Delegate>("get_CurrentPage");
                    }
                    else
                    {
                        if (!_stubs.TryGetMethodStub<CurrentPage_Get_Delegate>("get_CurrentPage", out del))
                        {
                            return default(int);
                        }
                    }

                    return del.Invoke();
                }
            }
        }

        int global::Epiphany.Model.Collections.IPagedCollection<T>.PageSize
        {
            get
            {
                {
                    PageSize_Get_Delegate del;
                    if (MockBehavior == MockBehavior.Strict)
                    {
                        del = _stubs.GetMethodStub<PageSize_Get_Delegate>("get_PageSize");
                    }
                    else
                    {
                        if (!_stubs.TryGetMethodStub<PageSize_Get_Delegate>("get_PageSize", out del))
                        {
                            return default(int);
                        }
                    }

                    return del.Invoke();
                }
            }
        }

        T global::Epiphany.Model.Collections.IPagedCollection<T>.this[int index]
        {
            get
            {
                {
                    Item_Get_Int32_Delegate del;
                    if (MockBehavior == MockBehavior.Strict)
                    {
                        del = _stubs.GetMethodStub<Item_Get_Int32_Delegate>("get_Item");
                    }
                    else
                    {
                        if (!_stubs.TryGetMethodStub<Item_Get_Int32_Delegate>("get_Item", out del))
                        {
                            return default(T);
                        }
                    }

                    return del.Invoke(index);
                }
            }
        }

        public delegate int Count_Get_Delegate();

        public StubIPagedCollection<T> Count_Get(Count_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate int Size_Get_Delegate();

        public StubIPagedCollection<T> Size_Get(Size_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate int CurrentPage_Get_Delegate();

        public StubIPagedCollection<T> CurrentPage_Get(CurrentPage_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate int PageSize_Get_Delegate();

        public StubIPagedCollection<T> PageSize_Get(PageSize_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate T Item_Get_Int32_Delegate(int index);

        public StubIPagedCollection<T> Item_Get(Item_Get_Int32_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task<bool> global::Epiphany.Model.Collections.IPagedCollection<T>.LoadPage()
        {
            LoadPage_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<LoadPage_Delegate>("LoadPage");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<LoadPage_Delegate>("LoadPage", out del))
                {
                    return Task.FromResult(default(bool));
                }
            }

            return del.Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<bool> LoadPage_Delegate();

        public StubIPagedCollection<T> LoadPage(LoadPage_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        void global::Epiphany.Model.Collections.IPagedCollection<T>.Clear()
        {
            Clear_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<Clear_Delegate>("Clear");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<Clear_Delegate>("Clear", out del))
                {
                    return;
                }
            }

            del.Invoke();
        }

        public delegate void Clear_Delegate();

        public StubIPagedCollection<T> Clear(Clear_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::Epiphany.Model.Collections.IAsyncEnumerator<T> global::Epiphany.Model.Collections.IAsyncEnumerable<T>.GetEnumerator()
        {
            IAsyncEnumerableOfT_GetEnumerator_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<IAsyncEnumerableOfT_GetEnumerator_Delegate>("GetEnumerator");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<IAsyncEnumerableOfT_GetEnumerator_Delegate>("GetEnumerator", out del))
                {
                    return default(global::Epiphany.Model.Collections.IAsyncEnumerator<T>);
                }
            }

            return del.Invoke();
        }

        public delegate global::Epiphany.Model.Collections.IAsyncEnumerator<T> IAsyncEnumerableOfT_GetEnumerator_Delegate();

        public StubIPagedCollection<T> GetEnumerator(IAsyncEnumerableOfT_GetEnumerator_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public event global::System.EventHandler<global::System.EventArgs> Reset;

        protected void On_Reset(object sender, global::System.EventArgs args)
        {
            global::System.EventHandler<global::System.EventArgs> handler = Reset;
            if (handler != null) { handler(sender, args); }
        }

        public void Reset_Raise(object sender, global::System.EventArgs args)
        {
            On_Reset(sender, args);
        }

        public StubIPagedCollection(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}

namespace Epiphany.Model
{
    [CompilerGenerated]
    public class StubIEntity : IEntity
    {
        private readonly StubContainer<StubIEntity> _stubs = new StubContainer<StubIEntity>();

        public MockBehavior MockBehavior { get; set; }

        object global::Epiphany.Model.IEntity.Id
        {
            get
            {
                {
                    Id_Get_Delegate del;
                    if (MockBehavior == MockBehavior.Strict)
                    {
                        del = _stubs.GetMethodStub<Id_Get_Delegate>("get_Id");
                    }
                    else
                    {
                        if (!_stubs.TryGetMethodStub<Id_Get_Delegate>("get_Id", out del))
                        {
                            return default(object);
                        }
                    }

                    return del.Invoke();
                }
            }
        }

        public delegate object Id_Get_Delegate();

        public StubIEntity Id_Get(Id_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public StubIEntity(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}

namespace Epiphany.Model
{
    [CompilerGenerated]
    public class StubIEntity<TKey> : IEntity<TKey>
    {
        private readonly StubContainer<StubIEntity<TKey>> _stubs = new StubContainer<StubIEntity<TKey>>();

        public MockBehavior MockBehavior { get; set; }

        TKey global::Epiphany.Model.IEntity<TKey>.Id
        {
            get
            {
                {
                    Id_Get_Delegate del;
                    if (MockBehavior == MockBehavior.Strict)
                    {
                        del = _stubs.GetMethodStub<Id_Get_Delegate>("get_Id");
                    }
                    else
                    {
                        if (!_stubs.TryGetMethodStub<Id_Get_Delegate>("get_Id", out del))
                        {
                            return default(TKey);
                        }
                    }

                    return del.Invoke();
                }
            }
        }

        object global::Epiphany.Model.IEntity.Id
        {
            get
            {
                {
                    IEntity_Id_Get_Delegate del;
                    if (MockBehavior == MockBehavior.Strict)
                    {
                        del = _stubs.GetMethodStub<IEntity_Id_Get_Delegate>("get_Id");
                    }
                    else
                    {
                        if (!_stubs.TryGetMethodStub<IEntity_Id_Get_Delegate>("get_Id", out del))
                        {
                            return default(object);
                        }
                    }

                    return del.Invoke();
                }
            }
        }

        public delegate TKey Id_Get_Delegate();

        public StubIEntity<TKey> Id_Get(Id_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate object IEntity_Id_Get_Delegate();

        public StubIEntity<TKey> Id_Get(IEntity_Id_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public StubIEntity(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}

namespace Epiphany.Logging
{
    [CompilerGenerated]
    public class StubILogWriter : ILogWriter
    {
        private readonly StubContainer<StubILogWriter> _stubs = new StubContainer<StubILogWriter>();

        public MockBehavior MockBehavior { get; set; }

        void global::Epiphany.Logging.ILogWriter.Write(global::Epiphany.Logging.LogLevel level, string log)
        {
            Write_LogLevel_String_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<Write_LogLevel_String_Delegate>("Write");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<Write_LogLevel_String_Delegate>("Write", out del))
                {
                    return;
                }
            }

            del.Invoke(level, log);
        }

        public delegate void Write_LogLevel_String_Delegate(global::Epiphany.Logging.LogLevel level, string log);

        public StubILogWriter Write(Write_LogLevel_String_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        void global::Epiphany.Logging.ILogWriter.WriteLine(global::Epiphany.Logging.LogLevel level, string log)
        {
            WriteLine_LogLevel_String_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<WriteLine_LogLevel_String_Delegate>("WriteLine");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<WriteLine_LogLevel_String_Delegate>("WriteLine", out del))
                {
                    return;
                }
            }

            del.Invoke(level, log);
        }

        public delegate void WriteLine_LogLevel_String_Delegate(global::Epiphany.Logging.LogLevel level, string log);

        public StubILogWriter WriteLine(WriteLine_LogLevel_String_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        void global::System.IDisposable.Dispose()
        {
            IDisposable_Dispose_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<IDisposable_Dispose_Delegate>("Dispose");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<IDisposable_Dispose_Delegate>("Dispose", out del))
                {
                    return;
                }
            }

            del.Invoke();
        }

        public delegate void IDisposable_Dispose_Delegate();

        public StubILogWriter Dispose(IDisposable_Dispose_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public StubILogWriter(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}

namespace Epiphany.Model.Services
{
    [CompilerGenerated]
    public class StubIAuthorService : IAuthorService
    {
        private readonly StubContainer<StubIAuthorService> _stubs = new StubContainer<StubIAuthorService>();

        public MockBehavior MockBehavior { get; set; }

        global::System.Threading.Tasks.Task<global::Epiphany.Model.AuthorModel> global::Epiphany.Model.Services.IAuthorService.GetAuthorAsync(long id)
        {
            GetAuthorAsync_Int64_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetAuthorAsync_Int64_Delegate>("GetAuthorAsync");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetAuthorAsync_Int64_Delegate>("GetAuthorAsync", out del))
                {
                    return Task.FromResult(default(global::Epiphany.Model.AuthorModel));
                }
            }

            return del.Invoke(id);
        }

        public delegate global::System.Threading.Tasks.Task<global::Epiphany.Model.AuthorModel> GetAuthorAsync_Int64_Delegate(long id);

        public StubIAuthorService GetAuthorAsync(GetAuthorAsync_Int64_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.IAuthorService.FlipFanshipAsync(global::Epiphany.Model.AuthorModel author)
        {
            FlipFanshipAsync_AuthorModel_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<FlipFanshipAsync_AuthorModel_Delegate>("FlipFanshipAsync");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<FlipFanshipAsync_AuthorModel_Delegate>("FlipFanshipAsync", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke(author);
        }

        public delegate global::System.Threading.Tasks.Task FlipFanshipAsync_AuthorModel_Delegate(global::Epiphany.Model.AuthorModel author);

        public StubIAuthorService FlipFanshipAsync(FlipFanshipAsync_AuthorModel_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.IAuthorService.FollowAuthor(global::Epiphany.Model.AuthorModel author)
        {
            FollowAuthor_AuthorModel_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<FollowAuthor_AuthorModel_Delegate>("FollowAuthor");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<FollowAuthor_AuthorModel_Delegate>("FollowAuthor", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke(author);
        }

        public delegate global::System.Threading.Tasks.Task FollowAuthor_AuthorModel_Delegate(global::Epiphany.Model.AuthorModel author);

        public StubIAuthorService FollowAuthor(FollowAuthor_AuthorModel_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public StubIAuthorService(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}

namespace Epiphany.Model.Services
{
    [CompilerGenerated]
    public class StubIAuthService : IAuthService
    {
        private readonly StubContainer<StubIAuthService> _stubs = new StubContainer<StubIAuthService>();

        public MockBehavior MockBehavior { get; set; }

        global::Epiphany.Model.Authentication.AuthConfig global::Epiphany.Model.Services.IAuthService.Configuration
        {
            get
            {
                {
                    Configuration_Get_Delegate del;
                    if (MockBehavior == MockBehavior.Strict)
                    {
                        del = _stubs.GetMethodStub<Configuration_Get_Delegate>("get_Configuration");
                    }
                    else
                    {
                        if (!_stubs.TryGetMethodStub<Configuration_Get_Delegate>("get_Configuration", out del))
                        {
                            return default(global::Epiphany.Model.Authentication.AuthConfig);
                        }
                    }

                    return del.Invoke();
                }
            }
        }

        bool global::Epiphany.Model.Services.IAuthService.IsCachedTokenAvailable
        {
            get
            {
                {
                    IsCachedTokenAvailable_Get_Delegate del;
                    if (MockBehavior == MockBehavior.Strict)
                    {
                        del = _stubs.GetMethodStub<IsCachedTokenAvailable_Get_Delegate>("get_IsCachedTokenAvailable");
                    }
                    else
                    {
                        if (!_stubs.TryGetMethodStub<IsCachedTokenAvailable_Get_Delegate>("get_IsCachedTokenAvailable", out del))
                        {
                            return default(bool);
                        }
                    }

                    return del.Invoke();
                }
            }
        }

        bool global::Epiphany.Model.Services.IAuthService.IsCachedCredentialAvailable
        {
            get
            {
                {
                    IsCachedCredentialAvailable_Get_Delegate del;
                    if (MockBehavior == MockBehavior.Strict)
                    {
                        del = _stubs.GetMethodStub<IsCachedCredentialAvailable_Get_Delegate>("get_IsCachedCredentialAvailable");
                    }
                    else
                    {
                        if (!_stubs.TryGetMethodStub<IsCachedCredentialAvailable_Get_Delegate>("get_IsCachedCredentialAvailable", out del))
                        {
                            return default(bool);
                        }
                    }

                    return del.Invoke();
                }
            }
        }

        public delegate global::Epiphany.Model.Authentication.AuthConfig Configuration_Get_Delegate();

        public StubIAuthService Configuration_Get(Configuration_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.IAuthService.RequestTemporaryToken()
        {
            RequestTemporaryToken_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<RequestTemporaryToken_Delegate>("RequestTemporaryToken");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<RequestTemporaryToken_Delegate>("RequestTemporaryToken", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke();
        }

        public delegate global::System.Threading.Tasks.Task RequestTemporaryToken_Delegate();

        public StubIAuthService RequestTemporaryToken(RequestTemporaryToken_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task<global::Epiphany.Model.Authentication.Token> global::Epiphany.Model.Services.IAuthService.GetToken()
        {
            GetToken_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetToken_Delegate>("GetToken");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetToken_Delegate>("GetToken", out del))
                {
                    return Task.FromResult(default(global::Epiphany.Model.Authentication.Token));
                }
            }

            return del.Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<global::Epiphany.Model.Authentication.Token> GetToken_Delegate();

        public StubIAuthService GetToken(GetToken_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Uri global::Epiphany.Model.Services.IAuthService.GetAuthorizeUri()
        {
            GetAuthorizeUri_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetAuthorizeUri_Delegate>("GetAuthorizeUri");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetAuthorizeUri_Delegate>("GetAuthorizeUri", out del))
                {
                    return default(global::System.Uri);
                }
            }

            return del.Invoke();
        }

        public delegate global::System.Uri GetAuthorizeUri_Delegate();

        public StubIAuthService GetAuthorizeUri(GetAuthorizeUri_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task<global::Epiphany.Model.Credential> global::Epiphany.Model.Services.IAuthService.GetCredentialAsync()
        {
            GetCredentialAsync_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetCredentialAsync_Delegate>("GetCredentialAsync");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetCredentialAsync_Delegate>("GetCredentialAsync", out del))
                {
                    return Task.FromResult(default(global::Epiphany.Model.Credential));
                }
            }

            return del.Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<global::Epiphany.Model.Credential> GetCredentialAsync_Delegate();

        public StubIAuthService GetCredentialAsync(GetCredentialAsync_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.IAuthService.Logout()
        {
            Logout_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<Logout_Delegate>("Logout");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<Logout_Delegate>("Logout", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke();
        }

        public delegate global::System.Threading.Tasks.Task Logout_Delegate();

        public StubIAuthService Logout(Logout_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate bool IsCachedTokenAvailable_Get_Delegate();

        public StubIAuthService IsCachedTokenAvailable_Get(IsCachedTokenAvailable_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate bool IsCachedCredentialAvailable_Get_Delegate();

        public StubIAuthService IsCachedCredentialAvailable_Get(IsCachedCredentialAvailable_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::Epiphany.Model.Authentication.Token global::Epiphany.Model.Services.IAuthService.GetCachedToken()
        {
            GetCachedToken_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetCachedToken_Delegate>("GetCachedToken");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetCachedToken_Delegate>("GetCachedToken", out del))
                {
                    return default(global::Epiphany.Model.Authentication.Token);
                }
            }

            return del.Invoke();
        }

        public delegate global::Epiphany.Model.Authentication.Token GetCachedToken_Delegate();

        public StubIAuthService GetCachedToken(GetCachedToken_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::Epiphany.Model.Credential global::Epiphany.Model.Services.IAuthService.GetCachedCredential()
        {
            GetCachedCredential_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetCachedCredential_Delegate>("GetCachedCredential");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetCachedCredential_Delegate>("GetCachedCredential", out del))
                {
                    return default(global::Epiphany.Model.Credential);
                }
            }

            return del.Invoke();
        }

        public delegate global::Epiphany.Model.Credential GetCachedCredential_Delegate();

        public StubIAuthService GetCachedCredential(GetCachedCredential_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::Epiphany.Web.IWebClient global::Epiphany.Model.Services.IAuthService.GetAuthCapableWebClient()
        {
            GetAuthCapableWebClient_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetAuthCapableWebClient_Delegate>("GetAuthCapableWebClient");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetAuthCapableWebClient_Delegate>("GetAuthCapableWebClient", out del))
                {
                    return default(global::Epiphany.Web.IWebClient);
                }
            }

            return del.Invoke();
        }

        public delegate global::Epiphany.Web.IWebClient GetAuthCapableWebClient_Delegate();

        public StubIAuthService GetAuthCapableWebClient(GetAuthCapableWebClient_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public StubIAuthService(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}

namespace Epiphany.Model.Services
{
    [CompilerGenerated]
    public class StubIBookService : IBookService
    {
        private readonly StubContainer<StubIBookService> _stubs = new StubContainer<StubIBookService>();

        public MockBehavior MockBehavior { get; set; }

        global::System.Threading.Tasks.Task<global::Epiphany.Model.BookModel> global::Epiphany.Model.Services.IBookService.GetBook(long id)
        {
            GetBook_Int64_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetBook_Int64_Delegate>("GetBook");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetBook_Int64_Delegate>("GetBook", out del))
                {
                    return Task.FromResult(default(global::Epiphany.Model.BookModel));
                }
            }

            return del.Invoke(id);
        }

        public delegate global::System.Threading.Tasks.Task<global::Epiphany.Model.BookModel> GetBook_Int64_Delegate(long id);

        public StubIBookService GetBook(GetBook_Int64_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.BookModel> global::Epiphany.Model.Services.IBookService.GetBooks(global::Epiphany.Model.AuthorModel author)
        {
            GetBooks_AuthorModel_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetBooks_AuthorModel_Delegate>("GetBooks");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetBooks_AuthorModel_Delegate>("GetBooks", out del))
                {
                    return default(global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.BookModel>);
                }
            }

            return del.Invoke(author);
        }

        public delegate global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.BookModel> GetBooks_AuthorModel_Delegate(global::Epiphany.Model.AuthorModel author);

        public StubIBookService GetBooks(GetBooks_AuthorModel_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.BookModel> global::Epiphany.Model.Services.IBookService.GetBooksByYear(long userId, int year)
        {
            GetBooksByYear_Int64_Int32_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetBooksByYear_Int64_Int32_Delegate>("GetBooksByYear");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetBooksByYear_Int64_Int32_Delegate>("GetBooksByYear", out del))
                {
                    return default(global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.BookModel>);
                }
            }

            return del.Invoke(userId, year);
        }

        public delegate global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.BookModel> GetBooksByYear_Int64_Int32_Delegate(long userId, int year);

        public StubIBookService GetBooksByYear(GetBooksByYear_Int64_Int32_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.BookModel> global::Epiphany.Model.Services.IBookService.GetBooks(long userId, string shelfName, global::Epiphany.Model.Services.BookSortType sortType, global::Epiphany.Model.Services.BookSortOrder order)
        {
            GetBooks_Int64_String_BookSortType_BookSortOrder_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetBooks_Int64_String_BookSortType_BookSortOrder_Delegate>("GetBooks");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetBooks_Int64_String_BookSortType_BookSortOrder_Delegate>("GetBooks", out del))
                {
                    return default(global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.BookModel>);
                }
            }

            return del.Invoke(userId, shelfName, sortType, order);
        }

        public delegate global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.BookModel> GetBooks_Int64_String_BookSortType_BookSortOrder_Delegate(long userId, string shelfName, global::Epiphany.Model.Services.BookSortType sortType, global::Epiphany.Model.Services.BookSortOrder order);

        public StubIBookService GetBooks(GetBooks_Int64_String_BookSortType_BookSortOrder_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.BookModel> global::Epiphany.Model.Services.IBookService.GetOwnedBooks(long userId)
        {
            GetOwnedBooks_Int64_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetOwnedBooks_Int64_Delegate>("GetOwnedBooks");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetOwnedBooks_Int64_Delegate>("GetOwnedBooks", out del))
                {
                    return default(global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.BookModel>);
                }
            }

            return del.Invoke(userId);
        }

        public delegate global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.BookModel> GetOwnedBooks_Int64_Delegate(long userId);

        public StubIBookService GetOwnedBooks(GetOwnedBooks_Int64_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.IBookService.AddBook(global::Epiphany.Model.BookshelfModel shelf, global::Epiphany.Model.BookModel book)
        {
            AddBook_BookshelfModel_BookModel_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<AddBook_BookshelfModel_BookModel_Delegate>("AddBook");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<AddBook_BookshelfModel_BookModel_Delegate>("AddBook", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke(shelf, book);
        }

        public delegate global::System.Threading.Tasks.Task AddBook_BookshelfModel_BookModel_Delegate(global::Epiphany.Model.BookshelfModel shelf, global::Epiphany.Model.BookModel book);

        public StubIBookService AddBook(AddBook_BookshelfModel_BookModel_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.IBookService.RemoveBook(global::Epiphany.Model.BookshelfModel shelf, global::Epiphany.Model.BookModel book)
        {
            RemoveBook_BookshelfModel_BookModel_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<RemoveBook_BookshelfModel_BookModel_Delegate>("RemoveBook");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<RemoveBook_BookshelfModel_BookModel_Delegate>("RemoveBook", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke(shelf, book);
        }

        public delegate global::System.Threading.Tasks.Task RemoveBook_BookshelfModel_BookModel_Delegate(global::Epiphany.Model.BookshelfModel shelf, global::Epiphany.Model.BookModel book);

        public StubIBookService RemoveBook(RemoveBook_BookshelfModel_BookModel_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.WorkModel> global::Epiphany.Model.Services.IBookService.Find(global::Epiphany.Model.Services.BookSearchType type, string term)
        {
            Find_BookSearchType_String_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<Find_BookSearchType_String_Delegate>("Find");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<Find_BookSearchType_String_Delegate>("Find", out del))
                {
                    return default(global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.WorkModel>);
                }
            }

            return del.Invoke(type, term);
        }

        public delegate global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.WorkModel> Find_BookSearchType_String_Delegate(global::Epiphany.Model.Services.BookSearchType type, string term);

        public StubIBookService Find(Find_BookSearchType_String_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public StubIBookService(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}

namespace Epiphany.Model.Services
{
    [CompilerGenerated]
    public class StubIBookshelfService : IBookshelfService
    {
        private readonly StubContainer<StubIBookshelfService> _stubs = new StubContainer<StubIBookshelfService>();

        public MockBehavior MockBehavior { get; set; }

        global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.BookshelfModel> global::Epiphany.Model.Services.IBookshelfService.GetBookshelves(long userId)
        {
            GetBookshelves_Int64_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetBookshelves_Int64_Delegate>("GetBookshelves");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetBookshelves_Int64_Delegate>("GetBookshelves", out del))
                {
                    return default(global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.BookshelfModel>);
                }
            }

            return del.Invoke(userId);
        }

        public delegate global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.BookshelfModel> GetBookshelves_Int64_Delegate(long userId);

        public StubIBookshelfService GetBookshelves(GetBookshelves_Int64_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.IBookshelfService.AddShelf(global::Epiphany.Model.BookshelfModel shelf)
        {
            AddShelf_BookshelfModel_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<AddShelf_BookshelfModel_Delegate>("AddShelf");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<AddShelf_BookshelfModel_Delegate>("AddShelf", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke(shelf);
        }

        public delegate global::System.Threading.Tasks.Task AddShelf_BookshelfModel_Delegate(global::Epiphany.Model.BookshelfModel shelf);

        public StubIBookshelfService AddShelf(AddShelf_BookshelfModel_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.IBookshelfService.RemoveShelf(global::Epiphany.Model.BookshelfModel shelf)
        {
            RemoveShelf_BookshelfModel_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<RemoveShelf_BookshelfModel_Delegate>("RemoveShelf");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<RemoveShelf_BookshelfModel_Delegate>("RemoveShelf", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke(shelf);
        }

        public delegate global::System.Threading.Tasks.Task RemoveShelf_BookshelfModel_Delegate(global::Epiphany.Model.BookshelfModel shelf);

        public StubIBookshelfService RemoveShelf(RemoveShelf_BookshelfModel_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public StubIBookshelfService(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}

namespace Epiphany.Model.Services
{
    [CompilerGenerated]
    public class StubIEventService : IEventService
    {
        private readonly StubContainer<StubIEventService> _stubs = new StubContainer<StubIEventService>();

        public MockBehavior MockBehavior { get; set; }

        global::System.Threading.Tasks.Task<global::System.Collections.Generic.IEnumerable<global::Epiphany.Model.LiteraryEventModel>> global::Epiphany.Model.Services.IEventService.GetEvents(double lat, double lon)
        {
            GetEvents_Double_Double_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetEvents_Double_Double_Delegate>("GetEvents");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetEvents_Double_Double_Delegate>("GetEvents", out del))
                {
                    return Task.FromResult(default(global::System.Collections.Generic.IEnumerable<global::Epiphany.Model.LiteraryEventModel>));
                }
            }

            return del.Invoke(lat, lon);
        }

        public delegate global::System.Threading.Tasks.Task<global::System.Collections.Generic.IEnumerable<global::Epiphany.Model.LiteraryEventModel>> GetEvents_Double_Double_Delegate(double lat, double lon);

        public StubIEventService GetEvents(GetEvents_Double_Double_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task<global::System.Collections.Generic.IEnumerable<global::Epiphany.Model.LiteraryEventModel>> global::Epiphany.Model.Services.IEventService.GetEvents(int postalCode)
        {
            GetEvents_Int32_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetEvents_Int32_Delegate>("GetEvents");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetEvents_Int32_Delegate>("GetEvents", out del))
                {
                    return Task.FromResult(default(global::System.Collections.Generic.IEnumerable<global::Epiphany.Model.LiteraryEventModel>));
                }
            }

            return del.Invoke(postalCode);
        }

        public delegate global::System.Threading.Tasks.Task<global::System.Collections.Generic.IEnumerable<global::Epiphany.Model.LiteraryEventModel>> GetEvents_Int32_Delegate(int postalCode);

        public StubIEventService GetEvents(GetEvents_Int32_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public StubIEventService(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}

namespace Epiphany.Model.Services
{
    [CompilerGenerated]
    public class StubIGroupService : IGroupService
    {
        private readonly StubContainer<StubIGroupService> _stubs = new StubContainer<StubIGroupService>();

        public MockBehavior MockBehavior { get; set; }

        global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.GroupModel> global::Epiphany.Model.Services.IGroupService.GetGroups(global::Epiphany.Model.UserModel user)
        {
            GetGroups_UserModel_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetGroups_UserModel_Delegate>("GetGroups");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetGroups_UserModel_Delegate>("GetGroups", out del))
                {
                    return default(global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.GroupModel>);
                }
            }

            return del.Invoke(user);
        }

        public delegate global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.GroupModel> GetGroups_UserModel_Delegate(global::Epiphany.Model.UserModel user);

        public StubIGroupService GetGroups(GetGroups_UserModel_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task<global::Epiphany.Model.GroupModel> global::Epiphany.Model.Services.IGroupService.GetGroup(long groupId)
        {
            GetGroup_Int64_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetGroup_Int64_Delegate>("GetGroup");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetGroup_Int64_Delegate>("GetGroup", out del))
                {
                    return Task.FromResult(default(global::Epiphany.Model.GroupModel));
                }
            }

            return del.Invoke(groupId);
        }

        public delegate global::System.Threading.Tasks.Task<global::Epiphany.Model.GroupModel> GetGroup_Int64_Delegate(long groupId);

        public StubIGroupService GetGroup(GetGroup_Int64_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.TopicModel> global::Epiphany.Model.Services.IGroupService.GetTopics(long groupId, long groupFolderId)
        {
            GetTopics_Int64_Int64_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetTopics_Int64_Int64_Delegate>("GetTopics");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetTopics_Int64_Int64_Delegate>("GetTopics", out del))
                {
                    return default(global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.TopicModel>);
                }
            }

            return del.Invoke(groupId, groupFolderId);
        }

        public delegate global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.TopicModel> GetTopics_Int64_Int64_Delegate(long groupId, long groupFolderId);

        public StubIGroupService GetTopics(GetTopics_Int64_Int64_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task<global::Epiphany.Model.TopicModel> global::Epiphany.Model.Services.IGroupService.GetTopic(long topicId)
        {
            GetTopic_Int64_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetTopic_Int64_Delegate>("GetTopic");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetTopic_Int64_Delegate>("GetTopic", out del))
                {
                    return Task.FromResult(default(global::Epiphany.Model.TopicModel));
                }
            }

            return del.Invoke(topicId);
        }

        public delegate global::System.Threading.Tasks.Task<global::Epiphany.Model.TopicModel> GetTopic_Int64_Delegate(long topicId);

        public StubIGroupService GetTopic(GetTopic_Int64_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.CommentModel> global::Epiphany.Model.Services.IGroupService.GetComments(global::Epiphany.Model.TopicModel topic)
        {
            GetComments_TopicModel_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetComments_TopicModel_Delegate>("GetComments");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetComments_TopicModel_Delegate>("GetComments", out del))
                {
                    return default(global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.CommentModel>);
                }
            }

            return del.Invoke(topic);
        }

        public delegate global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.CommentModel> GetComments_TopicModel_Delegate(global::Epiphany.Model.TopicModel topic);

        public StubIGroupService GetComments(GetComments_TopicModel_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.IGroupService.CreateTopic(global::Epiphany.Model.TopicModel topic, string body)
        {
            CreateTopic_TopicModel_String_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<CreateTopic_TopicModel_String_Delegate>("CreateTopic");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<CreateTopic_TopicModel_String_Delegate>("CreateTopic", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke(topic, body);
        }

        public delegate global::System.Threading.Tasks.Task CreateTopic_TopicModel_String_Delegate(global::Epiphany.Model.TopicModel topic, string body);

        public StubIGroupService CreateTopic(CreateTopic_TopicModel_String_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.IGroupService.AddComment(global::Epiphany.Model.TopicModel topic, global::Epiphany.Model.CommentModel comment)
        {
            AddComment_TopicModel_CommentModel_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<AddComment_TopicModel_CommentModel_Delegate>("AddComment");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<AddComment_TopicModel_CommentModel_Delegate>("AddComment", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke(topic, comment);
        }

        public delegate global::System.Threading.Tasks.Task AddComment_TopicModel_CommentModel_Delegate(global::Epiphany.Model.TopicModel topic, global::Epiphany.Model.CommentModel comment);

        public StubIGroupService AddComment(AddComment_TopicModel_CommentModel_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.IGroupService.JoinGroup(global::Epiphany.Model.GroupModel group)
        {
            JoinGroup_GroupModel_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<JoinGroup_GroupModel_Delegate>("JoinGroup");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<JoinGroup_GroupModel_Delegate>("JoinGroup", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke(group);
        }

        public delegate global::System.Threading.Tasks.Task JoinGroup_GroupModel_Delegate(global::Epiphany.Model.GroupModel group);

        public StubIGroupService JoinGroup(JoinGroup_GroupModel_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.GroupModel> global::Epiphany.Model.Services.IGroupService.Find(string term)
        {
            Find_String_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<Find_String_Delegate>("Find");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<Find_String_Delegate>("Find", out del))
                {
                    return default(global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.GroupModel>);
                }
            }

            return del.Invoke(term);
        }

        public delegate global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.GroupModel> Find_String_Delegate(string term);

        public StubIGroupService Find(Find_String_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public StubIGroupService(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}

namespace Epiphany.Model.Services
{
    [CompilerGenerated]
    public class StubILogonService : ILogonService
    {
        private readonly StubContainer<StubILogonService> _stubs = new StubContainer<StubILogonService>();

        public MockBehavior MockBehavior { get; set; }

        global::Epiphany.Model.Authentication.AuthConfig global::Epiphany.Model.Services.ILogonService.Configuration
        {
            get
            {
                {
                    Configuration_Get_Delegate del;
                    if (MockBehavior == MockBehavior.Strict)
                    {
                        del = _stubs.GetMethodStub<Configuration_Get_Delegate>("get_Configuration");
                    }
                    else
                    {
                        if (!_stubs.TryGetMethodStub<Configuration_Get_Delegate>("get_Configuration", out del))
                        {
                            return default(global::Epiphany.Model.Authentication.AuthConfig);
                        }
                    }

                    return del.Invoke();
                }
            }
        }

        global::Epiphany.Model.Authentication.Session global::Epiphany.Model.Services.ILogonService.Session
        {
            get
            {
                {
                    Session_Get_Delegate del;
                    if (MockBehavior == MockBehavior.Strict)
                    {
                        del = _stubs.GetMethodStub<Session_Get_Delegate>("get_Session");
                    }
                    else
                    {
                        if (!_stubs.TryGetMethodStub<Session_Get_Delegate>("get_Session", out del))
                        {
                            return default(global::Epiphany.Model.Authentication.Session);
                        }
                    }

                    return del.Invoke();
                }
            }
        }

        global::Epiphany.Model.Authentication.Token global::Epiphany.Model.Services.ILogonService.ActiveToken
        {
            get
            {
                {
                    ActiveToken_Get_Delegate del;
                    if (MockBehavior == MockBehavior.Strict)
                    {
                        del = _stubs.GetMethodStub<ActiveToken_Get_Delegate>("get_ActiveToken");
                    }
                    else
                    {
                        if (!_stubs.TryGetMethodStub<ActiveToken_Get_Delegate>("get_ActiveToken", out del))
                        {
                            return default(global::Epiphany.Model.Authentication.Token);
                        }
                    }

                    return del.Invoke();
                }
            }
        }

        global::Epiphany.Model.Services.LogonState global::Epiphany.Model.Services.ILogonService.State
        {
            get
            {
                {
                    State_Get_Delegate del;
                    if (MockBehavior == MockBehavior.Strict)
                    {
                        del = _stubs.GetMethodStub<State_Get_Delegate>("get_State");
                    }
                    else
                    {
                        if (!_stubs.TryGetMethodStub<State_Get_Delegate>("get_State", out del))
                        {
                            return default(global::Epiphany.Model.Services.LogonState);
                        }
                    }

                    return del.Invoke();
                }
            }
        }

        public delegate global::Epiphany.Model.Authentication.AuthConfig Configuration_Get_Delegate();

        public StubILogonService Configuration_Get(Configuration_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate global::Epiphany.Model.Authentication.Session Session_Get_Delegate();

        public StubILogonService Session_Get(Session_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate global::Epiphany.Model.Authentication.Token ActiveToken_Get_Delegate();

        public StubILogonService ActiveToken_Get(ActiveToken_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate global::Epiphany.Model.Services.LogonState State_Get_Delegate();

        public StubILogonService State_Get(State_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task<global::System.Uri> global::Epiphany.Model.Services.ILogonService.StartLogin()
        {
            StartLogin_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<StartLogin_Delegate>("StartLogin");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<StartLogin_Delegate>("StartLogin", out del))
                {
                    return Task.FromResult(default(global::System.Uri));
                }
            }

            return del.Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<global::System.Uri> StartLogin_Delegate();

        public StubILogonService StartLogin(StartLogin_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.ILogonService.FinishLogin()
        {
            FinishLogin_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<FinishLogin_Delegate>("FinishLogin");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<FinishLogin_Delegate>("FinishLogin", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke();
        }

        public delegate global::System.Threading.Tasks.Task FinishLogin_Delegate();

        public StubILogonService FinishLogin(FinishLogin_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task<bool> global::Epiphany.Model.Services.ILogonService.TryVerifyLogin()
        {
            TryVerifyLogin_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<TryVerifyLogin_Delegate>("TryVerifyLogin");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<TryVerifyLogin_Delegate>("TryVerifyLogin", out del))
                {
                    return Task.FromResult(default(bool));
                }
            }

            return del.Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<bool> TryVerifyLogin_Delegate();

        public StubILogonService TryVerifyLogin(TryVerifyLogin_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.ILogonService.Logout()
        {
            Logout_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<Logout_Delegate>("Logout");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<Logout_Delegate>("Logout", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke();
        }

        public delegate global::System.Threading.Tasks.Task Logout_Delegate();

        public StubILogonService Logout(Logout_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public event global::System.EventHandler<global::Epiphany.Model.Authentication.SessionChangedEventArgs> SessionChanged;

        protected void On_SessionChanged(object sender, global::Epiphany.Model.Authentication.SessionChangedEventArgs args)
        {
            global::System.EventHandler<global::Epiphany.Model.Authentication.SessionChangedEventArgs> handler = SessionChanged;
            if (handler != null) { handler(sender, args); }
        }

        public void SessionChanged_Raise(object sender, global::Epiphany.Model.Authentication.SessionChangedEventArgs args)
        {
            On_SessionChanged(sender, args);
        }

        public event global::System.EventHandler<global::Epiphany.Model.Authentication.TokenChangedEventArgs> TokenChanged;

        protected void On_TokenChanged(object sender, global::Epiphany.Model.Authentication.TokenChangedEventArgs args)
        {
            global::System.EventHandler<global::Epiphany.Model.Authentication.TokenChangedEventArgs> handler = TokenChanged;
            if (handler != null) { handler(sender, args); }
        }

        public void TokenChanged_Raise(object sender, global::Epiphany.Model.Authentication.TokenChangedEventArgs args)
        {
            On_TokenChanged(sender, args);
        }

        public StubILogonService(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}

namespace Epiphany.Model.Services
{
    [CompilerGenerated]
    public class StubINotificationService : INotificationService
    {
        private readonly StubContainer<StubINotificationService> _stubs = new StubContainer<StubINotificationService>();

        public MockBehavior MockBehavior { get; set; }

        global::System.Threading.Tasks.Task<global::System.Collections.Generic.IEnumerable<global::Epiphany.Model.NotificationModel>> global::Epiphany.Model.Services.INotificationService.GetNotifications()
        {
            GetNotifications_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetNotifications_Delegate>("GetNotifications");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetNotifications_Delegate>("GetNotifications", out del))
                {
                    return Task.FromResult(default(global::System.Collections.Generic.IEnumerable<global::Epiphany.Model.NotificationModel>));
                }
            }

            return del.Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<global::System.Collections.Generic.IEnumerable<global::Epiphany.Model.NotificationModel>> GetNotifications_Delegate();

        public StubINotificationService GetNotifications(GetNotifications_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public StubINotificationService(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}

namespace Epiphany.Model.Services
{
    [CompilerGenerated]
    public class StubIReviewService : IReviewService
    {
        private readonly StubContainer<StubIReviewService> _stubs = new StubContainer<StubIReviewService>();

        public MockBehavior MockBehavior { get; set; }

        global::System.Threading.Tasks.Task<global::Epiphany.Model.ReviewModel> global::Epiphany.Model.Services.IReviewService.GetReviewAsync(long id)
        {
            GetReviewAsync_Int64_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetReviewAsync_Int64_Delegate>("GetReviewAsync");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetReviewAsync_Int64_Delegate>("GetReviewAsync", out del))
                {
                    return Task.FromResult(default(global::Epiphany.Model.ReviewModel));
                }
            }

            return del.Invoke(id);
        }

        public delegate global::System.Threading.Tasks.Task<global::Epiphany.Model.ReviewModel> GetReviewAsync_Int64_Delegate(long id);

        public StubIReviewService GetReviewAsync(GetReviewAsync_Int64_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.ReviewModel> global::Epiphany.Model.Services.IReviewService.GetReviews(global::Epiphany.Model.BookModel book)
        {
            GetReviews_BookModel_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetReviews_BookModel_Delegate>("GetReviews");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetReviews_BookModel_Delegate>("GetReviews", out del))
                {
                    return default(global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.ReviewModel>);
                }
            }

            return del.Invoke(book);
        }

        public delegate global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.ReviewModel> GetReviews_BookModel_Delegate(global::Epiphany.Model.BookModel book);

        public StubIReviewService GetReviews(GetReviews_BookModel_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.IReviewService.AddReviewAsync(global::Epiphany.Model.BookModel book, global::Epiphany.Model.ReviewModel review)
        {
            AddReviewAsync_BookModel_ReviewModel_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<AddReviewAsync_BookModel_ReviewModel_Delegate>("AddReviewAsync");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<AddReviewAsync_BookModel_ReviewModel_Delegate>("AddReviewAsync", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke(book, review);
        }

        public delegate global::System.Threading.Tasks.Task AddReviewAsync_BookModel_ReviewModel_Delegate(global::Epiphany.Model.BookModel book, global::Epiphany.Model.ReviewModel review);

        public StubIReviewService AddReviewAsync(AddReviewAsync_BookModel_ReviewModel_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.IReviewService.EditReviewAsync(global::Epiphany.Model.BookModel book, global::Epiphany.Model.ReviewModel review, bool markAsFinished)
        {
            EditReviewAsync_BookModel_ReviewModel_Boolean_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<EditReviewAsync_BookModel_ReviewModel_Boolean_Delegate>("EditReviewAsync");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<EditReviewAsync_BookModel_ReviewModel_Boolean_Delegate>("EditReviewAsync", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke(book, review, markAsFinished);
        }

        public delegate global::System.Threading.Tasks.Task EditReviewAsync_BookModel_ReviewModel_Boolean_Delegate(global::Epiphany.Model.BookModel book, global::Epiphany.Model.ReviewModel review, bool markAsFinished);

        public StubIReviewService EditReviewAsync(EditReviewAsync_BookModel_ReviewModel_Boolean_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.IReviewService.LikeReviewAsync(global::Epiphany.Model.ReviewModel review)
        {
            LikeReviewAsync_ReviewModel_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<LikeReviewAsync_ReviewModel_Delegate>("LikeReviewAsync");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<LikeReviewAsync_ReviewModel_Delegate>("LikeReviewAsync", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke(review);
        }

        public delegate global::System.Threading.Tasks.Task LikeReviewAsync_ReviewModel_Delegate(global::Epiphany.Model.ReviewModel review);

        public StubIReviewService LikeReviewAsync(LikeReviewAsync_ReviewModel_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.IReviewService.UnlikeReviewAsync(global::Epiphany.Model.ReviewModel review)
        {
            UnlikeReviewAsync_ReviewModel_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<UnlikeReviewAsync_ReviewModel_Delegate>("UnlikeReviewAsync");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<UnlikeReviewAsync_ReviewModel_Delegate>("UnlikeReviewAsync", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke(review);
        }

        public delegate global::System.Threading.Tasks.Task UnlikeReviewAsync_ReviewModel_Delegate(global::Epiphany.Model.ReviewModel review);

        public StubIReviewService UnlikeReviewAsync(UnlikeReviewAsync_ReviewModel_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.IReviewService.AddComment(global::Epiphany.Model.ReviewModel review, global::Epiphany.Model.CommentModel comment)
        {
            AddComment_ReviewModel_CommentModel_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<AddComment_ReviewModel_CommentModel_Delegate>("AddComment");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<AddComment_ReviewModel_CommentModel_Delegate>("AddComment", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke(review, comment);
        }

        public delegate global::System.Threading.Tasks.Task AddComment_ReviewModel_CommentModel_Delegate(global::Epiphany.Model.ReviewModel review, global::Epiphany.Model.CommentModel comment);

        public StubIReviewService AddComment(AddComment_ReviewModel_CommentModel_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task<global::System.Collections.Generic.IList<global::Epiphany.Model.ReviewModel>> global::Epiphany.Model.Services.IReviewService.GetRecentReviewsAsync()
        {
            GetRecentReviewsAsync_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetRecentReviewsAsync_Delegate>("GetRecentReviewsAsync");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetRecentReviewsAsync_Delegate>("GetRecentReviewsAsync", out del))
                {
                    return Task.FromResult(default(global::System.Collections.Generic.IList<global::Epiphany.Model.ReviewModel>));
                }
            }

            return del.Invoke();
        }

        public delegate global::System.Threading.Tasks.Task<global::System.Collections.Generic.IList<global::Epiphany.Model.ReviewModel>> GetRecentReviewsAsync_Delegate();

        public StubIReviewService GetRecentReviewsAsync(GetRecentReviewsAsync_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public StubIReviewService(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}

namespace Epiphany.Model.Services
{
    [CompilerGenerated]
    public class StubIStatusService : IStatusService
    {
        private readonly StubContainer<StubIStatusService> _stubs = new StubContainer<StubIStatusService>();

        public MockBehavior MockBehavior { get; set; }

        global::System.Threading.Tasks.Task<global::Epiphany.Model.UserStatusModel> global::Epiphany.Model.Services.IStatusService.GetUserStatus(long id)
        {
            GetUserStatus_Int64_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetUserStatus_Int64_Delegate>("GetUserStatus");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetUserStatus_Int64_Delegate>("GetUserStatus", out del))
                {
                    return Task.FromResult(default(global::Epiphany.Model.UserStatusModel));
                }
            }

            return del.Invoke(id);
        }

        public delegate global::System.Threading.Tasks.Task<global::Epiphany.Model.UserStatusModel> GetUserStatus_Int64_Delegate(long id);

        public StubIStatusService GetUserStatus(GetUserStatus_Int64_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.IStatusService.UpdateUserStatus(global::Epiphany.Model.UserStatusModel status)
        {
            UpdateUserStatus_UserStatusModel_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<UpdateUserStatus_UserStatusModel_Delegate>("UpdateUserStatus");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<UpdateUserStatus_UserStatusModel_Delegate>("UpdateUserStatus", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke(status);
        }

        public delegate global::System.Threading.Tasks.Task UpdateUserStatus_UserStatusModel_Delegate(global::Epiphany.Model.UserStatusModel status);

        public StubIStatusService UpdateUserStatus(UpdateUserStatus_UserStatusModel_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.IStatusService.LikeStatus(global::Epiphany.Model.UserStatusModel status)
        {
            LikeStatus_UserStatusModel_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<LikeStatus_UserStatusModel_Delegate>("LikeStatus");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<LikeStatus_UserStatusModel_Delegate>("LikeStatus", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke(status);
        }

        public delegate global::System.Threading.Tasks.Task LikeStatus_UserStatusModel_Delegate(global::Epiphany.Model.UserStatusModel status);

        public StubIStatusService LikeStatus(LikeStatus_UserStatusModel_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.IStatusService.UnlikeStatus(global::Epiphany.Model.UserStatusModel status)
        {
            UnlikeStatus_UserStatusModel_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<UnlikeStatus_UserStatusModel_Delegate>("UnlikeStatus");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<UnlikeStatus_UserStatusModel_Delegate>("UnlikeStatus", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke(status);
        }

        public delegate global::System.Threading.Tasks.Task UnlikeStatus_UserStatusModel_Delegate(global::Epiphany.Model.UserStatusModel status);

        public StubIStatusService UnlikeStatus(UnlikeStatus_UserStatusModel_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.IStatusService.AddComment(global::Epiphany.Model.UserStatusModel status, global::Epiphany.Model.CommentModel comment)
        {
            AddComment_UserStatusModel_CommentModel_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<AddComment_UserStatusModel_CommentModel_Delegate>("AddComment");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<AddComment_UserStatusModel_CommentModel_Delegate>("AddComment", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke(status, comment);
        }

        public delegate global::System.Threading.Tasks.Task AddComment_UserStatusModel_CommentModel_Delegate(global::Epiphany.Model.UserStatusModel status, global::Epiphany.Model.CommentModel comment);

        public StubIStatusService AddComment(AddComment_UserStatusModel_CommentModel_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public StubIStatusService(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}

namespace Epiphany.Model.Services
{
    [CompilerGenerated]
    public class StubIUserService : IUserService
    {
        private readonly StubContainer<StubIUserService> _stubs = new StubContainer<StubIUserService>();

        public MockBehavior MockBehavior { get; set; }

        global::System.Threading.Tasks.Task<global::Epiphany.Model.ProfileModel> global::Epiphany.Model.Services.IUserService.GetProfileAsync(long id)
        {
            GetProfileAsync_Int64_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetProfileAsync_Int64_Delegate>("GetProfileAsync");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetProfileAsync_Int64_Delegate>("GetProfileAsync", out del))
                {
                    return Task.FromResult(default(global::Epiphany.Model.ProfileModel));
                }
            }

            return del.Invoke(id);
        }

        public delegate global::System.Threading.Tasks.Task<global::Epiphany.Model.ProfileModel> GetProfileAsync_Int64_Delegate(long id);

        public StubIUserService GetProfileAsync(GetProfileAsync_Int64_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.UserModel> global::Epiphany.Model.Services.IUserService.GetFriends(long id)
        {
            GetFriends_Int64_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetFriends_Int64_Delegate>("GetFriends");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetFriends_Int64_Delegate>("GetFriends", out del))
                {
                    return default(global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.UserModel>);
                }
            }

            return del.Invoke(id);
        }

        public delegate global::Epiphany.Model.Collections.IPagedCollection<global::Epiphany.Model.UserModel> GetFriends_Int64_Delegate(long id);

        public StubIUserService GetFriends(GetFriends_Int64_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task<global::System.Collections.Generic.IEnumerable<global::Epiphany.Model.FeedItemModel>> global::Epiphany.Model.Services.IUserService.GetFriendUpdatesAsync(global::Epiphany.Model.Services.FeedUpdateType type, global::Epiphany.Model.Services.FeedUpdateFilter filter)
        {
            GetFriendUpdatesAsync_FeedUpdateType_FeedUpdateFilter_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetFriendUpdatesAsync_FeedUpdateType_FeedUpdateFilter_Delegate>("GetFriendUpdatesAsync");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetFriendUpdatesAsync_FeedUpdateType_FeedUpdateFilter_Delegate>("GetFriendUpdatesAsync", out del))
                {
                    return Task.FromResult(default(global::System.Collections.Generic.IEnumerable<global::Epiphany.Model.FeedItemModel>));
                }
            }

            return del.Invoke(type, filter);
        }

        public delegate global::System.Threading.Tasks.Task<global::System.Collections.Generic.IEnumerable<global::Epiphany.Model.FeedItemModel>> GetFriendUpdatesAsync_FeedUpdateType_FeedUpdateFilter_Delegate(global::Epiphany.Model.Services.FeedUpdateType type, global::Epiphany.Model.Services.FeedUpdateFilter filter);

        public StubIUserService GetFriendUpdatesAsync(GetFriendUpdatesAsync_FeedUpdateType_FeedUpdateFilter_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.IUserService.AddFriend(global::Epiphany.Model.ProfileModel profile)
        {
            AddFriend_ProfileModel_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<AddFriend_ProfileModel_Delegate>("AddFriend");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<AddFriend_ProfileModel_Delegate>("AddFriend", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke(profile);
        }

        public delegate global::System.Threading.Tasks.Task AddFriend_ProfileModel_Delegate(global::Epiphany.Model.ProfileModel profile);

        public StubIUserService AddFriend(AddFriend_ProfileModel_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.IUserService.FollowUser(global::Epiphany.Model.ProfileModel user)
        {
            FollowUser_ProfileModel_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<FollowUser_ProfileModel_Delegate>("FollowUser");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<FollowUser_ProfileModel_Delegate>("FollowUser", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke(user);
        }

        public delegate global::System.Threading.Tasks.Task FollowUser_ProfileModel_Delegate(global::Epiphany.Model.ProfileModel user);

        public StubIUserService FollowUser(FollowUser_ProfileModel_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::System.Threading.Tasks.Task global::Epiphany.Model.Services.IUserService.UnfollowUser(global::Epiphany.Model.ProfileModel user)
        {
            UnfollowUser_ProfileModel_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<UnfollowUser_ProfileModel_Delegate>("UnfollowUser");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<UnfollowUser_ProfileModel_Delegate>("UnfollowUser", out del))
                {
                    return Task.FromResult(true);
                }
            }

            return del.Invoke(user);
        }

        public delegate global::System.Threading.Tasks.Task UnfollowUser_ProfileModel_Delegate(global::Epiphany.Model.ProfileModel user);

        public StubIUserService UnfollowUser(UnfollowUser_ProfileModel_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public StubIUserService(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}

namespace Epiphany.Model.Settings
{
    [CompilerGenerated]
    public class StubISettingStore : ISettingStore
    {
        private readonly StubContainer<StubISettingStore> _stubs = new StubContainer<StubISettingStore>();

        public MockBehavior MockBehavior { get; set; }

        T global::Epiphany.Model.Settings.ISettingStore.GetValueOrDefault<T>(global::Epiphany.Model.Settings.Setting setting, T defaultValue)
        {
            GetValueOrDefault_Setting_T_Delegate<T> del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetValueOrDefault_Setting_T_Delegate<T>>("GetValueOrDefault<T>");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetValueOrDefault_Setting_T_Delegate<T>>("GetValueOrDefault<T>", out del))
                {
                    return default(T);
                }
            }

            return del.Invoke(setting, defaultValue);
        }

        public delegate T GetValueOrDefault_Setting_T_Delegate<T>(global::Epiphany.Model.Settings.Setting setting, T defaultValue);

        public StubISettingStore GetValueOrDefault<T>(GetValueOrDefault_Setting_T_Delegate<T> del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        bool global::Epiphany.Model.Settings.ISettingStore.AddOrUpdate(global::Epiphany.Model.Settings.Setting setting, object value)
        {
            AddOrUpdate_Setting_Object_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<AddOrUpdate_Setting_Object_Delegate>("AddOrUpdate");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<AddOrUpdate_Setting_Object_Delegate>("AddOrUpdate", out del))
                {
                    return default(bool);
                }
            }

            return del.Invoke(setting, value);
        }

        public delegate bool AddOrUpdate_Setting_Object_Delegate(global::Epiphany.Model.Settings.Setting setting, object value);

        public StubISettingStore AddOrUpdate(AddOrUpdate_Setting_Object_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        bool global::Epiphany.Model.Settings.ISettingStore.Contains(global::Epiphany.Model.Settings.Setting setting)
        {
            Contains_Setting_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<Contains_Setting_Delegate>("Contains");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<Contains_Setting_Delegate>("Contains", out del))
                {
                    return default(bool);
                }
            }

            return del.Invoke(setting);
        }

        public delegate bool Contains_Setting_Delegate(global::Epiphany.Model.Settings.Setting setting);

        public StubISettingStore Contains(Contains_Setting_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public StubISettingStore(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}

namespace Epiphany.Web
{
    [CompilerGenerated]
    public class StubIAuthenticator : IAuthenticator
    {
        private readonly StubContainer<StubIAuthenticator> _stubs = new StubContainer<StubIAuthenticator>();

        public MockBehavior MockBehavior { get; set; }

        void global::Epiphany.Web.IAuthenticator.Authenticate(global::Epiphany.Web.WebRequest request)
        {
            Authenticate_WebRequest_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<Authenticate_WebRequest_Delegate>("Authenticate");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<Authenticate_WebRequest_Delegate>("Authenticate", out del))
                {
                    return;
                }
            }

            del.Invoke(request);
        }

        public delegate void Authenticate_WebRequest_Delegate(global::Epiphany.Web.WebRequest request);

        public StubIAuthenticator Authenticate(Authenticate_WebRequest_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public StubIAuthenticator(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}

namespace Epiphany.Web
{
    [CompilerGenerated]
    public class StubIAuthenticatorFactory : IAuthenticatorFactory
    {
        private readonly StubContainer<StubIAuthenticatorFactory> _stubs = new StubContainer<StubIAuthenticatorFactory>();

        public MockBehavior MockBehavior { get; set; }

        string global::Epiphany.Web.IAuthenticatorFactory.ConsumerKey
        {
            get
            {
                {
                    ConsumerKey_Get_Delegate del;
                    if (MockBehavior == MockBehavior.Strict)
                    {
                        del = _stubs.GetMethodStub<ConsumerKey_Get_Delegate>("get_ConsumerKey");
                    }
                    else
                    {
                        if (!_stubs.TryGetMethodStub<ConsumerKey_Get_Delegate>("get_ConsumerKey", out del))
                        {
                            return default(string);
                        }
                    }

                    return del.Invoke();
                }
            }
        }

        global::Epiphany.Web.IAuthenticator global::Epiphany.Web.IAuthenticatorFactory.CreateOAuthAuthenticator()
        {
            CreateOAuthAuthenticator_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<CreateOAuthAuthenticator_Delegate>("CreateOAuthAuthenticator");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<CreateOAuthAuthenticator_Delegate>("CreateOAuthAuthenticator", out del))
                {
                    return default(global::Epiphany.Web.IAuthenticator);
                }
            }

            return del.Invoke();
        }

        public delegate global::Epiphany.Web.IAuthenticator CreateOAuthAuthenticator_Delegate();

        public StubIAuthenticatorFactory CreateOAuthAuthenticator(CreateOAuthAuthenticator_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        bool global::Epiphany.Web.IAuthenticatorFactory.IsTokenAvailable()
        {
            IsTokenAvailable_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<IsTokenAvailable_Delegate>("IsTokenAvailable");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<IsTokenAvailable_Delegate>("IsTokenAvailable", out del))
                {
                    return default(bool);
                }
            }

            return del.Invoke();
        }

        public delegate bool IsTokenAvailable_Delegate();

        public StubIAuthenticatorFactory IsTokenAvailable(IsTokenAvailable_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate string ConsumerKey_Get_Delegate();

        public StubIAuthenticatorFactory ConsumerKey_Get(ConsumerKey_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public StubIAuthenticatorFactory(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}

namespace Epiphany.Web
{
    [CompilerGenerated]
    public class StubIWebClient : IWebClient
    {
        private readonly StubContainer<StubIWebClient> _stubs = new StubContainer<StubIWebClient>();

        public MockBehavior MockBehavior { get; set; }

        global::System.Threading.Tasks.Task<global::Epiphany.Web.WebResponse> global::Epiphany.Web.IWebClient.ExecuteAsync(global::Epiphany.Web.WebRequest request)
        {
            ExecuteAsync_WebRequest_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<ExecuteAsync_WebRequest_Delegate>("ExecuteAsync");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<ExecuteAsync_WebRequest_Delegate>("ExecuteAsync", out del))
                {
                    return Task.FromResult(default(global::Epiphany.Web.WebResponse));
                }
            }

            return del.Invoke(request);
        }

        public delegate global::System.Threading.Tasks.Task<global::Epiphany.Web.WebResponse> ExecuteAsync_WebRequest_Delegate(global::Epiphany.Web.WebRequest request);

        public StubIWebClient ExecuteAsync(ExecuteAsync_WebRequest_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public StubIWebClient(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}

namespace Epiphany.Xml
{
    [CompilerGenerated]
    public class StubIPartialCollection<T> : IPartialCollection<T>
    {
        private readonly StubContainer<StubIPartialCollection<T>> _stubs = new StubContainer<StubIPartialCollection<T>>();

        public MockBehavior MockBehavior { get; set; }

        string global::Epiphany.Xml.IPartialCollection<T>.Start
        {
            get
            {
                {
                    Start_Get_Delegate del;
                    if (MockBehavior == MockBehavior.Strict)
                    {
                        del = _stubs.GetMethodStub<Start_Get_Delegate>("get_Start");
                    }
                    else
                    {
                        if (!_stubs.TryGetMethodStub<Start_Get_Delegate>("get_Start", out del))
                        {
                            return default(string);
                        }
                    }

                    return del.Invoke();
                }
            }
        }

        string global::Epiphany.Xml.IPartialCollection<T>.End
        {
            get
            {
                {
                    End_Get_Delegate del;
                    if (MockBehavior == MockBehavior.Strict)
                    {
                        del = _stubs.GetMethodStub<End_Get_Delegate>("get_End");
                    }
                    else
                    {
                        if (!_stubs.TryGetMethodStub<End_Get_Delegate>("get_End", out del))
                        {
                            return default(string);
                        }
                    }

                    return del.Invoke();
                }
            }
        }

        string global::Epiphany.Xml.IPartialCollection<T>.Total
        {
            get
            {
                {
                    Total_Get_Delegate del;
                    if (MockBehavior == MockBehavior.Strict)
                    {
                        del = _stubs.GetMethodStub<Total_Get_Delegate>("get_Total");
                    }
                    else
                    {
                        if (!_stubs.TryGetMethodStub<Total_Get_Delegate>("get_Total", out del))
                        {
                            return default(string);
                        }
                    }

                    return del.Invoke();
                }
            }
        }

        T[] global::Epiphany.Xml.IPartialCollection<T>.Items
        {
            get
            {
                {
                    Items_Get_Delegate del;
                    if (MockBehavior == MockBehavior.Strict)
                    {
                        del = _stubs.GetMethodStub<Items_Get_Delegate>("get_Items");
                    }
                    else
                    {
                        if (!_stubs.TryGetMethodStub<Items_Get_Delegate>("get_Items", out del))
                        {
                            return default(T[]);
                        }
                    }

                    return del.Invoke();
                }
            }
        }

        public delegate string Start_Get_Delegate();

        public StubIPartialCollection<T> Start_Get(Start_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate string End_Get_Delegate();

        public StubIPartialCollection<T> End_Get(End_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate string Total_Get_Delegate();

        public StubIPartialCollection<T> Total_Get(Total_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate T[] Items_Get_Delegate();

        public StubIPartialCollection<T> Items_Get(Items_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public StubIPartialCollection(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}