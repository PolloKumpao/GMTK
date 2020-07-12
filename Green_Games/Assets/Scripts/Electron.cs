using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electron : MonoBehaviour
{
    //GameObject Player;
    // Start is called before the first frame update
    public float k;
    void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
 
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("Magnetismo");
        Vector3 magnetismo;
        if (collision.gameObject.tag == "Player")
        {

            magnetismo = collision.gameObject.GetComponent<Rigidbody2D>().position - this.GetComponent<Rigidbody2D>().position;
            magnetismo.z = 0;
            float magSqr = magnetismo.sqrMagnitude;
            if (magSqr > 0.0001f)
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(k * magnetismo.normalized * -1 / magSqr, ForceMode2D.Impulse);
            //magnetismo *= k;
            //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(magnetismo);
            //Debug.Log("MagnetismoPlayer");


        }
        else if (collision.gameObject.tag == "+")
        {
            magnetismo = collision.gameObject.GetComponent<Rigidbody2D>().position - this.GetComponent<Rigidbody2D>().position;
            magnetismo.z = 0;
            float magSqr = magnetismo.sqrMagnitude;
            if (magSqr > 0.0001f)
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(k * magnetismo.normalized / magSqr, ForceMode2D.Impulse);
            //magnetismo *= k;
            //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(magnetismo);
            //Debug.Log("Magnetismoparticula");

        }
        else if (collision.gameObject.tag == "-")
        {
            magnetismo = collision.gameObject.GetComponent<Rigidbody2D>().position - this.GetComponent<Rigidbody2D>().position;
            magnetismo.z = 0;
            float magSqr = magnetismo.sqrMagnitude;
            if (magSqr > 0.0001f)
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(k * magnetismo.normalized*-1 / magSqr, ForceMode2D.Impulse);
            //magnetismo *= k;
            //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(magnetismo);
            //Debug.Log("Magnetismoparticula");

        }

    }
   
}
