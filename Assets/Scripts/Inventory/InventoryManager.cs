using System;
using System.Collections.Generic;
using UnityEngine;


public class InventoryManager : SingletonMonoBehavior<InventoryManager> {
    private Dictionary<int, ItemDetails> itemDetailsDictionary;
    [SerializeField] private SO_ItemList itemList = null;

    protected override void Awake() {
        base.Awake();
        CreateItemDetailDictionary();
    }

    // private void Start() {
    //     CreateItemDetailDictionary();
    // }

    private void CreateItemDetailDictionary() {
        itemDetailsDictionary = new Dictionary<int, ItemDetails>();
        foreach (var itemDetails in itemList.itemDetails) {
            itemDetailsDictionary.Add(itemDetails.itemCode, itemDetails);
        }
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
}