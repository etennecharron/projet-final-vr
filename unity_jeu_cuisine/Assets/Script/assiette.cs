using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assiette : MonoBehaviour
{
    

    // Annonce de la variable qui va contenir les ingredients qui rentre et sors de l'assiette
    public List<GameObject> ingredientsArr = new List<GameObject>();
   



    // Permet de detecter les objets qui rentre en contact avec l'assiette
    private void OnTriggerEnter(Collider other)
    {
        // Verifie que l'objet qui rentre en contact est un ingredient et qu'il n'etait pas deja present dans l'assiette
        if (other.tag == "Ingredient" && other.GetComponent<ingredients>().ingredientPosition == false)
        {
            //met un maximum a la quantite d'ingredients que l'assiette peut contenir
            if (ingredientsArr.Count <= 5)
            {
                // Rajoute l'ingredient a la list B)
                ingredientsArr.Add(other.gameObject);
            }
            
        }

    }





    //Annonce qu'un objet sors de l'assiette
    private void OnTriggerExit(Collider other)
    {
        // Verifie que c'est bien un ingredient qui est rentre en contact avec l'objet
        if (other.tag == "Ingredient")
        {
            //Trouve l'index de l'objet dans la liste et l'enleve
            ingredientsArr.Remove(ingredientsArr.Find(ingredient => ingredient.gameObject == other.gameObject));
        }
    }






}
