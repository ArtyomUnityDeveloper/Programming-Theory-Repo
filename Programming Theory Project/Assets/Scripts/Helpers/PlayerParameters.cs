using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerParameters", menuName = "Additionals/Player Parameters")]
public class PlayerParameters : ScriptableObject
{
    // ENCAPSULATION - used in this Scriptable Object
    [SerializeField] private int experience = 1; // field
    public int Experience   // property
    {
        get
        {
            return experience; 
        }
        set
        {
            if (value > 0)
            {
                int currentLevel = experience / 1000;
                experience = value;  // method which can increase exp will be in Player class
                Level = experience / 1000;
                if (currentLevel < Level) // Increase AD every new LVL
                {
                    AttackDamage = AttackDamage + 1;
                }
            }
            else
            {
                Debug.LogError("You can't subtract experience!");  // protection from exp substraction
            }
        }
    }


    public int Level { get; private set; }


    public int ExpToNextLvl
    {
        get
        {
            int expForNextLvl = (Level + 1) * 1000;
            return ExpToNextLvl = expForNextLvl - Experience;
        }
        private set { }
    }


    private int health = 100;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            if (health > 100)
            {
                health = 100;
            }
            else if (health < 0)
            {
                health = 0;
            }
            else
            {
                health = value;
            }

        }
    }


    private int attackDamage = 20;
    public int AttackDamage
    {
        get
        {
            return attackDamage;
        }
        set
        {
            if (value > 0)
            {
                attackDamage = value;  // method which can increase exp will be in Player class
            }
            else
            {
                Debug.LogError("You can't subtract attackDamage!");  // protection from exp substraction
            }
        }
    }


}
