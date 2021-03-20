using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using System.Collections.ObjectModel;
using TBQuestGame.DataLayer;
using System.Windows;

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
        private GameItem _currentGameItem;

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
        public GameItem CurrentGameItem
        {
            get { return _currentGameItem; }
            set { _currentGameItem = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public GameSessionViewModel() {} //Default Constructor
        public GameSessionViewModel(Player player, Map masterGameMap)
        {
            _player = player;
            _masterGameMap = masterGameMap;
            InitializeView();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// game start up methods
        /// </summary>
        private void InitializeView()
        {
            _currentLocation = _masterGameMap.CurrentLocation;
            _accessibleLocations = new ObservableCollection<Location>();
            UpdateAccessibleLocations();
            UpdateVisibleButtons();
            _player.InventoryUpdate();
            _player.CalculateWealth();
            UpdateAccessibleGameItems();
        }
        /// <summary>
        /// fires when a player clicks on a map area button
        /// </summary>
        /// <param name="areaID"></param>
        public void PlayerAdvance(int areaID)
        {
            Player.NewPlayer = false;

            foreach (Location location in _masterGameMap.Locations)
            {
                if (areaID == location.Id)
                {
                    CurrentLocation = location;
                    GameMessage = CurrentLocation.LocationMessage;
                }
            }

            ModifyPlayerLives();
            ModifyPlayerHealth();
            UpdateAccessibleLocations();
            UpdateVisibleButtons();
        }
        /// <summary>
        /// updates areas that are accessible from current area
        /// </summary>
        private void UpdateAccessibleLocations()
        {
            //clear accessible locations
            _accessibleLocations.Clear();

            //start with no accessible locations
            foreach (Location location in _masterGameMap.Locations)
            {
                location.IsAccessible = false;
            }


            //update available locations based on current location
            foreach (int locationId in CurrentLocation.CurrentAvailableLocations)
            {
                foreach (Location location in _masterGameMap.Locations)
                {
                    if (location.Id == locationId)
                    {
                        location.IsAccessible = true;
                        _accessibleLocations.Add(location);
                    }
                }
            }
        }
        /// <summary>
        /// updates items that area available in certain areas
        /// </summary>
        private void UpdateAccessibleGameItems()
        {
            foreach (Location location in _masterGameMap.Locations)
            {
                for (int i = 0; i < location.GameItems.Count; i++)
                {
                    GameItem gameItem = location.GameItems[i];
                    if (!gameItem.IsAvailable)
                    {
                        location.RemoveGameItemFromLocation(gameItem);
                    }
                }
                    
            }
        }
        /// <summary>
        /// only areas that area accessible will show their buttons
        /// </summary>
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

        /// <summary>
        /// areas that modify player lives use this method when movement occurs
        /// </summary>
        private void ModifyPlayerLives()
        {
            if (CurrentLocation.ModifyLives != 0)
            {
                _player.Lives += CurrentLocation.ModifyLives;
            }
        }
        /// <summary>
        /// areas that modify player health use this method when movement occurs
        /// </summary>
        private void ModifyPlayerHealth()
        {
            if (CurrentLocation.ModifyHealth != 0)
            {
                _player.Health += CurrentLocation.ModifyHealth;
            }
        }
        /// <summary>
        /// removes game item from location and adds to player inventory
        /// </summary>
        public void AddItemToInventory()
        {

            if (_currentGameItem != null && _currentLocation.GameItems.Contains(_currentGameItem))
            {
                GameItem selectedGameItem = _currentGameItem as GameItem;

                //removes from location and adds to player inventory
                _currentLocation.RemoveGameItemFromLocation(selectedGameItem);
                _player.AddGameItemToInventory(selectedGameItem);

                OnPlayerPickUp(selectedGameItem);
            }
        }
        /// <summary>
        /// removes inventory from player and adds to location
        /// </summary>
        public void RemoveItemFromInventory()
        {

            if (_currentGameItem != null)
            {
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentLocation.AddGameItemToLocation(selectedGameItem);
                _player.RemoveGameItemFromInventory(selectedGameItem);

                OnPlayerPutDown(selectedGameItem);
            }
        }
        /// <summary>
        /// adds any gameitem value to player
        /// </summary>
        /// <param name="gameItem"></param>
        private void OnPlayerPickUp(GameItem gameItem)
        {
            _player.Wealth += gameItem.Value;
        }
        /// <summary>
        /// removes value of game item and if currently selected weapon removes attack points
        /// </summary>
        /// <param name="gameItem"></param>
        private void OnPlayerPutDown(GameItem gameItem)
        {
            if (gameItem is Weapon)
            {
                Weapon weapon = (Weapon)gameItem;
                if (_player.AttackPoints == weapon.AttackPoints)
                {
                    _player.AttackPoints = 0;
                }
            }
            _player.Wealth -= gameItem.Value;
        }
        /// <summary>
        /// switch statement to process different game items
        /// </summary>
        public void OnUseGameItem()
        {
            switch (_currentGameItem)
            {
                case Spell spell:
                    ProcessSpellUse(spell);
                    break;
                case Artifact artifact:
                    ProcessArtifacUse(artifact);
                    break;
                case Weapon weapon:
                    ProcessWeaponUse(weapon);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// using a weapon 'arms' the player with the weapon
        /// </summary>
        /// <param name="weapon"></param>
        private void ProcessWeaponUse(Weapon weapon)
        {
            _player.AttackPoints = weapon.AttackPoints;
        }
        /// <summary>
        /// based on artifact use action switch statement to process different use actions
        /// </summary>
        /// <param name="artifact"></param>
        private void ProcessArtifacUse(Artifact artifact)
        {
            switch (artifact.UseAction)
            {
                case Artifact.UseActionType.KILL_PLAYER:
                    _player.Lives--;
                    OnPlayerDies(artifact.UseMessage);
                    break;
                case Artifact.UseActionType.OPEN_LOCATION:
                    PlayerAdvance(100);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// based on spell use action switch statement to process different use actions
        /// </summary>
        /// <param name="spell"></param>
        private void ProcessSpellUse(Spell spell)
        {
            _player.Health += spell.HealthChange;
            _player.Lives += spell.LivesChange;
            _player.RemoveGameItemFromInventory(_currentGameItem);
        }

        /// <summary>
        /// process message box when player dies
        /// </summary>
        /// <param name="message"></param>
        private void OnPlayerDies(string message = "")
        {
            if (_player.Lives == 0)
            {
                string messagetext = message + $"\n\nYOU DIED! You have {_player.Lives} lives remaining. \n\n Play Again?";

                string titleText = "Death";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxResult result = MessageBox.Show(messagetext, titleText, button);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        Environment.Exit(0);
                        break;
                    case MessageBoxResult.No:
                        Environment.Exit(0);
                        break;
                }
            }
            else
            {
                string messageText = message + $"\n\nYOU DIED! You have {_player.Lives} lives remaining.  You will start in the Village!";
                string titleText = "Death";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBox.Show(messageText, titleText, button);
                PlayerAdvance(100);

            }



        }

        #endregion

    }
}
