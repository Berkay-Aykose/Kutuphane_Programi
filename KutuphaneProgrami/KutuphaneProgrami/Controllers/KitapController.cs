using KutuphaneProgrami.Data.Model;
using KutuphaneProgrami.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace KutuphaneProgrami.Controllers
{
    public class KitapController : Controller
    {
        UnitOfWork unitOfWork;

        public KitapController()
        {
            unitOfWork = new UnitOfWork();
        }
        // GET: Kitap
        public ActionResult Index()
        {
            var Kitaplar = unitOfWork.GetRepository<Kitap>().GetAll();
            return View(Kitaplar);
        }

        public ActionResult Ekle()
        {
            ViewBag.Kategoriler = unitOfWork.GetRepository<Kategori>().GetAll();
            ViewBag.Yazarlar = unitOfWork.GetRepository<Yazar>().GetAll();

            return View();
        }

        [HttpPost]
        public JsonResult EkleKtpJson(string Kategoriler, string Yazar, string KitapAd, string KitapAdet, string SiraNo)
        {
            if (!string.IsNullOrEmpty(Kategoriler) && !string.IsNullOrEmpty(Yazar) && !string.IsNullOrEmpty(KitapAd) && !string.IsNullOrEmpty(KitapAdet) && !string.IsNullOrEmpty(SiraNo))
            {
                List<Kategori> k = new List<Kategori>();

                var kategoriID = Convert.ToInt32(Kategoriler);
                var kategori = unitOfWork.GetRepository<Kategori>().GetById(kategoriID);
                k.Add(kategori);

                Kitap kitap = new Kitap();
                kitap.Ad = KitapAd;
                kitap.Adet = Convert.ToInt32(KitapAdet);
                kitap.YazarId = Convert.ToInt32(Yazar);
                kitap.EklenmeTarihi = DateTime.Now;
                kitap.SiraNo = SiraNo;
                kitap.Kategoriler = k;

                unitOfWork.GetRepository<Kitap>().Add(kitap);
                var durum = unitOfWork.SavaChanges();

                if (durum > 0)
                {
                    return Json("1");
                }
                else
                {
                    return Json("0");
                }
            }
            else { return Json("bosOlamaz"); }

        }

        [HttpPost]
        public JsonResult SilKtpJson(int kitapId)
        {
            unitOfWork.GetRepository<Kitap>().Delete(kitapId);
            int durum = unitOfWork.SavaChanges();

            if (durum > 0)
            {
                return Json("1");
            }
            else
            {
                return Json("0");
            }


        }

        public ActionResult Güncelle(int kitapId)
        {
            ViewBag.Kategoriler = unitOfWork.GetRepository<Kategori>().GetAll();
            ViewBag.Yazarlar = unitOfWork.GetRepository<Yazar>().GetAll();
            var Kitap = unitOfWork.GetRepository<Kitap>().GetById(kitapId);
            return View(Kitap);
        }

        [HttpPost]
        public JsonResult GüncelleKtpJson(int kitapId, string Kategoriler, string Yazar, string KitapAd, string KitapAdet, string SiraNo)
        {
            if (!string.IsNullOrEmpty(Kategoriler) && !string.IsNullOrEmpty(Yazar) && !string.IsNullOrEmpty(KitapAd) && !string.IsNullOrEmpty(KitapAdet) && !string.IsNullOrEmpty(SiraNo))
            {
                List<Kategori> k = new List<Kategori>();

                var kategoriID = Convert.ToInt32(Kategoriler);
                var kategori = unitOfWork.GetRepository<Kategori>().GetById(kategoriID);
                k.Add(kategori);

                var kitap = unitOfWork.GetRepository<Kitap>().GetById(kitapId);

                kitap.Ad = KitapAd;
                kitap.Adet = Convert.ToInt32(KitapAdet);
                kitap.YazarId = Convert.ToInt32(Yazar);
                kitap.EklenmeTarihi = DateTime.Now;
                kitap.SiraNo = SiraNo;
                kitap.Kategoriler.Clear();
                kitap.Kategoriler = k;

                unitOfWork.GetRepository<Kitap>().Update(kitap);
                var durum = unitOfWork.SavaChanges();

                if (durum > 0)
                {
                    return Json("1");
                }
                else
                {
                    return Json("0");
                }
            }
            else { return Json("bosOlamaz"); }

        }


    }
}