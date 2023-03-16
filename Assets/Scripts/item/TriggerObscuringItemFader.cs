using System;
using UnityEngine;

// 这个脚本附加到玩家, 玩家拥有一个附加的触碰器,当玩家与某些东西碰撞时,
// 会有一些关于碰撞的特殊方法被触发,所以当玩家与某些东一碰撞时,第一个被触发的是on触发器
// 这里检测玩家与那些对象发生碰撞
public class TriggerObscuringItemFader : MonoBehaviour {
    // 玩家与某些组件碰撞,获取碰撞对象&子对象的组件,然后触发淡入淡出效果
    private void OnTriggerEnter2D(Collider2D col) {
        ObscuringItemFader[] obscuringItemFaders = col.gameObject.GetComponentsInChildren<ObscuringItemFader>();
        if (obscuringItemFaders.Length > 0) {
            for (int i = 0; i < obscuringItemFaders.Length; i++) {
                obscuringItemFaders[i].FadeOut();
            }
        }
    }

        // 调用fade in
    private void OnTriggerExit2D(Collider2D other) {
        ObscuringItemFader[] obscuringItemFaders = other.gameObject.GetComponentsInChildren<ObscuringItemFader>();
        if (obscuringItemFaders.Length > 0) {
            for (int i = 0; i < obscuringItemFaders.Length; i++) {
                obscuringItemFaders[i].FadeIn();
            }
        }
    }
}