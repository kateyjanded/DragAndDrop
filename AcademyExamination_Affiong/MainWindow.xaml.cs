using AcademyExamination_Affiong.ViewModel;
using System.Windows;

namespace AcademyExamination_Affiong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm= new MainWindowViewModel(this);
            canvasContent.Content= new DragCanvas(vm);
            DataContext = vm;
        }
    }
}
