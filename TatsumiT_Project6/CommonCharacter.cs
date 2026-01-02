using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TatsumiT_Project6
{
    internal abstract class CommonCharacter
    {
        /*  shared data
         *      name
         *      health
         *      speed
         *      strength
         *      random
         *      
         *      
         * 
         */
        
        protected string name;
        protected int health;
        protected int speed;
        protected int strength;
        protected int level;
        protected Random rng;
        protected bool abilityUsed;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name">name of the character</param>
        /// <param name="health">health of the character</param>
        /// <param name="speed">speed of the character(determines which character will attack first)</param>
        /// <param name="level">level of the character(gives attack bonus)</param>
        /// <param name="strength">default attack param.</param>
        public CommonCharacter(string name, int health, int speed, int level, int strength)
        {
            this.name = name;
            this.health = health;
            this.speed = speed;
            this.strength = strength;
            this.level = level;
            abilityUsed = false;
            rng = new Random();
        }

        /// <summary>
        /// read only return name
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// read only return health
        /// </summary>
        public int Health
        {
            get { return health; }
        }

        /// <summary>
        /// read only return speed
        /// </summary>
        public int Speed
        {
            get { return speed; }
        }

        /// <summary>
        /// read only return level
        /// </summary>
        public int Level
        {
            get { return level; }
        }

        /// <summary>
        /// read only return strength
        /// </summary>
        public int Strength
        {
            get { return strength; }
        }

        /// <summary>
        /// read only return if the character is dead or not
        /// </summary>
        public bool IsDead
        {
            get { return health <= 0; }
        }

        /// <summary>
        /// read only return if character used ability
        /// </summary>
        public bool AbilityUsed
        {
            get { return abilityUsed; }
        }

        /// <summary>
        /// base attack will be 80 to 120% of the strength, and then add level bonus
        /// </summary>
        /// <returns>returns the amount of damage </returns>
        public virtual int Attack()
        {
            int baseAttack = (int)(strength*(rng.Next(8,13)/10.0));
            int finalAttack = baseAttack + rng.Next(1, level + 1);
            return finalAttack;
        }

        /// <summary>
        /// check if damage is not negative, and if damage is greater or equal to health, make health 0,
        /// else, subtract damage from health and return
        /// </summary>
        /// <param name="amountOfDamage">damage amount</param>
        /// <returns>amount of damaage dealt</returns>
        public virtual int TakeDamage(int amountOfDamage)
        {
            if (amountOfDamage < 0)
            {
                amountOfDamage = 0;
            }
            else if (amountOfDamage >= health)
            {
                amountOfDamage = health;
                health = 0;

            }
            else
            {
                health -= amountOfDamage;
            }
            return amountOfDamage;
        }

        public abstract bool ReadyToFlee();

        /// <summary>
        /// status of character
        /// </summary>
        /// <returns>string of status of the character</returns>
        public override string ToString()
        {
            return $"name: {name} | level: {level} | health: {health} | strength: {strength} | speed: {speed}";
        }
    }
}
