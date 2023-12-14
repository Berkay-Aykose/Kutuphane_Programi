using KutuphaneProgrami.Data.Model;
using KutuphaneProgrami.Data.UnitOfWork;
using System;
using System.Web.Mvc;

namespace KutuphaneProgrami.Controllers
{
    public class UyeController : Controller
    {
        UnitOfWork unitOfWork;

        public UyeController() 
        {
            unitOfWork = new UnitOfWork();
        }

        // GET: Uye
        public ActionResult Index()
        {
            var uyeler = unitOfWork.GetRepository<Uye>().GetAll();
            return View(uyeler);
        }

        public ActionResult Ekle()
        {
            return View();
        }

        public ActionResult Güncelle(int uyeId)
        {
            var Uye = unitOfWork.GetRepository<Uye>().GetById(uyeId);
            return View(Uye);
        }

        [HttpPost]
        public JsonResult EkleUyeJson(string uyeAd, string uyeSoyad, string uyeTc, string uyeTel)
        {
            if (!string.IsNullOrEmpty(uyeAd) && !string.IsNullOrEmpty(uyeSoyad))
            {
             
                Uye uye = new Uye();
                uye.Ad = uyeAd;
                uye.Soyad = uyeSoyad;
                uye.Tc = uyeTc;
                uye.Tel = uyeTel;
                uye.Ceza = 0;
                uye.KayiTarihi = DateTime.Now;

                unitOfWork.GetRepository<Uye>().Add(uye);
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
        public JsonResult GüncelleUyeJson(int uyeId,string uyeAd, string uyeSoyad, string uyeTc, string uyeTel)
        {
            if (!string.IsNullOrEmpty(uyeAd) && !string.IsNullOrEmpty(uyeSoyad))
            {

                var uye = unitOfWork.GetRepository<Uye>().GetById(uyeId);

                uye.Ad = uyeAd;
                uye.Soyad = uyeSoyad;
                uye.Tel = uyeTel;
                uye.KayiTarihi = DateTime.Now;
                uye.Tc = uyeTc;

                unitOfWork.GetRepository<Uye>().Update(uye);
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
        public JsonResult SilUyeJson(int uyeId)
        {
            unitOfWork.GetRepository<Uye>().Delete(uyeId);
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

    }
}