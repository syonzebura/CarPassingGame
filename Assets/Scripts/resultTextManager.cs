using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resultTextManager : MonoBehaviour
{
    //表示テキスト
    private Text resultText;
    //タイム
    private float timeresult=0;

    // Start is called before the first frame update
    void Start()
    {
        this.resultText = GetComponent<Text>();
        //Opentimeを代入
        this.timeresult = PlayerController.Opentime;
        //それぞれの判定
        if (this.timeresult > 35)
        {
            this.resultText.text = "タラタラしてんじゃねーよ";
        }
        else if (this.timeresult <= 35 && this.timeresult > 30)
        {
            this.resultText.text = "ちょっと遅くない？";
        }
        else if (this.timeresult <= 30 && this.timeresult > 25)
        {
            this.resultText.text = "まあまあね";
        }
        else if (this.timeresult <= 25 && this.timeresult > 17)
        {
            this.resultText.color = Color.yellow;
            this.resultText.text = "やるじゃない！";
        }
        else if (this.timeresult <= 17)
        {
            this.resultText.color = new Color(1.0f, 0, 0, 1.0f);
            this.resultText.text = "一発免停";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
