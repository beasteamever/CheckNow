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
        public static readonly DependencyProperty ErrorStringProperty;

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

        public new Brush Background
        {
            get => border.Background;
            set => border.Background = value;
        }

        public double SqueezeSize
        {
            get => (double)GetValue(SqueezeSizeProperty);
            set => SetValue(SqueezeSizeProperty, value);
        }

        public SweetButton()
        {
            InitializeComponent();

            this.Loaded += (s, args) =>
            {
                var squeezeStoryboard = this.FindResource("SqueezeAnimation") as Storyboard;
                var squeezqAnimation = squeezeStoryboard.Children[0] as DoubleAnimation;
                squeezqAnimation.To = SqueezeSize;

                border.Width = border.ActualWidth;

                _ellipseLenght = Math.PI * SqueezeSize;
                ellipse.StrokeDashArray = new DoubleCollection() { _ellipseLenght, _ellipseLenght };
            };
        }

        public void StopLoadAnimation(ButtonState state)
        {
            if (!IsLoading)
                return;

            // TODO Stop loading animation

            switch (state)
            {
                case ButtonState.Idle:
                    BeginStoryboard(FindResource("ToIdleAnimation") as Storyboard, HandoffBehavior.SnapshotAndReplace);
                    ellipse.Visibility = Visibility.Collapsed;
                    border.Visibility = Visibility.Visible;
                    break;
                case ButtonState.Loaded:
                    break;
            }


            IsLoading = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!IsLoading && SqueezeSize != 0.0)
            {
                IsLoading = true;
                text.Visibility = Visibility.Collapsed;
                var anim = this.FindResource("SqueezeAnimation") as Storyboard;
                this.BeginStoryboard(anim);
            }

        }

        private void SqueezeAnimation_Completed(object sender, EventArgs e)
        {
            ellipse.Visibility = Visibility.Visible;
            border.Visibility = Visibility.Hidden;

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
            _loadingAnimation.Children.Add(animation);
            Storyboard.SetTarget(animation, ellipse);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Ellipse.StrokeDashOffsetProperty));
            this.BeginStoryboard(_loadingAnimation);
        }

        public enum ButtonState
        {
            Idle,
            loading,
            Loaded
        }
    }
}
