using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeFall : MonoBehaviour
{

    [SerializeField] int dmg = 1;
    [SerializeField] GameObject explosionVFX;
    [SerializeField] float TimeKeptOnGround = 3;

    float g = -9.8f;
    // Start is called before the first frame update
    bool hit = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Launch(Vector3 initVel) {
        Debug.Log($"Start launch!. Initial vel is {initVel.ToString()}");
        float timer = 0;
        while (!hit)
        {
            // Debug.Log($"Flying ball: location: {transform.position.ToString()}");
            transform.position += new Vector3(
                initVel.x * Time.deltaTime,
                initVel.y * Time.deltaTime + g / 2 * Time.deltaTime * (2 * timer + Time.deltaTime),
                initVel.z * Time.deltaTime
                );
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    private void OnTriggerEnter(Collider other) {
        // Debug.Log($"Trigger Target:{other.gameObject.name}");
        string tag = other.gameObject.tag;
        if(tag != "Ground" && tag != "Enemy") return;
        Debug.Log($"Hit {other.gameObject.tag}");
        hit = true;
        if (tag == "Ground")
        {
            ExplodeOnGround();
        }
        else
        {
            ExplodeWithEnemy(other.gameObject);
        }
    }

    void ExplodeOnGround() {
        explosionVFX = Instantiate(explosionVFX, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject, TimeKeptOnGround);
    }
    void ExplodeWithEnemy(GameObject target) {
        explosionVFX = Instantiate(explosionVFX, target.transform.position, Quaternion.identity) as GameObject;
        explosionVFX.transform.parent = target.transform;
        target.TryGetComponent<Health>(out var targetHp);
        targetHp.sufferDmg(dmg);
        Destroy(gameObject);
    }
}
