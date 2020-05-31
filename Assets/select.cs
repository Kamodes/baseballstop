using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class select : MonoBehaviour
{
    public GameObject meet;
    public GameObject strong;
    public GameObject superstrong;
    private string select_swing;
    public Text explain_text;
    float timelimit = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explain()
    {
        float uppertime = 10.0f + timelimit;
        float undertime = 10.0f - timelimit;
        explain_text.text = "You Select" + select_swing + "\n" 
        + undertime + "から" + uppertime + "までにSTOPしましょう！";

    }
    
    public void Clickmeet()
    {
        timelimit = 0.5f;
        Destroy(meet.gameObject);
        Destroy(strong.gameObject);
        Destroy(superstrong.gameObject);
        select_swing = "meet";
        Explain();
    }

    public void Clickstrong()
    {
        timelimit = 0.3f;
        Destroy(meet.gameObject);
        Destroy(strong.gameObject);
        Destroy(superstrong.gameObject);
        select_swing = "strong";
        Explain();     
    }

    public void Clicksuperstrong()
    {
        timelimit = 0.1f;
        Destroy(meet.gameObject);
        Destroy(strong.gameObject);
        Destroy(superstrong.gameObject);
        select_swing = "superstrong";
        Explain();
    }
}
