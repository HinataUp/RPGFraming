using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ItemCodeDescriptionAttribute))]
public class ItemCodeDescriptionDrawer : PropertyDrawer {
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
        return EditorGUI.GetPropertyHeight(property) * 2;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        EditorGUI.BeginProperty(position, label, property);
        if (property.propertyType == SerializedPropertyType.Integer) {
            // 开始检查改变的值
            EditorGUI.BeginChangeCheck();
            // 如果itemCode 改变,将重新设置值
            var newValue = EditorGUI.IntField(
                new Rect(position.x, position.y, position.width, position.height / 2),
                label, property.intValue);

            EditorGUI.LabelField(
                new Rect(position.x, position.y + position.height / 2, position.width, position.height / 2),
                "Item Description", GetItemDescription(property.intValue));

            if (EditorGUI.EndChangeCheck()) {
                property.intValue = newValue;
            }
        }

        EditorGUI.EndProperty();
    }

    private string GetItemDescription(int itemCode) {
        var soItemList = AssetDatabase.LoadAssetAtPath("Assets/Scripts/ScriptableObjectAssets/Item/so_ItemList.asset",
            typeof(SO_ItemList)) as SO_ItemList;
        List<ItemDetails> itemDetailsList = soItemList.itemDetails;
        // 若真返回这个item 的细节，否则返回numll ，需要比对x 的itemCode 与itemCode 是否匹配
        ItemDetails itemDetails = itemDetailsList.Find(x => x.itemCode == itemCode);
        return itemDetails != null ? itemDetails.itemDescription : "";
    }
}