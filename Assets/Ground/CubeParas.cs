using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeParas : MonoBehaviour
{

    [SerializeField] GameObject cube;
    // Start is called before the first frame update

    public float LengthX{ get{ return size.x * transform.lossyScale.x;}}
    public float LengthY{ get{ return size.y * transform.lossyScale.y;}}
    public float LengthZ{ get{ return size.z * transform.lossyScale.z;}}
    Vector3 size;

    private void Awake() {
        cube.TryGetComponent<MeshFilter>(out var meshFilter);
        size = Vector3.Scale(meshFilter.mesh.bounds.size, cube.transform.lossyScale);
    }
}
