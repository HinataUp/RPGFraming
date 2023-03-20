using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class Item : MonoBehaviour {
    // [Range(10000,10100)]
    [ItemCodeDescription] [SerializeField] private int itemCode;
    private SpriteRenderer spriteRenderer;

    public int ItemCode {
        get => itemCode;
        set => itemCode = value;
    }

    private void Awake() {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start() {
        if (ItemCode != 0) {
            Init(ItemCode);
        }
    }

    public void Init(int itemCodeParam) {
        if (itemCodeParam == 0) return;
        ItemCode = itemCodeParam;
        ItemDetails itemDetails = InventoryManager.Instance.GetItemDetails(ItemCode);
        spriteRenderer.sprite = itemDetails.itemSprite;
        if (itemDetails.itemType == ItemType.ReapableScenary) {
            gameObject.AddComponent<ItemNudge>();
        }
    }
}