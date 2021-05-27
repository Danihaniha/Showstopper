using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Text text;
    public Image icon;
    public Image polaroid;
    public Button removeButton;

    public Equipment item;

    public void AddItem(Equipment newItem)
    {
        item = newItem;

        polaroid.enabled = true;
        text.text = item.name;
        icon.sprite = item.icon;
        icon.enabled = true;
        //removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        polaroid.enabled = false;
        text.text = null;
        icon.sprite = null;
        icon.enabled = false;
        //removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
