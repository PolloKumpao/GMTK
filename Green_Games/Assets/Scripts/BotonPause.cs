using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonPause : MonoBehaviour
{
    public Scene scene;
    public Image imagen;
    public Sprite Play;
    public Sprite Pause;
    // Start is called before the first frame update
    void Start()
    {
        scene = GameObject.FindGameObjectWithTag("Manager").GetComponent<Scene>();
    }

    // Update is called once per frame
    void Update()
    {
        if(scene.pause)
        {
            imagen.sprite = Play;
        }
        else 
        {
            imagen.sprite = Pause;
        }
        
    }
}
