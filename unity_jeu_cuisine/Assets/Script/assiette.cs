using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assiette : MonoBehaviour
{
    // Start is called before the first frame update
    public int contenantIndex = 0;
    public List<GameObject> ingredientsArrNouveau = new List<GameObject>();
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ingredient" && other.GetComponent<ingredients>().ingredientPosition == false)
        {
            //Debug.Log("colision avec un objet!");
            if (contenantIndex <= 5)
            {
                ingredientsArrNouveau.Add(other.gameObject);
            }
            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("DÉTECTION");
        if (other.tag == "Ingredient")
        {
            Debug.Log("ingredients sort");
            ingredientsArrNouveau.Remove(ingredientsArrNouveau.Find(ingredient => ingredient.gameObject == other.gameObject));
        }
    }

}
