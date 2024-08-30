using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftotherCarController : MonoBehaviour
{
    public float Lspeed;
    private Rigidbody myrigid;

    //Playerを取得。車が曲がったら戻すかどうかの判定のため
    private GameObject PlayerforLeft;
    //GameOverかどうかのbool。車が曲がったら戻すかどうかの判断のため
    private bool Gamestatas;

    // Start is called before the first frame update
    void Start()
    {
        this.myrigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.myrigid.velocity = new Vector3(0, this.myrigid.velocity.y, this.Lspeed);
        //GameOverかどうかのbool。車が曲がったら戻すかどうかの判断のため
        this.PlayerforLeft = GameObject.Find("Player");
        this.Gamestatas = this.PlayerforLeft.GetComponent<PlayerController>().Gamesituation;
        
    }

    //ゴールに触れたら壊す
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }

    //車が曲がったら元に戻す
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine("resetRotation");
        }
    }
    //車が曲がったら元に戻す
    IEnumerator resetRotation()
    {
        yield return new WaitForSeconds(2.0f);
        if (this.Gamestatas == true)
        {
            Vector3 firstAngle = new Vector3(0, 360, 0);
            transform.eulerAngles = firstAngle;
        }
        
    }
}
