using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedList
    {
        private Node head;
        private Node current;//This will have latest node
        public int Count;

        public LinkedList()
        {
            head = new Node();
            current = head;
        }

        public void AddAtLast(object data)
        {
            Node newNode = new Node();
            newNode.Value = data;
            current.Next = newNode;
            current = newNode;
            Count++;
        }

        public void AddAtStart(object data)
        {
            Node newNode = new Node() { Value = data};
            newNode.Next = head.Next;
            head.Next = newNode;
            Count++;
        }

        public void RemoveFromStart()
        {
            if (Count > 0)
            {
                head.Next = head.Next.Next;
                Count--;
            }
            else
            {
                Console.WriteLine("No element exist in this linked list.");
            }
        }

        /// <summary>
        /// Traverse from head and print all nodes value
        /// </summary>
        public void PrintAllNodes()
        {
            //Traverse from head 
            Console.Write("Head ->");
            Node curr = head;
            while (curr.Next != null)
            {
                curr = curr.Next;
                Console.Write(curr.Value);
                Console.Write("->");
            }
            Console.Write("NULL");
        }
    }

    public class Node
    {
        public Node Next;
        public object Value;
    }

class Program
{
    static void Main(string[] args)
    {
           
        LinkedList lnklist = new LinkedList();
        lnklist.PrintAllNodes();
        Console.WriteLine();

        lnklist.AddAtLast(12);
        lnklist.AddAtLast("John");
        lnklist.AddAtLast("Peter");
        lnklist.AddAtLast(34);
        lnklist.PrintAllNodes();
        Console.WriteLine();

        lnklist.AddAtStart(55);
        lnklist.PrintAllNodes();
        Console.WriteLine();

        lnklist.RemoveFromStart();
        lnklist.PrintAllNodes();


        Console.ReadKey();
    }
}
}
