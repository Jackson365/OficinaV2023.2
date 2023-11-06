using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBoss1 : MonoBehaviour
{

    public int maxHealth;

    public int currenthHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currenthHealth -= maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currenthHealth -= damage;
        
        if(currenthHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
