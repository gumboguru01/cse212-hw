using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities.
    // Expected Result: Items should be dequeued in order from highest to lowest priority.
    // Defect(s) Found: None after fixing PriorityQueue to evaluate priorities correctly.
    public void TestPriorityQueue_HighestPriorityFirst()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("Low", 1);
        queue.Enqueue("Medium", 5);
        queue.Enqueue("High", 10);

        Assert.AreEqual("High", queue.Dequeue());
        Assert.AreEqual("Medium", queue.Dequeue());
        Assert.AreEqual("Low", queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority.
    // Expected Result: They should be dequeued in the same order they were added (FIFO).
    // Defect(s) Found: Original code may not follow FIFO if implemented incorrectly.
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("First", 5);
        queue.Enqueue("Second", 5); 
        queue.Enqueue("Third", 5);

        Assert.AreEqual("First", queue.Dequeue());
        Assert.AreEqual("Second", queue.Dequeue());
        Assert.AreEqual("Third", queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue a single item and dequeue it.
    // Expected Result: The item is returned.
    // Defect(s) Found: None expected.
    public void TestPriorityQueue_OneItem()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("Solo", 42);
        Assert.AreEqual("Solo", queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: InvalidOperationException with correct message.
    // Defect(s) Found: Original code might not throw or might throw a different exception.
    public void TestPriorityQueue_EmptyDequeue()
    {
        var queue = new PriorityQueue();

        try
        {
            queue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("Queue is empty.", ex.Message);
        }
    }
}
