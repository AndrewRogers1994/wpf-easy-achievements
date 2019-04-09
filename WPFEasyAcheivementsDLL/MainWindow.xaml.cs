using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using TestApp.Models;

namespace TestApp
{
    public partial class MainWindow : Window
    {
        private BaseAcheivement acheivement = new BaseAcheivement("Test", "test123", totalSteps: 2);

        public MainWindow()
        {
            InitializeComponent();
            
            AcheivementSystem.AddAcheivement(acheivement);
        }

        private void FadeOutButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            acheivement.IncrementProgress();
            testAcheivement.isActive = false;
            new SecondScreen().ShowDialog();
            testAcheivement.isActive = true;
        }
    }
}