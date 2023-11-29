using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recette : MonoBehaviour
{
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "assiette")
        {
            Debug.Log("assiette détecter");
        
        if (other.GetComponent<assiette>().contenantArr[0].name == "avocat")
        {
            Debug.Log("OH MON DIEUX UNE ASSIETTE AVEC UN AVOCAT");
        }
        {

        }
        }
    }

}
