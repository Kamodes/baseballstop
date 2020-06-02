using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private bool botton_bool = false;
    // Start is called before the first frame update
    void Start()
    {
        if (mors == "meet")
        {
            explain.text = (10 - successtime).ToString() + "から" + (10 + successtime).ToString() + "までにふれば\nヒット！";
        }else if(mors == "strong")
        {
            explain.text = (10 - successtime).ToString() + "から" + (10 + successtime).ToString() + "までにふれば\n２塁打！";
        }else if(mors == "superstrong")
        {
            explain.text = (10 - successtime).ToString() + "から" + (10 + successtime).ToString() + "までにふれば\nホームラン！";
        }else
        {
            explain.text = "エラーです。店員をよんでください。";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(flag == true)
        {
            time += Time.deltaTime;
        }
        timelimit_text.text = time.ToString();
    }

    public void stopbotton()
    {
        Debug.Log("stop");
        Debug.Log(botton_bool);
        if (botton_bool == true){
            flag = false;
            if ((10 - successtime) < time && (10 + successtime) > time)
            {
                if (mors == "meet")
                {
                    result.text = "ヒット！";
                }
                else if (mors == "strong")
                {
                    result.text = "２塁打！";
                }
                else if (mors == "superstrong")
                {
                    result.text = "ホームラン！";
                }
                else
                {
                    result.text = "エラーです。店員をよんでください。";
                }
            }
            else
            {
                result.text = "残念、、三振、、、";
            }
        }
        botton_bool = true;
            
    } 

    public void startbotton()
    {
        Debug.Log("start");
        Debug.Log(botton_bool);
        if(botton_bool == false)
        {
            flag = true;
            botton_text.text = "stop";
        } 

    }
}
