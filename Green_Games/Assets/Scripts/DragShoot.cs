using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragShoot : MonoBehaviour
{

    Vector3 startPos, endPos, direction;
    Rigidbody2D myRigidbody2D;
    public float maxRange;
    private float shootPower = 4f;
    private Vector2 constSpeed;
    bool isPressed;
    bool canDrag = true;
    Camera camera;
    Vector3 currentpoint,oposite;
    public LineRenderer line;
    public AudioSource thorwFX;
    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }
    void Start()
    {
        
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        camera = Camera.main;
        startPos = myRigidbody2D.position;
        thorwFX = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(canDrag)
            {
                startPos = camera.ScreenToWorldPoint(Input.mousePosition);
                isPressed = true;
            }
           
        }
    }

    void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (canDrag)
            {
                endPos = currentpoint;
                direction = startPos - endPos;
                myRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                myRigidbody2D.velocity = direction * shootPower;
                constSpeed = myRigidbody2D.velocity;
                endline();
                isPressed = false;
                canDrag = false;
                thorwFX.Play();
            }
        }
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
        if (collision.gameObject.tag == "Particula")
        {
            //myRigidbody2D.velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            //Debug.Log("Colision");

        }
      
    }
    void DrawLine()
    {
        //line.positionCount = 2;
        Vector3[] Allpoint = new Vector3[2];
        Allpoint[0] = startPos;
        Allpoint[1] = oposite;
        line.SetPositions(Allpoint);
    }
    public void endline()
    {
        line.enabled = false;
    }
    private void Update()
    {
        if(isPressed)
        {
            currentpoint = camera.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(startPos,currentpoint) > maxRange)
            {
                Vector3 direction = (currentpoint - startPos).normalized;
                direction.z = 0;
                currentpoint = startPos + direction * maxRange;
                oposite = currentpoint + (2 * (startPos - currentpoint));
                oposite.z = 0;
                currentpoint.z = 0;
                DrawLine();
               // Debug.Log("Rango superado");
            }
            else
            {
                oposite = currentpoint + (2 * (startPos - currentpoint));
                oposite.z = 0;
                currentpoint.z = 0;
                DrawLine();
              //  Debug.Log("por debajo del rango");
            }
            
        }
        if(constSpeed.magnitude > myRigidbody2D.velocity.magnitude)
        {
            Vector2 tmp;
            tmp.x = myRigidbody2D.velocity.x * 1.1f;
            tmp.y = myRigidbody2D.velocity.y * 1.1f;
            myRigidbody2D.velocity = tmp;
        }else if (constSpeed.magnitude < myRigidbody2D.velocity.sqrMagnitude)
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