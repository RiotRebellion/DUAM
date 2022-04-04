using DUAM.ViewModels.Base;
using DUAM.Models;
using DUAM.Data.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Text.RegularExpressions;
using DUAM.Infrastructure.Converters;
using System;
using System.ComponentModel;
using System.Windows.Data;
using DUAM.Infrastructure.Commands;

namespace DUAM.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region Properties

        #region UserCollectionView

        private CollectionViewSource _userSourceCollection;

        public ICollectionView UserSourceCollection
        {
            get => this._userSourceCollection.View;
        }

        #endregion

        #region ConnectionStatus
        private string _connectionStatus;

        public string ConnectionStatus
        {
            get => _connectionStatus;
            set => Set(ref _connectionStatus, value);
        }
        #endregion

        #region LastUpdateStatus

        private string _lastUpdateStatus;

        public string LastUpdateStatus
        {
            get => _lastUpdateStatus;
            set => Set(ref _lastUpdateStatus, value);
        }

        #endregion

        #endregion

        public MainWindowViewModel(IRepository<User> userRepository)
        { 
            LastUpdateStatus = $"Обновленно {DateTime.Now}";

            #region UserSourceCollection

            _userSourceCollection = new CollectionViewSource();
            _userSourceCollection.Source = new ObservableCollection<UserDTO>(UserDTO.GetUsers(userRepository.Items));

            #endregion

            #region ConnectionCheck

            ConnectionStatus = ConnectionCheck(userRepository);

            #endregion
        }

        private string ConnectionCheck(IRepository<User> repository) => repository.GetConnectionState()
            ? "Подключено к БД"
            : "Нет подключения к БД";
    }
}
