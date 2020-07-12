using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public bool opened;
    SpriteRenderer imagen;
    Animation animacion;
    
    
    //public BoxCollider2D colision;
    // Start is called before the first frame update
    void Start()
    {
       opened = false;
       
       //colision =  this.GetComponents<BoxCollider2D>()[1];
       //imagendefault = imagen.sprite;



    }
    //private void OnMouseOver()
    //{
    //    if (!Input.GetMouseButton(0))
    //    {
    //        if (opened)
    //        {
    //            gameObject.GetComponent<Animator>().Play("Puerta");
    //            opened = false;
    //        }
    //        else
    //        {
    //            gameObject.GetComponent<Animator>().Play("Puerta2");
    //            opened = true;
    //        }
    //    }

    // }
    // Update is called once per frame
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up);

        // If it hits something...
        if(hit != null)
        if (hit.collider.tag == "Puerta")
        {
            //Debug.Log("Puerrtaa");
            if (Input.GetMouseButtonDown(0))
            {
                if (opened)
                {
                    hit.collider.GetComponent<Animator>().Play("Puerta2");
                        hit.collider.GetComponent<Puerta>().opened = false;
                }
                else
                {
                    hit.collider.GetComponent<Animator>().Play("Puerta");
                        hit.collider.GetComponent<Puerta>().opened = true;
                }
            }
        }

        if (opened)
        {
            gameObject.GetComponent<Animator>().PlayInFixedTime("Puerta", 1, 8.0f);
           // colision.enabled = false;
        }
        else
        {
            gameObject.GetComponent<Animator>().PlayInFixedTime("Puerta2", 1, 8.0f);
            //colision.enabled = true;
            // gameObject.GetComponent<Animator>().Play("Puerta");

        }
        //if(opened)
        //{

        //    if (!gameObject.GetComponent<Animator>().)
        //    {
        //        imagen.enabled = false;
        //        colision.enabled = false;
        //    }

        //}
        //else
        //{

        //    imagen.sprite = imagendefault;
        //    imagen.enabled = true;
        //    colision.enabled = true;
        //}
    }
 
    //private void OnMouseDown()
    //{
       
    //}
}
