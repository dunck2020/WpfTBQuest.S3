using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Player : Character
    {
        #region ENUMS

        #endregion

        #region FIELDS

        private bool _newPlayer;
        private int _lives;
        private int _attackPoints;
        private int _health;
        private int _wealth;

        private List<Location> _locationsVisited;

        private ObservableCollection<GameItem> _inventory;
        private ObservableCollection<GameItem> _artifacts;
        private ObservableCollection<GameItem> _weapons;
        private ObservableCollection<GameItem> _spells;
        private ObservableCollection<GameItem> _treasure;

        #endregion

        #region PROPERTIES

        public bool NewPlayer
        {
            get { return _newPlayer; }
            set { _newPlayer = value; }
        }
        public int Lives
        {
            get { return _lives; }
            set 
            {    
                _lives = value;
                OnPropertyChanged(nameof(Lives));   
            }
        }
        public int AttackPoints
        {
            get 
            { 
                return _attackPoints; 
            }
            set 
            { 
                _attackPoints = value;
                OnPropertyChanged(nameof(AttackPoints));
            }
        }
        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;

                if (_health > 100)
                {
                    _health = 100;
                    _lives++;
                }
                else if (_health <= 0)
                {
                    _health = 100;
                    _lives--;
                }

                OnPropertyChanged(nameof(Health));
            }
        }

        public List<Location> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }        
        
        public ObservableCollection<GameItem> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
        public ObservableCollection<GameItem> Artifacts
        {
            get { return _artifacts; }
            set { _artifacts = value; }
        }
        public ObservableCollection<GameItem> Weapons
        {
            get { return _weapons; }
            set { _weapons = value; }
        }
        public ObservableCollection<GameItem> Spells
        {
            get { return _spells; }
            set { _spells = value; }
        }        
        public ObservableCollection<GameItem> Treasure
        {
            get { return _treasure; }
            set { _treasure = value; }
        }
        public int Wealth
        {
            get { return _wealth; }
            set
            {
                _wealth = value;
                OnPropertyChanged(nameof(Wealth));
            }
        }

        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            _locationsVisited = new List<Location>();

            _weapons = new ObservableCollection<GameItem>();
            _treasure = new ObservableCollection<GameItem>();
            _artifacts = new ObservableCollection<GameItem>();
            _spells = new ObservableCollection<GameItem>();
        }

        public Player(int id, string name, int location, Genus kind, int lives, int attackPoints, int health, bool newPLayer)
            : base(id, name, location, kind)
        {
            _lives = lives;
            _attackPoints = attackPoints;
            _health = health;
            _newPlayer = newPLayer;

        }

        #endregion

        #region METHODS
        public void CalculateWealth()
        {
            Wealth = _inventory.Sum(i => i.Value);
        }

        public void InventoryUpdate()
        {
            Weapons.Clear();
            Artifacts.Clear();
            Spells.Clear();
            Treasure.Clear();


            foreach (var gameItem in _inventory)
            {
                if (gameItem is Weapon) Weapons.Add(gameItem); //1000
                if (gameItem is Artifact) Artifacts.Add(gameItem); //2000
                if (gameItem is Spell) Spells.Add(gameItem); //3000
                if (gameItem is Treasure) Treasure.Add(gameItem); //4000
                
            }
        }

        public void AddGameItemToInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _inventory.Add(selectedGameItem);
            }
            InventoryUpdate();
        }

        public void RemoveGameItemFromInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _inventory.Remove(selectedGameItem);
            }
            InventoryUpdate();
        }
        #endregion

    }
}
