using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSoundManager : MonoBehaviour
{
    //titleとruruのシーンでbgmが流れるようにする
    public bool DontDestroyEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        //titleとruruのシーンでbgmが流れるようにする
        if (DontDestroyEnabled)
        {
            DontDestroyOnLoad(this);

        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //titleとruruのシーンでbgmが流れるようにする
        if (SceneManager.GetActiveScene().name != "TitleScene"&& SceneManager.GetActiveScene().name != "RuruScene")
        {
            Destroy(this.gameObject);
        }

        GetComponent<AudioSource>().volume = SoundController.musicVolume;
    }
}
