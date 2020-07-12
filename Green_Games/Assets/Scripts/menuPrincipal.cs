using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuPrincipal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void play()
    {
        SceneManager.LoadScene(2);
    }
    public void levelSelect()
    {
        SceneManager.LoadScene(1);
    }
    public void exit( )
    {
        Application.Quit();
    }
    public void menu()
    {
        SceneManager.LoadScene(0);
    }
}
