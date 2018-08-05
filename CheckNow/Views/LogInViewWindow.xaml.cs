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

namespace CheckNow.Views
{
    /// <summary>
    /// Логика взаимодействия для LogInViewWindow.xaml
    /// </summary>
    public partial class LogInViewWindow : Window
    {
        public LogInViewWindow()
        {
            InitializeComponent();
        }

        private void HeaderTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            main.BeginStoryboard(this.Resources["ToLog"] as Storyboard, HandoffBehavior.SnapshotAndReplace);
        }

        private void HeaderTextBox_GotFocus_1(object sender, RoutedEventArgs e)
        {
            main.BeginStoryboard(this.Resources["ToPass"] as Storyboard, HandoffBehavior.SnapshotAndReplace);
            button.StopLoadAnimation(SweetControls.SweetButton.ButtonState.Idle);
        }
    }
}
