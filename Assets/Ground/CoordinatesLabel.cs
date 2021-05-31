using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

[ExecuteAlways]
public class CoordinatesLabel : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color unDeployableColor = Color.clear;
    Deploy block;
    TextMeshPro label;
    Vector2 coordinates = new Vector2Int();
    private void Awake() 
    {
        TryGetComponent<TextMeshPro>(out label);
        DisplayCoordinates();
    }

    private void Start() {
        transform.parent.TryGetComponent<Deploy>(out block);
    }

    // Update is called once per frame
    void Update()
    {
       if (!Application.isPlaying)
       {
            DisplayCoordinates();
            UpdateContainerName();
       }
    }

    void DisplayCoordinates()
    {
        coordinates[0] = Mathf.RoundToInt(transform.parent.position.x/EditorSnapSettings.move.x);
        coordinates[1] = Mathf.RoundToInt(transform.parent.position.z/EditorSnapSettings.move.z);
        label.text = $"({coordinates[0]},{coordinates[1]})";
        label.transform.localRotation = Quaternion.Euler(
            90, 
            label.transform.parent.rotation.eulerAngles.y*-1,
            0
        );
        label.color = (block == null || block.IsDeployable) ? defaultColor : unDeployableColor;
    }

    void UpdateContainerName()
    {
        transform.parent.name = label.text;
    }
}
