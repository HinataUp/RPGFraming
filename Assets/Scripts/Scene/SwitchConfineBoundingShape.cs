using UnityEngine;
using Cinemachine;

public class SwitchConfineBoundingShape : MonoBehaviour {
    void Start() {
        SwitchBoundingShape();
    }

    /// <summary>
    ///  Switch the collider that cinemachine users to define the edges of the screen 
    /// </summary>
    private void SwitchBoundingShape() {
        PolygonCollider2D polygonCollider2D =
            GameObject.FindWithTag(Tags.BoundsConfiner).GetComponent<PolygonCollider2D>();
        CinemachineConfiner cinemachineConfiner = GetComponent<CinemachineConfiner>();
        cinemachineConfiner.m_BoundingShape2D = polygonCollider2D;
        cinemachineConfiner.InvalidatePathCache();
    }
}