using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;
using ToDoList.Objects;

namespace ToDoList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Category> AllCategories = Category.GetAll();
        return View["index.cshtml", AllCategories];
      };

      Get["/tasks"] = _ => {
        List<Task> AllTasks = Task.GetAll();
        return View["tasks.cshtml", AllTasks];
      };

      Get["/categories"] = _ => {
        List<Category> AllCategories = Category.GetAll();
        return View["categories.cshtml", AllCategories];
      };

      Get["/categories/new"] = _ => {
        return View["categories_form.cshtml"];
      };

      Post["/categories/new"] = _ => {
        
      };
    }
  }
}
