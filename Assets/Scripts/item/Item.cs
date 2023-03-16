using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class Item : MonoBehaviour {
    [SerializeField] private int itemCode;
    private SpriteRenderer spriteRenderer;

    public int ItemCode {
        get => itemCode;
        set => itemCode = value;
    }

    private void Awake() {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        
    }

    private void Start() {
        if (ItemCode != 0) {
            Init(ItemCode);
        }
    }

    public void Init(int itemCodeParam) {
        
    }
}