using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using DATA;
using PlivackiCentarWeb.Models;

namespace PlivackiCentarWeb.Repositories
{
    public class HelperRepository : IHelperRepository
    {
        public bool DodajBazen(BazenViewModel model)
        {
            try
            {
                using (dataContext connection = new dataContext())
                {
                    Bazeni bazen = new Bazeni();
                    bazen.Dimenzije = model.Dimenzije;
                    bazen.Naziv = model.Naziv;
                    bazen.Opis = model.Opis;
                    bazen.GradId = model.GradId;

                    if (model.Slika != null)
                    {
                        string pic = System.IO.Path.GetFileName(model.Slika.FileName);
                        string path = System.IO.Path.Combine(
                                               System.Web.HttpContext.Current.Server.MapPath("~/assets/image/bazeni"), pic);
                        // file is uploaded
                        model.Slika.SaveAs(path);

                        // save the image path path to the database or you can send image 
                        // directly to database
                        // in-case if you want to store byte[] ie. for DB
                        using (MemoryStream ms = new MemoryStream())
                        {
                            model.Slika.InputStream.CopyTo(ms);
                            byte[] array = ms.GetBuffer();
                        }

                        bazen.Slika = pic;
                    }

                    connection.Bazeni.Add(bazen);
                    connection.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DodajGrupu(GrupaViewModel model)
        {
            try
            {
                using (dataContext connection = new dataContext())
                {
                    Grupe grupa = new Grupe();
                    grupa.Uzrast = model.Uzrast;
                    grupa.Vrsta = model.Vrsta;
                    connection.Grupe.Add(grupa);
                    connection.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DodajNovoTakmicenje(TakmicenjeViewModel model)
        {
            try
            {
                using (dataContext connection = new dataContext())
                {
                    Takmicenja takmicenje = new Takmicenja();
                    takmicenje.Datum = model.Datum;
                    takmicenje.GradId = model.GradId;
                    takmicenje.Naziv = model.Naziv;
                    takmicenje.OsvojenaMjesta = model.OsvojenaMjesta;
                    connection.Takmicenja.Add(takmicenje);
                    connection.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DodajPlivacaNaTakmicenje(int takmicenjeId, int plivacId)
        {
            try
            {
                using (dataContext connection = new dataContext())
                {
                    TakmicenjaPlivaci takmicenjePlivac = new TakmicenjaPlivaci();
                    takmicenjePlivac.PlivacId = plivacId;
                    takmicenjePlivac.TakmicenjeId = takmicenjeId;
                    connection.TakmicenjaPlivaci.Add(takmicenjePlivac);
                    connection.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DodajTermin(TerminViewModel model)
        {

            try
            {
                using (dataContext connection = new dataContext())
                {
                        Termini termin = new Termini();
                        termin.TrenerId = model.TrenerId;
                        termin.GrupaId = model.GrupaId;
                        termin.BazenId = model.BazenId;
                        termin.VrijemeDo = model.VrijemeDo;
                        termin.VrijemeOd = model.VrijemeOd;
                        connection.Termin.Add(termin);

                    connection.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }



        public List<BazenViewModel> GetBazeni()
        {
            using (dataContext connection = new dataContext())
            {
                return connection.Bazeni.Select(x => new BazenViewModel {
                    Id = x.Id,
                    Opis = x.Opis,
                    Naziv = x.Naziv,
                    Dimenzije = x.Dimenzije,
                    Grad = x.Grad.Naziv,
                    GradId = x.GradId,
                    SlikaUrl = x.Slika
                }).ToList();
            }
        }

        public List<Gradovi> GetGradovi()
        {
            using (dataContext connection = new dataContext())
            {
                return connection.Gradovi.ToList();
            }
        }

        public List<GrupaViewModel> GetGrupe()
        {
            using (dataContext connection = new dataContext())
            {
                return connection.Grupe.Select(x => new GrupaViewModel
                {
                    Id = x.Id,
                    Vrsta = x.Vrsta,
                    Uzrast = x.Uzrast,
                    BrojKlijenata = x.Plivaci.Count()
                }).ToList();
            }
        }



        public List<TerminViewModel> GetSveTermine()
        {
            using (dataContext connection = new dataContext())
            {
                List<TerminViewModel> plivaciTermini = connection.PlivaciTermin.Select(x => new TerminViewModel
                {
                    Id = x.Id,
                    Bazen = x.Termin.Bazen,
                    Grupa = x.Termin.Grupa,
                    Datum = x.Termin.Datum,
                    Trener = x.Termin.Trener,
                    VrijemeDo = x.Termin.VrijemeDo,
                    VrijemeOd = x.Termin.VrijemeDo
                }).ToList();


                List<TerminViewModel> rekreativciTermini = connection.RekreativciTermin.Select(x => new TerminViewModel
                {
                    Id = x.Id,
                    Bazen = x.Termin.Bazen,
                    Grupa = x.Termin.Grupa,
                    Datum = x.Termin.Datum,
                    Trener = x.Termin.Trener,
                    VrijemeDo = x.Termin.VrijemeDo,
                    VrijemeOd = x.Termin.VrijemeDo
                }).ToList();

                List<TerminViewModel> sviRezultati = new List<TerminViewModel>();
                sviRezultati.AddRange(plivaciTermini);
                sviRezultati.AddRange(rekreativciTermini);
                return sviRezultati;
            }
        }

        public List<TakmicenjeViewModel> GetTakmicenja()
        {
            using (dataContext connection = new dataContext())
            {
                return connection.Takmicenja.Select(x => new TakmicenjeViewModel
                {
                    Id = x.Id,
                    Naziv = x.Naziv,
                    Grad = x.Grad.Naziv,
                    GradId = x.GradId,
                    Datum = x.Datum,
                    OsvojenaMjesta = x.OsvojenaMjesta
                }).ToList();
            }
        }

        public List<TakmicenjeViewModel> GetTakmicenjaFromPlivac(int klijentId)
        {
            using (dataContext connection = new dataContext())
            {
                return connection.TakmicenjaPlivaci.Where(x => x.PlivacId == klijentId).Select(x => new TakmicenjeViewModel
                {
                    Id = x.TakmicenjeId,
                    Naziv = x.Takmicenje.Naziv,
                    Grad = x.Takmicenje.Grad.Naziv,
                    Datum = x.Takmicenje.Datum,
                    OsvojenaMjesta = x.Takmicenje.OsvojenaMjesta
                }).ToList();
            }
        }

        public List<TerminViewModel> GetTermine(int klijentId, bool isPlivac)
        {
            using (dataContext connection = new dataContext())
            {
                if(isPlivac)
                {
                    return connection.PlivaciTermin.Where(x => x.PlivaciId == klijentId).Select(x => new TerminViewModel
                    {
                        Id = x.Termin.Id,
                        Bazen = x.Termin.Bazen,
                        Trener = x.Termin.Trener,
                        VrijemeDo = x.Termin.VrijemeDo,
                        VrijemeOd = x.Termin.VrijemeOd,
                        Datum = x.Termin.Datum
                    }).ToList();
                }
                else
                {
                    return connection.RekreativciTermin.Where(x => x.RekreativacId == klijentId).Select(x => new TerminViewModel
                    {
                        Id = x.Termin.Id,
                        Bazen = x.Termin.Bazen,
                        Trener = x.Termin.Trener,
                        VrijemeDo = x.Termin.VrijemeDo,
                        VrijemeOd = x.Termin.VrijemeOd,
                        Datum = x.Termin.Datum
                    }).ToList();
                }
            }
        }

    }
}