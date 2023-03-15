using System;
using UnityEngine;
using UnityEngine.Video;


public class MovementAnimationParameterControl : MonoBehaviour {
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void OnEnable() {
        EventHandler.MovementEvent += SetAnimationParameters;
    }

    private void OnDisable() {
        EventHandler.MovementEvent -= SetAnimationParameters;
    }

    private void SetAnimationParameters(
        float xInput, float yInput,
        bool isWalking, bool isRunning, bool isIdle, bool isCarrying,
        bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
        bool isLiftingToolRight, bool isLiftingToolLeft, bool isLiftingToolUp, bool isLiftingToolDown,
        bool isPickingRight, bool isPickingLeft, bool isPickingUp, bool isPickingDown,
        bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingToolUp, bool isSwingingToolDown,
        bool idleUp, bool idleDown, bool idleRight, bool idleLeft, ToolEffect toolEffect) {
        animator.SetFloat(Settings.xInput, xInput);
        animator.SetFloat(Settings.yInput, yInput);
        animator.SetBool(Settings.isWalking, isWalking);
        animator.SetBool(Settings.isRunning, isRunning);
        animator.SetInteger(Settings.toolEffect, (int)toolEffect);
        if (isWalking) animator.SetTrigger(Settings.isWalking);
        if (isRunning) animator.SetTrigger(Settings.isRunning);
        if (isIdle) animator.SetTrigger(Settings.isIdle);
        if (isCarrying) animator.SetTrigger(Settings.isCarrying);

        if (isUsingToolRight) animator.SetTrigger(Settings.isUsingToolRight);
        if (isUsingToolDown) animator.SetTrigger(Settings.isUsingToolDown);
        if (isUsingToolLeft) animator.SetTrigger(Settings.isUsingToolLeft);
        if (isUsingToolUp) animator.SetTrigger(Settings.isUsingToolUp);

        if (isPickingDown) animator.SetTrigger(Settings.isPickingDown);
        if (isPickingLeft) animator.SetTrigger(Settings.isPickingLeft);
        if (isPickingRight) animator.SetTrigger(Settings.isPickingRight);
        if (isPickingUp) animator.SetTrigger(Settings.isPickingUp);

        if (isLiftingToolRight) animator.SetTrigger(Settings.isLiftingToolRight);
        if (isLiftingToolDown) animator.SetTrigger(Settings.isLiftingToolDown);
        if (isLiftingToolLeft) animator.SetTrigger(Settings.isLiftingToolLeft);
        if (isLiftingToolUp) animator.SetTrigger(Settings.isLiftingToolUp);

        if (isSwingingToolDown) animator.SetTrigger(Settings.isSwingingToolDown);
        if (isSwingingToolLeft) animator.SetTrigger(Settings.isSwingingToolLeft);
        if (isSwingingToolRight) animator.SetTrigger(Settings.isSwingingToolRight);
        if (isSwingingToolUp) animator.SetTrigger(Settings.isSwingingToolUp);


        if (idleUp) animator.SetTrigger(Settings.idleUp);
        if (idleLeft) animator.SetTrigger(Settings.idleLeft);
        if (idleDown) animator.SetTrigger(Settings.idleDown);
        if (idleRight) animator.SetTrigger(Settings.idleRight);
    }

    // 暂时空,结局获取不到body 
    private void AnimationEventPlayFootstepSound() {
    }
}