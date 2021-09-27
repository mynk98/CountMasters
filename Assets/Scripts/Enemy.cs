using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isAttacking = false;
    Transform characters;
    Rigidbody rbd;
    Platform plaform;
    [SerializeField]Manager gameManager;
    Controller controller;

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
        characters = GameObject.FindGameObjectWithTag("Characters").transform;
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<Manager>();
        controller = characters.GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.isPlaying)
        {
            transform.localEulerAngles = Vector3.zero;
            if (isAttacking)
            {
                rbd.AddForce(Vector3.Normalize(controller.GetCharactersCentroid() - transform.position) * 2.5f, ForceMode.Impulse);
            }
        }
    }

    public void Attack()
    {
        isAttacking = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Character")
        {
            GetComponentInParent<Enemies>().plaform.isMoving = false;
            Destroy(collision.gameObject);
            controller.UpdateChilds();
            GetComponentInParent<Enemies>().UpdateText();
            Destroy(gameObject);

        }
    }



}
