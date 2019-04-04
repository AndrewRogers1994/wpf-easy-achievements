using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace TestApp.Controls
{
    public partial class BasicDialog : UserControl
    {
        private bool acheivementVisible = false;
        private const double animationTime = 0.5;

        public BasicDialog()
        {
            InitializeComponent();
        }

        public void ToggleAcheivement()
        {
            if(acheivementVisible)
            {
                FadeOut();
            }
            else
            {
                FadeIn();
            }
        }

        public async void ShowAcheivement(int time, Action AnimationCompleteCallback = null)
        {
            FadeIn();
            await Task.Delay(TimeSpan.FromSeconds(animationTime + time));
            FadeOut();
            await Task.Delay(TimeSpan.FromSeconds(animationTime));
            AnimationCompleteCallback?.Invoke();
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
            Storyboard.SetTargetProperty(fadeOutAnimation, new PropertyPath(UserControl.OpacityProperty));
            Storyboard fadeOutStoryboard = new Storyboard();
            fadeOutStoryboard.Children.Add(fadeOutAnimation);
            fadeOutStoryboard.Completed += FadeOutStoryboard_Completed;
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
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath(UserControl.OpacityProperty));
            Storyboard fadeInStoryboard = new Storyboard();
            fadeInStoryboard.Children.Add(fadeInAnimation);
            fadeInStoryboard.Completed += FadeInStoryboard_Completed;
            fadeInStoryboard.Begin();
        }

        private void FadeOutStoryboard_Completed(object sender, EventArgs e)
        {
            acheivementVisible = false;
        }

        private void FadeInStoryboard_Completed(object sender, EventArgs e)
        {
            acheivementVisible = true;
        }

    }
}
