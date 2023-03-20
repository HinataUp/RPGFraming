using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

// 不是一个类,而是作为㢟附加到items ,并且需要碰撞框 以实现碰撞时的摇晃效果
// 因此需要设置对应的触发器on trigger 进入方法, on trigger exit 退出方法, 注意左右方向 ,然后靠xy轴的移动实现效果
// 应当有对应的动画效果播放
public class ItemNudge : MonoBehaviour {
    private WaitForSeconds pasue;
    private bool isAnimating = false;

    private void Awake() {
        pasue = new WaitForSeconds(0.04f);
    }

    private void OnTriggerEnter2D(Collider2D collider2D1) {
        if (isAnimating == false) {
            // 碰撞时依据玩家的位置来判断是顺时针还是逆时针旋转 摇摆
            if (gameObject.transform.position.x < collider2D1.transform.position.x) {
                StartCoroutine(RotateAntiClock());
            } else {
                StartCoroutine(RotateClock());
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collider2D2) {
        if(isAnimating == false) {
            if (gameObject.transform.position.x > collider2D2.transform.position.x) {
                StartCoroutine(RotateAntiClock());
            } else {
                StartCoroutine(RotateClock());
            }
        }
    }

    private IEnumerator RotateClock() {
        isAnimating = true;
        for (var i = 0; i < 4; i++) {
            gameObject.transform.GetChild(0).Rotate(0f, 0f, -2f);
            yield return pasue;
        }

        for (var i = 0; i < 5; i++) {
            gameObject.transform.GetChild(0).Rotate(0f, 0f, 2f);
            yield return pasue;
        }

        gameObject.transform.GetChild(0).Rotate(0f, 0f, -2f);
        yield return pasue;
        isAnimating = false;
    }

    // 逆时针旋转
    private IEnumerator RotateAntiClock() {
        isAnimating = true;
        for (var i = 0; i < 4; i++) {
            gameObject.transform.GetChild(0).Rotate(0f, 0f, 2f);
            yield return pasue;
        }

        for (var i = 0; i < 5; i++) {
            gameObject.transform.GetChild(0).Rotate(0f, 0f, -2f);
            yield return pasue;
        }

        gameObject.transform.GetChild(0).Rotate(0f, 0f, 2f);
        yield return pasue;
        isAnimating = false;
    }
}