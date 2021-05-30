using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocate : MonoBehaviour
{
    [SerializeField] GameObject aimer;

    private void Update() {
        var enemy = GameObject.FindWithTag("Enemy");
        aimer.transform.LookAt(new Vector3(
            enemy.transform.position.x,
            aimer.transform.position.y,
            enemy.transform.position.z)
        );
    }
}
