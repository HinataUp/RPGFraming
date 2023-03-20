using System;
using System.Collections.Generic;
using UnityEngine;


public class InventoryManager : SingletonMonoBehavior<InventoryManager> {
    private Dictionary<int, ItemDetails> itemDetailsDictionary;
    public List<InventoryItem>[] inventoryLists;

    [HideInInspector] public int[] inventoryListCapacityIntArray;

    [SerializeField] private SO_ItemList itemList = null;

    protected override void Awake() {
        base.Awake();
        CreateInventoryLists();
        CreateItemDetailDictionary();
    }

    private void CreateInventoryLists() {
        inventoryLists = new List<InventoryItem>[(int)InventoryLocation.count];
        for (int i = 0; i < (int)InventoryLocation.count; i++) {
            inventoryLists[i] = new List<InventoryItem>();
        }

        inventoryListCapacityIntArray = new int[(int)InventoryLocation.count];
        inventoryListCapacityIntArray[(int)InventoryLocation.player] = Settings.playerInitInventorySize;
    }

    private void CreateItemDetailDictionary() {
        itemDetailsDictionary = new Dictionary<int, ItemDetails>();
        foreach (var itemDetails in itemList.itemDetails) {
            itemDetailsDictionary.Add(itemDetails.itemCode, itemDetails);
        }
    }

    // 物品拾取后添加到背包并且销毁物品
    public void AddItem(InventoryLocation inventoryLocation, Item item, GameObject gameObjectDelete) {
        AddItem(inventoryLocation, item);
        Destroy(gameObjectDelete);
    }

    // 添加物品到背包
    public void AddItem(InventoryLocation inventoryLocation, Item item) {
        int itemCode = item.ItemCode;
        List<InventoryItem> inventoryList = inventoryLists[(int)inventoryLocation];
        int itemPosition = FindItemInInventory(inventoryLocation, itemCode);
        // 背包!=-1 ,物品已经存在,此时添加数量, 否则添加物品到新位置并且设置对应的数量
        if (itemPosition != -1) {
            AddItemAtPosition(inventoryList, itemCode, itemPosition);
        } else {
            AddItemAtPosition(inventoryList, itemCode);
        }

        EventHandler.CallInventoryUpdatedEvent(inventoryLocation, inventoryLists[(int)inventoryLocation]);
    }

    // 物品不存在时添加一个物品到背包,注意多个物品则多次触发
    private void AddItemAtPosition(List<InventoryItem> inventoryList, int itemCode) {
        InventoryItem inventoryItem = new InventoryItem();
        inventoryItem.itemCode = itemCode;
        inventoryItem.amount = 1;
        inventoryList.Add(inventoryItem);
        DebugPrintInventoryList(inventoryList);
    }

    private void AddItemAtPosition(List<InventoryItem> inventoryList, int itemCode, int itemPosition) {
        InventoryItem inventoryItem = new InventoryItem();
        int amount = inventoryList[itemPosition].amount + 1;
        inventoryItem.itemCode = itemCode;
        inventoryItem.amount = amount;
        inventoryList[itemPosition] = inventoryItem;
        // inventoryList.Add(inventoryItem);
        // 控制台debug 检测
        DebugPrintInventoryList(inventoryList);
    }


    // 查找物品在背包中的位置
    private int FindItemInInventory(InventoryLocation inventoryLocation, int itemCode) {
        List<InventoryItem> inventoryList = inventoryLists[(int)inventoryLocation];
        for (int i = 0; i < inventoryList.Count; i++) {
            if (inventoryList[i].itemCode == itemCode) {
                return i;
            }
        }

        return -1;
    }

    // 触发无实例引用异常,这里需要修一下,需要再Awake 中实例化,而不是再Stack,因为unity 找不到对应的引用
    public ItemDetails GetItemDetails(int itemCode) {
        ItemDetails itemDetails;
        if (itemDetailsDictionary.TryGetValue(itemCode, out itemDetails)) {
            return itemDetails;
        } else {
            return null;
        }
    }

    private void DebugPrintInventoryList(List<InventoryItem> inventoryList) {
        foreach (var InventoryItem in inventoryList) {
            Debug.Log("itemDescription: " +
                      InventoryManager.Instance.GetItemDetails(InventoryItem.itemCode).itemDescription + " amount: " +
                      InventoryItem.amount);
        }

        Debug.Log("=======pass=======");
    }
}