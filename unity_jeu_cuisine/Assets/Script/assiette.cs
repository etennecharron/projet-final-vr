using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assiette : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] contenantArr = new GameObject[6];
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
               // Debug.Log("woohoo objet détecter");
                contenantArr[contenantIndex] = other.gameObject;
               // Debug.Log(contenantArr[contenantIndex].name);
                contenantIndex++;
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
