using System;

namespace Lab_1
{
    public class Content
    {
        public string name { get; set; }

        public string String()
        {
            return string.Format("Items=  ", name);
        }

    }
    public class Items
    {
        public Stack<Content> stack { get; }
        public Items ()
        {
            stack = new Stack<Content>();
            stack.Push(new Content { name = "chair" });
            stack.Push(new Content { name = "table" });
            stack.Push(new Content { name = "sofa" });
            stack.Push(new Content { name = "bed" });
            stack.Push(new Content { name = "mirror" });
        }


    }
}
