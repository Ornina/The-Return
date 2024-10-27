using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public string locationName;

    [TextArea]
    public string locationDescription;

    public Connection[] connections;

    public List<Item> items = new List<Item>();



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public string GetItemsText()
    {
        if (items.Count == 0)
            return ("");
        string result = "You see a ";
        bool first = true;

        foreach (Item item in items)
        {
            if (item.itemEnabled)
            {
                if (!first)
                    result += " and ";
                result += item.itemDescription;
                first = false;
            }
        }
        result += "\n";
        return result;
    }

    public string GetConnectionsText()
    {
        string result = "";
        foreach (Connection connection in connections)
        {
            if (connection.connectionEnabled)
                result += connection.ConnectionDescription + "\n";

        }
        return result;
    }

    public Connection GetConnection(string connectionNoun)
    {
        foreach (Connection connection in connections)
        {
            if (connection.ConnectionName.ToLower() == connectionNoun.ToLower())
                return connection;
        }
        return null;
    }

    internal bool HasItem(Item itemToCheck)
    {
        foreach (Item item in items)
        {
            if (item == itemToCheck == item.itemEnabled)
                return true;
        }
        return false;
    }

    public bool HasItemByName(string name)
    {
        foreach (Item item in items)
        {
            if (item.itemName.ToLower() == name.ToLower())
                return true;
        }
        return false;
    }

  
}


