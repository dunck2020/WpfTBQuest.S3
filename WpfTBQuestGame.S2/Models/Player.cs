using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Player : Character
    {
        #region ENUMS
        public enum BattleRankLevel
        {
            BlackBelt,
            SwordsMan,
            Master,
            DeathDealer
        }

        #endregion

        #region FIELDS

        private bool _newPlayer;
        private int _lives;
        private int _battleXP;
        private int _health;
        private BattleRankLevel _battleRank;
        private List<Location> _locationsVisited;

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
        public int BattleXP
        {
            get { return _battleXP; }
            set { _battleXP = value; }
        }
        public int Health
        {
            get { return _health; }
            set 
            { 
                _health = value;
                OnPropertyChanged(nameof(Health));
            }
        }
        public BattleRankLevel BattleRank
        {
            get { return _battleRank; }
            set { _battleRank = value; }
        }
        public List<Location> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }
        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            _locationsVisited = new List<Location>();
        }

        public Player(
            int id, 
            string name, 
            int location, 
            Genus kind, 
            int lives, 
            int battleXP, 
            int health, 
            BattleRankLevel battleRank, 
            bool newPLayer)
            : base(id, name, location, kind)
        {
            _lives = lives;
            _battleXP = battleXP;
            _health = health;
            _battleRank = battleRank;
            _newPlayer = newPLayer;
        }

        #endregion

        #region METHODS


        #endregion

    }
}
