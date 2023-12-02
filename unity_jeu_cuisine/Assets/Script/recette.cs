using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recette : MonoBehaviour
{




    // V�rifie que le client n'a pas encore command� (elle est utiliser dans le script jeu.cs pour ne pas qu'un client commande plus qu'une recette)
    public bool demandeNourriture = false;

    // Liste al�atoire qui d�clare les ingr�dients n�c�ssaire pour la recette (Elle se remplie lorsque le script jeu.cs d�clare qu'une table a command�)
    public List<string> ListeIngredients;

    //V�rifie le nombre d'objet dans l'assiette que la recette avait besoins
    private int bonIngredient = 0;


    //V�rifie que l'assiette qui contient les ingr�dients correspond a la recette demand� par le client
    private void OnTriggerEnter(Collider other)
    {
        //V�rifie si l'objet qui vient de rentrer en contact avec le client est une assiette et si le client voulait de la nourriture
        if (other.tag == "assiette" && demandeNourriture == true)
        {
            //Debug.Log("assiette d�tecter et nourriture voulue"); GOOD

            //loop � travers le nombre d'ingr�dients que la liste d'ingr�dients poss�de
            for (int i = 0; i <= ListeIngredients.Count-1; i++)
            {
                // Debug.Log(ListeIngredients.Count-1); GOOD
                    //loop � travers le nombre d'ingr�dients que l'assiette qui vient de rentrer en contact avec la zone poss�de
                    for (int o = 0; o <= other.GetComponent<assiette>().ingredientsArr.Count-1; o++)
                    {
                    Debug.Log(other.GetComponent<assiette>().ingredientsArr.Count - 1);
                        //V�rifie que chaque ingr�dient pr�sent dans l'assiette corespond � un ingr�dient de la recette 
                        if (ListeIngredients[i] == other.GetComponent<assiette>().ingredientsArr[o].name /*transcrit le nom des Gameobjects et non LE Gameobject btw*/) // ERREUR SI YA 2 FOIS LE MEME INGR�DIENT DANS LA RECETTE, ON A JUSTE BESOINS DE L'INGR�DIENTE 1 FOIS POUR QUE �A PASSE D:
                        {
                            //augmente de 1 si un ingredient est demand� dans la recette
                            bonIngredient++;

                            // V�rifie qu le nombre d'ingr�dients bon pour la recette correspond a la taille de la recette
                            if (bonIngredient == ListeIngredients.Count)
                            {
                                Debug.Log("recette termin�e");
                                 //Enleve les ingr�dients n�cessaire � la recette et rend pr�tes a recevoir des nouveaux ingr�dients pour une nouvelle recette
                                ListeIngredients.Clear();
                                // Loop � travers les ingr�dients dans l'assiette lorsque la recette est bonne pour faire disparaitre les ingr�dients
                                for (int u = 0; u < other.GetComponent<assiette>().ingredientsArr.Count; u++)
                                {
                                    // Fais disparaitre les ingr�dients
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
