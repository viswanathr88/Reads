using Epiphany.Xml;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.IO;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace Epiphany.Xml.Tests
{
    [TestClass]
    public class ParseTests
    {
        private string url;

        [TestMethod]
        public async Task AuthorParseTest()
        {
            url = "Input\\Author.xml";
            string xml = await ReadFile(url);
            Response actual = Parser.GetResponse(xml);
            Response expected = await GetResponse(url);

            CompareLogic logic = new CompareLogic();
            ComparisonResult result = logic.Compare(actual.Author, expected.Author);
            Assert.IsTrue(result.AreEqual, result.DifferencesString);
        }

        [TestMethod]
        public async Task ProfileParseTest()
        {
            url = "Input\\Profile.xml";
            string xml = await ReadFile(url);
            Response actual = Parser.GetResponse(xml);
            Response expected = await GetResponse(url);

            CompareLogic logic = new CompareLogic();
            ComparisonResult result = logic.Compare(actual.Profile, expected.Profile);
            Assert.IsTrue(result.AreEqual, result.DifferencesString);
        }

        [TestMethod]
        public async Task BookParseTest()
        {
            url = "Input\\Book.xml";
            string xml = await ReadFile(url);
            Response actual = Parser.GetResponse(xml);
            Response expected = await GetResponse(url);

            CompareLogic logic = new CompareLogic();
            ComparisonResult result = logic.Compare(actual.Book, expected.Book);
            Assert.IsTrue(result.AreEqual, result.DifferencesString);
        }

        [TestMethod]
        public async Task BookReviewsParseTest()
        {
            url = "Input\\BookReviews.xml";
            string xml = await ReadFile(url);
            Response actual = Parser.GetResponse(xml);
            Response expected = await GetResponse(url);

            CompareLogic logic = new CompareLogic();
            ComparisonResult result = logic.Compare(actual.Book, expected.Book);
            Assert.IsTrue(result.AreEqual, result.DifferencesString);
        }

        [TestMethod]
        public async Task BooksByAnAuthorParseTest()
        {
            url = "Input\\BooksByAnAuthor.xml";
            string xml = await ReadFile(url);
            Response actual = Parser.GetResponse(xml);
            Response expected = await GetResponse(url);

            CompareLogic logic = new CompareLogic();
            ComparisonResult result = logic.Compare(actual.Author, expected.Author);
            Assert.IsTrue(result.AreEqual, result.DifferencesString);
        }

        [TestMethod]
        public async Task BookshelvesParseTest()
        {
            url = "Input\\Bookshelves.xml";
            string xml = await ReadFile(url);
            Response actual = Parser.GetResponse(xml);
            Response expected = await GetResponse(url);

            CompareLogic logic = new CompareLogic();
            ComparisonResult result = logic.Compare(actual.ShelfCollection, expected.ShelfCollection);
            Assert.IsTrue(result.AreEqual, result.DifferencesString);
        }

        [TestMethod]
        public async Task BooksInShelfParseTest()
        {
            url = "Input\\BooksInShelf.xml";
            string xml = await ReadFile(url);
            Response actual = Parser.GetResponse(xml);
            Response expected = await GetResponse(url);

            CompareLogic logic = new CompareLogic();
            ComparisonResult result = logic.Compare(actual.BooksInShelf, expected.BooksInShelf);
            Assert.IsTrue(result.AreEqual, result.DifferencesString);
        }

        [TestMethod]
        public async Task EventsParseTest()
        {
            url = "Input\\Events.xml";
            string xml = await ReadFile(url);
            Response actual = Parser.GetResponse(xml);
            Response expected = await GetResponse(url);

            CompareLogic logic = new CompareLogic();
            ComparisonResult result = logic.Compare(actual.Events, expected.Events);
            Assert.IsTrue(result.AreEqual, result.DifferencesString);
        }

        [TestMethod]
        public async Task FeedParseTest()
        {
            url = "Input\\Feed.xml";
            string xml = await ReadFile(url);
            Response actual = Parser.GetResponse(xml);
            Response expected = await GetResponse(url);

            CompareLogic logic = new CompareLogic();
            ComparisonResult result = logic.Compare(actual.Updates, expected.Updates);
            Assert.IsTrue(result.AreEqual, result.DifferencesString);
        }

        [TestMethod]
        public async Task FriendsParseTest()
        {
            url = "Input\\Friends.xml";
            string xml = await ReadFile(url);
            Response actual = Parser.GetResponse(xml);
            Response expected = await GetResponse(url);

            CompareLogic logic = new CompareLogic();
            ComparisonResult result = logic.Compare(actual.Friends, expected.Friends);
            Assert.IsTrue(result.AreEqual, result.DifferencesString);
        }

        [TestMethod]
        public async Task GroupParseTest()
        {
            url = "Input\\Group.xml";
            string xml = await ReadFile(url);
            Response actual = Parser.GetResponse(xml);
            Response expected = await GetResponse(url);

            CompareLogic logic = new CompareLogic();
            ComparisonResult result = logic.Compare(actual.Group, expected.Group);
            Assert.IsTrue(result.AreEqual, result.DifferencesString);
        }

        [TestMethod]
        public async Task GroupsParseTest()
        {
            url = "Input\\Feed.xml";
            string xml = await ReadFile(url);
            Response actual = Parser.GetResponse(xml);
            Response expected = await GetResponse(url);

            CompareLogic logic = new CompareLogic();
            ComparisonResult result = logic.Compare(actual.Groups, expected.Groups);
            Assert.IsTrue(result.AreEqual, result.DifferencesString);
        }

        [TestMethod]
        public async Task NotificationParseTest()
        {
            url = "Input\\Notification.xml";
            string xml = await ReadFile(url);
            Response actual = Parser.GetResponse(xml);
            Response expected = await GetResponse(url);

            CompareLogic logic = new CompareLogic();
            ComparisonResult result = logic.Compare(actual.Notifications, expected.Notifications);
            Assert.IsTrue(result.AreEqual, result.DifferencesString);
        }

        [TestMethod]
        public async Task ReviewParseTest()
        {
            url = "Input\\Review.xml";
            string xml = await ReadFile(url);
            Response actual = Parser.GetResponse(xml);
            Response expected = await GetResponse(url);

            CompareLogic logic = new CompareLogic();
            ComparisonResult result = logic.Compare(actual.Review, expected.Review);
            Assert.IsTrue(result.AreEqual, result.DifferencesString);
        }

        [TestMethod]
        public async Task SearchParseTest()
        {
            url = "Input\\Search.xml";
            string xml = await ReadFile(url);
            Response actual = Parser.GetResponse(xml);
            Response expected = await GetResponse(url);

            CompareLogic logic = new CompareLogic();
            ComparisonResult result = logic.Compare(actual.Search, expected.Search);
            Assert.IsTrue(result.AreEqual, result.DifferencesString);
        }

        [TestMethod]
        public async Task TopicParseTest()
        {
            url = "Input\\Topic.xml";
            string xml = await ReadFile(url);
            Response actual = Parser.GetResponse(xml);
            Response expected = await GetResponse(url);

            CompareLogic logic = new CompareLogic();
            ComparisonResult result = logic.Compare(actual.Topic, expected.Topic);
            Assert.IsTrue(result.AreEqual, result.DifferencesString);
        }

        [TestMethod]
        public async Task TopicsParseTest()
        {
            url = "Input\\Topics.xml";
            string xml = await ReadFile(url);
            Response actual = Parser.GetResponse(xml);
            Response expected = await GetResponse(url);

            CompareLogic logic = new CompareLogic();
            ComparisonResult result = logic.Compare(actual.GroupFolder, expected.GroupFolder);
            Assert.IsTrue(result.AreEqual, result.DifferencesString);
        }


        private async Task<string> ReadFile(string url)
        {
            var folder = Package.Current.InstalledLocation;

            using (Stream stream = await folder.OpenStreamForReadAsync(url))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    return content;
                }
            }
        }

        private async Task<Response> GetResponse(string url)
        {
            var folder = Package.Current.InstalledLocation;

            using (Stream stream = await folder.OpenStreamForReadAsync(url))
            {
                return TestParser.ParseXml(stream);
            }
        }
    }
}
