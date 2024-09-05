using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSoundManager : MonoBehaviour
{
    //AudioSourceたち
    [SerializeField] private AudioSource bgmS;
    [SerializeField] private AudioSource hitS;
    [SerializeField] private AudioSource clearS;
    

    //AudioClipたち（音源）
    [SerializeField] private AudioClip bgmC;
    [SerializeField] private AudioClip hitC;
    [SerializeField] private AudioClip clearC;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //BGMメソッド
    public void BGMse()
    {
        this.bgmS.volume= SoundController.musicVolume*0.8f;
        this.bgmS.PlayOneShot(this.bgmC);
    }
    //BGMStopメソッド
    public void BGMsestop()
    {
        this.bgmS.Stop();
    }
    //HITseメソッド
    public void HITse()
    {
        this.hitS.volume = SoundController.musicVolume * 0.8f;
        this.hitS.PlayOneShot(this.hitC);
    }
    //CLEARseメソッド
    public void CLEARse()
    {
        this.clearS.volume = SoundController.musicVolume;
        this.clearS.PlayOneShot(this.clearC);
    }
    
   
    
}
