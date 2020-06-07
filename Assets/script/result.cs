using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result : MonoBehaviour
{
    public Text result_text;
    private float result_score;  
    // Start is called before the first frame update
    void Start()
    {
        result_score = select.score_select;
        result_text.text = "残念！３アウト！\n君の最終スコアは " + result_score.ToString() + "だよ！";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
