using System.Threading.Tasks;
using System.Windows.Controls;
using WPFEasyAcheivements;
using WPFEasyAcheivements.Models;

namespace CreatingACustomDialog.Controls
{
    public partial class CustomControl : UserControl
    {
        public CustomControl()
        {
            InitializeComponent();
            Visibility = System.Windows.Visibility.Collapsed;

            //Subscribe to the progress and completion events of the acheivement system
            AcheivementSystem.AcheivementProgress += AcheivementSystem_AcheivementProgress;
            AcheivementSystem.AcheivementComplete += AcheivementSystem_AcheivementComplete;
        }

        private void AcheivementSystem_AcheivementComplete(BasicAcheivement acheivement)
        {
            ShowAcheivement(acheivement);
        }

        private void AcheivementSystem_AcheivementProgress(BasicAcheivement acheivement)
        {
            ShowAcheivement(acheivement);
        }

        private async void ShowAcheivement(BasicAcheivement acheivement)
        {
            acheivementTitle.Content = acheivement.AcheivementTitle;
            acheivementMessage.Content = acheivement.AcheivementMessage;
            acheivementProgress.Maximum = acheivement.TotalSteps;
            acheivementProgress.Value = acheivement.CurrentStep;

            Visibility = System.Windows.Visibility.Visible;
            await Task.Delay(2000);
            Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}
