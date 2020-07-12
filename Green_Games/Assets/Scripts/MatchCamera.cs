using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class MatchCamera : MonoBehaviour
{
    [Range(-1,7)]
    public int adaptPosition;
    public bool maintainWidth;
    float defaultwidth;
    float defaultheigth;
    Vector3 CameraPos;
    private void Start()
    {
        CameraPos = Camera.main.transform.position;

        defaultheigth = Camera.main.orthographicSize;
        defaultwidth = Camera.main.orthographicSize * Camera.main.aspect;
    }
    private void Update()
    {
        if(maintainWidth)
        {
            Camera.main.orthographicSize = defaultwidth / Camera.main.aspect;

            Camera.main.transform.position = new Vector3(CameraPos.x, adaptPosition * (defaultheigth - Camera.main.orthographicSize), CameraPos.z);
        }
    }
}

