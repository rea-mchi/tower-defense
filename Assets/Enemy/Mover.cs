using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] [Range(0,5)] float speed = 1;

    WayPoint[] path;
    Vector3 birthPoint;
    private void Awake() {

    }

    private void Start() {
        Debug.Log($"{gameObject.name} calls start");
        findPathAndBirthPoint();
        resetLocation();
        StartCoroutine(moveAlongPath());
    }
    
    private void OnEnable() {        
        if (path == null)
        {
            return;
        }
        Debug.Log($"{gameObject.name} calls onEnable");
        resetLocation();
        StartCoroutine(moveAlongPath());
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void findPathAndBirthPoint() {
        path = GameObject.FindWithTag("Path").GetComponentsInChildren<WayPoint>();
        // birth point
        path[0].transform.TryGetComponent<CubeParas>(out var cubeParas);
        birthPoint = new Vector3(
            path[0].transform.position.x,
            path[0].transform.position.y + cubeParas.LengthY,
            path[0].transform.position.z
        );
    }

    void resetLocation() {
        Debug.Log($"resetLocation:{birthPoint.ToString()}");
        transform.position = birthPoint;
    }

    IEnumerator moveAlongPath()
    {
        for (int i = 1; i < path.Length; i++){
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

        escapeOut();
    }
    
    void escapeOut() {
        gameObject.SetActive(false);
    }
}
