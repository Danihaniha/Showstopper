using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isSuspectItem = false;
    public bool isMotiveItem = false;

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }


}
