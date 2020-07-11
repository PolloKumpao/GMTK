using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartMov : MonoBehaviour
{

    Vector2 startPos, endPos, direction;
    Rigidbody2D myRigidbody2D;
    public float shootPower = 10f;
    private Vector2 constSpeed;
   
    void Start()
    {
        
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }

   

  

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Particula")
    //    {
    //        myRigidbody2D.velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
    //        Debug.Log("Colision");

    //    }
    //    Debug.Log("Colision");
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //myRigidbody2D.velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            Debug.Log("Colision");
            constSpeed = myRigidbody2D.velocity;

        }else if (collision.gameObject.tag == "Particula")
        {
            //myRigidbody2D.velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            Debug.Log("Colision");
            constSpeed = myRigidbody2D.velocity;

        }

    }
 
    private void Update()
    {
        while(constSpeed.magnitude > myRigidbody2D.velocity.magnitude)
        {
            Vector2 tmp;
            tmp.x = myRigidbody2D.velocity.x * 1.1f;
            tmp.y = myRigidbody2D.velocity.y * 1.1f;
            myRigidbody2D.velocity = tmp;
        }
    }
}