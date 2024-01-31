using ASPdotNetMarmosets.Data;
using ASPdotNetMarmosets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Debugger.Contracts.HotReload;

namespace ASPdotNetMarmosets.Controllers
{
    public class MarmosetsController : Controller
    {
        public static string RandomString(string chars, int length)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        private readonly FakeMarmosetsDb _fakeMarmosetsDb;

        public MarmosetsController(FakeMarmosetsDb fakeMarmosetsDb)
        {
            _fakeMarmosetsDb = fakeMarmosetsDb;
        }

        public IActionResult Index()
        {
            return View(_fakeMarmosetsDb.GetAll());
        }

        public IActionResult Details(int id)
        {
            Marmosets? marmosets = _fakeMarmosetsDb.GetById(id);
            return View(marmosets);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult AddMarmosets(Marmosets marmoset)
        {
            _fakeMarmosetsDb.Add(marmoset);
            return RedirectToAction(nameof(Index));
		}


		public IActionResult AddFakeMarmosets()
        {
            Marmosets? pluto = new Marmosets()
            {
                Nom = "Pluto",
                Age = 3,
                Poids = 5,
                Taille = 33
            };
            _fakeMarmosetsDb.Add(pluto);

            return RedirectToAction(nameof(Index));
        }


        public IActionResult AddFakeRandomMarmosets()
        {
            Random random = new Random();

            Marmosets? pluto = new Marmosets()
            {
                Nom = RandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 5),
                Age = random.Next(10),
                Poids = random.Next(10),
                Taille = random.Next(10)
            };
            _fakeMarmosetsDb.Add(pluto);

            return RedirectToAction(nameof(Index));
        }

        public ActionResult DeleteByID(int id)
        {

            Marmosets? marmosetToDelete = _fakeMarmosetsDb.GetById(id);

            if (marmosetToDelete == null)
				return RedirectToAction(nameof(Index));
            

			_fakeMarmosetsDb.Delete(id);
			return RedirectToAction(nameof(Index));

		}
    }
}
