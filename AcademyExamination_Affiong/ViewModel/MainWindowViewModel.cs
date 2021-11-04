using Microsoft.Win32;

namespace AcademyExamination_Affiong.ViewModel
{
    public class MainWindowViewModel
    {
        private MainWindow Window;
        public MainWindowViewModel()
        {
            Connected = new Command(GetConnectedShape);
            ToggleOn = new Command(Toggles);
            SaveToXml = new Command(Save);
            Browse = new Command(ChooseFile);
        }

        public MainWindowViewModel(MainWindow window) : this()
        {
            Window = window;
        }
        private void Save()
        {
            Savexml?.Invoke();
        }
        public Command Connected { get; set; }
        public Command ToggleOn { get; set; }
        public Command SaveToXml { get; set; }
        public Command Browse { get; set; }
        public string File;
        public event DraWLineHandler DraWLineEvent;
        public event ToggleHandler ToggleEvent;
        public event XmlEventHandler Savexml;

        private void Toggles()
        {
            ToggleEvent();
        }
        private void GetConnectedShape()
        {
            DraWLineEvent();
        }
        public void ChooseFile()
        {
            var dialogue = new OpenFileDialog();
            var result = dialogue.ShowDialog();
            if (result == true)
            {
                File = dialogue.FileName;
            }
            (Window.treeview.DataContext as TreeViewModel).File = File;
        }
    }
    public delegate void BrowseHandler();
    public delegate void ToggleHandler();
    public delegate void DraWLineHandler();
    public delegate void XmlEventHandler();
    public enum Tools
    {
        Line,
        Shape
    }
    public enum Toggle
    {
        ToggleOn,
        ToggleOf,
        None
    }
}