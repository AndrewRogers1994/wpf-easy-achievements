using System.Windows;
using System.Windows.Input;
using TestApp.Interfaces;
using TestApp.Models;

namespace TestApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void FadeOutButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            testAcheivement.ShowAcheivement(2, new System.Action(() =>
            {
                MessageBox.Show("Animation Complete", "The Animation has completed");
            }));
        }
    }
}