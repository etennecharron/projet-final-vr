using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assiette : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] contenantArr = new GameObject[5];
    public int contenantIndex = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ingredient")
        {
            //Debug.Log("colision avec un objet!");
            if (contenantIndex <= 5)
            {
               // Debug.Log("woohoo objet détecter");
                contenantArr[contenantIndex] = other.gameObject;
               // Debug.Log(contenantArr[contenantIndex].name);
                contenantIndex++;
            }
            
        }

    }
    }
