using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject objetASpawn;
    public GameObject spawn;
    public Transform parent;
    public List<GameObject> enfants;
    public string nomADonner;


    private void OnTriggerExit(Collider other)
    {
        if(other.name == nomADonner && enfants.Count < 10)
        {
            enfants.Add(Instantiate(objetASpawn, spawn.transform.position, spawn.transform.rotation, parent));
            for (int i = 0; i < enfants.Count; i++)
            {
                enfants[i].name = nomADonner;
                enfants[i].SetActive(true);
            }
        }
    }





}

