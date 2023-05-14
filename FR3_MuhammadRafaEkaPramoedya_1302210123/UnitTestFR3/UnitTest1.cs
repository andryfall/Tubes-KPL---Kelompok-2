using FR3_MuhammadRafaEkaPramoedya_1302210123;
namespace UnitTestFR3
{
    [TestClass]
    public class EventReposTest
    {
        [TestMethod]
        public void TestingAddEvent()
        {
            // Arrange
            EventRepos<Event> repository = new EventRepos<Event>();
            Event e = new Event() { Title = "Event 1", StartDate = new DateTime(2023, 6, 1), Description = "Description 1" };

            // Act
            repository.Add(e);
            List<Event> events = repository.Search(ev => ev.Title == "Event 1");

            // Assert
            Assert.AreEqual(1, events.Count);
            Assert.AreEqual("Event 1", events[0].Title);
            Assert.AreEqual(new DateTime(2023, 6, 1), events[0].StartDate);
            Assert.AreEqual("Description 1", events[0].Description);
        }

        [TestMethod]
        public void TestingSearch()
        {
            // Arrange
            EventRepos<Event> repository = new EventRepos<Event>();
            repository.Add(new Event() { Title = "Event 1", StartDate = new DateTime(2023, 6, 1), Description = "Description 1" });
            repository.Add(new Event() { Title = "Event 2", StartDate = new DateTime(2023, 6, 2), Description = "Description 2" });
            repository.Add(new Event() { Title = "Event 3", StartDate = new DateTime(2023, 6, 3), Description = "Description 3" });

            // Act
            List<Event> events = repository.Search(ev => ev.Title.Contains("Event 2"));

            // Assert
            Assert.AreEqual(1, events.Count);
            Assert.AreEqual("Event 2", events[0].Title);
            Assert.AreEqual(new DateTime(2023, 6, 2), events[0].StartDate);
            Assert.AreEqual("Description 2", events[0].Description);
        }
    }
}