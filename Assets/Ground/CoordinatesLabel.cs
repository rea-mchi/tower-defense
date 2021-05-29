using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

[ExecuteAlways]
public class CoordinatesLabel : MonoBehaviour
{
    TextMeshPro label;
    Vector2 coordinates = new Vector2Int();
    private void Awake() 
    {
        TryGetComponent<TextMeshPro>(out label);
        DisplayCoordinates();
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
    }

    void UpdateContainerName()
    {
        transform.parent.name = label.text;
    }
}
