using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWinPanel : MonoBehaviour
{
    public Text locationNameTitle;
    public Text expReceivedText;
    public Text adReceivedText;


    private void Awake()
    {
        gameObject.SetActive(false);
    }


    public void ShowWinUI(string locationName, int expReward, int adReward)
    {
        locationNameTitle.text = locationName;
        expReceivedText.text = "You received experience: " + expReward.ToString();
        adReceivedText.text = "Found equipment increases your attack damage: " + adReward.ToString();
        gameObject.SetActive(true);
    }

    public void CloseAndContinue()
    {
        gameObject.SetActive(false);
    }
}
