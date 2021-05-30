using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{

    [SerializeField] FreeFall cannonBall;
    [SerializeField] float launchVel;
    [SerializeField] float launchInterval;

    private bool coolDown = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var enemy = GameObject.FindWithTag("Enemy");
        if (enemy != null && coolDown)
        {
            Debug.Log("Prepare launch!");
            PrepareLaunch(enemy.transform);
        }
    }

    void PrepareLaunch(Transform target) {
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        Debug.Log($"Launch Direction is {direction.ToString()}");
        FreeFall ball = Instantiate(cannonBall, transform.position, Quaternion.identity);
        StartCoroutine(ball.Launch(direction * launchVel));
        StartCoroutine(Overheat());
    }

    IEnumerator Overheat() {
        coolDown = false;
        yield return new WaitForSeconds(launchInterval);
        coolDown = true;
    }
}
