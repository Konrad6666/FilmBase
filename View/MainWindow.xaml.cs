using ProjektBazaFilmow.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ProjektBazaFilmow.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var vm = new MainViewModel();
            InitializeComponent();
        }


        //private void GridViewColumnHeader_Loaded(object sender, RoutedEventArgs e)
        //{
        //    var columnHeader = (GridViewColumnHeader)sender;
        //    columnHeader.MouseEnter += ColumnHeader_MouseEnter;
        //    columnHeader.MouseLeave += ColumnHeader_MouseLeave;
        //}

        //private void ColumnHeader_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    var columnHeader = (GridViewColumnHeader)sender;
        //    columnHeader.Background = Brushes.Black; // Twoj kolor tla po najechaniu

        //    // Zmiana koloru tla kolumny
        //    var column = columnHeader.Column as GridViewColumn;
        //    if (column != null)
        //    {
        //        column.HeaderContainerStyle.Setters.Add(new Setter(BackgroundProperty, Brushes.Black));
        //    }
        //}

        //private void ColumnHeader_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    var columnHeader = (GridViewColumnHeader)sender;
        //    columnHeader.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF202020")); // Twoj domyslny kolor tla

        //    // Przywrocenie domyslnego koloru tla kolumny
        //    var column = columnHeader.Column as GridViewColumn;
        //    if (column != null)
        //    {
        //        column.HeaderContainerStyle.Setters.Add(new Setter(BackgroundProperty, Brushes.Transparent));
        //    }
        //}

    }
}
