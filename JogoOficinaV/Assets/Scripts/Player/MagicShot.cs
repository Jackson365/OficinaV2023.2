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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.GetComponent<Boss1>().Damage(damage);
                Destroy(gameObject);
            }

            if (collision.gameObject.tag == "Enemy")
            {
                collision.GetComponent<Boss2>().Damage(damage);
                Destroy(gameObject);
            }

            if (collision.gameObject.tag == "Enemy")
            {
                collision.GetComponent<Boss3>().Damage(damage);
                Destroy(gameObject);
            }
        }

    }
}
