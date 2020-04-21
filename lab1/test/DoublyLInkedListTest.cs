using System;
using Xunit;
using lab1;

public class DoublyLinkedListTest
{
    /*
        Every method annotated with [Fact] will be marked as a test and run by xUnit.net
        Fact methods cannot have parameters
        The [Theory] attribute denotes a parameterised test
    */
    [Theory]
    [InlineData(1)]

    public void AddTest(int value)
    {
        Console.WriteLine("Testing DoublyLinkedList.Add");
        var linked_list = new DoublyLinkedList(0);
        linked_list.Add(value);
        int new_head_key = linked_list.getHead().getKey();
        Assert.Equal(value, new_head_key);

        linked_list.Add(2);
        new_head_key = linked_list.getHead().getKey();
        Assert.Equal(2, new_head_key);
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
        Assert.Equal(2, curr.getKey());
        int next = curr.getNext().getKey();
        int prev = curr.getPrev().getKey();
        Assert.Equal(3, next);
        Assert.Equal(1, prev);
    }
}
