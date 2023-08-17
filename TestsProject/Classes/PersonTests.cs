using DVT___Challenge.Classes;


namespace TestsProject.Classes
{

    public class PersonTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPersonEqualityBasedOnIndex()
        {
            var list = new List<Person> { new Person(0,1)};

            list.Remove(new Person(0, 1));

            Assert.That(list.Count, Is.EqualTo(0), "Unexpected number of items after Delete from List operation. Equals not working as expected.");

        }
    }
}
