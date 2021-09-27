using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Rigidbody rbd;
    bool needForce;
    float currentTime=0;
    bool isAttacking = false;
    Vector3 enemies;

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
        AddForce();
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.isPlaying)
        {
            transform.localEulerAngles = Vector3.zero;
            //GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (needForce)
            {
                currentTime += Time.deltaTime;
                rbd.AddForce(-Vector3.Normalize(transform.localPosition) * 2, ForceMode.Impulse);
                if (currentTime >= 1.5f)
                {
                    needForce = false;
                    currentTime = 0;
                }
            }

            if (isAttacking)
            {
                rbd.AddForce(Vector3.Normalize(enemies - transform.position)*2, ForceMode.Impulse);
            }
        }

        
    }


    public void AddForce()
    {
        needForce = true;
    }

    public void Attack(Vector3 enmy)
    {
        isAttacking = true;
        enemies = enmy;
    }

    public void StopAttacking()
    {
        isAttacking = false;
    }

    
    

}
