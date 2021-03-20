using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Weapon : GameItem
    {

        public bool Bindable { get; set; }
        public int AttackPoints { get; set; }
        public int TimesCanUse { get; set; }
        public double EnemyHitsPerUse { get; set; }

        public Weapon(int id, string name, int value, string description, string useMessage, bool bindable, int attackPoints, int timesCanUse, double enemyHitsPerUse, bool isAvailable) :
            base (id, name, value, description, useMessage, isAvailable)
        {
            Bindable = bindable;
            AttackPoints = attackPoints;
            TimesCanUse = timesCanUse;
            EnemyHitsPerUse = enemyHitsPerUse;
            IsAvailable = isAvailable;
        }
        public override string InformationString()
        {
            return $"{Name}: {Description} \nAttack Points: {AttackPoints}";
        }
    }
}
