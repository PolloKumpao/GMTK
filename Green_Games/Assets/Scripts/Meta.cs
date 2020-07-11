using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour
{
    public int Objetivo;
    private int counter;
    public bool activo;
    public GameObject winpanel;
    // Start is called before the first frame update
    void Start()
    {
        winpanel = GameObject.FindGameObjectWithTag("Win");
        winpanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Objetivo == counter)
        {
            activo = true;
            winpanel.SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Particula")
        {
            //myRigidbody2D.velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            //Debug.Log("Colision");
            counter++;
            collision.gameObject.SetActive(false);


        }
    }
}
