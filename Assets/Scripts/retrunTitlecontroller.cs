using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retrunTitlecontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnclickretrunBotton()
    {
        //ここはタイトル画面に戻るようにする
        SceneManager.LoadScene("TitleScene");
    }

}
