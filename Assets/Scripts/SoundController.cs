using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundController : MonoBehaviour
{
    //全シーン共通のサウンド変数
    public static float musicVolume=0.3f;

    //sliderを代入するため
    private Slider slider;


    // Start is called before the first frame update
    void Start()
    {
        this.slider = GetComponent<Slider>();
        this.slider.value = musicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        //スライダーに合わせてmusicvolumeを変動
         musicVolume= this.slider.value;
        //Debug.Log(musicVolume);
        
    }
}
