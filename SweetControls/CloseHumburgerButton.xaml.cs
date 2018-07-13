using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace SweetControls
{
    /// <summary>
    /// Логика взаимодействия для CancelButton.xaml
    /// </summary>
    public sealed partial class CloseHumburgerButton : Button
    {
        bool _isOpen;
        PaddingContent _padding;

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public static new readonly DependencyProperty CommandProperty;
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public static new readonly DependencyProperty CommandParameterProperty;

        public static readonly DependencyProperty CloseClickParamProperty;
        public static readonly DependencyProperty OpenClickParamProperty;
        public static readonly DependencyProperty CloseClickProperty;
        public static readonly DependencyProperty OpenClickProperty;

        static CloseHumburgerButton()
        {
            CloseClickProperty = DependencyProperty.Register(nameof(CloseClick), typeof(ICommand), typeof(CloseHumburgerButton));
            OpenClickProperty = DependencyProperty.Register(nameof(OpenClick), typeof(ICommand), typeof(CloseHumburgerButton));

            CloseClickParamProperty = DependencyProperty.Register(nameof(CloseClickParam), typeof(object), typeof(CloseHumburgerButton));
            OpenClickParamProperty = DependencyProperty.Register(nameof(OpenClickParam), typeof(object), typeof(CloseHumburgerButton));
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new ICommand Command { get; set; }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new object CommandParameter { get; set; }

        public ICommand CloseClick
        {
            get => GetValue(CloseClickProperty) as ICommand;
            set => SetValue(CloseClickProperty, value);
        }

        public ICommand OpenClick
        {
            get => GetValue(OpenClickProperty) as ICommand;
            set => SetValue(OpenClickProperty, value);
        }

        public object CloseClickParam
        {
            get => GetValue(CloseClickParamProperty);
            set => SetValue(CloseClickParamProperty, value);
        }

        public object OpenClickParam
        {
            get => GetValue(OpenClickParamProperty);
            set => SetValue(OpenClickParamProperty, value);
        }

        public bool IsOpen
        {
            get => _isOpen;
            private set
            {
                if (value != _isOpen)
                {
                    var storyboard = value ? this.Resources["Close"] : this.Resources["Open"];
                    _isOpen = value;
                    main.BeginStoryboard((Storyboard)storyboard, HandoffBehavior.Compose);
                }
            }
        }

        public CloseHumburgerButton()
        {
            InitializeComponent();
            this.Loaded += LoadLines;

        }

        private void LoadLines(object sender, RoutedEventArgs e)
        {
            _padding = new PaddingContent();

            double width = this.Width;
            double heaight = this.Height;

            double x1 = (width * 0.5) - (width * 0.3);
            double x2 = (width * 0.5) + (width * 0.3);

            Canvas.SetLeft(TopLine, x1);
            Canvas.SetLeft(MiddleLine, x1);
            Canvas.SetLeft(BottomLine, x1);

            TopLine.X2 = x2 - x1;
            MiddleLine.X2 = x2 - x1;
            BottomLine.X2 = x2 - x1;

            double padding = heaight * 0.2;

            _padding.PaddingTop = heaight * 0.3;
            _padding.PaddingBottom = _padding.PaddingTop + padding * 2;

            Canvas.SetTop(TopLine, _padding.PaddingTop);
            Canvas.SetTop(MiddleLine, _padding.PaddingTop + padding);
            Canvas.SetTop(BottomLine, _padding.PaddingTop + padding * 2);

            this.Resources["Open"] = GetStoryboardOpen();
            this.Resources["Close"] = GetStoryboardClose();
        }

        private Storyboard GetStoryboardOpen()
        {
            var storyBoard = this.Resources["Open"] as Storyboard;
            var doubleAnim = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(0.3)),
                To = Canvas.GetTop(MiddleLine)
            };

            BindingOperations.SetBinding(doubleAnim, DoubleAnimation.FromProperty, new Binding("Canvas.Top") { ElementName = nameof(BottomLine) });

            Storyboard.SetTargetName(doubleAnim, nameof(BottomLine));
            Storyboard.SetTargetProperty(doubleAnim, new PropertyPath(Canvas.TopProperty));

            storyBoard.Children.Add(doubleAnim);

            return storyBoard;
        }

        private Storyboard GetStoryboardClose()
        {
            var storyBoard = this.Resources["Close"] as Storyboard;

            var doubleAnimTopLine = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(0.3)),
                To = _padding.PaddingTop
            };

            BindingOperations.SetBinding(doubleAnimTopLine, DoubleAnimation.FromProperty, new Binding("Canvas.Top") { ElementName = nameof(TopLine) });

            Storyboard.SetTargetName(doubleAnimTopLine, nameof(TopLine));
            Storyboard.SetTargetProperty(doubleAnimTopLine, new PropertyPath(Canvas.TopProperty));

            var doubleAnimBottomLine = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(0.3)),
                To = _padding.PaddingBottom
            };

            BindingOperations.SetBinding(doubleAnimBottomLine, DoubleAnimation.FromProperty, new Binding("Canvas.Top") { ElementName = nameof(BottomLine) });

            Storyboard.SetTargetName(doubleAnimBottomLine, nameof(BottomLine));
            Storyboard.SetTargetProperty(doubleAnimBottomLine, new PropertyPath(Canvas.TopProperty));

            storyBoard.Children.Add(doubleAnimTopLine);
            storyBoard.Children.Add(doubleAnimBottomLine);

            return storyBoard;
        }

        protected override void OnClick()
        {
            if (IsOpen)
                CloseClick?.Execute(CloseClickParam);
            else
                OpenClick?.Execute(OpenClickParam);

            IsOpen = !IsOpen;
        }

        struct PaddingContent
        {
            public double PaddingTop { get; set; }
            public double PaddingBottom { get; set; }
        }
    }
}

