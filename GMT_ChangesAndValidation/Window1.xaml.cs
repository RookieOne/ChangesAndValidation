using System.Windows;
using GMT_ChangesAndValidation.ViewModels;
using Microsoft.Windows.Controls;

namespace GMT_ChangesAndValidation
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            content.Content = new CashEstimatesViewModel();
        }
    }
}