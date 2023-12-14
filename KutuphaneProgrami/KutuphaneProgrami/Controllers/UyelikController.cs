using KutuphaneProgrami.Data.HelperClass;
using KutuphaneProgrami.Data.Model;
using KutuphaneProgrami.Data.UnitOfWork;
using System.Web.Mvc;

namespace KutuphaneProgrami.Controllers
{
    public class UyelikController : Controller
    {
        UnitOfWork unitOfWork;
        public UyelikController()
        {
            unitOfWork = new UnitOfWork();
        }
        // GET: Uyelik
        public ActionResult Index()
        {
            var uyeler = unitOfWork.GetRepository<Uye>().GetAll(x=>x.Yetki != null);
            return View(uyeler);
        }

        public ActionResult EkleUyelik()
        {
            var uyeler = unitOfWork.GetRepository<Uye>().GetAll(x => x.Yetki == null);
            return View(uyeler);
        }

        [HttpPost]
        public JsonResult EkleUyelikJson(int uyeId,string Mail, string parola, string parolaTekrar)
        {
            if (!string.IsNullOrEmpty(Mail) && !string.IsNullOrEmpty(parola) && !string.IsNullOrEmpty(parolaTekrar))
            {
                if(parola == parolaTekrar)
                {
                    parola = Sifreleme.Sifrele(parola);
                    var uyeler = unitOfWork.GetRepository<Uye>().GetById(uyeId);

                    uyeler.Id = uyeId;
                    uyeler.Mail = Mail;
                    uyeler.Sifre = parola;
                    uyeler.Yetki = "2";
                    //1=adin 2=modototör 3=izleyici

                    unitOfWork.GetRepository<Uye>().Add(uyeler);
                    unitOfWork.SavaChanges();
                    return Json("1");
                }
                else { return Json("parolaUyusmazligi"); }

            }
            else { return Json("bosOlamaz"); }
        }
    }
}