using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour
{
    
    public GameObject Leftothercar;
    public GameObject Rightothercar;

    // 距離を不規則にする
    private float adjustDistance=0;
    //ゴールを取得
    private GameObject Goal;

    //Playerの取得
    private GameObject player;

    //Goal-Playerの距離
    private float GPdistance;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //ゴールを取得
        this.Goal = GameObject.Find("Goal");

        //プレイヤーを取得
        this.player = GameObject.Find("Player");

        //両車線の車を生成
        for(int i = 30; i < this.Goal.transform.position.z; i += 30)
        {
            this.adjustDistance = Random.Range(-10, 10);
            GameObject lC = Instantiate(this.Leftothercar);
            //本来の位置
            //lC.transform.position = new Vector3(-2.4f, 0.5f, i+this.adjustDistance);
            lC.transform.position = new Vector3(Random.Range(-2.4f, -2.0f), 0.5f, i + this.adjustDistance);
        }

        for (float i =this.Goal.transform.position.z; i >40; i -= 150)
        {
            this.adjustDistance = Random.Range(-20, 20);
            GameObject RC = Instantiate(Rightothercar);
            //本来の位置
            //RC.transform.position = new Vector3(2.4f, 0.5f, i+this.adjustDistance);
            RC.transform.position = new Vector3(Random.Range(2.0f,2.4f), 0.5f, i + this.adjustDistance);
        }

        //右車線（対向車線）の車の追加生成。ししおどし式でupdate内でやってもよかったが、最初配置した車とタイミングが被る可能性あるためなし
        StartCoroutine("GanarateRightCar");

    }

    // Update is called once per frame
    void Update()
    {
        this.GPdistance = this.Goal.transform.position.z - this.player.transform.position.z;
    }

    //右車線（対向車線）の車の追加生成
    IEnumerator GanarateRightCar()
    {
        while (true)
        {
            float ajusttime = Random.Range(-1, 1);
            yield return new WaitForSeconds(6f + ajusttime);
            if (this.GPdistance > 300)//ゴール直前に車が生成されることを防ぐ
            {
                GameObject lC = Instantiate(this.Rightothercar);
                //本来の位置
                //lC.transform.position = new Vector3(2.4f, 0.5f, this.Goal.transform.position.z);
                lC.transform.position = new Vector3(Random.Range(2.0f, 2.4f), 0.5f, this.Goal.transform.position.z);
            }
            

        }
    }

    
}
