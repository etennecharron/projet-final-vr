using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jeu : MonoBehaviour
{
   
    [Header("Zone ou recevoir le repas")]
    public GameObject[] zonesRepas;
    [Header("Object contenant le script qui contient les recettes")]
    public GameObject recueilRecette;

    float startChrono;
    private void Update()


    {
        // � chaque 10 seconde, la function se r�p�te
        if (Time.realtimeSinceStartup - startChrono > 10f /* <--- A modifier pour changer l'attente entre chaque commande*/)
        {
            startChrono = Mathf.Floor(Time.realtimeSinceStartup);

            //donne un nombre (int) al�atoire entre 0 et le nombre de clients qui peut avoir un repas
            int tableRandom = Mathf.CeilToInt(Mathf.Round(Random.Range(0f, Mathf.Round(zonesRepas.Length - 1))));

            //variable plus rapide pour la table random s�l�ctionner B)
            GameObject table = zonesRepas[tableRandom];

            //V�rifie que le client n'a pas d�ja commander
            if(table.GetComponent<recette>().demandeNourriture == false)
            {
                // Annonce que le client � commander
                table.GetComponent<recette>().demandeNourriture = true;

                // Permet d'aller chercher un nombre parmis 0 et le nombres de recettes pour donner annoncer une commande
                int recetteRandom = Mathf.CeilToInt(Mathf.Round(Random.Range(0f, Mathf.Round(recueilRecette.GetComponent<receuil_recettes>().recettes.Length - 1))));

                // loop les ingr�dients de la recette s�l�ctionner
                for (int i = 0; i < recueilRecette.GetComponent<receuil_recettes>().recettes[recetteRandom].Length; i++)
                {
                    // rajoute a la liste d'ingr�dient les ingr�dients pour r�aliser sa recette
                    table.GetComponent<recette>().ListeIngredients.Add(recueilRecette.GetComponent<receuil_recettes>().recettes[recetteRandom][i]);
                }

                Debug.Log("la table " + table.name + "a commander un pokebowl");
            }
            


        }

    }



}
