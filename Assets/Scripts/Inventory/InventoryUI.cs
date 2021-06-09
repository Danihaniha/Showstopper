using UnityEngine;
using System;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public Transform suspectInventory;
    public Transform motiveInventory;
    public Transform weaponInventory;



    Inventory inventory;

    InventorySlot[] slotsSuspect;
    InventorySlot[] slotsMotive;
    InventorySlot[] slotsWeapon;

    private void Awake()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slotsSuspect = suspectInventory.GetComponentsInChildren<InventorySlot>();
        slotsMotive = motiveInventory.GetComponentsInChildren<InventorySlot>();
        slotsWeapon = weaponInventory.GetComponentsInChildren<InventorySlot>();
    }

    private void UpdateUI()
    {
        List<Equipment> weapons = inventory.items.FindAll(kakeMonster => kakeMonster.equipSlot == EquipmentSlot.Weapon);
        List<Equipment> suspect = inventory.items.FindAll(kakeMonster => kakeMonster.equipSlot == EquipmentSlot.Suspect);
        List<Equipment> motive = inventory.items.FindAll(kakeMonster => kakeMonster.equipSlot == EquipmentSlot.Motive);

        for (int i = 0; i < slotsWeapon.Length; i++)
        {
            if (i < weapons.Count)
            {
                slotsWeapon[i].AddItem(weapons[i]);
            }
            else
            {
                slotsWeapon[i].ClearSlot();
            }
        }

        for (int i = 0; i < slotsSuspect.Length; i++)
        {
            if (i < suspect.Count)
            {
                slotsSuspect[i].AddItem(suspect[i]);
            }
            else
            {
                slotsSuspect[i].ClearSlot();
            }
        }

        for (int i = 0; i < slotsMotive.Length; i++)
        {
            if (i < motive.Count)
            {
                slotsMotive[i].AddItem(motive[i]);
            }
            else
            {
                slotsMotive[i].ClearSlot();
            }
        }
    }
}
