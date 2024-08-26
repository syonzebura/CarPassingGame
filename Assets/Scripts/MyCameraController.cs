using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    //プレイヤーのオブジェクト
    private GameObject player;
    //playerとカメラの距離
    private float difference;

    // Start is called before the first frame update
    void Start()
    {
        //playerのオブジェクト取得
        this.player = GameObject.Find("Player");
        //Playerとカメラの位置の差を求める
        this.difference = this.player.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //playerの位置に合わせてカメラの位置を移動
        this.transform.position = new Vector3(this.player.transform.position.x, this.transform.position.y, this.player.transform.position.z - this.difference);
    }
}
