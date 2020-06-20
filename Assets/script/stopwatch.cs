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
    public Text start_text;
    public Text carsol_text1;
    public Text carsol_text2;
    private bool botton_bool = false;
    public AudioClip choiceBgm2;
    public AudioClip choicekaraburi;
    public AudioClip rightHome;
    public AudioClip monkuHome;
    public AudioClip utta;
    private float score;
    private GameObject next;
    public GameObject canvas;
    public GameObject stopbotton_obj;
    public GameObject bases;
    public GameObject outparent;
    public GameObject ball;
    public GameObject dest;
    public GameObject hitdest;
    public GameObject hitdest_right;
    private static bool[] runner = new bool[3] { false, false, false }; 
    private static int outcount = 0;
    private float limit_succesTime = 5.0f;
    private Vector3 ballposition;
    private Vector3 destposition;
    private float desttime = 0.5f;
    private bool hit = false;
    private bool mode_stopwatch = ModeManager.mode;
    private bool carsol = false;
    private Vector3 carsolposition;
    private bool timeflag;
    // Start is called before the first frame update
    void Start()
    {
        int random_time = Random.Range(3, 7);
        limit_succesTime = random_time;
        if (mors == "meet")
        {
            explain.text = limit_succesTime.ToString() + "ちょうどを狙え！\n" + (limit_succesTime - successtime).ToString() + "から" + (limit_succesTime + successtime).ToString() + "までにふれば\nヒット！";
        }else if(mors == "strong")
        {
            explain.text = limit_succesTime.ToString() + "ちょうどを狙え！\n" + (limit_succesTime - successtime).ToString() + "から" + (limit_succesTime + successtime).ToString() + "までにふれば\n２塁打！";
        }else if(mors == "superstrong")
        {
            explain.text = limit_succesTime.ToString() + "ちょうどを狙え！\n" + (limit_succesTime - successtime).ToString() + "から" + (limit_succesTime + successtime).ToString() + "までにふれば\nホームラン！";
        }else
        {
            explain.text = "エラーです。店員をよんでください。";
        }
        ballposition = ball.transform.position;
        destposition = dest.transform.position;
        carsolposition = new Vector3(0.1f, 0.8f, -8.0f);
        GameObject carsol_res = (GameObject)Resources.Load("carsol");
        GameObject.Instantiate(carsol_res, carsolposition, Quaternion.identity);
        timeflag = true;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 3; i++)
        {
            if (runner[i])
            {
                bases.transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.magenta;
            }
            else
            {
                bases.transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.gray;
            }
        }

        for (int i = 0; i < 2; i++)
        {
            if (outcount >= 1 + i)
            {
                outparent.transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.red;
            }
            else
            {
                outparent.transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.black;
            }
        }

        if (flag == true)
        {
            time += Time.deltaTime;
        }

        if (mode_stopwatch)
        {
            timelimit_text.text = time.ToString();
        }
        else
        {
           if(time < 2.5f)
            {
                timelimit_text.text = "HardMode!!得点２倍！\n" + time.ToString();
            }
            else if (timeflag)
            {
                timelimit_text.text = "HardMode!!得点２倍！";
            }

        }

        if((time > limit_succesTime - desttime) && (hit == false))
        {
            ball.transform.position = ball.transform.position + (destposition - ballposition) * Time.deltaTime / desttime;
        }

        if(time > limit_succesTime && time <= (limit_succesTime + Time.deltaTime))
        {
            Debug.Log(ball.transform.position);
        }
    }

    public void stopbotton()
    {
        score = 0;
        if (botton_bool == true){
            GameObject audio_res = (GameObject)Resources.Load("MusicManager");
            flag = false;
            timeflag = false;
            start_text.text = "";
            timelimit_text.text = "HardMode!!得点２倍！\n" + time.ToString();
            if (carsol == false)
            {
                if ((limit_succesTime - successtime) < time && (limit_succesTime + successtime) > time)
                {
                    GameObject.Instantiate(audio_res, transform.position, Quaternion.identity).GetComponent<AudioSource>().PlayOneShot(choiceBgm2);
                    this.gameObject.GetComponent<AudioSource>().volume = 1.0f;
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
                        GameObject.Instantiate(audio_res, transform.position, Quaternion.identity).GetComponent<AudioSource>().PlayOneShot(utta);
                        if ((time - limit_succesTime + successtime) < successtime + 0.03f)
                        {
                            ball.GetComponent<Rigidbody>().velocity = (hitdest.transform.position - destposition) - new Vector3(0, 15, 15);
                        }
                        else
                        {
                            ball.GetComponent<Rigidbody>().velocity = (hitdest_right.transform.position - destposition) - new Vector3(0, 15, 15);
                        }
                    
                    }
                    else if (mors == "strong")
                    {
                        result.text = "２塁打！";
                        GameObject.Instantiate(audio_res, transform.position, Quaternion.identity).GetComponent<AudioSource>().PlayOneShot(utta);
                        if (runner[2] && runner[1])
                        {
                            score += 2;
                        }else if(runner[1] || runner[2]){
                            score += 1;
                        }
                        runner[2] = runner[0];
                        runner[1] = true;
                        runner[0] = false;
                        if ((time - limit_succesTime + successtime) < successtime + 0.02f)
                        {
                            ball.GetComponent<Rigidbody>().velocity = (hitdest.transform.position - destposition) - new Vector3(0, 10, 15);
                        }
                        else
                        {
                            ball.GetComponent<Rigidbody>().velocity = (hitdest_right.transform.position - destposition) - new Vector3(0, 10, 15);
                        }
                    }
                    else if (mors == "superstrong")
                    {
                        result.text = "ホームラン！";
                        int count = 0;
                        for(int i = 0; i < 3; i++)
                        {
                            if (runner[i])
                            {
                                count++;
                                runner[i] = false;
                            }
                        }
                        score += count + 1;
                        if ((time - limit_succesTime + successtime) < successtime + 0.01f)
                        {
                            ball.GetComponent<Rigidbody>().velocity = (hitdest.transform.position - destposition);
                            GameObject.Instantiate(audio_res, transform.position, Quaternion.identity).GetComponent<AudioSource>().PlayOneShot(monkuHome);
                        }
                        else
                        {
                            ball.GetComponent<Rigidbody>().velocity = (hitdest_right.transform.position - destposition);
                            GameObject.Instantiate(audio_res, transform.position, Quaternion.identity).GetComponent<AudioSource>().PlayOneShot(rightHome);
                        }
                    }
                    else
                    {
                        result.text = "エラーです。\n店員をよんでください。";
                    }
                    ball.GetComponent<Rigidbody>().useGravity = true;
                    hit = true;
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
            }else
            {

            }
                

            if (mode_stopwatch)
            {
                select.score_select += score;
            }
            else
            {
                select.score_select += 2 * score;
            }
            
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
        if(botton_bool == false)
        {
            flag = true;
            start_text.text = "start!!";
            botton_text.text = "stop";
            carsol_text1.text = "";
            carsol_text2.text = "";
        } 

    }

    public void LoadResult()
    {
        SceneManager.LoadScene("Result");
    }
}
