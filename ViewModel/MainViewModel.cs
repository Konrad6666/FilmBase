using ProjektBazaFilmow.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit.Primitives;

namespace ProjektBazaFilmow.ViewModel
{
    class MainViewModel : BaseViewModel
    {

        public MainViewModel()
        {
            Entries = SqliteDataAccess.LoadDB();
            Genres = SqliteDataAccess.ReadGenres();
            NumberOfRecords = Entries.Count();
        }
        //Relay Methods
        private void Filter(string title, string genre, double rating, double release, long isWatched, double userRating, int duration)
        {
            Entries = SqliteDataAccess.LoadDB();
            for (int i = 0; i<Entries.Count;i++)
            {
                if (Entries[i].IsWatched != isWatched)
                {
                    Entries.RemoveAt(i);
                    i--;
                    continue;
                }
                if (title != null && Entries[i].Title != null && title.Length > 2)
                {

                    if (!Entries[i].Title.ToUpper(CultureInfo.InvariantCulture).Contains(title.ToUpper(CultureInfo.InvariantCulture))) 
                    {
                        Entries.RemoveAt(i);
                        i--;
                        continue;
                    }
                }
                if (genre != null && genre != "--brak--" && Entries[i].Genres != null)
                {
                    if (!Entries[i].Genres.Contains(genre))
                    {
                        Entries.RemoveAt(i);
                        i--;
                        continue;
                    }
                }
                if (Entries[i].Rating < rating)
                {
                    Entries.RemoveAt(i);
                    i--;
                    continue;
                }
                if (Entries[i].UserRating < userRating)
                {
                    Entries.RemoveAt(i);
                    i--;
                    continue;
                }

                if (Entries[i].ReleaseDate < release)
                {
                    Entries.RemoveAt(i);
                    i--;
                    continue;
                }
                if (Entries[i].Duration < duration)
                {
                    Entries.RemoveAt(i);
                    i--;
                    continue;
                }
            }
            NumberOfRecords = Entries.Count();
        }

        private void GetOverview(int index)
        {
            if(index > -1)
                MessageBox.Show(Entries[index].Overview, $"Opis filmu: {Entries[index].Title}");
        }

        //RelayCommands
        public RelayCommand FilterCommand => new(execute => Filter(Title, Genre, Rating, ReleaseDate, IsWatched, UserRating, Duration));


        private ObservableCollection<Item> _entries;
        public ObservableCollection<Item> Entries
        {
            get => _entries;
            set
            {
                _entries = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<string> Genres { get; set; } = new();



        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }
        private string _genre;
        public string Genre
        {
            get => _genre;
            set
            {
                _genre = value;
                OnPropertyChanged();
            }
        }
        private int _duration;
        public int Duration
        {
            get => _duration;
            set
            {
                _duration = value;
                OnPropertyChanged();
            }
        }
        private double _rating;
        public double Rating
        {
            get => _rating;
            set
            {
                _rating = value;
                OnPropertyChanged();
            }
        }
        private double _releaseDate = 1870;
        public double ReleaseDate
        {
            get => _releaseDate;
            set
            {
                _releaseDate = value;
                OnPropertyChanged();
            }
        }
        private long _isWatched = 0;
        public long IsWatched
        {
            get => _isWatched;
            set
            {
                _isWatched = value;
                OnPropertyChanged();
            }
        }
        private double _userRating;
        public double UserRating
        {
            get => _userRating;
            set
            {
                _userRating = value;
                OnPropertyChanged();
            }
        }
        private int _numberOfRecords;
        public int NumberOfRecords
        {
            get => _numberOfRecords;
            set
            {
                _numberOfRecords = value;
                OnPropertyChanged();
            }
        }
        private int _selectedIndex;

        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (_selectedIndex == value)
                    return;
                _selectedIndex = value;
                OnPropertyChanged();
                GetOverview(_selectedIndex);
            }
        }
    }
}
