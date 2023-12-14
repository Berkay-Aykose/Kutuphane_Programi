using KutuphaneProgrami.Data.Model;
using KutuphaneProgrami.Data.UnitOfWork;
using Quartz;
using System;
using System.Threading.Tasks;

namespace KutuphaneProgrami.Tasks.Jobs
{
    public class CezaArtirmaDusurmeJob : IJob
    {
        UnitOfWork unitOfWork;
        public CezaArtirmaDusurmeJob()
        {
            unitOfWork = new UnitOfWork();
        }
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                CezArtir();
                CezaDusur();
                unitOfWork.SavaChanges();
            }
            catch
            {
                
            }
            
        }

        void CezArtir() 
        {
            var oduncKitaplar = unitOfWork.GetRepository<OduncKitap>().GetAll(x=>x.GetirdigiTarih == null && DateTime.Now>x.GetirecegiTarih);
            foreach(var oduncKitap in oduncKitaplar)
            {
                oduncKitap.Uye.Ceza += 1;
                unitOfWork.GetRepository<Uye>().Update(oduncKitap.Uye);
            }
        }

        void CezaDusur()
        {
            var oduncKitaplar = unitOfWork.GetRepository<OduncKitap>().GetAll(x => x.GetirdigiTarih != null && x.Uye.Ceza>0);
            foreach (var oduncKitap in oduncKitaplar)
            {
                oduncKitap.Uye.Ceza -= 1;
                unitOfWork.GetRepository<Uye>().Update(oduncKitap.Uye);
            }
        }
        
    }
}