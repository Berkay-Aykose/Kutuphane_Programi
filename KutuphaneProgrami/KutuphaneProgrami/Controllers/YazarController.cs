using KutuphaneProgrami.Data.Model;
using KutuphaneProgrami.Data.UnitOfWork;
using System.Web.Mvc;

namespace KutuphaneProgrami.Controllers
{
    public class YazarController : Controller
    {
        UnitOfWork unitOfWork;

        public YazarController()
        {
            unitOfWork = new UnitOfWork();
        }
        // GET: Yazar
        public ActionResult Index()
        {
            var Yazarlar = unitOfWork.GetRepository<Yazar>().GetAll();
            return View(Yazarlar);
        }

        /*
         Main.js içindeki ekleme alanın controllerı
         */
        [HttpPost]
        public JsonResult EkleJson(string yzrAd)
        {
            Yazar yazar = new Yazar
            {
                Ad = yzrAd
            };
            var eklenenYzr = unitOfWork.GetRepository<Yazar>().Add(yazar);
            unitOfWork.SavaChanges();
            return Json(

                new
                {
                    Result = new
                    {
                        eklenenYzr.Id,
                        eklenenYzr.Ad
                    },
                    JsonRequestBehavior.AllowGet
                }
                );
        }

        /*
         Main.js içindeki güncelleme alanın controllerı
         */
        [HttpPost]
        public JsonResult GüncelleYzrJson(int yzrId, string yzrAd)
        {

            var yazar = unitOfWork.GetRepository<Yazar>().GetById(yzrId);
            yazar.Ad = yzrAd;
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

        /*
         Main.js içindeki silme alanın controllerı
         */
        [HttpPost]
        public JsonResult SilYzrJson(int yzrId)
        {
            unitOfWork.GetRepository<Yazar>().Delete(yzrId);

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