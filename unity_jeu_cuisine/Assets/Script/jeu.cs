using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jeu : MonoBehaviour
{
   
    [Header("Zone ou recevoir le repas")]
    public GameObject[] zonesRepas;
    [Header("Object contenant le script qui contient les recettes")]
    public GameObject recueilRecette;

    public int nombreDeVies = 5;

    public bool etatPartie = false;


    private void Start()
    {
        etatPartie = true;
    }

    float startChrono;
    private void Update()
    {
        // a chaque 10 seconde, la function se repete
        if (etatPartie == true && Time.realtimeSinceStartup - startChrono > 10f /* <--- A modifier pour changer l'attente entre chaque commande*/)
        {
            startChrono = Mathf.Floor(Time.realtimeSinceStartup);

            //donne un nombre (int) aleatoire entre 0 et le nombre de clients qui peut avoir un repas
            int tableRandom = Mathf.CeilToInt(Mathf.Round(Random.Range(0f, Mathf.Round(zonesRepas.Length - 1))));

            //variable plus rapide pour la table random selectionner B)
            GameObject table = zonesRepas[tableRandom];

            //Verifie que le client n'a pas deja commander
            if(table.GetComponent<client>().demandeNourriture == false && table.GetComponent<client>().cooldownOnOff == false)
            {
                // Annonce que le client a commander
                table.GetComponent<client>().demandeNourriture = true;

                table.GetComponent<client>().tempsPourRecette = Mathf.Floor(Time.realtimeSinceStartup);

                // Permet d'aller chercher un nombre parmis 0 et le nombres de recettes pour donner annoncer une commande
                int recetteRandom = Mathf.CeilToInt(Mathf.Round(Random.Range(0f, Mathf.Round(recueilRecette.GetComponent<receuil_recettes>().recettes.Length - 1))));

                // loop les ingredients de la recette selectionner
                for (int i = 0; i < recueilRecette.GetComponent<receuil_recettes>().recettes[recetteRandom].Length; i++)
                {
                    // rajoute a la liste d'ingredient les ingredients pour realiser sa recette
                    table.GetComponent<client>().ListeIngredients.Add(recueilRecette.GetComponent<receuil_recettes>().recettes[recetteRandom][i]);
                }

                Debug.Log("la table " + table.name + "a commander un pokebowl");
            }
            


        }
        else if (nombreDeVies <= 0)
        {
            etatPartie = false;
            for (int i = 0; i < zonesRepas.Length; i++)
            {
                /**A FAIRE***/
            }

            }


        

    }



}
