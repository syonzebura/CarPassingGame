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
    //Playerがゲームオーバーかを判断するフラグ変数。ゴール直前にぶつかった場合の誤作動を防ぐ
    private bool Gamesituation = true;
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

        if (this.canController == true)
        {
            //左右の動き(行動制限込み）
            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 4.5f)
            {
                velocityX = this.rightSpeed;
            }
            else if (Input.GetKey(KeyCode.LeftArrow)&&transform.position.x>-4.5f)
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
        }


        
        this.myrigid.velocity = new Vector3(velocityX, this.myrigid.velocity.y, this.speed);
    }

    //車がぶつかった時の処理
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LeftCar" || collision.gameObject.tag == "RightCar")
        {   
            this.canController = false;
            this.Gamesituation = false;
            StartCoroutine("GameOverWaitTime");
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

