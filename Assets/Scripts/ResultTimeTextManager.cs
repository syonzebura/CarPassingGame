using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultTimeTextManager : MonoBehaviour
{
    //TimeTextの取得
    private Text Timetext;

    // Start is called before the first frame update
    void Start()
    {
        this.Timetext=GetComponent<Text>();
        this.Timetext.text = "Time: 00:" + PlayerController.Opentime.ToString("F3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
