using Epiphany.Model.Adapter;
using Epiphany.Model.Collections;
using Epiphany.Model.DataSources;
using Epiphany.Xml;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Epiphany.Model.Tests.Collections
{
    [TestClass]
    public class PagedCollectionTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            IPagedCollection<UserModel> users;
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                users = new PagedCollection<UserModel, GoodreadsUser, GoodreadsFriends>(null, null, 0);
            });

            int size = 20;
            int pageSize = 5;

            users = new PagedCollection<UserModel, GoodreadsUser, GoodreadsFriends>(new MockCollectionDataSource(size), new UserAdapter(), pageSize);
            Assert.IsTrue(users.Count == 0, "Count is not zero initially");
        }

        [TestMethod]
        public async Task LoadPageTest()
        {
            int size = 11, pageSize = 10;
            //
            // Size is greater than count per page
            //
            IPagedDataSource<GoodreadsFriends> ds = new MockCollectionDataSource(size);
            PagedCollection<UserModel, GoodreadsUser, GoodreadsFriends> users = new PagedCollection<UserModel, GoodreadsUser, GoodreadsFriends>(ds, new UserAdapter(), pageSize);

            bool result = await users.LoadPage();
            Assert.IsTrue(result, "LoadPage failed");
            Assert.AreEqual(users.Items.Count, pageSize, "Paged Collection not Loading in multiples of counts per page");

            result = await users.LoadPage();
            Assert.IsTrue(result, "LoadPage failed");
            Assert.AreEqual(users.Items.Count, size, "Size does not match");

            result = await users.LoadPage();
            Assert.IsFalse(result, "LoadPage did not report completion. result is not false");

            //
            // Size is lesser than items per page
            //

            size = 5;
            pageSize = 10;

            ds = new MockCollectionDataSource(size);
            users = new PagedCollection<UserModel, GoodreadsUser, GoodreadsFriends>(ds, new UserAdapter(), pageSize);

            result = await users.LoadPage();
            Assert.IsTrue(result, "LoadPage failed");
            Assert.AreEqual(users.Items.Count, 5, "Size does not match");

            result = await users.LoadPage();
            Assert.IsFalse(result, "LoadPage did not report completion. result is not false");

            //
            // Size is zero
            //

            size = 0;
            pageSize = 10;

            ds = new MockCollectionDataSource(size);
            users = new PagedCollection<UserModel, GoodreadsUser, GoodreadsFriends>(ds, new UserAdapter(), pageSize);

            result = await users.LoadPage();
            Assert.IsFalse(result, "LoadPage did not report completion. result is not false");

            //
            // Items per count is zero
            //

            size = 10;
            pageSize = 0;
            ds = new MockCollectionDataSource(size);
            users = new PagedCollection<UserModel, GoodreadsUser, GoodreadsFriends>(ds, new UserAdapter(), pageSize);

            result = await users.LoadPage();
            Assert.IsFalse(result, "LoadPage did not report completion. result is not false");
        }

        [TestMethod]
        public async Task EnumeratorTest()
        {
            int size = 45;
            int pageSize = 10;

            MockCollectionDataSource ds = new MockCollectionDataSource(size);
            PagedCollection<UserModel, GoodreadsUser, GoodreadsFriends> users = new PagedCollection<UserModel, GoodreadsUser, GoodreadsFriends>(ds, new UserAdapter(), pageSize);

            IAsyncEnumerator<UserModel> enumerator = users.GetEnumerator();
            List<UserModel> actualItems = new List<UserModel>();
            while (await enumerator.MoveNext())
            {
                actualItems.Add(enumerator.Current);
            }

            Assert.AreEqual(actualItems.Count, ds.ExpectedItems.Count, "Count does not match");
            Assert.AreEqual(actualItems.Count, users.Count, "Count does not match");
            for (int i = 0; i < actualItems.Count; i++)
            {
                UserModel expectedItem = new UserModel(ds.ExpectedItems[i]);
                CompareLogic logic = new CompareLogic();
                ComparisonResult result = logic.Compare(actualItems[i], expectedItem);
                Assert.IsTrue(result.AreEqual, result.DifferencesString);
            }
        }

        [TestMethod]
        public async Task ClearTest()
        {
            int size = 11;
            int pageSize = 10;

            MockCollectionDataSource ds = new MockCollectionDataSource(size);
            PagedCollection<UserModel, GoodreadsUser, GoodreadsFriends> users = new PagedCollection<UserModel, GoodreadsUser, GoodreadsFriends>(ds, new UserAdapter(), pageSize);

            bool result = await users.LoadPage();
            Assert.IsTrue(users.Count == pageSize, "LoadPage failed");

            bool resetRaised = false;
            users.Reset += (s, e) =>
            {
                resetRaised = true;
            };

            users.Clear();
            Assert.AreEqual(users.Count, 0, "LoadPage failed");
            Assert.IsTrue(resetRaised, "Reset event not raised");
        }
    }

    class MockCollectionDataSource : IPagedDataSource<GoodreadsFriends>
    {
        private readonly int size;
        private List<GoodreadsUser> users = new List<GoodreadsUser>();

        public MockCollectionDataSource(int size)
        {
            this.size = size;

            for (int i = 0; i < size; i++)
            {
                GoodreadsUser user = new GoodreadsUser()
                {
                    Id = i + 1,
                    Name = "Test Name " + i + 1,
                    ImageUrl = "http://www.google.com",
                    Link = "http://www.google.com",
                    Location = "TestLoc " + i + 1
                };
                users.Add(user);
            }
        }

        public List<GoodreadsUser> ExpectedItems
        {
            get
            {
                return this.users;
            }
        }

        public Task<GoodreadsFriends> GetAsync(int page, int pageSize)
        {
            List<GoodreadsUser> list = new List<GoodreadsUser>();
            if (size == 0)
            {
                GoodreadsFriends friends = new GoodreadsFriends()
                {
                    Start = "0",
                    End = "0",
                    Total = "0"
                };
                return Task.FromResult<GoodreadsFriends>(friends);
            }

            for (int i = ((page - 1) * pageSize); i < Math.Min(size, page * pageSize); i++)
            {
                list.Add(users[i]);
            }

            GoodreadsFriends f = new GoodreadsFriends()
            {
                Start = ((page - 1) * pageSize).ToString(),
                End = Math.Min(size, page * pageSize).ToString(),
                Total = size.ToString(),
                Items = list.ToArray()
            };

            return Task.FromResult<GoodreadsFriends>(f);
        }
    }

}

