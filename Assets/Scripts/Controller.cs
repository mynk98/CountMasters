using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    Touch touch;
    [SerializeField] Text text;
    [SerializeField] GameObject character;
    [SerializeField] int spawnNumber;
    bool isMoving=false;
    float maxX=1;
    float minX=-1;
    float radius;
    Transform[] childs;
    float pressedX;
    public int noChilds;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetMouseButtonDown(0))
        {
            pressedX = Input.mousePosition.x;
            isMoving = true;
            

            //Multiply(spawnNumber);
        }

        if (Input.GetMouseButton(0) && isMoving)
        {

            text.text = (Input.mousePosition.x).ToString() + " " + pressedX;
            childs = GetComponentsInChildren<Transform>();
            radius = Mathf.Pow(childs.Length, 0.5f);
            maxX = 1 - radius*0.04f;
            minX = -1 + radius*0.04f;

            if (transform.position.x < maxX && Input.mousePosition.x > pressedX)
            {
                transform.position = new Vector3(transform.position.x + (Input.mousePosition.x - pressedX) * 0.003f, 0, transform.position.z);
            }
            else if (transform.position.x > minX && Input.mousePosition.x < pressedX)
            {
                transform.position = new Vector3(transform.position.x + (Input.mousePosition.x - pressedX) * 0.003f, 0, transform.position.z);
            }
            pressedX = Input.mousePosition.x;
            if (transform.position.x > maxX)
            {
                transform.position = new Vector3(maxX, 0, transform.position.z);
            }
            else if (transform.position.x < minX)
            {
                transform.position = new Vector3(minX, 0, transform.position.z);
            }


            //float t= Input.mousePosition.x/ Screen.width;
            //transform.position = new Vector3( Mathf.Lerp(minX,maxX,t), 0, transform.position.z);
            
            
        }
        else
        {
            isMoving = false;
        }
    }


    public void Multiply(int size)
    {
        radius = Mathf.Pow(spawnNumber,0.5f);
        //int c = 0;
        childs = GetComponentsInChildren<Transform>();

        for (int i = 1; i < childs.Length; i++)
        {
            Destroy(childs[i].gameObject);
        }

        for (int i = 0; i < size; i++)
        {
            float z = Random.Range(-radius/2, radius/2);
            float x = Random.Range(-radius / 2, radius / 2);
            GameObject newCharacter= Instantiate<GameObject>(character, gameObject.transform);
            newCharacter.transform.localScale = Vector3.one;
            newCharacter.transform.localPosition = new Vector3(x,0,z);
            
        }
    }
}
