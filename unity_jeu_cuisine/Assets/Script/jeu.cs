using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jeu : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] zonesRepas;


    float startChrono;
    private void Update()
    {
        if (Time.realtimeSinceStartup - startChrono > 0.050f)
        {
            startChrono = Mathf.Floor(Time.realtimeSinceStartup);
            if (startChrono == 10)
            {

                int tableRandom = Mathf.CeilToInt(Mathf.Round(Random.Range(0f, 3f)));

                zonesRepas[tableRandom].GetComponent<recette>().demandeNourriture = true;
            }
        }

    }



}
