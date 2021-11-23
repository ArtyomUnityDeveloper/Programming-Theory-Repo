using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILosePanel : MonoBehaviour
{
    public Text locationNameTitle;
    public Text expReceivedText;
    public Text hpLostText;


    private void Awake()
    {
        gameObject.SetActive(false);
    }


    public void ShowLoseUI(string locationName, int expReward, int hpLost)
    {
        locationNameTitle.text = locationName;
        expReceivedText.text = "You have learned valuable experience from your defeat: " + expReward.ToString();
        hpLostText.text = "You lost health points: " + hpLost.ToString();
        gameObject.SetActive(true);
    }

    public void CloseAndContinue()
    {
        gameObject.SetActive(false);
    }
}
