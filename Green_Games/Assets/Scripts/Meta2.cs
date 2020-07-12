using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meta2 : MonoBehaviour
{
    public int Objetivo;
    private int counter;
    public bool activo;
    public Scene scene;
    public Text contador;
    // Start is called before the first frame update
    void Start()
    {
        //winpanel = GameObject.FindGameObjectWithTag("Win");
        //winpanel.SetActive(false);
        scene = GameObject.FindGameObjectWithTag("Manager").GetComponent<Scene>();
        contador.text = Objetivo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        contador.text = Objetivo.ToString();
        if (Objetivo <= 0)
        {
            activo = true;
            //winpanel.SetActive(true);
            scene.win = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "+")
        {
            //myRigidbody2D.velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            //Debug.Log("Colision");
            Objetivo++;
            collision.gameObject.SetActive(false);


        }
        else if (collision.gameObject.tag == "-")
        {
            //myRigidbody2D.velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            //Debug.Log("Colision");
            Objetivo--;
            collision.gameObject.SetActive(false);


        }
        else if (collision.gameObject.tag == "Player")
        {
            //myRigidbody2D.velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            //Debug.Log("Colision");
            Objetivo++  ;
            collision.gameObject.SetActive(false);


        }
    }
}
