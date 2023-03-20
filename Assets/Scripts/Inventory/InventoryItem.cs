[System.Serializable]
public struct InventoryItem {
    public int itemCode;
    public int amount;
    public InventoryItem(int itemCode, int amount) {
        this.itemCode = itemCode;
        this.amount = amount;
    }
}