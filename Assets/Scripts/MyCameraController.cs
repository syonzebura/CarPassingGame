using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    //プレイヤーのオブジェクト
    private GameObject player;
    //playerとカメラの距離
    private float difference;
    //PlayerControllerのGamesituationを代入するためのbool
    private bool Gs;

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
        //810
        //Debug.Log(this.Gs);
        //playerの位置に合わせてカメラの位置を移動
        this.transform.position = new Vector3(this.player.transform.position.x, this.transform.position.y, this.player.transform.position.z - this.difference);
        //PlayerControllerのGamesituationを代入
        this.Gs = this.player.GetComponent<PlayerController>().Gamesituation;
        //もしゲームオーバーになったら、以下を実行
        if (this.Gs == false)
        {
            //プレイヤーの子オブジェクトになる
            this.gameObject.transform.parent = this.player.transform;
            //スクリプトのチェックを外す
            GetComponent<MyCameraController>().enabled = false;
        }
        
        
    }
}
