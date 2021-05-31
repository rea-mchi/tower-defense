using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] int maxHp = 5;
    
    int currentHp = 5;
    
    private void OnEnable() {
        // Debug.Log($"{gameObject.name} calls onEable");
        respawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHp < 1)
        {
            gameObject.SetActive(false);
        }
    }

    public void sufferDmg(int dmg) {
        currentHp -= dmg;
    }

    void respawn() {
        currentHp = maxHp;
    }
}
