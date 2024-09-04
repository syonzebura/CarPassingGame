using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeoutController : MonoBehaviour
{
    public bool isFadeout=false;//フェードアウトのフラグ

    private float alpha = 0.0f;//透過率
    private float fadeSpeed = 0.4f;//フェードにかかる時間

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isFadeout);
        //Debug.Log(alpha);
        if (isFadeout)
        {
            alpha += Time.deltaTime / this.fadeSpeed;
            if (alpha >= 1.0f)//真っ黒になったら
            {
                isFadeout = false;
                alpha = 1.0f;
            }
            this.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
    }

    public void GameOverFadeout()
    {
        this.isFadeout = true;

    }
}
