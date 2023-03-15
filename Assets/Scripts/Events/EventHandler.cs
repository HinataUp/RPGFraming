﻿public delegate void MovementDelegate(
    float inputX, float inputY,
    bool isWalking, bool isRunning, bool isIdle, bool isCarrying,
    bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
    bool isLiftingToolRight, bool isLiftingToolLeft, bool isLiftingToolUp, bool isLiftingToolDown,
    bool isPickingRight, bool isPickingLeft, bool isPickingUp, bool isPickingDown,
    bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingToolUp, bool isSwingingToolDown,
    bool idleUp, bool idleDown, bool idleRight, bool idleLeft,
    ToolEffect toolEffect
);


public static class EventHandler {
    public static event MovementDelegate MovementEvent;

    public static void CallMovementEvent(float inputX, float inputY,
        bool isWalking, bool isRunning, bool isIdle, bool isCarrying,
        bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
        bool isLiftingToolRight, bool isLiftingToolLeft, bool isLiftingToolUp, bool isLiftingToolDown,
        bool isPickingRight, bool isPickingLeft, bool isPickingUp, bool isPickingDown,
        bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingToolUp, bool isSwingingToolDown,
        bool idleUp, bool idleDown, bool idleRight, bool idleLeft, ToolEffect toolEffect) {
        MovementEvent?.Invoke(inputX, inputY,
            isWalking, isRunning, isIdle, isCarrying,
            isUsingToolRight, isUsingToolLeft, isUsingToolUp, isUsingToolDown,
            isLiftingToolRight, isLiftingToolLeft, isLiftingToolUp, isLiftingToolDown,
            isPickingRight, isPickingLeft, isPickingUp, isPickingDown,
            isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown,
            idleUp, idleDown, idleRight, idleLeft, toolEffect);
    }
}