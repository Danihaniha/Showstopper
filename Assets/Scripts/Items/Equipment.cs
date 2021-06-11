using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    public CharacterName characterName;

    [TextArea]
    public string ItemDescription;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}

public enum EquipmentSlot { Suspect, Motive, Weapon }

public enum CharacterName { None, MikeM1, PeggyM1, AmeliaM1, AmeliaM2, AndyM2, JesseM2, BuzzM2, MissFittsM3, MissBehavedM3, WandaStraponM3, AnitaTensionM3, BusterBlockM3}