using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Rigidbody rbd;
    bool needForce;
    float currentTime=0;
    int c = 0;

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
        AddForce();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = Vector3.zero;
        //GetComponent<Rigidbody>().velocity = Vector3.zero;
        if (needForce)
        {
            currentTime += Time.deltaTime;
            rbd.AddForce(-Vector3.Normalize(transform.localPosition)*2, ForceMode.Impulse);
            if (currentTime >= 1.5f)
            {
                needForce = false;
                currentTime = 0;
            }
        }
    }


    public void AddForce()
    {
        needForce = true;
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        needForce = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        needForce = true;
    }*/

}
