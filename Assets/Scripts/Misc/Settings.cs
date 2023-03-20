using UnityEngine;


public class Settings {
    // 淡入淡出设置,参数
    public const float fadeInSeconds = 0.25f;
    public const float fadeOutSeconds = 0.35f;
    public const float targetAlpha = 0.35f;

    // inventory settings
    public const int playerInitInventorySize = 36;
    public const int playerMaxInventorySize = 72;

    // player movement
    public static float runningSpped = 7.2f;
    public static float walkingSpped = 4.2f;

    // player animation parameters
    public static int xInput;
    public static int yInput;
    public static int isWalking;
    public static int isRunning;
    public static int isIdle;
    public static int isCarrying;
    public static int isUsingToolRight;
    public static int isUsingToolLeft;
    public static int isUsingToolUp;
    public static int isUsingToolDown;
    public static int isLiftingToolRight;
    public static int isLiftingToolLeft;
    public static int isLiftingToolUp;
    public static int isLiftingToolDown;
    public static int isPickingRight;
    public static int isPickingLeft;
    public static int isPickingUp;
    public static int isPickingDown;
    public static int isSwingingToolRight;
    public static int isSwingingToolLeft;
    public static int isSwingingToolUp;
    public static int isSwingingToolDown;
    public static int idleUp;
    public static int idleDown;
    public static int idleRight;
    public static int idleLeft;
    public static int toolEffect;

    static Settings() {
        xInput = Animator.StringToHash("xInput");
        yInput = Animator.StringToHash("yInput");
        isWalking = Animator.StringToHash("isWalking");
        isCarrying = Animator.StringToHash("isCarrying");
        isRunning = Animator.StringToHash("isRunning");
        isIdle = Animator.StringToHash("isIdle");
        toolEffect = Animator.StringToHash("toolEffect");
        isPickingDown = Animator.StringToHash("isPickingDown");
        isPickingLeft = Animator.StringToHash("isPickingLeft");
        isPickingRight = Animator.StringToHash("isPickingRight");
        isPickingUp = Animator.StringToHash("isPickingUp");
        isLiftingToolDown = Animator.StringToHash("isLiftingToolDown");
        isLiftingToolLeft = Animator.StringToHash("isLiftingToolLeft");
        isLiftingToolRight = Animator.StringToHash("isLiftingToolRight");
        isLiftingToolUp = Animator.StringToHash("isLiftingToolUp");
        isSwingingToolDown = Animator.StringToHash("isSwingingToolDown");
        isSwingingToolLeft = Animator.StringToHash("isSwingingToolLeft");
        isSwingingToolRight = Animator.StringToHash("isSwingingToolRight");
        isSwingingToolUp = Animator.StringToHash("isSwingingToolUp");
        isUsingToolDown = Animator.StringToHash("isUsingToolDown");
        isUsingToolLeft = Animator.StringToHash("isUsingToolLeft");
        isUsingToolRight = Animator.StringToHash("isUsingToolRight");
        isUsingToolUp = Animator.StringToHash("isUsingToolUp");
        idleDown = Animator.StringToHash("idleDown");
        idleLeft = Animator.StringToHash("idleLeft");
        idleRight = Animator.StringToHash("idleRight");
        idleUp = Animator.StringToHash("idleUp");
    }
}