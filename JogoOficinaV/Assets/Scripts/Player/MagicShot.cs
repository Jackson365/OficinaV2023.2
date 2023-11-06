using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MagicShot : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;
    public int damage;

    public bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRight)
        {
            rig.velocity = Vector2.right * speed;
        }
        else
        {
            rig.velocity = Vector2.left * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyTest>().Damage(damage);
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider collision)
    {
        if (collision.gameObject.tag == "boss1")
        {
            collision.GetComponent<Boss1>().Damage(damage);
            Destroy(gameObject);
        }
    }
}
