using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float delayBeforeSpawning = 3;
    [SerializeField] float spawningInterval = 2;
    [SerializeField] [Range(1,4)] int capacity = 4;

    GameObject[] pool;

    private void Start() {
        pool = new GameObject[capacity];
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning() {
        yield return new WaitForSeconds(delayBeforeSpawning);
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(spawningInterval);
        }
    }

    void Spawn() {
        for (int i = 0; i < capacity; i++)
        {
            if (pool[i] == null)
            {
                pool[i] = Instantiate(enemyPrefab, transform);
                break;
            }else if (!pool[i].activeSelf)
            {
                pool[i].SetActive(true);
                break;
            }
        }
    }
}
