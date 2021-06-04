using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public List<Equipment> items = new List<Equipment>();

    public bool Add (Equipment item)
    {
        if (items.Contains(item))
            return false;

        if (item.isSuspectItem)
        {
            // Her må jeg sjekke om det finnes en i inventory fra før av. Hvis ikke, så kan du legge til én.
            // Her må jeg også prompte dialogpanelet according til Suspect?

            if (items.Count >= space) // && sjekk her om itemen finnes i inventoryet allerede
            {
                Debug.Log("Not enough room.");
                return false;
            }

            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }

        if (!item.isSuspectItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return false;
            }

            items.Add(item);

            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }

        return true;
    }

    public void Remove(Equipment item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
