using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] float moveInterval = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(moveAlongPath());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator moveAlongPath()
    {
        foreach(WayPoint wayPoint in path)
        {
            yield return new WaitForSeconds(moveInterval);
            Vector2 nextPos = wayPoint.currentPos;
            transform.position = new Vector3(nextPos[0], 0, nextPos[1]);
        }
    }
}
