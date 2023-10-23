using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class Boss3 : MonoBehaviour
{
    public float speed;
    public float walkTime;
    public bool walkRigth = true;
    private float tempTiro;
    public float tempTiroMax = 2;
    public GameObject prefabDeTiro;

    private float timer;

    private Rigidbody2D rig;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

    }

    
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        tempTiro += Time.deltaTime;
        
        if (timer >= walkTime)
        {
            walkRigth = !walkRigth;
            timer = 0f;
        }

        if (tempTiro >= tempTiroMax)
        {
            //aqui que vai instanciar o tiro
            GameObject clone = Instantiate(prefabDeTiro, transform.GetChild(0).position, Quaternion.identity);
            if (!walkRigth)
            {
                clone.transform.Rotate(Vector3.up,180 );
            }
            
            tempTiro = 0;
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
