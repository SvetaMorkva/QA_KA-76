using NUnit.Framework;

namespace Lab_1
{
    public class UnitTest1
    {
        StackItems[] item = new StackItems[5];

        [SetUp]
        public void SetUp()
        {
            item[0] = new StackItems();
            item[1] = new StackItems();
            item[2] = new StackItems();
            item[3] = new StackItems();

        }

        [Test]
        public void Test_Pop()
        {
            MyStack<Item> a = item[0].stack;
            Item name = a.Pop();
            Assert.AreEqual(4, a.Count);
        }

        [Test]
        public void Test_Push()
        {
            MyStack<Item> a = item[1].stack;
            Item add_name = new Item { name = "Sixth" };
            a.Push(add_name);
            Assert.AreEqual(add_name, a.Peek());

        }

        [Test]
        public void Test_Peek()
        {
            MyStack<Item> a = item[2].stack;
            Item delet_name = a.Pop();
            Assert.AreEqual("Fourth", a.Peek().name);
        }
    }
}
