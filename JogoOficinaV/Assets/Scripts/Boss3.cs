using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3 : MonoBehaviour
{
    public float speed;
    public float walkTime;
    public bool walkRigth = true;

    private float timer;

    private Rigidbody2D rig;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

    }

    
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        
        if (timer >= walkTime)
        {
            walkRigth = !walkRigth;
            timer = 0f;
        }

        if (walkRigth)
        {
            transform.eulerAngles = new Vector2(0, 0);
            rig.velocity = Vector2.right * speed;
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
            rig.velocity = Vector2.left * speed;
        }
        
        
        
    }
}
