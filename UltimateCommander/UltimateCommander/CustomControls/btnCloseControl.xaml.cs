using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UltimateCommander
{
	/// <summary>
	/// Interaction logic for btnCloseControl.xaml
	/// </summary>
	public partial class btnCloseControl : UserControl
	{
        Window wind;
		public btnCloseControl(Window wind)
		{
			this.InitializeComponent();
            this.wind = wind;
		}
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
	}
}