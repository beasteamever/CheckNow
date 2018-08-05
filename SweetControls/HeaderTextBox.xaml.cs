using System;
using System.ComponentModel;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace SweetControls
{
    /// <summary>
    /// Логика взаимодействия для HeaderTextBox.xaml
    /// </summary>
    public sealed partial class HeaderTextBox : UserControl
    {
        private SecureString _securePassword;

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new static readonly DependencyProperty ContentProperty;

        /// <summary>
        /// Identifies dependency property fo Text property
        /// </summary>
        public static readonly DependencyProperty TextProperty;
        public static readonly DependencyProperty TextHeaderProperty;
        /*public static readonly DependencyProperty FontSizeProperty;*/
        public static readonly DependencyProperty FontFamilyHeaderProperty;
        public static readonly DependencyProperty FontSizeHeaderProperty;
        public static readonly DependencyProperty FontStretchHeaderProperty;
        public static readonly DependencyProperty FontWeightHeaderProperty;
        public static readonly DependencyProperty FontStyleHeaderProperty;
        public static readonly DependencyProperty ResizeHeaderFontSizeProperty;
        public static readonly DependencyProperty ForegroundHeaderProperty;
        public static readonly DependencyProperty CaretBrushProperty;

        public static readonly DependencyProperty IsPasswordTextProperty;

        static HeaderTextBox()
        {
            TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(HeaderTextBox),
                new PropertyMetadata(String.Empty));

            TextHeaderProperty = DependencyProperty.Register(nameof(TextHeader), typeof(string), typeof(HeaderTextBox),
                new PropertyMetadata(String.Empty));

            FontFamilyHeaderProperty = DependencyProperty.Register(nameof(FontFamilyHeader), typeof(FontFamily), typeof(HeaderTextBox),
                new PropertyMetadata(defaultValue:null));

            FontSizeHeaderProperty = DependencyProperty.Register(nameof(FontSizeHeader), typeof(double), typeof(HeaderTextBox),
                new PropertyMetadata(13.0));

            FontStretchHeaderProperty = DependencyProperty.Register(nameof(FontStretchHeader), typeof(FontStretch), typeof(HeaderTextBox),
                new PropertyMetadata(FontStretches.Normal));

            FontWeightHeaderProperty = DependencyProperty.Register(nameof(FontWeightHeader), typeof(FontWeight), typeof(HeaderTextBox),
                new PropertyMetadata(FontWeights.Normal));

            FontStyleHeaderProperty = DependencyProperty.Register(nameof(FontStyleHeader), typeof(FontStyle), typeof(HeaderTextBox),
                new PropertyMetadata(FontStyles.Normal));

            ForegroundHeaderProperty = DependencyProperty.Register(nameof(ForegroundHeader), typeof(Brush), typeof(HeaderTextBox),
                new PropertyMetadata(Brushes.Black));

            ResizeHeaderFontSizeProperty = DependencyProperty.Register(nameof(ResizeHeaderFontSize), typeof(double), typeof(HeaderTextBox));

            IsPasswordTextProperty = DependencyProperty.Register(nameof(IsPasswordText), typeof(bool), typeof(HeaderTextBox), new PropertyMetadata(false));

            CaretBrushProperty = DependencyProperty.Register(nameof(CaretBrush), typeof(Brush), typeof(HeaderTextBox), new PropertyMetadata(Brushes.Black));
        }

        private double _fontSizeHeaderBeforAnim;

        public string Text
        {
            get => GetValue(TextProperty).ToString();
            set => SetValue(TextProperty, value);
        }

        public string TextHeader
        {
            get => GetValue(TextHeaderProperty).ToString();
            set => SetValue(TextHeaderProperty, value);
        }

        public FontStyle FontStyleHeader
        {
            get => (FontStyle)GetValue(FontStyleHeaderProperty);
            set => SetValue(FontStyleHeaderProperty, value);
        }

        public double FontSizeHeader
        {
            get => (double)GetValue(FontSizeHeaderProperty);
            set => SetValue(FontSizeHeaderProperty, value);
        }

        public FontStretch FontStretchHeader
        {
            get => (FontStretch)GetValue(FontStretchHeaderProperty);
            set => SetValue(FontStretchHeaderProperty, value);
        }

        public FontWeight FontWeightHeader
        {
            get => (FontWeight)GetValue(FontWeightHeaderProperty);
            set => SetValue(FontWeightHeaderProperty, value);
        }

        public FontFamily FontFamilyHeader
        {
            get => GetValue(FontFamilyHeaderProperty) as FontFamily;
            set => SetValue(FontFamilyHeaderProperty, value);

        }

        public double ResizeHeaderFontSize
        {
            get => (double)GetValue(ResizeHeaderFontSizeProperty);
            set => SetValue(ResizeHeaderFontSizeProperty, value);
        }

        public Brush ForegroundHeader
        {
            get => (Brush)GetValue(ForegroundHeaderProperty);
            set => SetValue(ForegroundHeaderProperty, value);
        }

        public Brush CaretBrush
        {
            get => GetValue(CaretBrushProperty) as Brush;
            set => SetValue(CaretBrushProperty, value);
        }

        public bool IsPasswordText
        {
            get => (Boolean)GetValue(IsPasswordTextProperty);
            set => SetValue(IsPasswordTextProperty, value);
        }

        public HeaderTextBox()
        {
            InitializeComponent();

            ResizeHeaderFontSize = 9;

            Content.PreviewMouseLeftButtonDown += (s, a) =>
            {
                if (String.IsNullOrEmpty(Content.Text))
                    main.BeginStoryboard((Storyboard)this.Resources["ToInput"], HandoffBehavior.Compose);
            };

            Content.LostFocus += (s, a) =>
            {
                if (String.IsNullOrEmpty(Content.Text))
                    main.BeginStoryboard((Storyboard)this.Resources["ToIdle"], HandoffBehavior.Compose);
            };

            Loaded += (s, a) =>
            {
                _fontSizeHeaderBeforAnim = Header.FontSize;
                this.Resources["ToInput"] = GetToInputStoryboard();
                this.Resources["ToIdle"] = GetToIdleStoryboard();
                if (IsPasswordText)
                {
                    Content.TextChanged += Content_TextChanged;
                    _securePassword = new SecureString();
                }
            };
        }

        // TODO fix securePassword
        private void Content_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textChaned = e.Changes;

            foreach (var changes in textChaned)
            {
                var letter = Content.Text[changes.Offset];

                if (changes.RemovedLength != 0)
                {
                    _securePassword.RemoveAt(changes.Offset);
                }


                if (changes.AddedLength != 0 && letter != '*')
                {
                    if (changes.Offset == Content.Text.Length - 1)
                        _securePassword.AppendChar(letter);
                    else
                        _securePassword.InsertAt(changes.Offset, letter);

                    Text = Content.Text.Replace(Content.Text[changes.Offset], '*');
                    Content.CaretIndex = changes.Offset + 1;
                }
            }
        }

        // Debug helper
        private unsafe string SecureStringToString(SecureString secureString)
        {
            IntPtr ptr = IntPtr.Zero;

            ptr = Marshal.SecureStringToGlobalAllocUnicode(secureString);
            return Marshal.PtrToStringUni(ptr);
        }

        private Storyboard GetToInputStoryboard()
        {
            var storyboard = this.Resources["ToInput"] as Storyboard;

            var fontSizeHeaderAnim = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(0.2)),
                To = ResizeHeaderFontSize
            };

            BindingOperations.SetBinding(fontSizeHeaderAnim, DoubleAnimation.FromProperty, new Binding(nameof(FontSize)) { ElementName = nameof(Header) });

            Storyboard.SetTargetName(fontSizeHeaderAnim, nameof(Header));
            Storyboard.SetTargetProperty(fontSizeHeaderAnim, new PropertyPath(TextBlock.FontSizeProperty));

            storyboard.Children.Add(fontSizeHeaderAnim);

            return storyboard;
        }

        private Storyboard GetToIdleStoryboard()
        {
            var storyboard = this.Resources["ToIdle"] as Storyboard;

            var fontSizeHeaderAnim = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(0.2)),
                To = _fontSizeHeaderBeforAnim
            };

            BindingOperations.SetBinding(fontSizeHeaderAnim, DoubleAnimation.FromProperty, new Binding(nameof(FontSize)) { ElementName = nameof(Header) });

            Storyboard.SetTargetName(fontSizeHeaderAnim, nameof(Header));
            Storyboard.SetTargetProperty(fontSizeHeaderAnim, new PropertyPath(TextBlock.FontSizeProperty));

            storyboard.Children.Add(fontSizeHeaderAnim);

            return storyboard;
        }
    }
}
