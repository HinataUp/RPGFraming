﻿using System;
using System.Collections.Generic;
using UnityEngine;


public class Player : SingletonMonoBehavior<Player> {
    // 通过摄像机获取玩家的位置
    private Camera mainCamera;
    
    //movement parameters
    private float inputX;
    private float inputY;
    private bool isCarrying = false;
    private ToolEffect toolEffect = ToolEffect.none;

    private bool isWalking;
    private bool isRunning;
    private bool isIdle;

    private bool isUsingToolRight;
    private bool isUsingToolLeft;
    private bool isUsingToolUp;
    private bool isUsingToolDown;

    private bool isLiftingToolRight;
    private bool isLiftingToolLeft;
    private bool isLiftingToolUp;
    private bool isLiftingToolDown;

    private bool isPickingRight;
    private bool isPickingLeft;
    private bool isPickingUp;
    private bool isPickingDown;

    private bool isSwingingToolRight;
    private bool isSwingingToolLeft;
    private bool isSwingingToolUp;
    private bool isSwingingToolDown;

    private bool idleUp;
    private bool idleDown;
    private bool idleRight;
    private bool idleLeft;

    private Rigidbody2D playerRigidbody2D;
    // 暂时隐藏警告
#pragma warning disable 414
    private Direction playerDirection;
#pragma warning restore 414
    private float movementSpeed;
    private bool _playerInputIsDisabled = false;

    // public bool PlayerInputIsDisabled {
    //     get;
    //     set;
    // } = false;

    public bool PlayerInputIsDisabled {
        get => _playerInputIsDisabled;
        set => _playerInputIsDisabled = value;
    }

    protected override void Awake() {
        base.Awake();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        
        // 在Awake中获取摄像机
        mainCamera = Camera.main;
    }

    private void Update() {
        #region Player Input

        ResetAnimationTriggers();

        PlayerMovementInput();
        PlayerWalkInput();
        EventHandler.CallMovementEvent(inputX, inputY,
            isWalking, isRunning, isIdle, isCarrying,
            isUsingToolRight, isUsingToolLeft, isUsingToolUp, isUsingToolDown,
            isLiftingToolRight, isLiftingToolLeft, isLiftingToolUp, isLiftingToolDown,
            isPickingRight, isPickingLeft, isPickingUp, isPickingDown,
            isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown,
            false, false, false, false, toolEffect);

        #endregion
    }

    private void FixedUpdate() {
        PlayerMovement();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void PlayerMovement() {
        Vector2 move = new Vector2(inputX * movementSpeed * Time.deltaTime,
            inputY * movementSpeed * Time.deltaTime);
        // Debug.Log($"水平移动{move.x},垂直移动{move.y} ");
        playerRigidbody2D.MovePosition(playerRigidbody2D.position + move);
    }

    private void PlayerWalkInput() {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
            isWalking = false;
            isRunning = true;
            isIdle = false;
            movementSpeed = Settings.runningSpped;
        } else {
            isWalking = true;
            isRunning = false;
            isIdle = false;
            movementSpeed = Settings.walkingSpped;
        }
    }

    private void PlayerMovementInput() {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        if (inputX != 0 && inputY != 0) {
            inputX *= 0.71f;
            inputY *= 0.71f;
        }

        if (inputX != 0 || inputY != 0) {
            isWalking = true;
            isRunning = false;
            isIdle = false;
            movementSpeed = Settings.runningSpped;
            if (inputX < 0) {
                playerDirection = Direction.left;
            } else if (inputX > 0) {
                playerDirection = Direction.right;
            } else if (inputY < 0) {
                playerDirection = Direction.down;
            } else {
                playerDirection = Direction.up;
            }
        } else if (inputX == 0 || inputY == 0) {
            isRunning = false;
            isWalking = false;
            isIdle = true;
        }
    }

    private void ResetAnimationTriggers() {
        isPickingDown = false;
        isPickingUp = false;
        isPickingLeft = false;
        isPickingRight = false;

        isUsingToolDown = false;
        isUsingToolUp = false;
        isUsingToolRight = false;
        isUsingToolLeft = false;

        isLiftingToolDown = false;
        isLiftingToolLeft = false;
        isLiftingToolRight = false;
        isLiftingToolUp = false;

        isSwingingToolDown = false;
        isSwingingToolLeft = false;
        isSwingingToolRight = false;
        isSwingingToolUp = false;
        toolEffect = ToolEffect.none;
    }
    // 通过摄像机获取玩家的位置
    // 如果需要将玩家的位置转换为屏幕上的坐标，可以使用Camera的WorldToScreenPoint()方法将2D位置转换为3D位置再转换为屏幕坐标。
    public Vector3 GetPlayerPosition() {
        var a  = mainCamera.fieldOfView;
        // Debug.Log("显示摄像头坐标");
        return mainCamera.WorldToScreenPoint(transform.position);
    }
}