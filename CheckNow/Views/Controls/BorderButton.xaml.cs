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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CheckNow.Views.Controls
{
    /// <summary>
    /// Логика взаимодействия для BorderButton.xaml
    /// </summary>
    public partial class BorderButton : Button
    {
        private static readonly DependencyProperty CornerRadiusProperty;

        static BorderButton()
        {
            CornerRadiusProperty = DependencyProperty.Register(nameof(CornerRadius), typeof(Thickness), typeof(BorderButton),
                new PropertyMetadata(new PropertyChangedCallback(OnCornerRadiusChanged)));
        }

        private static void OnCornerRadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            /*if (border != null)
            {
                this.RemoveLogicalChild(newContent);
                border.Child = newContent as UIElement;

                base.OnContentChanged(oldContent, border);
                return;
            }*/

            base.OnContentChanged(oldContent, newContent);
        }

        public Thickness CornerRadius
        {
            get => (Thickness)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public BorderButton()
        {
            InitializeComponent();
            Template.Seal();
        }
    }
}
