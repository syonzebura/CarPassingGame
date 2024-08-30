using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    

    // Start is called before the first frame update

    void Start()
    {
        //ココでフレームレート固定
        Application.targetFrameRate = 60;

        this.myrigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float velocityX = 0;


        if (this.canController == true|| this.Gamesituation==true)
        {
            //左右の動き(行動制限込み）
            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 4.2f)
            {
                velocityX = this.rightSpeed;
            }
            else if (Input.GetKey(KeyCode.LeftArrow)&&transform.position.x>-4.2f)
            {
                velocityX = this.leftSpeed;
            }
            //加速減速（速度制限込み）
            if (Input.GetKey(KeyCode.UpArrow)&&this.speed<50)
            {
                this.speed += 0.18f;
            }
            else if (Input.GetKey(KeyCode.DownArrow)&&this.speed>0)
            {
                this.speed -= 0.5f;
            }



            //もしも車が回転していた場合、breakCountを3にする
            //rotationはQuaternionを取得するため、eulerAnglesでわかりやすく変換
            if (this.transform.eulerAngles.y>20&&this.transform.eulerAngles.y<340)
            {
                this.breakCount+= 3;
                //810
                //Debug.Log("hit");
                
            }

            //もしもbreakCountが3になったらゲームオーバー this.Gamesituationのおかげでupdate内でコルーチン使える
            if (this.breakCount>=3)
            {
                this.canController = false;
                this.Gamesituation = false;
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
        SceneManager.LoadScene("SampleScene");

    }

    //車がゴールした際の処理
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal"&&this.Gamesituation==true)
        {
            this.canController = false;
            StartCoroutine("GameClearWaitTime");
        }
    }
    //ゴールしてから少し時間をおいてゲームクリアにする
    IEnumerator GameClearWaitTime()
    {
        this.speed = 0f;
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("SampleScene");
    }
    

}

