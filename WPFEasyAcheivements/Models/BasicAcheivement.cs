using System;

namespace WPFEasyAcheivements.Models
{
    public class BasicAcheivement
    {
        public string AcheivementTitle { get; private set; } = "Acheivement Title Goes here";
        public string AcheivementMessage { get; private set; } = "Acheivement Message Goes here";
        public int CurrentStep { get; private set; } = 0;
        public int TotalSteps { get; private set; } = 1;
        public event Action<BasicAcheivement> AchveimentProgress;

        public BasicAcheivement(string Title, string message, int currentStep = 0, int totalSteps = 1)
        {
            AcheivementTitle = Title;
            AcheivementMessage = message;
            CurrentStep = currentStep;
            TotalSteps = totalSteps;
        }

        public double GetComplectionPercent()
        {
            return ((double)CurrentStep / TotalSteps) * 100;
        }

        public void IncrementProgress()
        {
            CurrentStep++;
            if(AchveimentProgress != null)
            {
                AchveimentProgress.Invoke(this);
            }
        }

        public void DecrementProgress()
        {
            CurrentStep--;
            if (AchveimentProgress != null)
            {
                AchveimentProgress.Invoke(this);
            }
        }

        public void IncrementProgress(int amount)
        {
            CurrentStep += amount;
            if(CurrentStep > TotalSteps)
            {
                CurrentStep = TotalSteps;
            }

            if (AchveimentProgress != null)
            {
                AchveimentProgress.Invoke(this);
            }
        }

        public void DecrementProgress(int amount)
        {
            CurrentStep -= amount;
            if (CurrentStep < 0)
            {
                CurrentStep = 0;
            }

            if (AchveimentProgress != null)
            {
                AchveimentProgress.Invoke(this);
            }
        }
    }
}
