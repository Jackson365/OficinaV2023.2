using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTest : MonoBehaviour
{
    public int health;
    public static EnemyTest testEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int dmg)
    {
        health -= dmg;

        if(health <= 0)
        { 
            SceneManager.LoadScene("CenaTeste");
            Destroy(gameObject);
        }
    }
}
