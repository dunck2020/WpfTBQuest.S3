using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQuestGame.Models
{
    public class Map
    {
        #region FIELDS

        private List<Location> _locations;
        private Location _currentLocation;
        //private ObservableCollection<Location> _accessibleLocation;

        #endregion

        #region PROPERTIES

        public List<Location> Locations
        {
            get { return _locations; }
            set { _locations = value; }
        }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set { _currentLocation = value; }
        }
        //public ObservableCollection<Location> AccessibleLocation
        //{
        //    get { return _accessibleLocation; }
        //    set { _accessibleLocation = value; }
        //}

        #endregion

        #region CONSTRUCTORS
        public Map()
        {
            _locations = new List<Location>();
        }

        #endregion

        #region METHODS


        #endregion

    }
}
