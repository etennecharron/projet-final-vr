using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assiette : MonoBehaviour
{
    

    // Annonce de la variable qui va contenir les ingrédients qui rentre et sors de l'assiette
    public List<GameObject> ingredientsArr = new List<GameObject>();
   



    // Permet de détecter les objets qui rentre en contact avec l'assiette
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie que l'objet qui rentre en contact est un ingrédient et qu'il n'était pas déja présent dans l'assiette
        if (other.tag == "Ingredient" && other.GetComponent<ingredients>().ingredientPosition == false)
        {
            //met un maximum a la quantité d'ingrédients que l'assiette peut contenir
            if (ingredientsArr.Count <= 5)
            {
                // Rajoute l'ingrédient a la list B)
                ingredientsArr.Add(other.gameObject);
            }
            
        }

    }





    //Annonce qu'un objet sors de l'assiette
    private void OnTriggerExit(Collider other)
    {
        // VÉrifie que c'est bien un ingrédient qui est rentré en contact avec l'objet
        if (other.tag == "Ingredient")
        {
            //Trouve l'index de l'objet dans la liste et l'enlève
            ingredientsArr.Remove(ingredientsArr.Find(ingredient => ingredient.gameObject == other.gameObject));
        }
    }






}
