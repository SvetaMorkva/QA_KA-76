using NUnit.Framework;

namespace Queue
{

    public class UnitTest1
    {
        Items[] item = new Items[6];

        [SetUp]
        public void SetUp()
        {
            item[0] = new Items();
            item[1] = new Items();
            item[2] = new Items();
            item[3] = new Items();


        }
        

        [Test]
        public void Test_Enqueue()
        {
            Queue<People> a = item[0].queue;
            People add_name = new People { name = "July" };
            a.Enqueue(add_name);
            Assert.AreEqual(add_name, a.Last());

        }

        [Test]
        public void Test_Peek()
        {
            Queue<People> a = item[1].queue;
            Assert.AreEqual("Pol", a.Peek().name);
        }

        [Test]
        public void Test_Dequeue()
        {
            Queue<People> a = item[3].queue;
            People name = a.Dequeue();
            Assert.AreEqual(5, a.Count);
        }
    }
}
