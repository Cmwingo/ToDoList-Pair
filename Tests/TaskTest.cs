using Xunit;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ToDoList.Objects;
using System;

namespace ToDoList
{
  public class ToDoTest : IDisposable
  {
    public ToDoTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ToDoList_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Task.GetAll().Count;

      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_Equal_ReturnsTrueIfDescriptionsAreTheSame()
    {
      Task firstTask = new Task("Mow the lawn", 1, "01-01-17");
      Task secondTask = new Task("Mow the lawn", 1, "01-01-17");

      Assert.Equal(firstTask, secondTask);
    }
    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      Task testTask = new Task("Mow the lawn", 1, "01-01-17");

      testTask.Save();
      List<Task> result = Task.GetAll();
      List<Task> testList = new List<Task>{testTask};

      Assert.Equal(testList, result);
    }

    public void Dispose()
    {
      Task.DeleteAll();
    }

    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      Task testTask = new Task("Mow the lawn", 1, "01-01-17");

      testTask.Save();
      Task savedTask = Task.GetAll()[0];

      int result = savedTask.GetId();
      int testId = testTask.GetId();

      Assert.Equal(testId, result);
    }
    [Fact]
    public void Test_Find_FindsTaskInDatabase()
    {
      Task testTask = new Task("Mow the lawn", 1, "01-01-17");
      testTask.Save();

      Task foundTask = Task.Find(testTask.GetId());

      Assert.Equal(testTask, foundTask);
    }
  }
}
