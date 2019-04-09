using System;
using System.Collections.Generic;
using System.Linq;
using TestApp.Models;

namespace WPFEasyAcheivements
{
    public static class AcheivementSystem
    {
        private static List<BaseAcheivement> addedAcheivements = new List<BaseAcheivement>();
        public static event Action<BaseAcheivement> AcheivementComplete;
        public static event Action<BaseAcheivement> AcheivementProgress;



        public static void AddAcheivement(BaseAcheivement acheivement)
        {
            acheivement.AchveimentProgress += Acheivement_AchveimentProgress;
            addedAcheivements.Add(acheivement);
        }

        public static List<BaseAcheivement> GetAllAcheivements()
        {
            return addedAcheivements;
        }

        public static List<BaseAcheivement> GetCompletedAcheivements()
        {
            return addedAcheivements.Where(x => x.GetComplectionPercent() == 100).ToList();
        }

        private static void Acheivement_AchveimentProgress(BaseAcheivement obj)
        {
            if(AcheivementProgress != null)
            {
                if (obj.GetComplectionPercent() == 100)
                {
                    AcheivementComplete.Invoke(obj);
                }
                else
                {
                    AcheivementProgress.Invoke(obj);
                }
            }
        }

        public static void AddAcheivements(List<BaseAcheivement> acheivements)
        {
            addedAcheivements.AddRange(acheivements);
        }

        /*
        private static void OnAcheivementComplete(EventArgs e)
        {
            EventHandler handler = AcheivementComplete;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        */

    }
}
