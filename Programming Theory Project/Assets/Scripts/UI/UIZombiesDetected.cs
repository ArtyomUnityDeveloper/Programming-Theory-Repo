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


    // проверь архиктуру-структуру кода, может метод лучше было назвать сет контент, как в UIMainScene по аналогии, а заполнение
    // панели вообще вынести в отдельный метод (абстракция), также как и очистку
    // важно: очищать detectedContent нужно нажатием кнопки Leave, также может понадобиться отбрасывание игрока на расстояние 
    // постройки, расстояние больше дистанции
    // в скрипте Player.cs сделай паблик метод ClearTargetAndOut 
    // его функции: сначала указать грузовику цель куда отъехать, затем когда он отъехал
    // сделать m_Target == null чтобы не вызывалось меню каждый апдейт
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
        gameObject.SetActive(false); // РАБОТАТЬ ТАКОЕ НЕ БУДЕТ! Нужно сделать ClearContent метод! По аналогии с UIMainScene!!!!
    }

    private void Fight()
    {
        throw new NotImplementedException();
    }
}
