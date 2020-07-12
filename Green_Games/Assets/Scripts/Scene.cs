using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
    public bool pause;
    public bool win;
    public bool lose;

    public GameObject winpanel;
    public GameObject losepanel;
    public GameObject pausepanel;
    public Meta[] metas;
    // Start is called before the first frame update
    void Start()
    {
        winpanel = GameObject.FindGameObjectWithTag("Win");
        losepanel = GameObject.FindGameObjectWithTag("Lose");
        pausepanel = GameObject.FindGameObjectWithTag("Pause");
        winpanel.SetActive(false);
        losepanel.SetActive(false);
        pausepanel.SetActive(false);
        pause = false;
        Time.timeScale = 1;
        //Meta = FindObjectsOfTypeAll<Meta>();
        
       
    }
    public void Paused()
    {
        if(pause)
        {
            pause = false;
            Time.timeScale = 1;
            pausepanel.SetActive(false);
        }
        else
        {
            pause = true;
            Time.timeScale = 0;
        }
      
    }
    // Update is called once per frame
    void Update()
    {
        if(win)
        {
            winpanel.SetActive(true);
            losepanel.SetActive(false);
            pausepanel.SetActive(false);
            Time.timeScale = 0;
        }
        else if(lose)
        {
            losepanel.SetActive(true);
            winpanel.SetActive(false);
            pausepanel.SetActive(false);
            Time.timeScale = 0;

        }
        else if(pause)
        {
            pausepanel.SetActive(true);
            losepanel.SetActive(false);
            winpanel.SetActive(false);
            

        }
        for (int i = 0; metas.Length < i; i++)
        {
            if(metas[i].activo)
            {
                win = true;
            }
            else
            {
                Debug.Log("Metas false");
                win = false;
                break;
            }
            
        }


    }
}
