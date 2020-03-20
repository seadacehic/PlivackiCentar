using DATA;
using PlivackiCentarWeb.Models;
using System.Collections.Generic;

namespace PlivackiCentarWeb.Repositories
{
    public interface IAccountRepository
    {
        Nalozi CheckLogin(string username, string password);

        Nalozi RegisterNewRekreativac(RegisterViewModel model);
        bool DodajNovogKlijenta(KlijentViewModel model);
        bool DodajNovogTrenera(TrenerViewModel model);
        List<KlijentViewModel> GetKlijenti();
        List<KlijentViewModel> GetRekreativce();
        List<KlijentViewModel> GetPlivace();
        List<TrenerViewModel> GetTreneri();
    }
}