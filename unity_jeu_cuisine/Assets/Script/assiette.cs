using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assiette : MonoBehaviour
{
    

    // Annonce de la variable qui va contenir les ingr�dients qui rentre et sors de l'assiette
    public List<GameObject> ingredientsArr = new List<GameObject>();
   



    // Permet de d�tecter les objets qui rentre en contact avec l'assiette
    private void OnTriggerEnter(Collider other)
    {
        // V�rifie que l'objet qui rentre en contact est un ingr�dient et qu'il n'�tait pas d�ja pr�sent dans l'assiette
        if (other.tag == "Ingredient" && other.GetComponent<ingredients>().ingredientPosition == false)
        {
            //met un maximum a la quantit� d'ingr�dients que l'assiette peut contenir
            if (ingredientsArr.Count <= 5)
            {
                // Rajoute l'ingr�dient a la list B)
                ingredientsArr.Add(other.gameObject);
            }
            
        }

    }





    //Annonce qu'un objet sors de l'assiette
    private void OnTriggerExit(Collider other)
    {
        // V�rifie que c'est bien un ingr�dient qui est rentr� en contact avec l'objet
        if (other.tag == "Ingredient")
        {
            //Trouve l'index de l'objet dans la liste et l'enl�ve
            ingredientsArr.Remove(ingredientsArr.Find(ingredient => ingredient.gameObject == other.gameObject));
        }
    }






}
