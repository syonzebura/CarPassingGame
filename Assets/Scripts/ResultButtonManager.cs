using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //スペースキーが押された際はリトライできるようにする
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void OnclickRetryButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void OnclickFirstButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
