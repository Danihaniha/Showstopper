using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{

    #region Singleton

    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Image[] EquipmentUISlots;
    
    public Equipment[] currentEquipment;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    public string[] rightEquipment = { "Telephone", "Axe", "Bucket" };

    private void Start()
    {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    // Code to Equip items into the Equipment Manager.
    public void Equip (Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = null;

        if(currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;
        EquipmentUISlots[slotIndex].sprite = newItem.icon;
    }

    // Code to Unequip items from the Equipment Manager.
    public void Unequip (int slotIndex)
    {
        if(currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }

    public void WinOrLose()
    {
        int test1 = Array.IndexOf(rightEquipment, currentEquipment[0].name);
        int test2 = Array.IndexOf(rightEquipment, currentEquipment[1].name);
        int test3 = Array.IndexOf(rightEquipment, currentEquipment[2].name);


        if (test1 != -1 && test2 != -1 && test3 != -1)
        {
            Debug.LogError("YOU GUESSED RIGHT!");
        }
        else
        {
            Debug.LogWarning("YOU WERE WRONG!");
        }
    }
}
