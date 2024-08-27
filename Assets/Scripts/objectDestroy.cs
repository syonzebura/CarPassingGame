using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectDestroy : MonoBehaviour
{
    //プレイヤーの位置参照して、プレイヤーよりオブジェクトを削除する

    private GameObject player;
    private float safetyLine = 50f;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < this.player.transform.position.z - this.safetyLine)
        {
            Destroy(this.gameObject);
        }
    }
}
