using System;

namespace Lab1
{
    public class Mock
    {
        public static CustomList<Word> list = new CustomList<Word>();
        public static void FillMock()
        {
            list.Add(new Word { Value = "abc",        Count = 3 });
            list.Add(new Word { Value = "abcd",       Count = 4 });
            list.Add(new Word { Value = "a",          Count = 1 });
            list.Add(new Word { Value = "abcdef",     Count = 6 });
            list.Add(new Word { Value = "1234567890", Count = 10 });
        }
    }

    public class Word
    {
        public string Value { get; set; }
        public int Count { get; set; }

        public void toString()
        {
            Console.Write(string.Format("{0} - {1}\n", Value, Count));
        }
    }
}
