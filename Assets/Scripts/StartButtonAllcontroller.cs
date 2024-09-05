using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButtonAllcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //TitleSceneの処理
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("RuruScene");
            }
        }
        //RuruSceneの処理
        else if (SceneManager.GetActiveScene().name == "RuruScene")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
        
    }

    //titleからルール説明へ
    public void OnclickStartbutton()
    {
        SceneManager.LoadScene("RuruScene");
    }
    //ルール説明からゲームへ
    public void OnclickGamestartbtutton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
