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

    public static UIZombiesDetected ZombiesDetectedInstance { get; private set; }

    public interface IUIZombiesDetectedContent
    {
        string GetLocationTitle();
        string[] GetZombiesInfo();
        int GetStrength();
    }

    protected IUIZombiesDetectedContent m_DetectedContent;


    private void Awake()
    {
        ZombiesDetectedInstance = this;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        ZombiesDetectedInstance = null;
    }


    // ������� ���������-��������� ����, ����� ����� ����� ���� ������� ��� �������, ��� � UIMainScene �� ��������, � ����������
    // ������ ������ ������� � ��������� ����� (����������), ����� ��� � �������
    // �����: ������� detectedContent ����� �������� ������ Leave, ����� ����� ������������ ������������ ������ �� ���������� 
    // ���������, ���������� ������ ���������
    // � ������� Player.cs ������ ������ ����� ClearTargetAndOut 
    // ��� �������: ������� ������� ��������� ���� ���� ��������, ����� ����� �� �������
    // ������� m_Target == null ����� �� ���������� ���� ������ ������
    public void ZombiesDetectedPanelFill(IUIZombiesDetectedContent detectedContent)
    {
        gameObject.SetActive(true);
        titleText.text = detectedContent.GetLocationTitle();

        string[] zombiesInfo = detectedContent.GetZombiesInfo();

        for (int i = 0; i < zombiesInfo.Length; i++)
        {
            dataText[i].text = zombiesInfo[i];
        }

        zombiesStrength.text = "    Summary zombies strenght: " + detectedContent.GetStrength().ToString();

    }


    public void FightButton()
    {
        Fight();
    }

    public void LeaveButton()
    {
        gameObject.SetActive(false); // �������� ����� �� �����! ����� ������� ClearContent �����! �� �������� � UIMainScene!!!!
    }

    private void Fight()
    {
        throw new NotImplementedException();
    }
}
