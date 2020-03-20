using DATA;
using PlivackiCentarWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlivackiCentarWeb.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public Nalozi CheckLogin(string username, string password)
        {
            using (dataContext connection = new dataContext())
            {
                return connection.Nalozi.Where(x => x.Email.Trim() == username.Trim() && x.Lozinka == password).FirstOrDefault();
            }
        }

        public bool DodajNovogKlijenta(KlijentViewModel model)
        {
            try
            {
                using (dataContext connection = new dataContext())
                {
                    Nalozi nalog = new Nalozi();
                    nalog.Email = model.Email;
                    nalog.Ime = model.Ime;
                    nalog.Prezime = model.Prezime;
                    nalog.Lozinka = model.DatumRodjenja.Value.ToString("ddMMyyyy");
                    nalog.IsRekreativac = model.IsRekreativac ? true : false;
                    nalog.IsAdministrator = false;
                    nalog.IsPlivac = model.IsPlivac ? true : false;
                    nalog.IsTrener = false;
                    nalog.Aktivan = true;
                    connection.Nalozi.Add(nalog);
                    connection.SaveChanges();

                    if(model.IsPlivac)
                    {
                        Plivaci plivac = new Plivaci();
                        plivac.Email = model.Email;
                        plivac.Ime = model.Ime;
                        plivac.Prezime = model.Prezime;
                        plivac.DatumRodjenja = model.DatumRodjenja;
                        plivac.Spol = model.Spol;
                        plivac.Telefon = model.Telefon;
                        plivac.NalogId = nalog.Id;
                        connection.Plivaci.Add(plivac);
                        connection.SaveChanges();
                    }
                    else
                    {
                        Rekreativci rekreativac = new Rekreativci();
                        rekreativac.Email = model.Email;
                        rekreativac.Ime = model.Ime;
                        rekreativac.Prezime = model.Prezime;
                        rekreativac.DatumRodjenja = model.DatumRodjenja;
                        rekreativac.Spol = model.Spol;
                        rekreativac.Telefon = model.Telefon;
                        rekreativac.NalogId = nalog.Id;
                        connection.Rekreativci.Add(rekreativac);
                        connection.SaveChanges();
                    }
        
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DodajNovogTrenera(TrenerViewModel model)
        {
            try
            {
                using (dataContext connection = new dataContext())
                {
                    Nalozi nalog = new Nalozi();
                    nalog.Email = model.Email;
                    nalog.Ime = model.Ime;
                    nalog.Prezime = model.Prezime;
                    nalog.Lozinka = model.DatumRodjenja.Value.ToString("ddMMyyyy");
                    nalog.IsRekreativac = false;
                    nalog.IsAdministrator = false;
                    nalog.IsPlivac = false;
                    nalog.IsTrener = true;
                    nalog.Aktivan = true;
                    connection.Nalozi.Add(nalog);
                    connection.SaveChanges();

                    Treneri trener = new Treneri();
                    trener.Email = model.Email;
                    trener.Ime = model.Ime;
                    trener.Prezime = model.Prezime;
                    trener.DatumRodjenja = model.DatumRodjenja;
                    trener.Zvanje = model.Zvanje;
                    trener.Spol = model.Spol;
                    trener.Kontakt = model.Telefon;
                    trener.NalogId = nalog.Id;
                    connection.Treneri.Add(trener);
                    connection.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<KlijentViewModel> GetKlijenti()
        {
            using (dataContext connection = new dataContext())
            {
                List<KlijentViewModel> plivaci = connection.Plivaci.Select(x => new KlijentViewModel
                {
                    Id = x.Id,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    ImePrezime = x.Ime + " " + x.Prezime,
                    Email = x.Email,
                    DatumRodjenja = x.DatumRodjenja,
                    Spol = x.Spol,
                    Telefon = x.Telefon,
                    IsPlivac = true,
                    IsRekreativac = false
                }).ToList();

                List <KlijentViewModel> rekreativci = connection.Rekreativci.Select(x => new KlijentViewModel
                {
                    Id = x.Id,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    ImePrezime = x.Ime + " " + x.Prezime,
                    Email = x.Email,
                    DatumRodjenja = x.DatumRodjenja,
                    Spol = x.Spol,
                    Telefon = x.Telefon,
                    IsRekreativac = true,
                    IsPlivac = false
                }).ToList();

                List<KlijentViewModel> rezultati = new List<KlijentViewModel>();
                rezultati.AddRange(plivaci);
                rezultati.AddRange(rekreativci);
                return rezultati;
            }
        }

        public List<KlijentViewModel> GetPlivace()
        {
            using (dataContext connection = new dataContext())
            {
                List<KlijentViewModel> plivaci = connection.Plivaci.Select(x => new KlijentViewModel
                {
                    Id = x.Id,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    ImePrezime = x.Ime + " " + x.Prezime,
                    Email = x.Email,
                    DatumRodjenja = x.DatumRodjenja,
                    Spol = x.Spol,
                    Telefon = x.Telefon,
                    IsRekreativac = false,
                    IsPlivac = true
                }).ToList();

                return plivaci;
            }
        }

        public List<KlijentViewModel> GetRekreativce()
        {
            using (dataContext connection = new dataContext())
            {
                List<KlijentViewModel> rekreativci = connection.Rekreativci.Select(x => new KlijentViewModel
                {
                    Id = x.Id,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    ImePrezime = x.Ime + " " + x.Prezime,
                    Email = x.Email,
                    DatumRodjenja = x.DatumRodjenja,
                    Spol = x.Spol,
                    Telefon = x.Telefon,
                    IsRekreativac = true,
                    IsPlivac = false
                }).ToList();

                return rekreativci;
            }
        }

        public List<TrenerViewModel> GetTreneri()
        {
            using (dataContext connection = new dataContext())
            {
                return connection.Treneri.Select(x => new TrenerViewModel
                {
                    Id = x.Id,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    Email = x.Email,
                    DatumRodjenja = x.DatumRodjenja,
                    Spol = x.Spol,
                    Telefon = x.Kontakt,
                    Zvanje = x.Zvanje
                }).ToList();
            }
        }

        public Nalozi RegisterNewRekreativac(RegisterViewModel model)
        {
            try
            {
                using (dataContext connection = new dataContext())
                {
                    Nalozi nalog = new Nalozi();
                    nalog.Email = model.Email;
                    nalog.Ime = model.Firstname;
                    nalog.Prezime = model.Lastname;
                    nalog.Lozinka = model.Password;
                    nalog.IsRekreativac = true;
                    nalog.IsAdministrator = false;
                    nalog.IsPlivac = false;
                    nalog.IsTrener = false;
                    nalog.Aktivan = true;
                    connection.Nalozi.Add(nalog);
                    connection.SaveChanges();

                    Rekreativci rekreativac = new Rekreativci();
                    rekreativac.Email = model.Email;
                    rekreativac.Ime = model.Firstname;
                    rekreativac.Prezime = model.Lastname;
                    rekreativac.NalogId = nalog.Id;
                    connection.Rekreativci.Add(rekreativac);
                    connection.SaveChanges();

                    return nalog;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}