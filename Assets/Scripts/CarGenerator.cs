using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour
{
    
    public GameObject Leftothercar;
    public GameObject Rightothercar;

    // 距離を不規則にする(まだ未使用）
    private float adjustDistance=0;
    //ゴールを取得
    private GameObject Goal;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //ゴールを取得
        this.Goal = GameObject.Find("Goal");

        //両車線の車を生成
        for(int i = 30; i < 200; i += 30)
        {
            GameObject lC = Instantiate(this.Leftothercar);
            lC.transform.position = new Vector3(-2.5f, 0.5f, i);
        }

        for (float i =this.Goal.transform.position.z; i >40; i -= 100)
        {
            GameObject RC = Instantiate(Rightothercar);
            RC.transform.position = new Vector3(2.5f, 0.5f, i);
        }

        //右車線（対向車線）の車の追加生成
        StartCoroutine("GanarateRightCar");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //右車線（対向車線）の車の追加生成
    IEnumerator GanarateRightCar()
    {
        while (true)
        {
            yield return new WaitForSeconds(7f);
            GameObject lC = Instantiate(this.Rightothercar);
            lC.transform.position= new Vector3(2.5f, 0.5f, this.Goal.transform.position.z);
            
        }
    }

    
}
