using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Windows;

namespace ProjektBazaFilmow.Model
{
    public class Item
    {
        public string Title { get; set; }
        public double ReleaseDate { get; set; }
        private double _rating;
        public double Rating
        {
            get => _rating;
            set
            {
                _rating = value;
            }
        }
        public string Genres { get; set; }
        public string Overview { get; set; }
        public double Duration { get; set; }
        private double _userRating;
        public double UserRating
        {
            get => _userRating;
            set
            {
                OnPropertyChanged(nameof(UserRating));
                _userRating = value;
            }
        }
        public double UserRatingResult
        {
            get
            {
                return _userRating;
            }
            set
            {
                _userRating = value;
                OnPropertyChanged(nameof(UserRatingResult));
                UpdateRating(this);
            }
        }
        private long _isWatched;
        public long IsWatched
        {
            get { return _isWatched; }
            set
            {
                OnPropertyChanged(nameof(IsWatched));
                _isWatched = value;
            }
        }
        public long IsWatchedResult
        {
            get {
                return _isWatched;
            }
            set
            {
                _isWatched = value;
                OnPropertyChanged(nameof(IsWatchedResult));
                Update(this);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void Update(Item item)
        {
            using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
            {
                cnn.Open();
                var command = cnn.CreateCommand();

                command.CommandText = "UPDATE Filmy SET IsWatched = @IsWatched WHERE Title = @Title";

                var isWatchedParam = command.CreateParameter();
                isWatchedParam.ParameterName = "@IsWatched";
                isWatchedParam.Value = item.IsWatched != 0L;
                command.Parameters.Add(isWatchedParam);

                var titleParam = command.CreateParameter();
                titleParam.ParameterName = "@Title";
                titleParam.Value = item.Title;
                command.Parameters.Add(titleParam);

                command.ExecuteNonQuery();
            }
        }
        public void UpdateRating(Item item)
        {
            using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
            {
                cnn.Open();
                var command = cnn.CreateCommand();

                command.CommandText = "UPDATE Filmy SET UserRating = @UserRating WHERE Title = @Title";

                var userRatingParam = command.CreateParameter();
                userRatingParam.ParameterName = "@UserRating";
                userRatingParam.Value = item.UserRating;
                command.Parameters.Add(userRatingParam);

                var titleParam = command.CreateParameter();
                titleParam.ParameterName = "@Title";
                titleParam.Value = item.Title;
                command.Parameters.Add(titleParam);

                command.ExecuteNonQuery();
            }
        }
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }

}
