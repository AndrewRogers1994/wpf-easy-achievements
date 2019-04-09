using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WPFEasyAcheivements.Controls
{
    public partial class BasicDialog : UserControl
    {
        private const double animationTime = 0.5;
        public bool isActive = true;

        public BasicDialog()
        {
            InitializeComponent();
            AcheivementSystem.AcheivementProgress += AcheivementSystem_AcheivementProgress;
            AcheivementSystem.AcheivementComplete += AcheivementSystem_AcheivementComplete;
        }

        private void AcheivementSystem_AcheivementComplete(Models.BaseAcheivement obj)
        {
            acheivementTitle.Content = obj.AcheivementTitle;
            acheivementDescription.Content = "COMPLETE:" + obj.AcheivementMessage;
            ShowAcheivement(2, null);
        }

        private void AcheivementSystem_AcheivementProgress(Models.BaseAcheivement obj)
        {
            acheivementTitle.Content = obj.AcheivementTitle;
            acheivementDescription.Content = obj.AcheivementMessage;
            ShowAcheivement(2, null);
        }

        private async void ShowAcheivement(int time, Action AnimationCompleteCallback = null)
        {
            if (isActive)
            {
                FadeIn();
                await Task.Delay(TimeSpan.FromSeconds(animationTime + time));
                FadeOut();
                await Task.Delay(TimeSpan.FromSeconds(animationTime));
                AnimationCompleteCallback?.Invoke();
            }
        }


        private void FadeOut()
        {
            DoubleAnimation fadeOutAnimation = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(animationTime)
            };

            Storyboard.SetTarget(fadeOutAnimation, AcheivementWindow);
            Storyboard.SetTargetProperty(fadeOutAnimation, new PropertyPath(OpacityProperty));
            Storyboard fadeOutStoryboard = new Storyboard();
            fadeOutStoryboard.Children.Add(fadeOutAnimation);
            fadeOutStoryboard.Begin();        
        }

        private void FadeIn()
        {
            DoubleAnimation fadeInAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(animationTime)
            };

            Storyboard.SetTarget(fadeInAnimation, AcheivementWindow);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath(OpacityProperty));
            Storyboard fadeInStoryboard = new Storyboard();
            fadeInStoryboard.Children.Add(fadeInAnimation);
 
            fadeInStoryboard.Begin();
        }


    }
}
