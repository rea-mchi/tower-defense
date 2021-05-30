using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{

    [SerializeField] GameObject selectedFX;
    
    private void OnMouseOver() {
        selectedFX.TryGetComponent<MeshRenderer>(out var renderer);
        renderer.enabled = true;
    }

    private void OnMouseExit() {
        selectedFX.TryGetComponent<MeshRenderer>(out var renderer);
        renderer.enabled = false;
    }
}
