using KutuphaneProgrami.Data.Model;
using KutuphaneProgrami.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace KutuphaneProgrami.Controllers
{
    public class OduncKitapController : Controller
    {
        UnitOfWork unitOfWork;

        public OduncKitapController() 
        {
            unitOfWork = new UnitOfWork();
        }

        // GET: OduncKitap
        public ActionResult VerilenKitap()
        {
            var oduncKitap = unitOfWork.GetRepository<OduncKitap>().GetAll(x => x.GetirdigiTarih == null);
            return View(oduncKitap);
        }

        public ActionResult TeslimEdilenKitap()
        {
            var oduncKitap = unitOfWork.GetRepository<OduncKitap>().GetAll(x=>x.GetirdigiTarih != null);
            return View(oduncKitap);
        }

        public ActionResult KitapVer()
        {
            ViewBag.Uyeler = unitOfWork.GetRepository<Uye>().GetAll();
            return View();
        }

        [HttpPost]
        public JsonResult KitapVerJson(int uyeId, DateTime getirecegiTarih)
        {
            OduncKitap oduncKitap = new OduncKitap();

            oduncKitap.AlisTarihi = DateTime.Now;
            oduncKitap.GetirecegiTarih = getirecegiTarih;
            oduncKitap.UyeId = uyeId;

            unitOfWork.GetRepository<OduncKitap>().Add(oduncKitap);
            var durum = unitOfWork.SavaChanges();

            if(durum > 0) 
            {
                return Json("1");
            }
            else
            {
                return Json("0");
            }
        }

        [HttpPost]
        public JsonResult GetırdIsaretleJson(int oduncKtpId)
        {
            var oduncKitap = unitOfWork.GetRepository<OduncKitap>().GetById(oduncKtpId);
            oduncKitap.GetirdigiTarih = DateTime.Now;
            unitOfWork.GetRepository<OduncKitap>().Update(oduncKitap);
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

    }
}