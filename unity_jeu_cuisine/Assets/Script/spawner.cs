using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class spawner : MonoBehaviour
{
    public GameObject objetASpawn;
    public GameObject spawn;
    public Transform parent;
    public List<GameObject> enfants;
    public string nomADonner;


    //private bool objetSortit;
    public bool contientDejaIngredient;
    private int contientObjetNb = 0;
    private void OnTriggerExit(Collider other)
    {
        if(other.name == nomADonner && enfants.Count < 10 && other.GetComponent<ingredients>().ingredientSortis == false)
        {
            enfants.Add(Instantiate(objetASpawn, spawn.transform.position, spawn.transform.rotation, parent));
            for (int i = 0; i < enfants.Count; i++)
            {
                enfants[i].name = nomADonner;
                enfants[i].SetActive(true);
            }   
        }

        if(other.name == nomADonner && other.GetComponent<ingredients>().ingredientSortis == false )
        {
            other.GetComponent<ingredients>().ingredientSortis = true;
            for (int i = 0; i < enfants.Count; i++)
            {
                if (enfants[i].GetComponent<ingredients>().ingredientSortis == true)
                {
                    contientObjetNb++;
                }
            }
            
            if (contientObjetNb == enfants.Count)
            {
                contientDejaIngredient = true;
                Debug.Log("aucun objet dans la zone");
            }
            else
            {
                contientObjetNb = 0;
            }
        }
    }


    private bool cooldownSpawnEtat;
    private float cooldownSpawn;

    private void Update()
    {

        if(cooldownSpawnEtat == false && enfants.Count < 10 && contientDejaIngredient == true)
        {
            Debug.Log("chrono commencer");
            cooldownSpawnEtat = true;
            cooldownSpawn = Time.realtimeSinceStartup;
           
        }

        if (Time.realtimeSinceStartup - cooldownSpawn > 10f && cooldownSpawnEtat == true)
        {
            enfants.Add(Instantiate(objetASpawn, spawn.transform.position, spawn.transform.rotation, parent));
            for (int i = 0; i < enfants.Count; i++)
            {
                enfants[i].name = nomADonner;
                enfants[i].SetActive(true);
            }
            cooldownSpawnEtat = false;
            Debug.Log("objet spawn");

        }


    }




}

