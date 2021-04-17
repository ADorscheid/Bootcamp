using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Tasks.Models;

namespace TasksTests
{
    [TestClass]
    public class TaskTest
    {
        [TestMethod]
        public void TestConstructorWith2Parameters()
        {
            //arrange-nothing
            DateTime dueDate = DateTime.Now;
            string taskName = "task Name";
            //act
            Task createdTask = new Task(taskName,dueDate);

            //assert
            Assert.AreEqual(0,createdTask.TaskId);
            Assert.AreEqual(false,createdTask.IsCompleted);
            Assert.AreEqual(taskName, createdTask.TaskName);
            Assert.AreEqual(dueDate, createdTask.DueDate);

        }
    }
}
