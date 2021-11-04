using AcademyExamination_Affiong.ViewModel;
using System.Windows.Controls;
using System.Windows.Input;
namespace AcademyExamination_Affiong.Views
{
    /// <summary>
    /// Interaction logic for TreeView.xaml
    /// </summary>
    public partial class TreeView : UserControl
    {
        public TreeView()
        {
            InitializeComponent();
            DataContext = new TreeViewModel();
        }
        private void TreeViewItem_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var data = (TreeViewItem)sender;
                data.IsExpanded = true;
                (DataContext as TreeViewModel).SelectedElement = data;
            }
        }
    }
}
