using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float k;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Particula")
        {
            //myRigidbody2D.velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            //Debug.Log("Colision");
            collision.gameObject.SetActive(false);


        }else if (collision.gameObject.tag == "Player")
        {
            //myRigidbody2D.velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            //Debug.Log("Colision");
            collision.gameObject.SetActive(false);


        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Magnetismo");
        Vector3 magnetismo;
        if (collision.gameObject.tag == "Player")
        {

            magnetismo = collision.gameObject.GetComponent<Rigidbody2D>().position - this.GetComponent<Rigidbody2D>().position;
            magnetismo.z = 0;
            float magSqr = magnetismo.sqrMagnitude;
            if (magSqr > 0.0001f)
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(k * magnetismo.normalized / magSqr, ForceMode2D.Impulse);
            //magnetismo *= k;
            //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(magnetismo);
            Debug.Log("MagnetismoPlayer");


        }
        else if (collision.gameObject.tag == "Particula")
        {
            magnetismo = collision.gameObject.GetComponent<Rigidbody2D>().position - this.GetComponent<Rigidbody2D>().position;
            magnetismo.z = 0;
            float magSqr = magnetismo.sqrMagnitude;
            if (magSqr > 0.0001f)
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(k * magnetismo.normalized / magSqr, ForceMode2D.Impulse);
            //magnetismo *= k;
            //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(magnetismo);
            Debug.Log("Magnetismoparticula");

        }
    }
}
