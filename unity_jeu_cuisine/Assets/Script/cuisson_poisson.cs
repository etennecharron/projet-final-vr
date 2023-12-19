using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCuisson : MonoBehaviour
{
    public string ingredientNom01 = "poisson";
    public string ingredientNom02 = "tofus";

    private GameObject poisson;
    private GameObject tofu;

    public Material texturePoissonCuit;
    public Material texturePoissonBrule;
    public Material textureTofuCuit;
    public Material textureTofuBrule;

    private bool enCuisson;
    private float tempsCuisson;
    private float tempsBrulure = 10f;

    public GameObject rondFour;
    public GameObject fumer;
    private bool fourActiver = false;

    void Update()
    {

       if( rondFour.transform.rotation.z > 0)
        {
            fumer.SetActive(true);
            fourActiver = true;

        }
        else { 
            fourActiver = false;
            fumer.SetActive(false);
        };

        if (enCuisson == true && fourActiver == true)
        {
            Debug.Log("en train de cuire");
            tempsCuisson += Time.deltaTime;
            if (tempsCuisson >= tempsBrulure)
            {
                Debug.Log("cuisson parfaite");
                if (poisson != null)
                {
                    ChangerTexturePoisson(texturePoissonCuit);
                }
                if (tofu != null)
                {
                    ChangerTextureTofu(textureTofuCuit);
                }
                // Faire d'autres actions si nécessaire pour le poisson brûlé
            }
            else if (tempsCuisson >= 10f)
            {
                Debug.Log("bruler D:");
                if(poisson != null)
                {
                    ChangerTexturePoisson(texturePoissonBrule);
                }
                if(tofu != null)
                {
                    ChangerTextureTofu(textureTofuBrule);
                }
                
                // Faire d'autres actions si nécessaire pour le poisson cuit
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(fourActiver == true) {
            if (other.gameObject.name == "poisson")
            {
                Debug.Log("poisson");
                poisson = other.gameObject;
                enCuisson = true;
            }
            else if (other.gameObject.name == "tofu")
            {
                Debug.Log("tofu");
                tofu = other.gameObject;
                enCuisson = true;
            }
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "poisson")
        {
            enCuisson = false;
            tempsCuisson = 0f;
            // Réinitialiser le temps de cuisson lorsque le poisson quitte la zone de cuisson
        }else if(other.gameObject.name == "tofu")
        {
            enCuisson = false;
            tempsCuisson = 0f;
            // Réinitialiser le temps de cuisson lorsque le poisson quitte la zone de cuisson
        }
    }

    void ChangerTexturePoisson(Material nouvelleTexture)
    {
        Renderer rend = poisson.GetComponent<Renderer>();
        rend.material = nouvelleTexture;
        poisson.name = "poisson cuit";
    }

    void ChangerTextureTofu(Material nouvelleTexture)
    {
        Renderer rend = tofu.GetComponent<Renderer>();
        rend.material = nouvelleTexture;
        tofu.name = "tofu cuit";
    }
}