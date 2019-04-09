using System.Windows;
using WPFEasyAcheivements.Models;

namespace CreatingACustomDialog
{
    public partial class MainWindow : Window
    {
        BasicAcheivement acheivement = new BasicAcheivement("This is a test acheivement", "Thank you for checking out this code :)", totalSteps: 100);
        public MainWindow()
        {
            InitializeComponent();
            WPFEasyAcheivements.AcheivementSystem.AddAcheivement(acheivement);
        }

        private void Button_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            acheivement.IncrementProgress();
        }
    }
}
