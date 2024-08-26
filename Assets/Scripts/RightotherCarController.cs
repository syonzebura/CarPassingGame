using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightotherCarController : MonoBehaviour
{
    public float Rspeed;
    private Rigidbody myrigid;
    // Start is called before the first frame update
    void Start()
    {
        this.myrigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.myrigid.velocity = new Vector3(0, 0, this.Rspeed);
    }
}
