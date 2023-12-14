using KutuphaneProgrami.Data.Model;
using KutuphaneProgrami.Data.UnitOfWork;
using System.Web.Mvc;

namespace KutuphaneProgrami.Controllers
{
    public class KategoriController : Controller
    {

        UnitOfWork unitOfWork;

        public KategoriController()
        {
            unitOfWork = new UnitOfWork();
        }

        // GET: Kategori
        public ActionResult Index()
        {

            var Kategoriler = unitOfWork.GetRepository<Kategori>().GetAll();
            return View(Kategoriler);

        }

        /*
         Main.js içindeki ekleme alanın controllerı
         */
        [HttpPost]
        public JsonResult EkleJson(string ktgAd)
        {
            Kategori ktgri = new Kategori
            {
                Ad = ktgAd
            };
            var eklenenKtg = unitOfWork.GetRepository<Kategori>().Add(ktgri);
            unitOfWork.SavaChanges();
            return Json(

                new
                {
                    Result = new
                    {
                        eklenenKtg.Id,
                        eklenenKtg.Ad
                    },
                    JsonRequestBehavior.AllowGet
                }
                );
        }

        /*
         Main.js içindeki düzenleme alanın controllerı
         */
        [HttpPost]
        public JsonResult GüncelleJson(int ktgId, string ktgAd) {

            var kategori = unitOfWork.GetRepository<Kategori>().GetById(ktgId);
            kategori.Ad = ktgAd;
            var durum = unitOfWork.SavaChanges();

            if(durum>0)
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
        public JsonResult SilJson(int ktgId)
        {
            unitOfWork.GetRepository<Kategori>().Delete(ktgId);

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