using System;
using System.Diagnostics;

namespace LinkedList
{
    public class LinkedListOperation
    {
        public Node Head { get; set; }
        public void AddNode(Node newNode, Action<Node> linkedListOperationAction)
        {
            if (Head == null)
            {
                Head = newNode;
                return;
            }

            linkedListOperationAction(newNode);
        }

        public void InsertNodeAtEnd(Node node)
        {
            Node temp = Head;

            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = node;
        }

        public void InsertNodeAtFirst(Node node)
        {
            node.Next = Head;
            Head = node;
        }

        public void InsertNodeAtAGivenPosition(Node node, int indexPosition)
        {
            int counter = 0;
            Node temp = Head;

            while (temp.Next != null)
            {
                if (indexPosition == counter)
                {
                    node.Next = temp.Next;
                    temp.Next = node;
                    
                    return;
                }
                temp = temp.Next;
                counter++;
            }
        }

        public void DeleteFirstNode()
            => Head = Head.Next;

        public void DeleteLastNode()
        {
            Node temp = Head;
            Node previousNode = Head;

            while (temp.Next != null)
            {
                previousNode = temp;
                temp = temp.Next;
            }
            previousNode.Next = null;
        }

        public void DeleteNodeFromMiddle(int nodeIndexPosition)
        {
            int counter = 0;
            Node temp = Head;
            Node previousNode = Head;
           
            while (temp.Next != null)
            {
                if (nodeIndexPosition == counter)
                {
                    previousNode.Next = temp.Next;
                    return;
                }
                previousNode = temp;
                temp = temp.Next;
                counter++;
            }
        }

        public void Traverse()
        {
            while (Head.Next != null)
            {
                Head = Head.Next;
                Debug.WriteLine(Head.Data);
            }
        }
    }
}
