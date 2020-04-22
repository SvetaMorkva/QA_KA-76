using System;

namespace Lab_1
{
    public class Content
    {
        
        public string name { get; set; }
        
        public string String()
        {
            return string.Format("Name=  ",name);
        }
     
    }
    public class People
    {
        public Stack<Content> stack { get; }
        public People(int n=5)
        {
            stack = new Stack<Content>();
                stack.Push(new Content { name = "Tom" });
                stack.Push(new Content { name = "Bob" });
                stack.Push(new Content { name = "Sam" });
                stack.Push(new Content { name = "Ann" });
                stack.Push(new Content { name = "Elen" });
             
            
        }
        
       

    }
}
