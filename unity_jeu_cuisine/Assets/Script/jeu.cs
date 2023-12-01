using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jeu : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] zonesRepas;
    public GameObject recueilRecette;

    float startChrono;
    private void Update()
    {
        
        if (Time.realtimeSinceStartup - startChrono > 10f)
        {
            startChrono = Mathf.Floor(Time.realtimeSinceStartup);
           // Debug.Log(Time.realtimeSinceStartup);
            int tableRandom = Mathf.CeilToInt(Mathf.Round(Random.Range(0f, Mathf.Round(zonesRepas.Length - 1))));

            GameObject table = zonesRepas[tableRandom];

            table.GetComponent<recette>().demandeNourriture = true;

            int recetteRandom = Mathf.CeilToInt(Mathf.Round(Random.Range(0f, Mathf.Round(recueilRecette.GetComponent<receuil_recettes>().recettes.Length-1))));
            for(int i = 0; i< recueilRecette.GetComponent<receuil_recettes>().recettes[recetteRandom].Length;i++)
            {
                table.GetComponent<recette>().ListeIngredients.Add(recueilRecette.GetComponent<receuil_recettes>().recettes[recetteRandom][i]);
            }

            Debug.Log("la table " + table.name + "a commander un pokebowl");


        }

    }



}
