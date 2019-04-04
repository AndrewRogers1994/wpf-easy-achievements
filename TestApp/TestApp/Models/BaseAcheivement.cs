using TestApp.Interfaces;

namespace TestApp.Models
{
    public class BaseAcheivement
    {
        public string AcheivementTitle { get; private set; } = "Acheivement Title Goes here";
        public string AcheivementMessage { get; private set; } = "Acheivement Message Goes here";
        public int CurrentStep { get; private set; } = 0;
        public int TotalSteps { get; private set; } = 1;
        private IAcheivement AcheivementInterface;

        public BaseAcheivement(string Title, string message, IAcheivement AcheivementCallbacks, int currentStep = 0, int totalSteps = 1)
        {
            AcheivementTitle = Title;
            AcheivementMessage = message;
            CurrentStep = currentStep;
            TotalSteps = totalSteps;
            AcheivementInterface = AcheivementCallbacks;
        }

        public double GetComplectionPercent()
        {
            return ((double)CurrentStep / TotalSteps) * 100;
        }

        public void IncrementProgress()
        {
            CurrentStep++;
            AcheivementInterface.OnAcheivementProgress(this);
        }

    }
}
