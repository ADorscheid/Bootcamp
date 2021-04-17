using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tasks.Models;

namespace Tasks.Tests
{
    [TestClass]
    public class TaskTests
    {
        [TestMethod]
        public void TestConstructor1()
        {
            // Arrange - nothing to do here

            // Act - Create a task using the 2-parameter constructor
            DateTime dueDate = DateTime.Now;
            Task task = new Task("Test Name", dueDate);

            // Assert
            Assert.AreEqual(0, task.TaskId);
            Assert.AreEqual(false, task.IsCompleted);
            Assert.AreEqual("Test Name", task.TaskName);
            Assert.AreEqual(dueDate, task.DueDate);
        }
    }
}

// Checklist for why I cannot reference my "class under test".
//  Is my Test project referencing (Dependencies -> Projects) the "target" project?
//      - If not, add Project Reference
// Is the "target" class public?
// Is the "target method" public?