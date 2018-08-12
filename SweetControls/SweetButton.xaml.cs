using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Linq;

namespace SweetControls
{
    /// <summary>
    /// Логика взаимодействия для SweetButton.xaml
    /// </summary>
    public partial class SweetButton : Button
    {
        private static readonly DependencyProperty CornerRadiusProperty;
        private static readonly DependencyProperty TextProperty;
        private static readonly DependencyProperty SqueezeSizeProperty;

        static SweetButton()
        {
            CornerRadiusProperty = DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(SweetButton),
                new PropertyMetadata(new CornerRadius(0)));

            TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(SweetButton),
                new PropertyMetadata(String.Empty));

            SqueezeSizeProperty = DependencyProperty.Register(nameof(SqueezeSize), typeof(double), typeof(SweetButton),
                new PropertyMetadata(0.0));
        }

        private double _ellipseLenght;
        private Storyboard _loadingAnimation;

        protected override void OnClick()
        {
            base.OnClick();

            if (!IsLoading && SqueezeSize != 0.0)
            {
                State = ButtonState.Loading;
                text.Visibility = Visibility.Collapsed;
                var anim = this.FindResource("SqueezeAnimation") as Storyboard;
                this.BeginStoryboard(anim);
            }
        }

        private void SqueezeAnimation_Completed(object sender, EventArgs e)
        {
            _loadingAnimation = new Storyboard();
            var animation = new DoubleAnimation()
            {
                From = 0,
                To = _ellipseLenght * 2,
                Duration = new Duration(TimeSpan.FromSeconds(1.5)),
                AccelerationRatio = 0.3,
                DecelerationRatio = 0.5,
                RepeatBehavior = RepeatBehavior.Forever
            };

            Storyboard.SetTarget(animation, ellipse);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Ellipse.StrokeDashOffsetProperty));

            _loadingAnimation.Children.Add(animation);
            _loadingAnimation.Begin(ellipse, true);
            IsLoading = true;
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public string Text
        {
            get => GetValue(TextProperty).ToString();
            set => SetValue(TextProperty, value);
        }

        public bool IsLoading
        {
            get;
            set;
        }

        public double SqueezeSize
        {
            get => (double)GetValue(SqueezeSizeProperty);
            set => SetValue(SqueezeSizeProperty, value);
        }

        public ButtonState State
        {
            get;
            private set;
        }

        public SweetButton()
        {
            InitializeComponent();

            this.Loaded += (s, args) =>
            {
                var squeezeStoryboard = this.FindResource("SqueezeAnimation") as Storyboard;
                ((DoubleAnimation)squeezeStoryboard.Children[0]).To = SqueezeSize;

                var toIdleAnimation = this.FindResource("ToIdleAnimation") as Storyboard;
                ((DoubleAnimation)toIdleAnimation.Children[0]).To = border.ActualWidth;

                border.Width = border.ActualWidth;

                _ellipseLenght = Math.PI * SqueezeSize;
                ellipse.StrokeDashArray = new DoubleCollection() { _ellipseLenght, _ellipseLenght };

                checkIcon.Width = SqueezeSize - 20;
                checkIcon.Height = ellipse.Height - 20;
            };
        }

        public void StopLoadAnimation(ButtonState nextState)
        {
            if (!IsLoading)
                return;

            State = nextState;
            var anim = _loadingAnimation.Children[0] as DoubleAnimation;
            double animSpeed = _ellipseLenght * 2 / 1.5;
            double animTime = (_ellipseLenght * 2 - ellipse.StrokeDashOffset) / animSpeed;

            _loadingAnimation.Pause(ellipse);

            anim.RepeatBehavior = new RepeatBehavior(1);
            anim.From = ellipse.StrokeDashOffset;
            anim.Duration = new Duration(TimeSpan.FromSeconds(animTime));

            anim.Completed += (s, a) =>
            {
                switch (nextState)
                {
                    case ButtonState.Idle:
                        BeginStoryboard(FindResource("ToIdleAnimation") as Storyboard, HandoffBehavior.Compose);
                        text.Visibility = Visibility.Visible;
                        break;
                    case ButtonState.Loaded:
                        BeginStoryboard(FindResource("ShowContentAnimation") as Storyboard, HandoffBehavior.Compose);
                        break;
                }
            };

            _loadingAnimation.Begin(ellipse, true);

            IsLoading = false;
        }

        public enum ButtonState
        {
            Idle,
            Loading,
            Loaded
        }
    }
}
