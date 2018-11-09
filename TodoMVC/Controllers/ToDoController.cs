using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TodoMVC.Models;

namespace TodoMVC.Controllers
{
    public class ToDoController : Controller
    {
        // GET: ToDo
        public ActionResult Index()
        {
            IEnumerable<MVCTDoDBModel> toDoList;
            HttpResponseMessage response = ClientVariables.apiClient.GetAsync("Todo").Result;
            toDoList = response.Content.ReadAsAsync<IEnumerable<MVCTDoDBModel>>().Result;
            return View(toDoList);
        }   

        public ActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
                return View(new MVCTDoDBModel());
            else
            {
                HttpResponseMessage response = ClientVariables.apiClient.GetAsync("ToDo/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MVCTDoDBModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(MVCTDoDBModel toDo)
        {
            if (toDo.TaskId == 0)
            {
                HttpResponseMessage response = ClientVariables.apiClient.PostAsJsonAsync("ToDo", toDo).Result;

            }
            else
            {
                HttpResponseMessage response = ClientVariables.apiClient.PutAsJsonAsync("ToDo/" + toDo.TaskId, toDo).Result;

            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = ClientVariables.apiClient.DeleteAsync("ToDo/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}