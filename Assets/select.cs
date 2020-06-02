using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class select : MonoBehaviour
{
    private string select_swing;
    public Text explain_text;
    public GameObject canvas;
    float timelimit = 0.0f;
    private GameObject meet;
    private GameObject strong;
    private GameObject superstrong;
    // Start is called before the first frame update
    void Start()
    {
        GameObject meet_res = (GameObject)Resources.Load("meet");
        GameObject strong_res = (GameObject)Resources.Load("strongswing");
        GameObject superstrong_res = (GameObject)Resources.Load("superstrong");
        meet = (GameObject)Instantiate(meet_res, meet_res.transform.position, Quaternion.identity);
        strong = (GameObject)Instantiate(strong_res, strong_res.transform.position, Quaternion.identity);
        superstrong = (GameObject)Instantiate(superstrong_res, superstrong_res.transform.position, Quaternion.identity);
        meet.transform.SetParent(canvas.transform, false);
        strong.transform.SetParent(canvas.transform, false);
        superstrong.transform.SetParent(canvas.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explain()
    {
        float uppertime = 10.0f + timelimit;
        float undertime = 10.0f - timelimit;
        explain_text.text = "You Select " + select_swing + "\n" 
        + undertime + "から" + uppertime + "までにSTOPしましょう！";

    }
    
    public void Clickmeet()
    {
        timelimit = 0.5f;
        DestroyImmediate(meet.gameObject, true);
        DestroyImmediate(strong.gameObject, true);
        DestroyImmediate(superstrong.gameObject, true);
        select_swing = "meet";
        Explain();
    }

    public void Clickstrong()
    {
        timelimit = 0.3f;
        DestroyImmediate(meet.gameObject, true);
        DestroyImmediate(strong.gameObject, true);
        DestroyImmediate(superstrong.gameObject, true);
        select_swing = "strong";
        Explain();     
    }

    public void Clicksuperstrong()
    {
        timelimit = 0.1f;
        DestroyImmediate(meet.gameObject, true);
        DestroyImmediate(strong.gameObject, true);
        DestroyImmediate(superstrong.gameObject, true);
        select_swing = "superstrong";
        Explain();
    }
}
