using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCuisson : MonoBehaviour
{
    public string ingredientNom01 = "poisson";
    public string ingredientNom02 = "tofus";

    private GameObject poisson;
    private GameObject tofus;

    public Material texturePoissonCuit;
    public Material texturePoissonBrule;
    public Material textureTofuCuit;
    public Material textureTofuBrule;

    private bool enCuisson;
    private float tempsCuisson;
    private float tempsBrulure = 10f;

    void Update()
    {
        if (enCuisson)
        {
            tempsCuisson += Time.deltaTime;

            if (tempsCuisson >= tempsBrulure)
            {
                ChangerTexturePoisson(texturePoissonBrule);
                ChangerTextureTofu(texturePoissonBrule);
                // Faire d'autres actions si nécessaire pour le poisson brûlé
            }
            else if (tempsCuisson >= 5f)
            {
                ChangerTexturePoisson(texturePoissonCuit);
                ChangerTextureTofu(texturePoissonBrule);
                // Faire d'autres actions si nécessaire pour le poisson cuit
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "poisson")
        {
            poisson = other.gameObject;
            enCuisson = true;
        }else if (other.gameObject.name == "tofu")
        {
            tofus = other.gameObject;
            enCuisson = true;
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
    }

    void ChangerTextureTofu(Material nouvelleTexture)
    {
        Renderer rend = poisson.GetComponent<Renderer>();
        rend.material = nouvelleTexture;
    }
}