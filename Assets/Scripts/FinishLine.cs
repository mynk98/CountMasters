using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            Time.timeScale = 0;
            print("Level Complete");
        }
    }
}
