using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingredients : MonoBehaviour
{
[Header("Objet à téléporter")]    
    public GameObject ingredient;

[Header("Endroit où téléporter")]
    public GameObject zoneIngredient;

    [Header("Est ce l'ingrédient est dans une assiette")]
    public bool ingredientPosition = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ground")
        {
            ingredient.SetActive(false);
        }

        if(other.tag == "assiette")
        {
            ingredientPosition = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "assiette")
        {
            ingredientPosition = false;
        }
    }



}
