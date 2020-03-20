using DATA;
using PlivackiCentarWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlivackiCentarWeb.Repositories
{
    public interface IHelperRepository
    {
        List<Gradovi> GetGradovi();
        List<TakmicenjeViewModel> GetTakmicenja();
        List<TakmicenjeViewModel> GetTakmicenjaFromPlivac(int klijentId);
        List<BazenViewModel> GetBazeni();
        List<GrupaViewModel> GetGrupe();
        List<TerminViewModel> GetTermine(int klijentId, bool isPlivac);
        List<TerminViewModel> GetSveTermine();

        bool DodajPlivacaNaTakmicenje(int takmicenjeId, int plivacId);
        bool DodajNovoTakmicenje(TakmicenjeViewModel model);
        bool DodajGrupu(GrupaViewModel model);
        bool DodajBazen(BazenViewModel model);
        bool DodajTermin(TerminViewModel model);
    }
}