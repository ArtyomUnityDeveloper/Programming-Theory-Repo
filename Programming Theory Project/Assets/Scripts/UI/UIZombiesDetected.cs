//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIZombiesDetected : MonoBehaviour
{
    public Text titleText;
    public Text[] dataText;
    public Text zombiesStrength;
    Player player;
    public PlayerParameters playerStatsSO;
    private int currentLocationZombiesStrenght;
    private string currentLocationName;
    private HostileLocation currentLocation;
    public UIWinPanel winUIReference;
    public UILosePanel loseUIReference;

    public static UIZombiesDetected ZombiesDetectedInstance;

    public interface IUIZombiesDetectedContent
    {
        string GetLocationTitle();
        string[] GetZombiesInfo();
        int GetStrength();

        HostileLocation GetLocation();
    }

    protected IUIZombiesDetectedContent m_DetectedContent;
    private IUIZombiesDetectedContent currentContent;


    private void Awake()
    {
        ZombiesDetectedInstance = this;
        gameObject.SetActive(false);
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnDestroy()
    {
        ZombiesDetectedInstance = null;
    }


    // проверь архиктуру-структуру кода, может метод лучше было назвать сет контент, как в UIMainScene по аналогии, а заполнение
    // панели вообще вынести в отдельный метод (абстракция), также как и очистку
    // важно: очищать detectedContent нужно нажатием кнопки Leave, также может понадобиться отбрасывание игрока на расстояние 
    // постройки, расстояние больше дистанции
    // в скрипте Player.cs сделай паблик метод LeaveLocation()
    // его функции: сначала указать грузовику цель куда отъехать m_Target == база, затем когда он отъехал
    // сделать m_Target == null чтобы не вызывалось меню каждый апдейт
    public void SetNewHostileLocation(IUIZombiesDetectedContent detectedContent)
    {
        FillUIZombiesDetectedPanel(detectedContent);
        currentContent = detectedContent;
        currentLocation = detectedContent.GetLocation();

    }

    private void FillUIZombiesDetectedPanel(IUIZombiesDetectedContent detectedContent)
    {
        gameObject.SetActive(true);
        currentLocationName = detectedContent.GetLocationTitle();
        titleText.text = $"At Location " + currentLocationName + " zombies detected:";

        string[] zombiesInfo = detectedContent.GetZombiesInfo();

        for (int i = 0; i < zombiesInfo.Length; i++)
        {
            dataText[i].text = zombiesInfo[i];
        }

        currentLocationZombiesStrenght = detectedContent.GetStrength();
        zombiesStrength.text = "    Summary zombies strenght: " + detectedContent.GetStrength().ToString();
    }

    public void FightButton()
    {
        Fight();
    }

    public void LeaveButton()
    {
        player.LeaveLocation();
        gameObject.SetActive(false); //  Потом нужно сделать ClearContent метод! По аналогии с UIMainScene!!!!
    }

    private void Fight()
    {
        if (playerStatsSO.AttackDamage > currentLocationZombiesStrenght)
        {
            //Debug.Log("You win!");
            currentLocation.KillZombies();
            FillUIZombiesDetectedPanel(currentContent); // somewhere here I must fix bug
            gameObject.SetActive(false);

            RewardPlayer();
        }
        else if (playerStatsSO.AttackDamage <= currentLocationZombiesStrenght)
        {
            //Debug.Log("Battle was lost...");
            gameObject.SetActive(false);
            player.LeaveLocation();

            HitPlayer(); 
        }
    }

    private void HitPlayer()
    {
        // calculate lost health and consolation prize exp
        int lostHealth = Random.Range(25, 75);
        int expPrize = 500;

        // pass values to PlayerStats scriptable object
        playerStatsSO.Health -= lostHealth;
        playerStatsSO.Experience += expPrize;

        // show lose UI
        loseUIReference.ShowLoseUI(currentLocationName, expPrize, lostHealth);
    }


    // ABSTRACTION
    private void RewardPlayer()
    {
        // calculate reward
        int experienceReward = currentLocationZombiesStrenght * 100;
        int attackDamageReward = 30;

        // reward player
        playerStatsSO.Experience += experienceReward;
        playerStatsSO.AttackDamage += attackDamageReward;

        // show win UI
        winUIReference.ShowWinUI(currentLocationName, experienceReward, attackDamageReward);
    }
}
