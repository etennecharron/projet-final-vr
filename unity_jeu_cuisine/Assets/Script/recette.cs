using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recette : MonoBehaviour
{

    public string[] recette01 = new string[1];

    public bool demandeNourriture = false;
    private int bonIngredient = 0;
    public GameObject objetRecette;
    public int numeroRecette;

    public List<string> ListeIngredients;

    /**
    private GameObject[] recetteChoisis; 

    private void selectionRecette()
    {
        recetteChoisis = objetRecette.GetComponent<receuil_recettes>().recette01;
    }
    **/

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "assiette")
        {
            Debug.Log("assiette détecter");
        
            for (int i = 0; i < recette01.Length; i++)
            {
                for (int o = 0; o < other.GetComponent<assiette>().ingredientsArrNouveau.Count;o++)
                {
                   
                    if (recette01[i] == other.GetComponent<assiette>().ingredientsArrNouveau[o].name) 
                    {    
                        bonIngredient++;
                        Debug.Log(bonIngredient);
                        Debug.Log(recette01.Length);
                        if (bonIngredient == recette01.Length)
                        {
                            Debug.Log("recette terminée");
                            for(int u = 0; u < other.GetComponent<assiette>().ingredientsArrNouveau.Count;u++)
                            {
                                other.GetComponent<assiette>().ingredientsArrNouveau[u].gameObject.SetActive(false);
                            }
                            
                        }
                    }
                }
                
            }
        {

        }
        }
    }

}
