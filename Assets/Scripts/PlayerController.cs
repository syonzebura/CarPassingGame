using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody myrigid;
    public float speed;
    public float rightSpeed;
    public float leftSpeed;

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

        

        //左右の動き
        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocityX = this.rightSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocityX = this.leftSpeed;
        }
        //加速減速
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.speed += 0.18f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            this.speed -=0.5f;
        }
        
        this.myrigid.velocity = new Vector3(velocityX, 0, this.speed);
    }
}
