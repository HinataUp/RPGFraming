using System.Collections.Generic;
using UnityEngine;

// 这是一个创建资源菜单命令,该命令会在unity继承自unity类,并在unity生成对应的脚本,随后可以在unity 有相关创建命令
// 这里创建的是一个list 存储对象类型是ItemDetails 
[CreateAssetMenu(fileName = "so_ItemList", menuName = "Scriptable Object/Item/Item List")]
public class SO_ItemList : ScriptableObject {
    [SerializeField] public List<ItemDetails> itemDetails;
}