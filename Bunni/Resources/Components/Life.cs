using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunni.Resources.Modules;

namespace Bunni.Resources.Components
{
    public class Life : Component
    {

        private double _health = 100.0;
        public double Health
        {
            get
            {
                return _health;
            }
            set
            {
                if (value >= MaxHealth)
                {
                    _health = MaxHealth;
                    IsAlive = true;
                }
                else if (value > MinHealth)
                {
                    _health = value;
                    IsAlive = true;
                }
                else if (value <= MinHealth)
                {
                    _health = MinHealth;
                    IsAlive = false;
                }
            }
        }
        public double MinHealth { get; set; } = 0.0;
        public double MaxHealth { get; set; } = 100.0;
        public bool IsAlive { get; set; } = true;

        public Life() { }

        /// <summary>
        /// Creates life property and changes starting MaxHealth
        /// </summary>
        /// <param name="_parent"></param>
        /// <param name="_maxHealth"></param>
        public Life(double _maxHealth)
        {
            MaxHealth = _maxHealth;
            Health = _maxHealth;
        }

        /// <summary>
        /// Creates life property and changes starting MaxHealth and MinHealth
        /// </summary>
        /// <param name="_parent"></param>
        /// <param name="_maxHealth"></param>
        /// <param name="_minHealth"></param>
        public Life(double _maxHealth, double _minHealth)
        {
            MaxHealth = _maxHealth;
            MinHealth = _minHealth;
            Health = _maxHealth;
        }

        /// <summary>
        /// Creates life property and changes starting Maxhealth, Minhealth, and Health
        /// </summary>
        /// <param name="_parent"></param>
        /// <param name="_maxHealth"></param>
        /// <param name="_minHealth"></param>
        /// <param name="_health"></param>
        public Life(double _maxHealth, double _minHealth, double _health)
        {
            MaxHealth = _maxHealth;
            MinHealth = _minHealth;
            Health = _health;
        }

        /// <summary>
        /// Damanges the Entity. Health cannot go below
        /// </summary>
        /// <param name="_damage"></param>
        /// <returns></returns>
        public double Damage(double _damage)
        {
            Health -= _damage;
            return Health;
        }
        /// <summary>
        /// Heals the Entity. Health cannot go above max health.
        /// </summary>
        /// <param name="_heal"></param>
        /// <returns></returns>
        public double Heal(double _heal)
        {
            Health += _heal;
            return Health;
        }

        /// <summary>
        /// Checks to see if entity has max health.
        /// </summary>
        /// <returns></returns>
        public bool HasMaxHealth()
        {
            if(Health == MaxHealth)
            {
                return true;
            }else
            {
                return false;
            }
        }


    }
}
