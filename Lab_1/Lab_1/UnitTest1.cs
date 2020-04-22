using NUnit.Framework;

namespace Lab_1
{
    
    public class UnitTest1
    {
        People[] list = new People[5];
        [SetUp]
        public void SetUp()
        {
            list[0] = new People();
            list[1] = new People();
            list[2] = new People();

        }
        [Test]
        public void Test_Pop()
        {
            Stack<Content> a = list[0].stack;
            Content name = a.Pop();
            Assert.AreEqual(4, a.Count);
        }
        [Test]
        public void Test_Push()
        {
            Stack<Content> a = list[1].stack;
            Content add_name = new Content {name="Alice" };
            a.Push(add_name);
            Assert.AreEqual(add_name,a.Peek());   
        }
        [Test]
        public void Test_Peek()
        {
            Stack<Content> a = list[2].stack;
            Content delet_name = a.Pop();
            Assert.AreEqual("Ann", a.Peek().name);
        }
    }
}
