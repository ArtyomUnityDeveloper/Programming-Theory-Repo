using System;
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
    private HostileLocation currentLocation;

    public static UIZombiesDetected ZombiesDetectedInstance { get; private set; }

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


    // ������� ���������-��������� ����, ����� ����� ����� ���� ������� ��� �������, ��� � UIMainScene �� ��������, � ����������
    // ������ ������ ������� � ��������� ����� (����������), ����� ��� � �������
    // �����: ������� detectedContent ����� �������� ������ Leave, ����� ����� ������������ ������������ ������ �� ���������� 
    // ���������, ���������� ������ ���������
    // � ������� Player.cs ������ ������ ����� LeaveLocation()
    // ��� �������: ������� ������� ��������� ���� ���� �������� m_Target == ����, ����� ����� �� �������
    // ������� m_Target == null ����� �� ���������� ���� ������ ������
    public void SetNewHostileLocation(IUIZombiesDetectedContent detectedContent)
    {
        FillUIZombiesDetectedPanel(detectedContent);
        currentContent = detectedContent;
        currentLocation = detectedContent.GetLocation();

    }

    private void FillUIZombiesDetectedPanel(IUIZombiesDetectedContent detectedContent)
    {
        gameObject.SetActive(true);
        titleText.text = detectedContent.GetLocationTitle();

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
        gameObject.SetActive(false); //  ����� ����� ������� ClearContent �����! �� �������� � UIMainScene!!!!
    }

    private void Fight()
    {
        if (playerStatsSO.AttackDamage > currentLocationZombiesStrenght)
        {
            Debug.Log("You win!");
            currentLocation.KillZombies();
            FillUIZombiesDetectedPanel(currentContent);
            gameObject.SetActive(false);
            player.LeaveLocation();

            RewardPlayer();
        }
        else if (playerStatsSO.AttackDamage <= currentLocationZombiesStrenght)
        {
            Debug.Log("Battle was lost...");
        }
    }

    private void RewardPlayer()
    {
        throw new NotImplementedException(); // ���� ������ ���� � ���� �����
    }
}
