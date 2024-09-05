using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody myrigid;
    public float speed;
    public float rightSpeed;
    public float leftSpeed;

    //Playerが操作できるかどうか判断するフラグ変数。
    private bool canController = true;
    //Playerがゲームオーバーかを判断するフラグ変数。ゴール直前にぶつかった場合の誤作動を防ぐ cameracontrollerでも使用
    public bool Gamesituation = true;
    //車がぶつかっているかどうかのフラグ変数
    private bool carcollison = false;
    //車が壊れるカウント変数
    private int breakCount = 0;

    //タイムリミットのテキスト
    private GameObject timeText;
    //タイムリミットの変数
    public float timeLimit;

    //speedcircleのゲームオブジェクト取得
    private GameObject speedcircle;

    //speedTextのオブジェクト取得
    private GameObject speedText;

    //GameOvercolorを取得
    public GameObject GameOvercolor;

    //fadeoutのため
    public GameObject Gop;

    //retrunTitlebotton削除のため
    public GameObject reTi;

    //SoundManager取得のため
    public GameObject soundManager;

    //エンジン音の取得
    private AudioSource engineSound;

    //timeのstatic化
    public static float Opentime;
    /*
    //Limtのテキスト
    private GameObject LimtText;
    //Limt点滅のタイム
    private float Limttime;
    //Limtの点滅速度
    private float LimtSpeed=0.5f;
    //Limtのテキスト
    private Text LimttextCp;
    */
    // Start is called before the first frame update

    void Start()
    {
        //ココでフレームレート固定
        Application.targetFrameRate = 60;

        this.myrigid = GetComponent<Rigidbody>();

        //タイムリミットオブジェクトを取得
        this.timeText = GameObject.Find("TimeText");

        //speedcircleを取得
        this.speedcircle = GameObject.Find("speedcircle");
        //speedtextの取得
        this.speedText = GameObject.Find("speedText");

        
        //BGMse
        this.soundManager.GetComponent<SceneSoundManager>().BGMse();

        //エンジン音の取得
        this.engineSound = GetComponent<AudioSource>();
        //エンジン音の音量調節
        this.engineSound.volume = SoundController.musicVolume*0.8f;

        /*
        //Limtオブジェクトを取得
        this.LimtText = GameObject.Find("LimtText");
        //LimtのTextコンポーネントを取得
        this.LimttextCp = this.LimtText.GetComponent<Text>();
        */
    }

    // Update is called once per frame
    void Update()
    {
        float velocityX = 0;
        //Limtの点滅を実行
        /*this.LimttextCp.color = LimtGetTextColorAlpha(this.LimttextCp.color);*/

        //エンジン音のピッチ変える
        this.engineSound.pitch = this.speed * 0.06f;

        if (this.canController == true&&this.Gamesituation==true)
        {
            //ちょっとずつ減速する
            this.speed *= 0.999f;
            //表示速度を表示
            float showSpeed = this.speed * 0.02f;
            //speedcircleを変動
            this.speedcircle.GetComponent<Image>().fillAmount = showSpeed;
            //speedTextを変動
            float speedtextspeed = this.speed * 2.5f;
            this.speedText.GetComponent<Text>().text = speedtextspeed.ToString("F0");
            //タイムリミットの計算
            this.timeLimit += Time.deltaTime;
            //タイムリミットの表示
            this.timeText.GetComponent<Text>().text = "00:" + this.timeLimit.ToString("F3");
            

            //左右の行動制限
            if (transform.position.x < -4.1f)
            {
                transform.position=new Vector3(-4.1f,transform.position.y,transform.position.z);
            }
            else if (transform.position.x > 4.1f)
            {
                transform.position = new Vector3(4.1f, transform.position.y, transform.position.z);
            }

            //左右の動き(行動制限込み）
            if ((Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D))
                && transform.position.x < 4.1f)
            {
                velocityX = this.rightSpeed;
            }
            else if ((Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A))
                &&transform.position.x>-4.2f)
            {
                velocityX = this.leftSpeed;
            }
            //加速減速（速度制限込み）
            if ((Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W))
                &&this.speed<50)
            {
                //this.speed += 0.16f;
                this.speed *= 1.005f;
            }
            else if ((Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S))
                &&this.speed>10)
            {
                //this.speed -= 0.5f;
                this.speed *= 0.99f;
            }



            //もしも車が回転していた場合、breakCountを3にする
            //rotationはQuaternionを取得するため、eulerAnglesでわかりやすく変換
            if (this.transform.eulerAngles.y>20&&this.transform.eulerAngles.y<340)
            {
                this.breakCount+= 3;
                this.timeText.GetComponent<Text>().text = "---" + "---- ";
                //Txetの色を変える
                Text textobj=this.timeText.GetComponent<Text>();
                textobj.color = new Color(1.0f, 0, 0, 1.0f);
                
                //810
                //Debug.Log("hit");

            }
            //もしもtimeLimtが0を切ったらbreakcountを3にする
            /*else if (this.timeLimit < 0)
            {
                this.breakCount += 3;
                this.timeText.GetComponent<Text>().text = "00:" + "0.000 ";
                //Txetの色を変える
                Text textobj = this.timeText.GetComponent<Text>();
                textobj.color = new Color(1.0f, 0, 0, 1.0f);
            }
            */

            //もしもbreakCountが3になったらゲームオーバー this.Gamesituationのおかげでupdate内でコルーチン使える
            if (this.breakCount>=3)
            {
                this.canController = false;
                this.Gamesituation = false;
                //ゲームオーバーならスピードメーターを変更
                this.speedText.GetComponent<Text>().text = "---";
                Text stextobj = this.speedText.GetComponent<Text>();
                stextobj.color = new Color(1.0f, 0, 0, 1.0f);

                //BGMseを止める
                this.soundManager.GetComponent<SceneSoundManager>().BGMsestop();
                

                //retruntitlebottonを消す
                Destroy(this.reTi);

                //Gameovercolorを適用する
                this.GameOvercolor.SetActive(true);

                StartCoroutine("GameOverWaitTime");
            }
            //プレイ中は車の角度を固定する
            if (this.carcollison == false)
            {
                Vector3 firstAngle = new Vector3(0, 360, 0);
                transform.eulerAngles = firstAngle;
            }
            
        }

        //810
        //Debug.Log(this.transform.rotation);
        //Debug.Log(transform.eulerAngles);
        this.myrigid.velocity = new Vector3(velocityX, this.myrigid.velocity.y, this.speed);
    }

    //車がぶつかった時breakCountを1増やす。carcolisonflagを切る
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LeftCar" || collision.gameObject.tag == "RightCar")
        {
            //HITse
            this.soundManager.GetComponent<SceneSoundManager>().HITse();
            //this.breakCount += 1;
            this.carcollison = true;
            //810
            //Debug.Log(this.breakCount);
        }
    }
    //車がぶつかり終えた時carcolissonflagを再びつける
    private void OnCollisionExit(Collision collision)
    {
        if ((collision.gameObject.tag == "LeftCar" || collision.gameObject.tag == "RightCar")&&
            breakCount<3)
        {
            /*Vector3 firstAngle = new Vector3(0, 360, 0);
            transform.eulerAngles = firstAngle;*/

            this.carcollison = false;
            
            
        }
    }

    //ぶつかってから少し時間をおいてゲームオーバーにする
    IEnumerator GameOverWaitTime()
    {
        yield return new WaitForSeconds(2.0f);
        this.Gop.GetComponent<fadeoutController>().Fadeout();
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("SampleScene");

    }

    //車がゴールした際の処理
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal"&&this.Gamesituation==true)
        {
            this.canController = false;
            //retruntitlebottonを消す
            Destroy(this.reTi);
            //BGMseを止める
            this.soundManager.GetComponent<SceneSoundManager>().BGMsestop();
            //エンジン音止める
            this.engineSound.Stop();
            //CLEARse
            this.soundManager.GetComponent<SceneSoundManager>().CLEARse();
            StartCoroutine("GameClearWaitTime");
        }
    }
    //ゴールしてから少し時間をおいてゲームクリアにする
    IEnumerator GameClearWaitTime()
    {
        Opentime = this.timeLimit;
        this.speed = 10f;
        yield return new WaitForSeconds(2.0f);
        this.Gop.GetComponent<fadeoutController>().Fadeout();
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("ResultScene");
    }

    //Limtの点滅
    /*Color LimtGetTextColorAlpha(Color color)
    {
        this.Limttime += Time.deltaTime * this.LimtSpeed * 5.0f;
        color.a = Mathf.Sin(this.Limttime);
        return color;
    }*/


    
    

}

