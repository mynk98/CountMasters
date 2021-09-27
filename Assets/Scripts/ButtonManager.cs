using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    Platform platform;
    

    private void Start()
    {
        platform = GameObject.FindGameObjectWithTag("Platform").GetComponent<Platform>();
    }


    public void StartGame()
    {
        platform.isMoving = true;
        gameObject.SetActive(false);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Replay()
    {
        Time.timeScale = 1;
        Manager.isPlaying = true;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        //platform.isMoving = true;
        
    }
}
