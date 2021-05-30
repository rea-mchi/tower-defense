using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deploy : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] bool isDepolyable = false;
    [SerializeField] GameObject groundBlock;

    MeshFilter groundMesh;
    private void Start() {
        groundBlock.TryGetComponent<MeshFilter>(out groundMesh);
    }
    private void OnMouseDown() {
        if (isDepolyable)
        {
            Debug.Log("Deploy cannon!");
            Vector3 blockSize = groundMesh.mesh.bounds.size;
            Vector3 pos = new Vector3(
                transform.position.x, 
                transform.position.y + blockSize.y * transform.lossyScale.y * groundBlock.transform.lossyScale.y, 
                transform.position.z
                );
            Instantiate(towerPrefab, pos, transform.rotation);
            isDepolyable = false;
        }
    }
}
