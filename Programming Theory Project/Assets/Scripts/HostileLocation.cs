using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A subclass of Location that have resources and zombies.
/// </summary>


// INHERITANCE EXAMPLE
public class HostileLocation : Location, 
    UIZombiesDetected.IUIZombiesDetectedContent
{
    [Header ("Resources Info")]
    public ResourceItem[] items;
    public int[] numberOfItems;



    [Header("3 zombies with strength 2, 4 zombies with strength 1, etc...")]
    public int[] amountOfZombies;
    [Tooltip("Best array size is 3 because of code peculiarities")]
    public int[] strengthOfZombies;

    [Tooltip("Set array size is 5 because of code peculiarities")]
    public string[] zombiesInfo;

    // ENCAPSULATION
    public int totalStrength { get; private set; }
    public int experienceForWin { get; private set; }


    private void Start()
    {
        FillHostileLocationInventory();
        FillZombiesInfo();
        CalculateStrength();
        CalculateExperienceForWin();
    }

    private void CalculateExperienceForWin()
    {
        for (int i = 0; i < amountOfZombies.Length; i++)
        {
            experienceForWin += amountOfZombies[i] * strengthOfZombies[i] * 100;
        }
    }

    public override bool IsZombiesHere()
    {

        if (amountOfZombies.Length > 1 && strengthOfZombies.Length > 1)
        {
            //Debug.Log("Zombies is here");
            var uiZdInfo = gameObject.GetComponentInChildren<UIZombiesDetected.IUIZombiesDetectedContent>();
            UIZombiesDetected.ZombiesDetectedInstance.SetNewHostileLocation(uiZdInfo);
            return true;
        }
        else if (amountOfZombies.Length > 0 && strengthOfZombies.Length == 0)
        {
            Debug.LogError("Set zombies strength");
            return false;
        }
        else if (amountOfZombies.Length == 0 && strengthOfZombies.Length > 0)
        {
            Debug.LogError("Set amount of zombies");
            return false;
        }
        else if (amountOfZombies.Length <= 1 && strengthOfZombies.Length <= 1)
        {
            return false;
        }
        else
        {
            return false;
        }
    }


    // ABSTRACTION
    private void FillZombiesInfo()
    {
        for (int i = 0; i < amountOfZombies.Length; i++)
        {
            zombiesInfo[i] = amountOfZombies[i] + " zombies with strength " + strengthOfZombies[i];
        }
    }


    private void CalculateStrength()
    {
        for (int i = 0; i < amountOfZombies.Length; i++)
        {
            totalStrength += amountOfZombies[i] * strengthOfZombies[i];
        }
    }


    // ABSTRACTION
    private void FillHostileLocationInventory()
    {
        int i = 0;
        foreach (ResourceItem item in items)
        {
            AddItem(item.Id, numberOfItems[i]);
            i++;
        }
    }

    // POLYMORPHISM
    public override string GetData()
    {
        return locationDescription;
    }

    public string GetLocationTitle()
    {
        return gameObject.name;
        //return $"At Location " + gameObject.name + " zombies detected:";
    }

    public string[] GetZombiesInfo()
    {
        return zombiesInfo;
    }

    public int GetStrength()
    {
        return totalStrength;
    }

    public HostileLocation GetLocation()
    {
        return this;
    }

    public void KillZombies()
    {
        amountOfZombies = new int[] { 0 };
        strengthOfZombies = new int[] { 0 };
    }
}

