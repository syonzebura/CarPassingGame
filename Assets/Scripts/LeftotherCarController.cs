using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftotherCarController : MonoBehaviour
{
    public float Lspeed;
    private Rigidbody myrigid;

    // Start is called before the first frame update
    void Start()
    {
        this.myrigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.myrigid.velocity = new Vector3(0, this.myrigid.velocity.y, this.Lspeed);
    }

    //ゴールに触れたら壊す
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
