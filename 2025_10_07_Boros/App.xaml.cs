using _2025_10_07_Boros.Model;
using _2025_10_07_Boros.Persistence;
using _2025_10_07_Boros.ViewModel;
using Microsoft.Win32;
using System.Configuration;
using System.Data;
using System.Windows;

namespace _2025_10_07_Boros
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow _mainWindow;
        private ColorPickerModel _model;
        private ColorPickerViewModel _viewModel;
        private IDataAccess _dataAccess;

        public App()
        {
            Startup += App_Startup;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            _dataAccess = new TextDataAccess();
            _model = new ColorPickerModel(_dataAccess);
            _viewModel = new ColorPickerViewModel(_model);
            _mainWindow = new MainWindow();
            _viewModel.ExitEvent += OnExit;
            _viewModel.SaveEvent += OnSave;
            _viewModel.LoadEvent += OnLoad;
            _mainWindow.DataContext = _viewModel;
            _mainWindow.Show();
        }

        private async void OnLoad(object? sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "txt files (*txt)|*.txt";
                if (openFileDialog.ShowDialog() == true)
                {
                   await _model.Load(openFileDialog.FileName);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error - Load", "Color Picker", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
            
        private void OnSave(object? sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "txt files (*txt)|*.txt";
                if (saveFileDialog.ShowDialog() == true)
                {
                    _model.Save(saveFileDialog.FileName);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error - Save", "Color Picker", MessageBoxButton.OK, MessageBoxImage.Error );
            }
        }

        private void OnExit(object? sender, EventArgs e)
        {
            _mainWindow.Close();
        }
    }

}
