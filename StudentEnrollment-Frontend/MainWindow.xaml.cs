using StudentEnrollment_Frontend.ViewModel;
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

namespace StudentEnrollment_Frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        //private void ButtonAddTest_Click(object sender, RoutedEventArgs e)
        //{
        //    // Call CreateNewCourse directly
        //    ((MainWindowViewModel)DataContext).CreateNewCourse();
        //}
    }
}