using CheckNow.Utility;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace CheckNow.Views
{
    /// <summary>
    /// Логика взаимодействия для ProjectListViewItem.xaml
    /// </summary>
    public partial class ProjectListViewItem : Border
    {
        private bool _isOpen;

        /// <summary>
        ///  Identifies dependency property Priority
        /// </summary>
        public static readonly DependencyProperty PriorityProperty;
        /// <summary>
        /// Identifies dependency property Deadline
        /// </summary>
        public static readonly DependencyProperty DeadlineProperty;
        /// <summary>
        /// Identifies dependency property DateStart
        /// </summary>
        public static readonly DependencyProperty DateStartProperty;
        /// <summary>
        /// Identifies dependency property ProjectName
        /// </summary>
        public static readonly DependencyProperty ProjectNameProperty;
        /// <summary>
        /// Identifies dependency property ProjectManager
        /// </summary>
        public static readonly DependencyProperty ProjectManagerProperty;
        /// <summary>
        /// Identifies dependency property  Team
        /// </summary>
        public static readonly DependencyProperty TeamProperty;
        /// <summary>
        /// Identifies dependency property  Customer
        /// </summary>
        public static readonly DependencyProperty CustomerInfoProperty;

        /// <summary>
        /// Identifies dependency property DoubleClickedCommand
        /// </summary>
        public static readonly DependencyProperty DoubleClickedCommandProperty;

        #region Static members

        static ProjectListViewItem()
        {
            PriorityProperty = DependencyProperty.Register(nameof(Priority), typeof(Priority), typeof(ProjectListViewItem),
                new PropertyMetadata(Priority.Low, new PropertyChangedCallback(PriorityChanging)));

            DeadlineProperty = DependencyProperty.Register(nameof(Deadline), typeof(DateTime), typeof(ProjectListViewItem),
                new PropertyMetadata(new PropertyChangedCallback(OnDeadlineChanged)));

            DateStartProperty = DependencyProperty.Register(nameof(DateStart), typeof(DateTime), typeof(ProjectListViewItem),
                new PropertyMetadata(new PropertyChangedCallback(OnDateStartChanged)));

            ProjectNameProperty = DependencyProperty.Register(nameof(ProjectName), typeof(string), typeof(ProjectListViewItem),
                new PropertyMetadata(new PropertyChangedCallback(OnProjectNameChanged)));

            ProjectManagerProperty = DependencyProperty.Register(nameof(ProjectManager), typeof(PersonViewModel), typeof(ProjectListViewItem),
                new PropertyMetadata(null, new PropertyChangedCallback(OnProjectManagerChanged)));

            TeamProperty = DependencyProperty.Register(nameof(Team), typeof(PersonViewModel), typeof(ProjectListViewItem),
                new PropertyMetadata(null, new PropertyChangedCallback(OnTeamChanged)));

            CustomerInfoProperty = DependencyProperty.Register(nameof(CustomerInfo), typeof(CustomerInfoViewModel), typeof(ProjectListViewItem),
                new PropertyMetadata(null, new PropertyChangedCallback(OnCustomerInfoChanged)));

            DoubleClickedCommandProperty = DependencyProperty.Register(nameof(DoubleClickedCommand), typeof(ICommand), typeof(ProjectListViewItem));
        }

        protected static void OnCustomerInfoChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected static void OnTeamChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected static void OnProjectManagerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected static void PriorityChanging(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var view = d as ProjectListViewItem;
            var priority = (Priority)e.NewValue;

            switch (priority)
            {
                case Priority.Hight:
                    view.header.Background = view.FindResource("DarkRedColor") as Brush;
                    break;
                case Priority.Medium:
                    view.header.Background = view.FindResource("DarkOrangeColor") as Brush;
                    break;
                case Priority.Low:
                    view.header.Background = view.FindResource("DarkGreenColor") as Brush;
                    break;

            }
        }

        protected static void OnDeadlineChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected static void OnDateStartChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected static void OnProjectNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        public ICommand DoubleClickedCommand
        {
            get => GetValue(DoubleClickedCommandProperty) as ICommand;
            set => SetValue(DoubleClickedCommandProperty, value);
        }

        public CustomerInfoViewModel CustomerInfo
        {
            get => GetValue(CustomerInfoProperty) as CustomerInfoViewModel;
            set => SetValue(CustomerInfoProperty, value);
        }

        public PersonViewModel Team
        {
            get => GetValue(TeamProperty) as PersonViewModel;
            set => SetValue(TeamProperty, value);
        }

        public PersonViewModel ProjectManager
        {
            get => GetValue(ProjectManagerProperty) as PersonViewModel;
            set => SetValue(ProjectManagerProperty, value);
        }

        public string ProjectName
        {
            get => GetValue(ProjectNameProperty).ToString();
            set => SetValue(ProjectNameProperty, value);
        }

        public DateTime DateStart
        {
            get => (DateTime)GetValue(DateStartProperty);
            set => SetValue(DateStartProperty, value);
        }

        public DateTime Deadline
        {
            get => (DateTime)GetValue(DeadlineProperty);
            set => SetValue(DeadlineProperty, value);
        }

        public Priority Priority
        {
            get => (Priority)GetValue(PriorityProperty);
            set => SetValue(PriorityProperty, value);
        }

        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                if (value != _isOpen)
                {
                    var storyboard = value ? this.Resources["Close"] : this.Resources["Open"];
                    _isOpen = value;
                    main.BeginStoryboard((Storyboard)storyboard, HandoffBehavior.Compose);
                }
            }
        }

        public ProjectListViewItem()
        {
            InitializeComponent();
        }

        private void Clicked(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
                DoubleClickedCommand?.Execute(null);
            else
                IsOpen = !IsOpen;
        }
    }

    public enum Priority
    {
        Hight,
        Medium,
        Low
    }
}
