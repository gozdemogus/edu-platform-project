using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseIdentity.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TodoListController : Controller
    {
        private readonly ITodoListService _todoListService;
        private readonly ITodoItemService _todoItemService;

        private readonly UserManager<AppUser> _userManager;


        public TodoListController(ITodoListService todoListService, UserManager<AppUser> userManager, ITodoItemService todoItemService)
        {
            _todoListService = todoListService;
            _userManager = userManager;
            _todoItemService = todoItemService;
        }


        // GET: /<controller>/
        //kullanıcının to-do listini getirir
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
           var values =  _todoListService.getTodoListByUser(user.Id);

            if (object.ReferenceEquals(values, null))
            {
                ViewBag.nolist = true;
            }

            return View(values);
        }

        //Yeni bir to-dolist ekler
        public async Task<IActionResult> Add()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            TodoList todoList = new TodoList();
            todoList.UserId = user.Id;
            _todoListService.TInsert(todoList);

            return View("Index");
        }

        //list item'ın statusunu degistirir
        public async Task<IActionResult> Change(int id, bool status)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var todoItem = _todoItemService.TGetById(id);
         
            todoItem.Completed = status;
            todoItem.LastUpdate = DateTime.Now;
            _todoItemService.TUpdate(todoItem);

            var url = Url.RouteUrl("areas", new { controller = "TodoList", action = "Index", area = "Admin" });
            return Redirect(url);
        }

        //detayları görüntülemesi icin minik balon cıkıcak
        public async Task<IActionResult> GetDetail(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var todoItem = _todoItemService.TGetById(id);

            return PartialView("_Detail", todoItem.Details.ToString());

        }
        
    
        public async Task<IActionResult> Remove(int id)
        {
            var todoItem = _todoItemService.TGetById(id);
            _todoItemService.TDelete(todoItem);

            var url = Url.RouteUrl("areas", new { controller = "TodoList", action = "Index", area = "Admin" });
            return Redirect(url);
        }

        [HttpGet]
        public async Task<IActionResult> AddNewTodoItem()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTodoItem(string description, string details, DateTime deadline)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
           var todoListByUSer =  _todoListService.getTodoListByUser(user.Id);
            if(details == null)
            {
                details = "Not Specified";
            }

            if(todoListByUSer != null)
            {
                TodoItem todoItem = new TodoItem();
                todoItem.Description = description;
                todoItem.Details = details;
                todoItem.Deadline = deadline;
                todoItem.TodoListId = todoListByUSer.Id;

                _todoItemService.TInsert(todoItem);
            }
            else
            {
                TodoList todoList = new TodoList();
                todoList.UserId = user.Id;

                _todoListService.TInsert(todoList);
                var todoListByUSer2 = _todoListService.getTodoListByUser(user.Id);

                TodoItem todoItem = new TodoItem();
                todoItem.Description = description;
                todoItem.Details = details;
                todoItem.Deadline = deadline;
                todoItem.TodoListId = todoListByUSer2.Id;

                _todoItemService.TInsert(todoItem);
            }


            var url = Url.RouteUrl("areas", new { controller = "TodoList", action = "Index", area = "Admin" });
            return Redirect(url);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var values = _todoItemService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TodoItem todoItem)
        {
           var tdItem = _todoItemService.TGetById(todoItem.Id);

            if (todoItem.Deadline != null)
            {
                tdItem.Deadline = todoItem.Deadline;
            }



          //  tdItem.Deadline = todoItem.Deadline;
            tdItem.Description = todoItem.Description;
            tdItem.Details = todoItem.Details;
            tdItem.LastUpdate = DateTime.Now;

            _todoItemService.TUpdate(tdItem);

            var url = Url.RouteUrl("areas", new { controller = "TodoList", action = "Index", area = "Admin" });
            return Redirect(url);
        }
    }
}

