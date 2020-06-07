using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class stopwatch : MonoBehaviour
{
    public Text timelimit_text;
    private float time = 0.0f;
    private float successtime = select.timelimit;
    //private float successtime = 0.3f;
    private bool flag = false;
    private string mors = select.select_swing;
    //private string mors = "strong";
    public Text explain;
    public Text result;
    public Text botton_text;
    public Text score_text;
    private bool botton_bool = false;
    public AudioClip choiceBgm2;
    public AudioClip choicekaraburi;
    private float score;
    private GameObject next;
    public GameObject canvas;
    public GameObject stopbotton_obj;
    public GameObject bases;
    public GameObject outparent;
    private static bool[] runner = new bool[3] { false, false, false }; 
    private static int outcount = 0;
    private float limit_succesTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        int random_time = Random.Range(3, 10);
        limit_succesTime = random_time;
        if (mors == "meet")
        {
            explain.text = (limit_succesTime - successtime).ToString() + "から" + (limit_succesTime + successtime).ToString() + "までにふれば\nヒット！";
        }else if(mors == "strong")
        {
            explain.text = (limit_succesTime - successtime).ToString() + "から" + (limit_succesTime + successtime).ToString() + "までにふれば\n２塁打！";
        }else if(mors == "superstrong")
        {
            explain.text = (limit_succesTime - successtime).ToString() + "から" + (limit_succesTime + successtime).ToString() + "までにふれば\nホームラン！";
        }else
        {
            explain.text = "エラーです。店員をよんでください。";
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 3; i++)
        {
            if (runner[i])
            {
                bases.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = Color.magenta;
            }
            else
            {
                bases.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = Color.gray;
            }
        }

        for (int i = 0; i < 2; i++)
        {
            if (outcount >= 1 + i)
            {
                outparent.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                outparent.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = Color.black;
            }
        }

        if (flag == true)
        {
            time += Time.deltaTime;
        }
        timelimit_text.text = time.ToString();
    }

    public void stopbotton()
    {
        score = 0;
        Debug.Log("stop");
        Debug.Log(botton_bool);
        if (botton_bool == true){
            GameObject audio_res = (GameObject)Resources.Load("MusicManager");
            flag = false;
            if ((limit_succesTime - successtime) < time && (limit_succesTime + successtime) > time)
            {
                GameObject.Instantiate(audio_res, transform.position, Quaternion.identity).GetComponent<AudioSource>().PlayOneShot(choiceBgm2);
                if (mors == "meet")
                {
                    result.text = "ヒット！";
                    if (runner[2])
                    {
                        score += 1;
                    }
                    runner[2] = runner[1];
                    runner[1] = runner[0];
                    runner[0] = true;
                }
                else if (mors == "strong")
                {
                    result.text = "２塁打！";
                    if(runner[2] && runner[1])
                    {
                        score += 2;
                    }else if(runner[1] || runner[2]){
                        score += 1;
                    }
                    runner[2] = runner[0];
                    runner[1] = true;
                    runner[0] = false;
                }
                else if (mors == "superstrong")
                {
                    result.text = "ホームラン！";
                    int count = 0;
                    for(int i = 0; i < 3; i++)
                    {
                        if (runner[i]) count++;
                    }
                    score += count + 1;
                }
                else
                {
                    result.text = "エラーです。店員をよんでください。";
                }
            }
            else
            {
                GameObject.Instantiate(audio_res, transform.position, Quaternion.identity).GetComponent<AudioSource>().PlayOneShot(choicekaraburi);
                result.text = "残念、、三振、、、";
                outcount++;
                if(outcount == 3)
                {
                    Invoke("LoadResult", 1.0f);
                }
            }
            select.score_select += score;
            score_text.text = "君のスコアは" + select.score_select.ToString();
            GameObject next_res = (GameObject)Resources.Load("Next");
            next = (GameObject)Instantiate(next_res, next_res.transform.position, Quaternion.identity);
            next.transform.SetParent(canvas.transform, false);
            Destroy(stopbotton_obj);
        }
        botton_bool = true;
    } 

    public void nextbotton()
    {
        SceneManager.LoadScene("select");
    }

    public void startbotton()
    {
        Debug.Log(select.score_select);
        if(botton_bool == false)
        {
            flag = true;
            botton_text.text = "stop";
        } 

    }

    public void LoadResult()
    {
        SceneManager.LoadScene("Result");
    }
}
