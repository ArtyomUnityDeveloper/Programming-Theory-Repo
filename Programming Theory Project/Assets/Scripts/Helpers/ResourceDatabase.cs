using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResourcesDatabase", menuName = "Additionals/Resources Database")]
public class ResourceDatabase : ScriptableObject
{
    public List<ResourceItem> ResourceTypes = new List<ResourceItem>();

    private Dictionary<string, ResourceItem> m_Database;


    // Init and GetItem are used in the UIMainScene script

    public void Init()
    {
        m_Database = new Dictionary<string, ResourceItem>();
        foreach (var resourceItem in ResourceTypes)
        {
            m_Database.Add(resourceItem.Id, resourceItem);
        }
    }

    public ResourceItem GetItem(string uniqueId)
    {
        m_Database.TryGetValue(uniqueId, out ResourceItem type);
        return type;
    }
}
