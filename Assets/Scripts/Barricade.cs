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
        
        if (other.gameObject.tag == "Character" && !GetComponentInParent<Barricades>().hasCollided)
        {
            GetComponentInParent<Barricades>().hasCollided = true;
            if (operation == operations.add)
            {
                multiplier = other.transform.parent.GetComponentsInChildren<Character>().Length + value;
            }
            else
            {
                multiplier = (other.transform.parent.GetComponentsInChildren<Character>().Length) * value;
            }

            Controller controller = other.GetComponentInParent<Controller>();
            controller.Multiply(multiplier);
            
            

        }
    }
}
