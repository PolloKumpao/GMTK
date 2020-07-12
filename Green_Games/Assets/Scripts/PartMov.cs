using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartMov : MonoBehaviour
{

    Vector2 startPos, endPos, direction;
    Rigidbody2D myRigidbody2D;
    public float shootPower = 10f;
    private float maxSpeed = 20f;
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
            if (myRigidbody2D.velocity.magnitude < maxSpeed)
            {
                constSpeed = myRigidbody2D.velocity;
                Debug.Log(myRigidbody2D.velocity.magnitude);
            }
            else
            {
                Debug.Log(myRigidbody2D.velocity.magnitude);
                constSpeed = (myRigidbody2D.velocity.normalized * maxSpeed);
               
            }
            //myRigidbody2D.velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            //Debug.Log("Colision");
            //constSpeed = myRigidbody2D.velocity;

        }else if (collision.gameObject.tag == "+")
        {
            //myRigidbody2D.velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            //Debug.Log("Colision");
            if (myRigidbody2D.velocity.magnitude < maxSpeed)
            {
               
                constSpeed = myRigidbody2D.velocity;
                Debug.Log(myRigidbody2D.velocity.magnitude);
            }
            else
            {
               
                Debug.Log("capado");
                Debug.Log(myRigidbody2D.velocity.magnitude);
                constSpeed = (myRigidbody2D.velocity.normalized * maxSpeed);
            }

        }
        else if (collision.gameObject.tag == "-")
        {
            //myRigidbody2D.velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            //Debug.Log("Colision");
            if (myRigidbody2D.velocity.magnitude < maxSpeed)
            {
                Debug.Log("capado");
                Debug.Log(myRigidbody2D.velocity.magnitude);
                constSpeed = myRigidbody2D.velocity;
            }
            else
            {
                constSpeed = (myRigidbody2D.velocity.normalized * maxSpeed);
            }

        }

    }
 
    private void Update()
    {
        if(constSpeed.sqrMagnitude > myRigidbody2D.velocity.sqrMagnitude)
        {
            Vector2 tmp;
            tmp.x = myRigidbody2D.velocity.x * 1.1f;
            tmp.y = myRigidbody2D.velocity.y * 1.1f;
            //if(tmp.sqrMagnitude < maxSpeed)
           
            myRigidbody2D.velocity = tmp;
            
        }
        else if (constSpeed.magnitude < myRigidbody2D.velocity.sqrMagnitude)
        {
            Vector2 tmp;
            tmp.x = myRigidbody2D.velocity.x * 0.9f;
            tmp.y = myRigidbody2D.velocity.y * 0.9f;
            //if(tmp.sqrMagnitude < maxSpeed)
            myRigidbody2D.velocity = tmp;
            //Debug.Log(constSpeed.sqrMagnitude);
        }
    }
}

