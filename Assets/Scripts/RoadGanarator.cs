using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGanarator : MonoBehaviour
{
    public GameObject Road;
    //道の数
    public int RoadCounts;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < this.RoadCounts; i++)
        {
            GameObject RoadPrefab = Instantiate(Road);
            RoadPrefab.transform.position = new Vector3(0, 0.5f, i * 24);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
