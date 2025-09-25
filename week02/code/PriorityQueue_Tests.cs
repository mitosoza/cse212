using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following people and priorities: Peter (1), Tim (5), Sue (3), and Bob (2)
    // Expected Result: Tim, Sue, Bob, Peter
    // Defect(s) Found: 1, expected 'Sue' and actual was 'Tim'. It's not checking last item in the list.
    public void TestPriorityQueue_HighestPriorityFirst()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Peter", 1);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 3);
        priorityQueue.Enqueue("Bob", 2);

        Assert.AreEqual("Tim", priorityQueue.Dequeue());
        Assert.AreEqual("Sue", priorityQueue.Dequeue());
        Assert.AreEqual("Bob", priorityQueue.Dequeue());
        Assert.AreEqual("Peter", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Create a queue with the following people and priorities: Bob (2), Tim (5), Sue (3), John (5), and Peter (1)
    // Expected Result: Tim, John, Sue, Bob, Peter
    // Defect(s) Found: 1, expected 'Tim', but actual was 'John'. They have the same priority, but Tim was not dequeuded
    public void TestPriorityQueue_DuplicatedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 2);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 3);
        priorityQueue.Enqueue("John", 5);
        priorityQueue.Enqueue("Peter", 1);

        Assert.AreEqual("Tim", priorityQueue.Dequeue());
        Assert.AreEqual("John", priorityQueue.Dequeue());
        Assert.AreEqual("Sue", priorityQueue.Dequeue());
        Assert.AreEqual("Bob", priorityQueue.Dequeue());
        Assert.AreEqual("Peter", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to get the next person from an empty queue
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: 0, succeeded.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                              e.GetType(), e.Message)
            );
        }
    }
}