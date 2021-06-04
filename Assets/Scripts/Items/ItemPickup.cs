using UnityEngine;

public class ItemPickup : Interactable
{
    public Equipment item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp && !item.isSuspectItem)
            Destroy(gameObject);
    }
}
