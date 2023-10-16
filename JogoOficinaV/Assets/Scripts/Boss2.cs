using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    public float speed;
    public float walkTime;

    private bool Timer;
    private bool walkRigth;
    private Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Timer += Time.deltaTime;
        if(Timer >= walkTime)
        {
            Timer = 0f;
        }

        if (walkRigth)
        {
            
        }
    }
}
