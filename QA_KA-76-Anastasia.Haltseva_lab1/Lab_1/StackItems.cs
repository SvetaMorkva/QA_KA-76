using System;
namespace Lab_1
{
    public class Item
    {
        public string name { get; set; }

        public string String()
        {
            return string.Format("Items=  ", name);
        }

    }
    public class StackItems
    {
        public MyStack<Item> stack { get; }
        public StackItems()
        {
            stack = new MyStack<Item>();
            stack.Push(new Item { name = "First" });
            stack.Push(new Item { name = "Seckond" });
            stack.Push(new Item { name = "Third" });
            stack.Push(new Item { name = "Fourth" });
            stack.Push(new Item { name = "Fifth" });
        }
    }
}
