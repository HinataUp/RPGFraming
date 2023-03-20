using System;
using System.Collections.Generic;


using UnityEngine;

public class UIInventoryBar : MonoBehaviour {
    // 序列化保存空白精灵图像,用来填充空的格子
    [SerializeField] private Sprite emptySlotSprite = null;
    [SerializeField] private UIInventorySlot[] inventorySlot = null;
    
    // 
    private void OnEnable() {
        EventHandler.InventoryUpdatedEvent += InventoryUpdated;
    }

    private void OnDisable() {
        EventHandler.InventoryUpdatedEvent -= InventoryUpdated;
    }

    
    private void InventoryUpdated(InventoryLocation inventoryLocation, List<InventoryItem> inventoryList) {
        
        if (inventoryLocation == InventoryLocation.player) {
            ClearInventorySlot();
        }
        
        if(inventorySlot.Length > 0 && inventoryList.Count > 0) {
            for (int i = 0; i < inventorySlot.Length; i++) {
                if (i < inventoryList.Count) {
                    int itemcode = inventoryList[i].itemCode;
                    ItemDetails itemDetails = InventoryManager.Instance.GetItemDetails(itemcode);
                    if (itemDetails != null) {
                        inventorySlot[i].inventorySlotImage.sprite = itemDetails.itemSprite;
                        inventorySlot[i].inventorySlotText.text = inventoryList[i].amount.ToString();
                        inventorySlot[i].itemDetails = itemDetails;
                        inventorySlot[i].itemAmount = inventoryList[i].amount;
                    } else {
                        break;
                    }
                } 
            }
        }
        
    }

    private void ClearInventorySlot() {
        if (inventorySlot.Length > 0) {
            for (int i = 0; i < inventorySlot.Length; i++) {
                inventorySlot[i].inventorySlotImage.sprite = emptySlotSprite;
                inventorySlot[i].inventorySlotText.text = "";
                inventorySlot[i].itemDetails = null;
                inventorySlot[i].itemAmount = 0;
            }
        }
    }

    // player position
    private RectTransform _rectTransform;
    // Inventory
    private bool _isInventoryBarPositionBottom = true;
    // 
    public bool IsInventoryBarPositionBottom {
        get => _isInventoryBarPositionBottom;
        set => _isInventoryBarPositionBottom = value;
    }
    
    private void Awake() {
        _rectTransform = GetComponent<RectTransform>();
       
    }

    private void Update() {
        SwitchInventoryBarPosition();
    }

    // 根据时间情况更改 底部bar的位置
    private void SwitchInventoryBarPosition() {
        Vector3 playerPosition = Player.Instance.GetPlayerPosition();
        
        // Debug.Log($"{playerPosition.y}");
        // 大于自身位置的0.3倍,且bar不在底部则移动到底部,否则放顶部
        if (playerPosition.y > 70f && IsInventoryBarPositionBottom == false) {
            
            _rectTransform.pivot = new Vector2(0.5f, 0f);
            _rectTransform.anchorMin = new Vector2(0.5f, 0f);
            _rectTransform.anchorMax = new Vector2(0.5f, 0f);
            _rectTransform.anchoredPosition = new Vector2(0f, 5f);
            _isInventoryBarPositionBottom = true;
            
        }else if (playerPosition.y <= 70f && IsInventoryBarPositionBottom == true) {
            // Debug.Log($"{playerPosition.y}");
            _rectTransform.pivot = new Vector2(0.5f, 1f);
            _rectTransform.anchorMin = new Vector2(0.5f, 1f);
            _rectTransform.anchorMax = new Vector2(0.5f, 1f);
            _rectTransform.anchoredPosition = new Vector2(0f, -5f);
            _isInventoryBarPositionBottom = false;
        }
    }
}