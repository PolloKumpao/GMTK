using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragShoot : MonoBehaviour
{

    Vector2 startPos, endPos, direction;
    Rigidbody2D myRigidbody2D;
    public float shootPower = 10f;
    private Vector2 constSpeed;
    Camera camera;
    public LineRenderer line;
    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }
    void Start()
    {
        
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        camera = Camera.main;
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }
    }

    void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            direction = startPos - endPos;
            myRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            myRigidbody2D.velocity = direction * shootPower;
            constSpeed = myRigidbody2D.velocity;
            endline();
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
    void DrawLine(Vector3 startpoint, Vector3 endpoint)
    {
        line.positionCount = 2;
        Vector3[] Allpoint = new Vector3[2];
        Allpoint[0] = startpoint;
        Allpoint[1] = endpoint;
        line.SetPositions(Allpoint);
    }
    public void endline()
    {
        line.positionCount = 0;
    }
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 currentpoint = camera.ScreenToViewportPoint(Input.mousePosition);
            currentpoint.z = 15;
            DrawLine(startPos, currentpoint);
        }
        while(constSpeed.magnitude > myRigidbody2D.velocity.magnitude)
        {
            Vector2 tmp;
            tmp.x = myRigidbody2D.velocity.x * 1.1f;
            tmp.y = myRigidbody2D.velocity.y * 1.1f;
            myRigidbody2D.velocity = tmp;
        }
    }
}