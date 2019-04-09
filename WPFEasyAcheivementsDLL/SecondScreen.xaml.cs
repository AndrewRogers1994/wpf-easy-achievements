using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using TestApp.Models;

namespace TestApp
{
    public partial class SecondScreen : Window
    {

        public SecondScreen()
        {
            InitializeComponent();
            
            //AcheivementSystem.AddAcheivement(acheivement);
        }

        private void FadeOutButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //acheivement.IncrementProgress();
            AcheivementSystem.GetAllAcheivements()[0].IncrementProgress();
  
        }
    }
}