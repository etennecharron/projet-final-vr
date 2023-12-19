using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCuisson : MonoBehaviour
{
    public GameObject poisson;
    public Material texturePoissonCuit;
    public Material texturePoissonBrule;
    public GameObject tofu;
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
        if (other.gameObject == poisson)
        {
            enCuisson = true;
        }else if (other.gameObject == tofu)
        {
            enCuisson = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == poisson)
        {
            enCuisson = false;
            tempsCuisson = 0f;
            // Réinitialiser le temps de cuisson lorsque le poisson quitte la zone de cuisson
        }else if(other.gameObject == tofu){
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