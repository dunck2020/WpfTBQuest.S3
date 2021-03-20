using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using System.Collections.ObjectModel;
using TBQuestGame.DataLayer;

namespace TBQuestGame.PresentationLayer
{
    public class GameSessionViewModel : ObservableObject
    {

        #region AREA VISIBILITY FIELDS AND PROPERTIES

        private bool _isVillageVisible;
        private bool _isMountainvisible;
        private bool _isForestVisible;
        private bool _isSwampVisible;
        private bool _isHarborVisible;
        private bool _isElfHoldVisible;
        private bool _isCaveVisible;
        private bool _isWitchesCampVisible;
        private bool _isIslandOfLostSoulsVisible;
        private bool _isAbyssVisible;
        private bool _isHomeVisible;

        public bool IsVillageVisible
        {
            get { return _isVillageVisible; }
            set
            {
                _isVillageVisible = value;
                OnPropertyChanged(nameof(IsVillageVisible));
            }

        }
        public bool IsMountainVisible
        {
            get { return _isMountainvisible; }
            set
            {
                _isMountainvisible = value;
                OnPropertyChanged(nameof(IsMountainVisible));
            }
        }
        public bool IsForestVisible
        {
            get { return _isForestVisible; }
            set
            {
                _isForestVisible = value;
                OnPropertyChanged(nameof(IsForestVisible));
            }
        }
        public bool IsSwampVisible
        {
            get { return _isSwampVisible; }
            set
            {
                _isSwampVisible = value;
                OnPropertyChanged(nameof(IsSwampVisible));
            }
        }
        public bool IsHarborVisible
        {
            get { return _isHarborVisible; }
            set
            {
                _isHarborVisible = value;
                OnPropertyChanged(nameof(IsHarborVisible));
            }
        }
        public bool IsElfHoldVisible
        {
            get { return _isElfHoldVisible; }
            set
            {
                _isElfHoldVisible = value;
                OnPropertyChanged(nameof(IsElfHoldVisible));
            }
        }
        public bool IsCaveVisible
        {
            get { return _isCaveVisible; }
            set
            {
                _isCaveVisible = value;
                OnPropertyChanged(nameof(IsCaveVisible));
            }
        }
        public bool IsWitchesCampVisible
        {
            get { return _isWitchesCampVisible; }
            set
            {
                _isWitchesCampVisible = value;
                OnPropertyChanged(nameof(IsWitchesCampVisible));
            }
        }
        public bool IsIslandOfLostSoulsVisible
        {
            get { return _isIslandOfLostSoulsVisible; }
            set
            {
                _isIslandOfLostSoulsVisible = value;
                OnPropertyChanged(nameof(IsIslandOfLostSoulsVisible));
            }
        }
        public bool IsAbyssVisible
        {
            get { return _isAbyssVisible; }
            set
            {
                _isAbyssVisible = value;
                OnPropertyChanged(nameof(IsAbyssVisible));
            }
        }
        public bool IsHomeVisible
        {
            get { return _isHomeVisible; }
            set
            {
                _isHomeVisible = value;
                OnPropertyChanged(nameof(IsHomeVisible));
            }
        }

        #endregion

        #region FIELDS

        private Player _player;
        private string _gameMessage;
        private Map _masterGameMap;
        private Location _currentLocation;
        private ObservableCollection<Location> _accessibleLocations;
        private string _currentLocationName;

        #endregion

        #region PROPERTIES

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }
        public string GameMessage
        {
            set 
            { 
                _gameMessage = value;
                OnPropertyChanged(nameof(GameMessage));
            }
            get
            {
                if (_player.NewPlayer)
                {
                    _gameMessage = GameData.DEFAULT_GAME_MESSAGE + "\n\n\n" + CurrentLocation.LocationMessage.ToString();
                }
                else
                {
                    _gameMessage = CurrentLocation.LocationMessage.ToString();
                }
                return _gameMessage; 
            }
        }
        public Map MasterGameMap
        {
            get { return _masterGameMap; }
            set { _masterGameMap = value; }
        }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
            }
            
        }
        public ObservableCollection<Location> AccessibleLocations
        {
            get { return _accessibleLocations; }
            set
            {
                _accessibleLocations = value;
                OnPropertyChanged(nameof(AccessibleLocations));
            }
        }
        public string CurrentLocationName
        {
            get { return _currentLocationName; }
            set 
            {
                _currentLocationName = value;
                OnPropertyChanged(nameof(CurrentLocationName));
            }
        }

        #endregion

        #region CONSTRUCTORS

        public GameSessionViewModel()
        {
        }

        public GameSessionViewModel(Player player, Map masterGameMap)
        {
            _player = player;
            _masterGameMap = masterGameMap;
            _currentLocation = _masterGameMap.CurrentLocation;
            _accessibleLocations = new ObservableCollection<Location>();
            
            UpdateAccessibleLocations();
            UpdateAreaMap();
            UpdateVisibleButtons();
        }

        #endregion

        #region METHODS

        public void PlayerAdvance(int areaID)
        {
            Player.NewPlayer = false;

            foreach (Location location in AccessibleLocations)
            {
                if (areaID == location.Id)
                {
                    CurrentLocation = location;
                    GameMessage = CurrentLocation.LocationMessage;
                }
            }

            ModifyPlayerLives();
            ModifyPlayerHealth();
            UpdateAreaMap();
            UpdateAccessibleLocations();
            UpdateVisibleButtons();
        }
        private void UpdateAreaMap()
        {
            switch (CurrentLocation.Id)
            {
                case 100:
                    foreach (Location location in _masterGameMap.Locations)
                    {
                        if (location.Id == 101 || location.Id == 102 || location.Id == 103 || location.Id == 104 || location.Id == 105)
                            location.IsAccessible = true;
                        else
                            location.IsAccessible = false;
                    }
                    break;
                case 101:
                    foreach (Location location in _masterGameMap.Locations)
                    {
                        if (location.Id == 201 || location.Id == 100)
                            location.IsAccessible = true;
                        else
                            location.IsAccessible = false;
                    }
                    break;
                case 201:
                    foreach (Location location in _masterGameMap.Locations)
                    {
                        if (location.Id == 101)
                            location.IsAccessible = true;
                        else
                            location.IsAccessible = false;
                    }
                    break;
                case 102:
                    foreach (Location location in _masterGameMap.Locations)
                    {
                        if (location.Id == 100 || location.Id == 202)
                            location.IsAccessible = true;
                        else
                            location.IsAccessible = false;
                    }
                    break;
                case 202:
                    foreach (Location location in _masterGameMap.Locations)
                    {
                        if (location.Id == 102)
                            location.IsAccessible = true;
                        else
                            location.IsAccessible = false;
                    }
                    break;
                case 105:
                    foreach (Location location in _masterGameMap.Locations)
                    {
                        if (location.Id == 300 || location.Id == 100)
                            location.IsAccessible = true;
                        else
                            location.IsAccessible = false;
                    }
                    break;
                case 300:
                    foreach (Location location in _masterGameMap.Locations)
                    {
                        if (location.Id == 105)
                            location.IsAccessible = true;
                        else
                            location.IsAccessible = false;
                    }
                    break;
                case 104:
                    foreach (Location location in _masterGameMap.Locations)
                    {
                        if (location.Id == 204 || location.Id == 100)
                            location.IsAccessible = true;
                        else
                            location.IsAccessible = false;
                    }
                    break;
                case 204:
                    foreach (Location location in _masterGameMap.Locations)
                    {
                        if (location.Id == 104)
                            location.IsAccessible = true;
                        else
                            location.IsAccessible = false;
                    }
                    break;
                case 103:
                    foreach (Location location in _masterGameMap.Locations)
                    {
                        if (location.Id == 100 || location.Id == 203)
                            location.IsAccessible = true;
                        else
                            location.IsAccessible = false;
                    }
                    break;
                case 203:
                    foreach (Location location in _masterGameMap.Locations)
                    {
                        if (location.Id == 103)
                            location.IsAccessible = true;
                        else
                            location.IsAccessible = false;
                    }
                    break;
            }
        }
        private void UpdateAccessibleLocations()
        {
            //start with no accessible locations
            _accessibleLocations.Clear();

            foreach (Location location in _masterGameMap.Locations)
            {
                if (location.IsAccessible)
                    _accessibleLocations.Add(location);

                if (location.Id == _currentLocation.Id)
                    _accessibleLocations.Remove(location);
            }
        }
        private void UpdateVisibleButtons()
        {
            foreach (Location location in _masterGameMap.Locations)
            {
                switch (location.Id)
                {
                    case 100:
                        IsVillageVisible = location.IsAccessible;
                        break;
                    case 101:
                        IsMountainVisible = location.IsAccessible;
                        break;
                    case 102:
                        IsForestVisible = location.IsAccessible;
                        break;
                    case 103:
                        IsSwampVisible = location.IsAccessible;
                        break;
                    case 104:
                        IsHarborVisible = location.IsAccessible;
                        break;
                    case 105:
                        IsAbyssVisible = location.IsAccessible;
                        break;
                    case 201:
                        IsCaveVisible = location.IsAccessible;
                        break;
                    case 202:
                        IsElfHoldVisible = location.IsAccessible;
                        break;
                    case 203:
                        IsWitchesCampVisible = location.IsAccessible;
                        break;
                    case 204:
                        IsIslandOfLostSoulsVisible = location.IsAccessible;
                        break;
                    case 300:
                        IsHomeVisible = location.IsAccessible;
                        break;

                }

            }
        }
        private void ModifyPlayerLives()
        {
            if (CurrentLocation.ModifyLives != 0)
            {
                Player.Lives += CurrentLocation.ModifyLives;
            }
        }
        private void ModifyPlayerHealth()
        {
            if (CurrentLocation.ModifyHealth != 0)
            {
                Player.Health += CurrentLocation.ModifyHealth;
            }
        }

        #endregion

    }
}
