using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.PresentationLayer;

namespace TBQuestGame.Models
{
    public class Location
    {
        #region FIELDS

        private int _id;
        private string _name;
        private string _description;
        private bool _isAccessible;
        private string _locationMessage;
        private int _modifyLives;
        private int _modifyHealth;
        private List<Location> _currentAvailableLocations;

        #endregion

        #region PROPERTIES

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public bool IsAccessible
        {
            get { return _isAccessible; }
            set { _isAccessible = value; }
        }
        public string LocationMessage
        {
            get 
            {   
                return _locationMessage; 
            }
            set 
            { 
                _locationMessage = value; 
            }
        }
        public int ModifyLives
        {
            get { return _modifyLives; }
            set { _modifyLives = value; }
        }
        public int ModifyHealth
        {
            get { return _modifyHealth; }
            set { _modifyHealth = value; }
        }
        public List<Location> CurrentAvailableLocations
        {
            get { return _currentAvailableLocations; }
            set { _currentAvailableLocations = value; }
        }

        #endregion
    }
}
