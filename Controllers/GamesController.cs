using GameStore.BLL.Services;
using GameStore.BLL.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStore.UI.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameService gameService;
        //  3 DI
        public GamesController(IGameService service)
        {
            gameService = service;
        }
        // GET: Games
        public ActionResult Index()
        {
            return View();
        }
    }
}