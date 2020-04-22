using NUnit.Framework;

namespace Lab_1
{

    public class UnitTest1
    {
        Items[] item = new Items[5];
        
        [SetUp]
        public void SetUp()
        {
            item[0] = new Items();
            item[1] = new Items();
            item[2] = new Items();

        }

        [Test]
        public void Test_Pop()
        {
            Stack<Content> a = item[0].stack;
            Content name = a.Pop();
            Assert.AreEqual(4, a.Count);
        }

        [Test]
        public void Test_Push()
        {
            Stack<Content> a = item[1].stack;
            Content add_name = new Content { name = "box" };
            a.Push(add_name);
            Assert.AreEqual(add_name, a.Peek());

        }

        [Test]
        public void Test_Peek()
        {
            Stack<Content> a = item[2].stack;
            Content delet_name = a.Pop();
            Assert.AreEqual("bed", a.Peek().name);
        }
    }
}
