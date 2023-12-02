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
        // À chaque 10 seconde, la function se répète
        if (Time.realtimeSinceStartup - startChrono > 10f /* <--- A modifier pour changer l'attente entre chaque commande*/)
        {
            startChrono = Mathf.Floor(Time.realtimeSinceStartup);

            //donne un nombre (int) aléatoire entre 0 et le nombre de clients qui peut avoir un repas
            int tableRandom = Mathf.CeilToInt(Mathf.Round(Random.Range(0f, Mathf.Round(zonesRepas.Length - 1))));

            //variable plus rapide pour la table random séléctionner B)
            GameObject table = zonesRepas[tableRandom];

            //Vérifie que le client n'a pas déja commander
            if(table.GetComponent<recette>().demandeNourriture == false)
            {
                // Annonce que le client à commander
                table.GetComponent<recette>().demandeNourriture = true;

                // Permet d'aller chercher un nombre parmis 0 et le nombres de recettes pour donner annoncer une commande
                int recetteRandom = Mathf.CeilToInt(Mathf.Round(Random.Range(0f, Mathf.Round(recueilRecette.GetComponent<receuil_recettes>().recettes.Length - 1))));

                // loop les ingrédients de la recette séléctionner
                for (int i = 0; i < recueilRecette.GetComponent<receuil_recettes>().recettes[recetteRandom].Length; i++)
                {
                    // rajoute a la liste d'ingrédient les ingrédients pour réaliser sa recette
                    table.GetComponent<recette>().ListeIngredients.Add(recueilRecette.GetComponent<receuil_recettes>().recettes[recetteRandom][i]);
                }

                Debug.Log("la table " + table.name + "a commander un pokebowl");
            }
            


        }

    }



}
