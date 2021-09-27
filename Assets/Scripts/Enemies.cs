using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemies : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    public int midRow = 5;
    bool hasInitiated = false;
    Enemy[] childs;
    [SerializeField]bool isAttacking = false;
    public Platform plaform;
    TMP_Text text;
    public int enemiesCount;
    [SerializeField] Manager gameManager;
    Controller controller;
    float time = 0;
    bool istimerOn = false;
    BoxCollider bcollider;

    // Start is called before the first frame update
    void Start()
    {
        plaform = GetComponentInParent<Platform>();
        text = GetComponentInChildren<TMP_Text>();
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<Manager>();
        controller = GameObject.FindGameObjectWithTag("Characters").GetComponent<Controller>();
        bcollider = GetComponent<BoxCollider>();
        bcollider.size = new Vector3(bcollider.size.x, bcollider.size.y, midRow + 3);
    }

    // Update is called once per frame
    void Update()
    {
        childs = GetComponentsInChildren<Enemy>();
        enemiesCount =childs.Length;
        if (enemiesCount == 0 && isAttacking)
        {
            gameManager.AfterFight(gameObject.GetComponent<Enemies>(), controller);
        }

        if (istimerOn)
        {
            time += Time.deltaTime;
        }
    }

    public void Initiate(int midRow)
    {

        if (!hasInitiated)
        {
            hasInitiated = true;
            for (int i = -midRow / 2; i <= midRow / 2; i++)
            {
                GameObject newEnemy = Instantiate<GameObject>(enemy, transform);
                newEnemy.transform.localPosition = new Vector3(i, 0, 0);
            }
            for (int i = 1; i <= midRow / 2; i++)
            {
                int x = 0;
                if (i % 2 == 0)
                {
                    x = 1;
                }

                for (float j = -(midRow - i) / 2; j < ((midRow - i) / 2) + x; j++)
                {
                    if (i % 2 != 0)
                    {
                        GameObject newEnemy = Instantiate<GameObject>(enemy, transform);
                        newEnemy.transform.localPosition = new Vector3(j + 0.5f, 0, i);
                        newEnemy = Instantiate<GameObject>(enemy, transform);
                        newEnemy.transform.localPosition = new Vector3(j + 0.5f, 0, -i);
                    }
                    else
                    {
                        GameObject newEnemy = Instantiate<GameObject>(enemy, transform);
                        newEnemy.transform.localPosition = new Vector3(j, 0, i);
                        newEnemy = Instantiate<GameObject>(enemy, transform);
                        newEnemy.transform.localPosition = new Vector3(j, 0, -i);
                    }
                }
            }
            
            childs = GetComponentsInChildren<Enemy>();
            enemiesCount = childs.Length;
            text.text = enemiesCount.ToString();

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Character" && !isAttacking)
        {
            isAttacking = true;
            for (int i = 0; i < childs.Length; i++)
            {
                childs[i].Attack();
            }

            plaform.Stop();
            other.GetComponentInParent<Controller>().isAttacking = true;
            other.GetComponentInParent<Controller>().Attack(other.transform.parent.position);
            //other.GetComponentInParent<Controller>().AddForce();
            other.GetComponentInParent<Controller>().enemies = gameObject.GetComponent<Enemies>();
            //Invoke("CallAfterFight", 1);

        }

        StartTimer();
        if (time >= 5)
        {
            for (int i = 0; i < childs.Length; i++)
            {
                Destroy(childs[i]);
            }
        }
    }

    void CallAfterFight()
    {
        gameManager.AfterFight(gameObject.GetComponent<Enemies>(), controller);
    }

    void StartTimer()
    {
        istimerOn = true;
    }

    public void UpdateText()
    {
        childs = GetComponentsInChildren<Enemy>();
        enemiesCount = childs.Length;
        text.text = enemiesCount.ToString();
    }

    /*public Vector3 GetEnemiesCentroid()
    {
        float x = 0, y = 0, z = 0;
        for (int i = 0; i < childs.Length; i++)
        {
            x += childs[i].transform.position.x;
            y += childs[i].transform.position.y;
            z += childs[i].transform.position.z;
        }
        x /= childs.Length;
        y /= childs.Length;
        z /= childs.Length;

        return new Vector3(x, y, z);
    }*/




}
