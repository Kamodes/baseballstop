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
    private int random;
    public static float score_select = 0;//staticは一つしかないから。
    List<GameObject> botton_list = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject meet_res = (GameObject)Resources.Load("meet");
        GameObject strong_res = (GameObject)Resources.Load("strongswing");
        GameObject superstrong_res = (GameObject)Resources.Load("superstrong");
        GameObject[] ob_list = new GameObject[3] { meet_res, strong_res, superstrong_res};

        

        for (int i = 0; i < 3; i++)
        {
            random = Random.Range(1, 4);
            switch(random)
            {
                case 1:
                    meet = (GameObject)Instantiate(meet_res, ob_list[i].transform.position, Quaternion.identity);
                    meet.transform.SetParent(canvas.transform, false);
                    botton_list.Add(meet);
                    break;
                case 2:
                    strong = (GameObject)Instantiate(strong_res, ob_list[i].transform.position, Quaternion.identity);
                    strong.transform.SetParent(canvas.transform, false);
                    botton_list.Add(strong);
                    break;
                case 3:
                    superstrong = (GameObject)Instantiate(superstrong_res, ob_list[i].transform.position, Quaternion.identity);
                    superstrong.transform.SetParent(canvas.transform, false);
                    botton_list.Add(superstrong);
                    break;
                default:
                    break;
            }
        }
       
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
        audioSource = GameObject.Instantiate(audio_res, transform.position, Quaternion.identity).GetComponent<AudioSource>();
        audioSource.PlayOneShot(choiceBgm);
        timelimit = 0.1f;
        select_swing = "meet";
        //Explain();
        //Debug.Log("meet");//new!
        Invoke("Scene_Load", 0.3f);
    }

    public void Clickstrong()
    {
        GameObject audio_res = (GameObject)Resources.Load("MusicManager");
        audioSource = GameObject.Instantiate(audio_res, transform.position, Quaternion.identity).GetComponent<AudioSource>();
        audioSource.PlayOneShot(choiceBgm);
        timelimit = 0.07f;
        select_swing = "strong";
        // Explain();     
        Invoke("Scene_Load", 0.3f);
    }

    public void Clicksuperstrong()
    {
        GameObject audio_res = (GameObject)Resources.Load("MusicManager");
        audioSource = GameObject.Instantiate(audio_res, transform.position, Quaternion.identity).GetComponent<AudioSource>();
        audioSource.PlayOneShot(choiceBgm);
        timelimit = 0.03f;
        select_swing = "superstrong";
        // Explain();
        Invoke("Scene_Load", 0.3f);
    }

    public void Scene_Load()
    {
        SceneManager.LoadScene("stopwatch");
    }
}
