using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleStroll : MonoBehaviour
{
    public float speed =-5 ;

    public float destroyX;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return;
        }
        
        if (transform.position.x<destroyX)
        {
            Destroy(gameObject);
        }
    }

   
    
   
}
