using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Barricade : MonoBehaviour
{
    enum operations
    {
        multiply,
        add
    }

    [SerializeField]operations operation;
    [SerializeField] int value;
    TMP_Text text;
    int multiplier;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        if (operation == operations.multiply)
        {
            text.text = "x" + value;
        }
        else
        {
            text.text = "+" + value;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            if (operation == operations.add)
            {
                multiplier = other.transform.parent.GetComponentsInChildren<Transform>().Length + value - 1;
            }
            else
            {
                multiplier = (other.transform.parent.GetComponentsInChildren<Transform>().Length - 1) * value;
            }

            other.GetComponentInParent<Controller>().Multiply(multiplier);
        }
    }
}
