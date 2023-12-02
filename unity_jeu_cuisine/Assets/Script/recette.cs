using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recette : MonoBehaviour
{




    // Vérifie que le client n'a pas encore commandé (elle est utiliser dans le script jeu.cs pour ne pas qu'un client commande plus qu'une recette)
    public bool demandeNourriture = false;

    // Liste aléatoire qui déclare les ingrédients nécéssaire pour la recette (Elle se remplie lorsque le script jeu.cs déclare qu'une table a commandé)
    public List<string> ListeIngredients;

    //Vérifie le nombre d'objet dans l'assiette que la recette avait besoins
    private int bonIngredient = 0;


    //Vérifie que l'assiette qui contient les ingrédients correspond a la recette demandé par le client
    private void OnTriggerEnter(Collider other)
    {
        //Vérifie si l'objet qui vient de rentrer en contact avec le client est une assiette et si le client voulait de la nourriture
        if (other.tag == "assiette" && demandeNourriture == true)
        {
            //Debug.Log("assiette détecter et nourriture voulue"); GOOD

            //loop à travers le nombre d'ingrédients que la liste d'ingrédients possède
            for (int i = 0; i <= ListeIngredients.Count-1; i++)
            {
                // Debug.Log(ListeIngredients.Count-1); GOOD
                    //loop à travers le nombre d'ingrédients que l'assiette qui vient de rentrer en contact avec la zone possède
                    for (int o = 0; o <= other.GetComponent<assiette>().ingredientsArr.Count-1; o++)
                    {
                    Debug.Log(other.GetComponent<assiette>().ingredientsArr.Count - 1);
                        //Vérifie que chaque ingrédient présent dans l'assiette corespond à un ingrédient de la recette 
                        if (ListeIngredients[i] == other.GetComponent<assiette>().ingredientsArr[o].name /*transcrit le nom des Gameobjects et non LE Gameobject btw*/) // ERREUR SI YA 2 FOIS LE MEME INGRÉDIENT DANS LA RECETTE, ON A JUSTE BESOINS DE L'INGRÉDIENTE 1 FOIS POUR QUE ÇA PASSE D:
                        {
                            //augmente de 1 si un ingredient est demandé dans la recette
                            bonIngredient++;

                            // Vérifie qu le nombre d'ingrédients bon pour la recette correspond a la taille de la recette
                            if (bonIngredient == ListeIngredients.Count)
                            {
                                Debug.Log("recette terminée");
                                 //Enleve les ingrédients nécessaire à la recette et rend prêtes a recevoir des nouveaux ingrédients pour une nouvelle recette
                                ListeIngredients.Clear();
                                // Loop à travers les ingrédients dans l'assiette lorsque la recette est bonne pour faire disparaitre les ingrédients
                                for (int u = 0; u < other.GetComponent<assiette>().ingredientsArr.Count; u++)
                                {
                                    // Fais disparaitre les ingrédients
                                    other.GetComponent<assiette>().ingredientsArr[u].gameObject.SetActive(false);
                                }

                            }
                        else
                        {
                            Debug.Log("mauvais recette");
                        }
                        }
                    }
            }
        }
    }




    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "assiette")
        {
            bonIngredient = 0;
        }
    }






}
