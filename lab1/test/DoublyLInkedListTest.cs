using System;
using Xunit;
using lab1;

// namespace lab1
// {
    public class DoublyLinkedListTest
    {
        [Theory]
        [InlineData(1)]
        public void AddTest(int value)
        {
            Console.WriteLine("Testing DoublyLinkedList.Add");
            var linked_list = new DoublyLinkedList(0);
            linked_list.Add(value);
            int new_head_key = linked_list.getHead().getKey();
            Assert.Equal(new_head_key, value);

            linked_list.Add(2);
            new_head_key = linked_list.getHead().getKey();
            Assert.Equal(new_head_key, 2);
        }

        [Fact]

        public void GetNextPrevTest()
        {
            Console.WriteLine("Testing Node.GetNext");
            DoublyLinkedList linked_list = new DoublyLinkedList(0);
            linked_list.Add(1);
            linked_list.Add(2);
            linked_list.Add(3);
            Node curr = linked_list.GetCurrent(2);
            Assert.Equal(curr.getKey(), 2);
            int next = curr.getNext().getKey();
            int prev = curr.getPrev().getKey();
            Assert.Equal(next, 3);
            Assert.Equal(prev, 1);
        }
    }
// }
