using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Particula : MonoBehaviour
{
    public Transform pivot;
    private Vector2 originPivot;
    public float springRange;
    public float maxVel;
  

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        originPivot.x = pivot.position.x;
        originPivot.y = pivot.position.y;
    }
     
    Vector2 dis;
    bool canDrag = true;
    private void OnMouseDrag()
    {
        if (!canDrag)
            return;
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dis = pos - pivot.position;
        //dis.z = 0;
        if(dis.magnitude > springRange)
        {
            dis = dis.normalized * springRange;
            
        }
       // transform.position = dis + originPivot;

    }

    private void OnMouseUp()
    {
        if (!canDrag)
            return;
        canDrag = false;

        //rb.bodyType = RigidbodyType2D.Dynamic;
        
        rb.velocity = -dis.normalized * maxVel;
        Debug.Log(rb.velocity);


    }
  
}
