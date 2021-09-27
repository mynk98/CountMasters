using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public int characters;
    public int enemies;
    [SerializeField] Platform platform;
    public static bool isPlaying = true;

    // Start is called before the first frame update
    void Start()
    {
        platform = GameObject.FindGameObjectWithTag("Platform").GetComponent<Platform>();
    }

    public void AfterFight(Enemies enemy, Controller controller)
    {

        if (enemies >= characters)
        {
            enemy.GetComponentInChildren<TMP_Text>().text = (enemies - characters).ToString();
            Destroy(controller.gameObject);
            GameOver();
        }
        else
        {
            controller.Multiply(characters - enemies, true);
            print(characters - enemies);
            //controller.UpdateChilds();
            controller.isAttacking = false;
            controller.AddForce();
            controller.StopAttack();
            Destroy(enemy.gameObject);
            platform.StartAgain();

        }
    }

    public void GameOver()
    {
        print("GameOver");
        isPlaying = false;
        Time.timeScale = 0;

    }
}
