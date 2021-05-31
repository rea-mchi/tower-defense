using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deploy : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] bool isDepolyable = false;

    public bool IsDeployable{ get { return isDepolyable; } }

    private void OnMouseDown() {
        if (isDepolyable)
        {
            transform.TryGetComponent<CubeParas>(out var cubeParas);
            Vector3 pos = new Vector3(
                transform.position.x, 
                transform.position.y + cubeParas.LengthY,
                transform.position.z
                );
            Instantiate(towerPrefab, pos, transform.rotation);
            isDepolyable = false;
        }
    }
}
