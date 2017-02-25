using System;
using System.Windows.Threading;
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
using System.IO;
using Microsoft.Win32;
using WPFColorPickerLib;

namespace draw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point currentPoint = new Point();
        SolidColorBrush scb;

        public MainWindow()
        {
            InitializeComponent();

            //paintSurface.MouseUp += new MouseButtonEventHandler(Canvas_MouseUp_1);

            var frameTimer = new DispatcherTimer();
            // Asteroids in the background ?
            frameTimer.Tick += OnFrame;
            frameTimer.Interval = TimeSpan.FromSeconds(1.0 / 60.0);
            frameTimer.Start();
        }

        private void OnFrame(object sender, EventArgs e)
        {
            var el = new Ellipse();
           //el.Stroke = SystemColors.WindowFrameBrush;
            el.Stroke = scb;
            el.StrokeThickness = 10;
            el.SetValue(Canvas.LeftProperty, currentPoint.X);
            el.SetValue(Canvas.TopProperty, currentPoint.Y);
            paintSurface.Children.Add(el);
        }

        private void Canvas_MouseUp_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Mouse up", "Confirmation");
        }

        private void Canvas_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(this);
        }

        private void Canvas_MouseMove_1(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Line line = new Line();

                line.Stroke = scb;
                line.StrokeThickness = 1;
                line.X1 = currentPoint.X-27;
                line.Y1 = currentPoint.Y-35;
                line.X2 = e.GetPosition(this).X-27;
                line.Y2 = e.GetPosition(this).Y-35;

                currentPoint = e.GetPosition(this);

                paintSurface.Children.Add(line);
            }
            textBox_x.Text = e.GetPosition(this).X.ToString();
            textBox_y.Text = e.GetPosition(this).Y.ToString();

        }

        private void NewItem_Click(object sender, RoutedEventArgs e)
        {

            //   OpenFileDialogSample openFileDialogSample = new OpenFileDialogSample();
            //   openFileDialogSample.Show();

            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
        }

        private void OpenItem_Click(object sender, RoutedEventArgs e)
        {

            //   OpenFileDialogSample openFileDialogSample = new OpenFileDialogSample();
            //   openFileDialogSample.Show();


            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
        }

        private void SaveItem_Click(object sender, RoutedEventArgs e)
        {

            //   OpenFileDialogSample openFileDialogSample = new OpenFileDialogSample();
            //   openFileDialogSample.Show();


            SaveFileDialog ofd = new SaveFileDialog();
            ofd.ShowDialog();
        }



        private void ColourItem_Click(object sender, RoutedEventArgs e)
        { 
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Owner = this;
            if ((bool)colorDialog.ShowDialog())
            {
                scb = new SolidColorBrush(colorDialog.SelectedColor);
            }
   
        }

        private void FontItem_Click(object sender, RoutedEventArgs e)
        {
            ColorFont.ColorFontDialog fntDialog = new ColorFont.ColorFontDialog();
            fntDialog.Owner = this;
            //fntDialog.ShowDialog();

            fntDialog.Font = ColorFont.FontInfo.GetControlFont(fntDialog);
            fntDialog.ShowDialog();
        }
     


private void OnMenuExit(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to close this window?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                // Close the window
                Application.Current.Shutdown();
            }
            else
            {
                // Do not close the window
                MessageBoxResult result = MessageBox.Show("Carry On", "Confirmation");
            }
        }
    }
}
