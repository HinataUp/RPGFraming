using System;
using System.Collections;
using UnityEngine;

// 淡入淡出效果, 通过碰撞器 ,碰撞触发获取对象,然后将淡入淡出效果的 alpha 附加到对碰撞对象 的 sprite渲染器上 

[RequireComponent(typeof(SpriteRenderer))]
public class ObscuringItemFader : MonoBehaviour {
    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void FadeIn() {
        StartCoroutine(FadeInRoutine());
    }
    public void FadeOut() {
        StartCoroutine(FadeOutRoutine());
    }




    private IEnumerator FadeInRoutine() {
        float currentAlpha = spriteRenderer.color.a;
        float distance = 1f - currentAlpha;
        while (1f - currentAlpha > 0.01f) {
            currentAlpha += distance / Settings.fadeOutSeconds * Time.deltaTime;
            spriteRenderer.color = new Color(1f, 1f, 1f, currentAlpha);
            yield return null;
        }

        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    }

    private IEnumerator FadeOutRoutine() {
        float currentAlpha = spriteRenderer.color.a;
        float distance = currentAlpha - Settings.targetAlpha;
        while (currentAlpha - Settings.targetAlpha > 0.01f) {
            currentAlpha -= distance / Settings.fadeOutSeconds * Time.deltaTime;
            spriteRenderer.color = new Color(1f, 1f, 1f, currentAlpha);
            yield return null;
        }

        spriteRenderer.color = new Color(1f, 1f, 1f, Settings.targetAlpha);
    }
}
