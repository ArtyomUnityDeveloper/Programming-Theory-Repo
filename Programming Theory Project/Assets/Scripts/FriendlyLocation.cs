using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A special building that hold a static reference so it can be found by other script easily (e.g. for Unit to go back
/// to it). Also it can autoheal the player. And it will contain quest checking code.
/// </summary>


// INHERITANCE EXAMPLE
public class FriendlyLocation : Location
{
    public static FriendlyLocation Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}
