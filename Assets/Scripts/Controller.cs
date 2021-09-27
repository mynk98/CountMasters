using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Controller : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] GameObject character;
    [SerializeField] int spawnNumber;
    bool isMoving=false;
    float maxX=1;
    float minX=-1;
    float radius;
    Character[] childs;
    float pressedX;
    public int noChilds;
    [SerializeField]Transform mainCamera;
    [SerializeField]TMP_Text childsNoText;
    public bool isAttacking = false;
    public Enemies enemies;
    Manager manager;
    [SerializeField] bool d;
    // Start is called before the first frame update
    void Start()
    {
        UpdateChilds();
        manager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        childs = GetComponentsInChildren<Character>();
        noChilds = childs.Length;
        if (noChilds == 0)
        {
            manager.AfterFight(enemies, gameObject.GetComponent<Controller>());
        }

        if (Input.GetMouseButtonDown(0))
        {
            pressedX = Input.mousePosition.x;
            isMoving = true;
            

           //Multiply(spawnNumber,d);
            
        }

        if (Input.GetMouseButton(0) && isMoving && !isAttacking)
        {

            childs = GetComponentsInChildren<Character>();
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

            mainCamera.position = new Vector3(transform.position.x / 5, mainCamera.position.y, mainCamera.position.z);
        }
        else
        {
            isMoving = false;
        }

        //UpdateChilds();

    }


    public void Multiply(int size,bool addDiff=false)
    {
        radius = Mathf.Pow(size,0.5f);
        childs = GetComponentsInChildren<Character>();

        if (!addDiff)
        {
            for (int i = 0; i < childs.Length; i++)
            {
                Destroy(childs[i].gameObject);
            }

            for (int i = 0; i < size; i++)
            {
                float z = Random.Range(-radius / 2, radius / 2);
                float x = Random.Range(-radius / 2, radius / 2);
                GameObject newCharacter = Instantiate<GameObject>(character, gameObject.transform);
                newCharacter.transform.localScale = Vector3.one;
                newCharacter.transform.localPosition = new Vector3(x, 0, z);
            }
        }
        else
        {
            for (int i = 0; i < childs.Length-size; i++)
            {
                Destroy(childs[i].gameObject);
            }

            for (int i = 0; i < size-childs.Length; i++)
            {
                float z = Random.Range(-radius / 2, radius / 2);
                float x = Random.Range(-radius / 2, radius / 2);
                GameObject newCharacter = Instantiate<GameObject>(character, gameObject.transform);
                newCharacter.transform.localScale = Vector3.one;
                newCharacter.transform.localPosition = new Vector3(x, 0, z);

            }

            for (int i = 0; i < childs.Length; i++)
            {
                childs[i].AddForce();
            }

        }

        
        childsNoText.text = size.ToString();
    }

    public void Attack(Vector3 enmy)
    {
        childs = GetComponentsInChildren<Character>();
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].Attack(enmy);
        }
        isAttacking = true;
    }

    public void StopAttack()
    {
        childs = GetComponentsInChildren<Character>();
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].StopAttacking();
        }
        isAttacking = false;
    }

    public void UpdateChilds()
    {
        noChilds = GetComponentsInChildren<Character>().Length;
        childsNoText.text = noChilds.ToString();

    }

    public int GetChildsCount()
    {
        return GetComponentsInChildren<Character>().Length;
    }

    public void AddForce()
    {
        childs = GetComponentsInChildren<Character>();
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].AddForce();
        }
    }

    
}
