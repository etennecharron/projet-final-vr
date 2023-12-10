using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingredients : MonoBehaviour
{
    // Déclarer l'objet qui va être téléporter
[Header("Objet à téléporter")]    
    public GameObject ingredient;

    //L'endroit que l'objet doit être téléporter à
    [Header("Endroit où téléporter")]
    public GameObject scriptSpawn;

    //Vérifie que l'objet est dans une assiette (La variable est utilisé pour le script Assiette qui détecte la présence de l'ingrédient dans l'assiette)
    [Header("Est ce l'ingrédient est dans une assiette")]
    public bool ingredientPosition = false;

    //Vérifie si l'objet rentre en contact avec un objet
    private void OnTriggerEnter(Collider other)
    {

        //Vérifie si l'objet rencontrer possède le tag ground (Tag appliqué au plancher du jeu) 
        if (other.tag == "ground")
        {
            // Si l'objet rencontré est le planché, l'objet désigné pour être téléporter sera téléporter à la zone désigné comme endroit où être téléporter
            scriptSpawn.GetComponent<spawner>().enfants.Remove(ingredient);
            Destroy(ingredient);
        }

        //Vérifie si l'ingrédient rentre en contact avec unne assiette 
        if(other.tag == "assiette")
        {
            // si elle est rentré en contact avec un assiette, déclare qu'elle l'est
            ingredientPosition = true;
        }
    }

    
    //Vérifie si l'objet sors d'un autre objet
    private void OnTriggerExit(Collider other)
    {
        // Vérifie si l'ingrédient est sortie d'une assiette
        if (other.tag == "assiette")
        {
            // déclare que l'ingrédient n'est présentement plus dans l'assiette
            ingredientPosition = false;
        }
    }


}
