using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A subclass of Location that have resources and zombies.
/// </summary>


// INHERITANCE EXAMPLE
public class HostileLocation : Location
{
    [Header ("Resources Info")]
    public ResourceItem[] items;
    public int[] numberOfItems;



    [Header("3 zombies with strength 2, 4 zombies with strength 1, etc...")]
    public int[] amountOfZombies;
    public int[] strengthOfZombies;

    private void Start()
    {
        FillHostileLocationInventory();
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

    public override string GetData()
    {
        return locationDescription;
    }
}
