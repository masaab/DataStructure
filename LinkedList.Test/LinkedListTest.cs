using System.Collections.Generic;
using Xunit;

namespace LinkedList.Test
{
    public class LinkedListTest
    {
        [Fact]
        public void InsertNodeEndOfListTest()
        {
            //Arrange
            LinkedListOperation linkedListOperation = new LinkedListOperation();

            //Act
            foreach (Node node in SampleNodes())
            {
                linkedListOperation.AddNode(node, linkedListOperation.InsertNodeAtEnd);
            }

            //Assert
            int counter = 0;

            while (linkedListOperation.Head.Next != null)
            {
                Assert.Equal(SampleNodes()[counter].Data,linkedListOperation.Head.Data);
                counter++;
                linkedListOperation.Head = linkedListOperation.Head.Next;
            }
        }

       [Fact]
       public void InsertNodeBeginingOfListTest()
        {
            //Arrange
            LinkedListOperation linkedListOperation = new LinkedListOperation();

            //Act
            foreach (Node node in SampleNodes())
            {
                linkedListOperation.AddNode(node, linkedListOperation.InsertNodeAtFirst);
            }

            //Assert
            int counter = 0;
            var list = SampleNodes();
            list.Reverse();

            while (linkedListOperation.Head.Next != null)
            {
                Assert.Equal(list[counter].Data, linkedListOperation.Head.Data);
                counter++;
                linkedListOperation.Head = linkedListOperation.Head.Next;
            }
        }

        [Theory]
        [InlineData("item 3 again", 3)]
        public void InsertNodeBetweenList(string nodeValue, int indexValue)
        {
            //Arrange
            var linkedListOperation = ArrangeScenarioForDeleteOperation();

            //Act
            linkedListOperation.InsertNodeAtAGivenPosition(new Node(nodeValue), indexValue);

            //Assert
            bool isNodeExists = false;

            while (linkedListOperation.Head != null)
            {
                if (linkedListOperation.Head.Data == nodeValue)
                    isNodeExists = true;

                linkedListOperation.Head = linkedListOperation.Head.Next;
            }

            Assert.True(isNodeExists);
        }

        [Fact]
        public void DeleteFirstNode()
        {
            //Arrange
            var linkedListOperation = ArrangeScenarioForDeleteOperation();

            //Act
            linkedListOperation.DeleteFirstNode();

            //Assert
            Assert.Equal("item 2", linkedListOperation.Head.Data);
        }

        [Theory]
        [InlineData(3,"item 4")]
        public void DeleteNodeFromMiddle(int index, string value)
        {
            //Arrange
            var linkedListOperation = ArrangeScenarioForDeleteOperation();

            //Act
            linkedListOperation.DeleteNodeFromMiddle(index);

            //Assert
            bool isDeleted = true;

            while (linkedListOperation.Head != null)
            {
                if (linkedListOperation.Head.Data == value)
                    isDeleted = false;

                linkedListOperation.Head = linkedListOperation.Head.Next;
            }

            Assert.True(isDeleted);
        }

        [Theory]
        [InlineData("item 5")]
        public void DeleteLastNode(string expectedValue)
        {
            //Arrange
            var linkedListOperation = ArrangeScenarioForDeleteOperation();

            //Act
            linkedListOperation.DeleteLastNode();

            //Assert
            while (linkedListOperation.Head.Next != null)
            {
                linkedListOperation.Head = linkedListOperation.Head.Next;
            }

            Assert.Equal(expectedValue, linkedListOperation.Head.Data);
        }

        private LinkedListOperation ArrangeScenarioForDeleteOperation()
        {
            LinkedListOperation linkedListOperation = new LinkedListOperation();

            foreach (Node node in SampleNodes())
            {
                linkedListOperation.AddNode(node, linkedListOperation.InsertNodeAtEnd);
            }
            return linkedListOperation;
        }

        private List<Node> SampleNodes()
        {
            return new List<Node>
            {
                new Node("item 1"),
                new Node("item 2"),
                new Node("item 3"),
                new Node("item 4"),
                new Node("item 5"),
                new Node("item 6"),
            };
        }
    }
}
