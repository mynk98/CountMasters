using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool isMoving;
    [SerializeField] float speed;
    float z;
    // Start is called before the first frame update
    void Start()
    {
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            z -= Time.deltaTime * speed;
            transform.position = new Vector3(transform.position.x, transform.position.y, z);
        }
    }
}
