using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishLine : MonoBehaviour
{
    [SerializeField]GameObject levelComplete;
    [SerializeField] TMP_Text scoreText;
    Controller controller;
    bool isLevelComplete=false;

    private void Start()
    {
        //levelComplete = GameObject.FindGameObjectWithTag("Level Complete");
        controller = GameObject.FindGameObjectWithTag("Characters").GetComponent<Controller>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            if (!isLevelComplete)
            {
                isLevelComplete = true;
                Time.timeScale = 0;
                scoreText.text = "Score: " + (Manager.score + controller.GetComponentsInChildren<Character>().Length).ToString();
                print(Manager.score);
                print(controller.GetComponentsInChildren<Character>().Length);
                Manager.score += controller.noChilds;
                levelComplete.SetActive(true);
            }
        }
    }
}
