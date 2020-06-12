using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeManager : MonoBehaviour
{
    public static bool mode = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void easy()
    {
        mode = true;
        SceneManager.LoadScene("select");
    }

    public void hard()
    {
        mode = false;
        SceneManager.LoadScene("select");
    }
}
