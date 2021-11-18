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

    [TextArea]
    [SerializeField] private string locationDescription;

    [Header("3 zombies with strength 2, 4 zombies with strength 1, etc...")]
    public int[] amountOfZombies;
    public int[] strengthOfZombies;

    private void Start()
    {
        int i = 0;
        foreach (ResourceItem item in items)
        {
            AddItem(item.Id, numberOfItems[i]);
            i++;
        }
    }

    /* private float m_ProductionSpeed = 0.5f; // private backing field
     public float ProductionSpeed // public property
     {
         get { return m_ProductionSpeed; } // getter returns backing field
         set
         {
             {
                 if (value < 0.0f)
                 {

                     Debug.LogError("You can't set a negative production speed!");
                 }
                 else
                 {
                     m_ProductionSpeed = value; // original setter now in if/else statement
                 }
             }
         } // setter uses backing field
     }

     private float m_CurrentProduction = 0.0f;

     private void Update()
     {
         if (m_CurrentProduction > 1.0f)
         {
             int amountToAdd = Mathf.FloorToInt(m_CurrentProduction);
             int leftOver = AddItem(Item.Id, amountToAdd);

             m_CurrentProduction = m_CurrentProduction - amountToAdd + leftOver;
         }

         if (m_CurrentProduction < 1.0f)
         {
             m_CurrentProduction += m_ProductionSpeed * Time.deltaTime;
         }
     } */

    public override string GetData()
    {
        //return $"Producing at the speed of {m_ProductionSpeed}/s";
        return locationDescription;
    }
}
