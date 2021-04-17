using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Tasks.Models;

namespace TasksTests
{
    [TestClass]
    public class TaskListTest
    {

        [TestMethod]
        public void addTaskTest()
        {
            //Arrange
            string taskName = "test task name";
            DateTime dueDate = DateTime.Now;
            Task task = new Task(taskName,dueDate);

            TaskList taskList = new TaskList("testTaskListFile");

            //act
            Task addedTask = taskList.addTask(task);


            //assert
            Assert.IsNotNull(addedTask);
            Assert.AreEqual(1, taskList.Count);
            Assert.AreNotEqual(0, addedTask.TaskId);
            Assert.IsTrue(addedTask.TaskId>0,"AddTask should set the task's id to a positive integer");
        }
    }
}
