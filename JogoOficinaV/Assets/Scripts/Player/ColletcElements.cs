using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColletcElements : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<Player>();
            Destroy(gameObject);
        }
    }
}
