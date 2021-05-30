using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] [Range(0,5)] float speed = 1;

    // private void Awake() {
    //     transform.position = new Vector3(
    //         path[0].transform.position.x,
    //         transform.position.y,
    //         path[0].transform.position.z
    //     );
    // }
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
        for (int i = 1; i < path.Count; i++){
            Vector2 startPos = new Vector2(path[i-1].transform.position.x, path[i-1].transform.position.z);
            Vector2 destination = new Vector2(path[i].transform.position.x, path[i].transform.position.z);
            float movePercentage = 0;

            Vector3 currentPos = transform.position;
            transform.LookAt(currentPos + new Vector3(destination[0]-startPos[0],0,destination[1]-startPos[1]));

            while (movePercentage < 1)
            {
                movePercentage += Time.deltaTime * speed;
                Vector2 tempPos = Vector2.Lerp(startPos, destination, movePercentage);
                transform.position = currentPos +  new Vector3(tempPos[0]-startPos[0], 0 ,tempPos[1]-startPos[1]);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
