using System;
using System.Collections.Generic;
using System.Linq;
using WPFEasyAcheivements.Models;

namespace WPFEasyAcheivements
{
    public static class AcheivementSystem
    {
        private static List<BasicAcheivement> addedAcheivements = new List<BasicAcheivement>();
        public static event Action<BasicAcheivement> AcheivementComplete;
        public static event Action<BasicAcheivement> AcheivementProgress;



        public static void AddAcheivement(BasicAcheivement acheivement)
        {
            acheivement.AchveimentProgress += Acheivement_AchveimentProgress;
            addedAcheivements.Add(acheivement);
        }

        public static List<BasicAcheivement> GetAllAcheivements()
        {
            return addedAcheivements;
        }

        public static List<BasicAcheivement> GetCompletedAcheivements()
        {
            return addedAcheivements.Where(x => x.GetComplectionPercent() == 100).ToList();
        }

        private static void Acheivement_AchveimentProgress(BasicAcheivement obj)
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

        public static void AddAcheivements(List<BasicAcheivement> acheivements)
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
