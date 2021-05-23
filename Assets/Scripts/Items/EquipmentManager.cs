using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{

    #region Singleton

    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    Equipment[] currentEquipment;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    public string[] rightEquipment = { "Telephone", "Axe" };

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


    // Code to check if currently equipped Suspect, Motive and Weapon is the right combination to win or to loose, and which loads the matching scenario if you win/loose.
    //  Trenger: string[] cars = {"Volvo", "BMW", " typ i toppen og så sjekke om Slot contains noe fra stringen cars
    //public void WinOrLose()
    //  {
    //      If slotIndex(1) == rightEquipment && slotIndex(2) == rightEquipment && slotIndex(3) == rightEquipment
    //      {
    //          Load Win-scenario;
    //      }
    //      else
    //      {
    //          Load Lose-scenario;
    //      }
    //  }
}
