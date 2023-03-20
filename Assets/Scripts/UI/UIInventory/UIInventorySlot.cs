
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventorySlot : MonoBehaviour{
    public Image inventorySlotHighLight;
    public Image inventorySlotImage;
    public TextMeshProUGUI inventorySlotText;
    [HideInInspector] public ItemDetails itemDetails;
    [HideInInspector] public int itemAmount;
}