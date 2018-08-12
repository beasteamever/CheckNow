using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ButtonState = SweetControls.SweetButton.ButtonState;

namespace CheckNow.Views
{
    /// <summary>
    /// Логика взаимодействия для LogInViewWindow.xaml
    /// </summary>
    public partial class LogInViewWindow : Window
    {
        private LoginWindowState _state;

        private void HeaderTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (State != LoginWindowState.Remember)
                main.BeginStoryboard(this.Resources["ToLog"] as Storyboard, HandoffBehavior.SnapshotAndReplace);
        }

        private void HeaderTextBox_GotFocus_1(object sender, RoutedEventArgs e)
        {
            if (State != LoginWindowState.Remember)
                main.BeginStoryboard(this.Resources["ToPass"] as Storyboard, HandoffBehavior.SnapshotAndReplace);
        }

        private void SweetButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if (button.State == ButtonState.Idle)
                ((Storyboard)FindResource("ButtonMouseEnter")).Begin();

        }

        private void SweetButton_MouseLeave(object sender, MouseEventArgs e)
        {
            if (button.State == ButtonState.Idle)
                ((Storyboard)FindResource("ButtonMouseLeave")).Begin();
        }

        private void SweetButton_Click(object sender, RoutedEventArgs e)
        {
            if (button.State == ButtonState.Idle)
                ((Storyboard)FindResource("ButtonMouseLeave")).Begin();
        }

        public LogInViewWindow()
        {
            InitializeComponent();

        }

        public LoginWindowState State
        {
            get => _state;
            set
            {
                if (value == LoginWindowState.Remember)
                {
                    Header.Visibility = Visibility.Collapsed;
                    Log.Visibility = Visibility.Collapsed;
                    PersonNameContainer.Visibility = Visibility.Visible;
                    PersonImageEllipse.Visibility = Visibility.Visible;
                    Line.StrokeDashOffset = -365;
                }
                else
                {
                    Header.Visibility = Visibility.Visible;
                    Log.Visibility = Visibility.Visible;
                    PersonName.Visibility = Visibility.Collapsed;
                    PersonImageEllipse.Visibility = Visibility.Collapsed;
                    Line.StrokeDashOffset = 0;
                }

                _state = value;
            }
        }

        private void PersonName_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var anim = FindResource("ToNonRemeberSateAnimation") as Storyboard;
            anim.Completed += (s, a) =>
            {
                var secondAnim = FindResource("ToNonRemeberSateShowAnimation") as Storyboard;
                secondAnim.Completed += (se, ar) => PersonNameContainer.Visibility = Visibility.Collapsed;
                secondAnim.Begin();

                State = LoginWindowState.NonRemeber;
            };
            anim.Begin();
        }

        public enum LoginWindowState
        {
            NonRemeber,
            Remember
        }
    }
}
