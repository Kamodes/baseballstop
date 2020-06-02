using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class select : MonoBehaviour
{
    public static string select_swing = "null";
    public Text explain_text;
    public GameObject canvas;
    public static float timelimit = 0.0f;
    private GameObject meet;
    private GameObject strong;
    private GameObject superstrong;
    public AudioClip choiceBgm;
    private AudioSource audioSource;

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
        + undertime.ToString() + "から" + uppertime.ToString() + "までにSTOPしましょう！";

    }
    
    public void Clickmeet()
    {
        GameObject audio_res = (GameObject)Resources.Load("MusicManager");
        GameObject.Instantiate(audio_res, transform.position, Quaternion.identity).GetComponent<AudioSource>().PlayOneShot(choiceBgm);
       // audioSource.PlayOneShot(choiceBgm);
        timelimit = 0.5f;
        //GameObject.Destroy(meet.gameObject);
        //GameObject.Destroy(strong.gameObject);
        //GameObject.Destroy(superstrong.gameObject);
        select_swing = "meet";
        //Explain();
        //Debug.Log("meet");//new!
        SceneManager.LoadScene("stopwatch");


    }

    public void Clickstrong()
    {
        GameObject audio_res = (GameObject)Resources.Load("MusicManager");
        audioSource = GameObject.Instantiate(audio_res, transform.position, Quaternion.identity).GetComponent<AudioSource>();
        audioSource.PlayOneShot(choiceBgm);
        timelimit = 0.3f;
        //GameObject.Destroy(meet.gameObject);
        //GameObject.Destroy(strong.gameObject);
        //GameObject.Destroy(superstrong.gameObject);
        select_swing = "strong";
        // Explain();     
        SceneManager.LoadScene("stopwatch");
    }

    public void Clicksuperstrong()
    {
        GameObject audio_res = (GameObject)Resources.Load("MusicManager");
        audioSource = GameObject.Instantiate(audio_res, transform.position, Quaternion.identity).GetComponent<AudioSource>();
        audioSource.PlayOneShot(choiceBgm);
        timelimit = 0.1f;
        //GameObject.Destroy(meet.gameObject);
        //GameObject.Destroy(strong.gameObject);
        //GameObject.Destroy(superstrong.gameObject);
        select_swing = "superstrong";
        // Explain();
        SceneManager.LoadScene("stopwatch");
    }
}
