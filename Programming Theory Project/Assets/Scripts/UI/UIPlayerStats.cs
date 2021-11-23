using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerStats : MonoBehaviour
{
    public PlayerParameters playerStatsSO;
    public Text currentLevel;
    public Text expToNextLevel;
    public Text playerHp;
    public Text playerAttackDamage;


    // Start is called before the first frame update
    void Start()
    {
        // Initial player stats on new game session
        playerStatsSO.Experience = 1050;
        playerStatsSO.Health = 100;
        playerStatsSO.AttackDamage = 10; //20 is basic value
    }

    // Update is called once per frame
    void Update()
    {
        // Keys for test purposes
        if (Input.GetKeyDown("f"))
        {
            StartCoroutine("AddExp");
        }

        if (Input.GetKeyDown("g"))
        {
            StartCoroutine("HitPlayer");
        }

        if (Input.GetKeyDown("h"))
        {
            StartCoroutine("HealPlayer");
        }

        if (Input.GetKeyDown("j"))
        {
            StartCoroutine("IncreaseAD");
        }

        currentLevel.text = playerStatsSO.Level.ToString();
        expToNextLevel.text = playerStatsSO.ExpToNextLvl.ToString();
        playerHp.text = playerStatsSO.Health.ToString();
        playerAttackDamage.text = playerStatsSO.AttackDamage.ToString();
    }


    // Coroutines for test purposes
    IEnumerator AddExp()
    {
        playerStatsSO.Experience += 200; 
        yield return new WaitForSeconds(1f);
    }

    IEnumerator HitPlayer()
    {
        playerStatsSO.Health += (-5);
        yield return new WaitForSeconds(1f);
    }

    IEnumerator HealPlayer()
    {
        playerStatsSO.Health += (20);
        yield return new WaitForSeconds(1f);
    }

    IEnumerator IncreaseAD()
    {
        playerStatsSO.AttackDamage += (1);
        yield return new WaitForSeconds(1f);
    }
}
