using PlivackiCentarWeb.Filters;
using PlivackiCentarWeb.Models;
using PlivackiCentarWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlivackiCentarWeb.Controllers
{

    [AccountRoleAuthorize(role: "admin")]
    public class AdminController : Controller
    {
        public readonly IAccountRepository _accountRepository;
        public readonly IHelperRepository _helperRepository;

        public AdminController(IAccountRepository accountRepository, IHelperRepository helperRepository)
        {
            _accountRepository = accountRepository;
            _helperRepository = helperRepository;
        }
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.Title = "ADMIN";
            return View();
        }
        public ActionResult Klijenti()
        {
            ViewBag.Title = "Klijenti";
            var lista = _accountRepository.GetKlijenti();
            return View(lista);
        }
        public ActionResult NoviKlijent()
        {
            ViewBag.Title = "Novi klijent";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NoviKlijent(KlijentViewModel model)
        {
            ViewBag.Title = "Novi klijent";

            if (ModelState.IsValid)
            {
                var isDodan = _accountRepository.DodajNovogKlijenta(model);
                if (isDodan)
                    return PartialView("_uspjeh", "/Admin/Klijenti");
                else
                    return PartialView("_greska", "/Admin/Klijenti");
            }
            else
            {
                ModelState.AddModelError("", "Provjerite podatke i pokušajte opet.");
                return PartialView("_noviKlijent", model);
            }
        }

        public ActionResult Treneri()
        {
            ViewBag.Title = "Treneri";
            var lista = _accountRepository.GetTreneri();
            return View(lista);
        }
        public ActionResult NoviTrener()
        {
            ViewBag.Title = "Novi trener";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NoviTrener(TrenerViewModel model)
        {
            ViewBag.Title = "Novi trener";

            if (ModelState.IsValid)
            {
                var isDodan = _accountRepository.DodajNovogTrenera(model);
                if (isDodan)
                    return PartialView("_uspjeh", "/Admin/Treneri");
                else
                    return PartialView("_greska", "/Admin/Treneri");
            }
            else
            {
                ModelState.AddModelError("", "Provjerite podatke i pokušajte opet.");
                return PartialView("_noviTrener", model);
            }
        }

        public ActionResult Takmicenja()
        {
            ViewBag.Title = "Takmičenja";
            var lista = _helperRepository.GetTakmicenja();
            return View(lista);
        }

        public ActionResult NovoTakmicenje()
        {
            ViewBag.Title = "Novo takmičenje";
            TakmicenjeViewModel model = new TakmicenjeViewModel();
            model.Gradovi = _helperRepository.GetGradovi();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NovoTakmicenje(TakmicenjeViewModel model)
        {
            ViewBag.Title = "Novo takmičenje";

            if (ModelState.IsValid)
            {
                var isDodan = _helperRepository.DodajNovoTakmicenje(model);
                if (isDodan)
                    return PartialView("_uspjeh", "/Admin/Takmicenja");
                else
                    return PartialView("_greska", "/Admin/Takmicenja");
            }
            else
            {
                model.Gradovi = _helperRepository.GetGradovi();
                ModelState.AddModelError("", "Provjerite podatke i pokušajte opet.");
                return PartialView("_novoTakmicenje", model);
            }
        }
        public ActionResult Grupe()
        {
            ViewBag.Title = "Grupe";
            var lista = _helperRepository.GetGrupe();
            return View(lista);
        }

        public ActionResult NovaGrupa()
        {
            ViewBag.Title = "Nova grupa";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NovaGrupa(GrupaViewModel model)
        {
            ViewBag.Title = "Nova grupa";

            if (ModelState.IsValid)
            {
                var isDodan = _helperRepository.DodajGrupu(model);
                if (isDodan)
                    return PartialView("_uspjeh", "/Admin/Grupe");
                else
                    return PartialView("_greska", "/Admin/Grupe");
            }
            else
            {
                ModelState.AddModelError("", "Provjerite podatke i pokušajte opet.");
                return PartialView("_novaGrupa", model);
            }
        }


        public ActionResult Termini()
        {
            ViewBag.Title = "Termini";
            var lista = _helperRepository.GetSveTermine();
            return View(lista);
        }

        public ActionResult NoviTermin()
        {
            ViewBag.Title = "Novi termin";
            TerminViewModel model = new TerminViewModel();
            model.Bazeni = _helperRepository.GetBazeni();
            model.Treneri = _accountRepository.GetTreneri();
            model.Grupe = _helperRepository.GetGrupe();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NoviTermin(TerminViewModel model)
        {
            ViewBag.Title = "Novi termin";

            if (ModelState.IsValid)
            {
                var isDodan = _helperRepository.DodajTermin(model);
                if (isDodan)
                    return PartialView("_uspjeh", "/Admin/Termini");
                else
                    return PartialView("_greska", "/Admin/Termini");
            }
            else
            {
                model.Bazeni = _helperRepository.GetBazeni();
                model.Treneri = _accountRepository.GetTreneri();
                model.Grupe = _helperRepository.GetGrupe();
   
                ModelState.AddModelError("", "Provjerite podatke i pokušajte opet.");
                return PartialView("_noviTermin", model);
            }
        }

        public ActionResult Bazeni()
        {
            ViewBag.Title = "Bazeni";
            var lista = _helperRepository.GetBazeni();
            return View(lista);
        }

        public ActionResult NoviBazen()
        {
            ViewBag.Title = "Novi bazen";
            BazenViewModel model = new BazenViewModel();
            model.Gradovi = _helperRepository.GetGradovi();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NoviBazen(BazenViewModel model)
        {
            ViewBag.Title = "Novi bazen";

            if (ModelState.IsValid)
            {
                var isDodan = _helperRepository.DodajBazen(model);
                if (isDodan)
                    return PartialView("_uspjeh", "/Admin/Bazeni");
                else
                    return PartialView("_greska", "/Admin/Bazeni");
            }
            else
            {
                model.Gradovi = _helperRepository.GetGradovi();
                ModelState.AddModelError("", "Provjerite podatke i pokušajte opet.");
                return PartialView("_noviBazen", model);
            }
        }

        public ActionResult Klijent(int klijentId, bool isPlivac = true)
        {
            ViewBag.Title = "Klijent";

            KlijentPreviewViewModel model = new KlijentPreviewViewModel();
            model.Id = klijentId;
            model.IsPlivac = isPlivac;
            model.IsRekreativac = !isPlivac;
            model.Termini = _helperRepository.GetTermine(klijentId, isPlivac);

            return View(model);
        }

        public ActionResult _klijentTakmicenja (int klijentId)
        {
            TakmicenjePlivacViewModel model = new TakmicenjePlivacViewModel();
            model.SvaTakmicenja = _helperRepository.GetTakmicenja();
            model.TakmicenjaKlijenta = _helperRepository.GetTakmicenjaFromPlivac(klijentId);
            model.PlivacId = klijentId;

            return PartialView("_klijentTakmicenja", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NovoKlijentTakmicenje(TakmicenjePlivacViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isDodan = _helperRepository.DodajPlivacaNaTakmicenje(model.TakmicenjeId, model.PlivacId);
                model.SvaTakmicenja = _helperRepository.GetTakmicenja();
                model.TakmicenjaKlijenta = _helperRepository.GetTakmicenjaFromPlivac(model.PlivacId);
                model.PlivacId = model.PlivacId;
                return PartialView("_klijentTakmicenja", model);
            }
            else
            {
                model.SvaTakmicenja = _helperRepository.GetTakmicenja();
                model.TakmicenjaKlijenta = _helperRepository.GetTakmicenjaFromPlivac(model.PlivacId);
                model.PlivacId = model.PlivacId;
                ModelState.AddModelError("", "Provjerite podatke i pokušajte opet.");
                return PartialView("_klijentTakmicenja", model);
            }
        }
    }
}