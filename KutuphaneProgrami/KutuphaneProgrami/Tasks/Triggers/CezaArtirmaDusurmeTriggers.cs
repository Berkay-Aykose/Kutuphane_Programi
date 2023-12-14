using KutuphaneProgrami.Tasks.Jobs;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KutuphaneProgrami.Tasks.Triggers
{
    public class CezaArtirmaDusurmeTriggers
    { 
        public static void Başlat()
        {
            IScheduler zamanlayici = StdSchedulerFactory.GetDefaultScheduler();

            if (!zamanlayici.IsStarted) 
            {
                zamanlayici.Start();
            }

            IJobDetail görev = JobBuilder.Create<CezaArtirmaDusurmeJob>().Build();

            ICronTrigger tetikleyici = (ICronTrigger)TriggerBuilder.Create()
            .WithIdentity("CezaArtirmaDusurmeJob","null")
            .WithCronSchedule("0 0 22 * * ? *")
            .Build();

            zamanlayici.ScheduleJob(görev,tetikleyici);
        }
    }
}