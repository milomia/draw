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

namespace ColorPicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

        public partial class ColorPicker : Window
        {
            #region Ctor
            public ColorPicker()
            {
                InitializeComponent();
            }
            #endregion

            #region Public Properties
            public Color SelectedColor
            {
                get { return colorPicker.SelectedColor; }
            }
            #endregion

            #region Private Methods
            /// <summary>
            /// Closes the dialog on Enter key pressed
            /// </summary>
            private void Window_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Enter)
                {
                    this.Close();
                }
            }

            /// <summary>
            /// User is happy with choice
            /// </summary>
            private void btnOk_Click(object sender, RoutedEventArgs e)
            {
                DialogResult = true;
            }

            /// <summary>
            /// User is not happy with choice
            /// </summary>
            private void btnCancel_Click(object sender, RoutedEventArgs e)
            {
                DialogResult = false;
            }
            #endregion
        }
    }
}
