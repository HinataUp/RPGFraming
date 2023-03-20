using UnityEngine;

public class ItemPickUp : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D col) {
        Item item = col.GetComponent<Item>();
        if (item != null) {
            ItemDetails itemDetails = InventoryManager.Instance.GetItemDetails(item.ItemCode);
            //  打印Item到控制台,测试用
            // Debug.Log(itemDetails.itemDescription);
            if (itemDetails.canBePickedUp) {
                InventoryManager.Instance.AddItem(InventoryLocation.player, item, col.gameObject);
            }
        }
    }
}