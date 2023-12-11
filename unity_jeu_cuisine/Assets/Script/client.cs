using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WebSocketSharp;

public class client : MonoBehaviour
{
    public GameObject table;
    public GameObject scriptJeu;
    public TextMeshProUGUI scoreMenu;
    // Verifie que le client n'a pas encore commande (elle est utiliser dans le script jeu.cs pour ne pas qu'un client commande plus qu'une recette)
    public bool demandeNourriture = false;

    // Liste aleatoire qui declare les ingredients necessaire pour la recette (Elle se remplie lorsque le script jeu.cs declare qu'une table a command�)
    public List<string> ListeIngredients;

    //Verifie le nombre d'objet dans l'assiette que la recette avait besoins
    private int bonIngredient = 0;

    public bool cooldownOnOff;


    public TextMeshProUGUI menuCuisineTexte;
    public TextMeshProUGUI menuVies;

    //Verifie que l'assiette qui contient les ingredients correspond a la recette demander par le client
    private void OnTriggerEnter(Collider other)
    {
        //Verifie si l'objet qui vient de rentrer en contact avec le client est une assiette et si le client voulait de la nourriture
        if (other.tag == "assiette" && demandeNourriture == true)
        {
            
            //Debug.Log("assiette detecter et nourriture voulue"); GOOD

            //loop a travers le nombre d'ingredients que la liste d'ingredients possede
            for (int i = 0; i <= ListeIngredients.Count-1; i++)
            {
                // Debug.Log(ListeIngredients.Count-1); GOOD
                    //loop e travers le nombre d'ingredients que l'assiette qui vient de rentrer en contact avec la zone possede
                    for (int o = 0; o <= other.GetComponent<assiette>().ingredientsArr.Count-1; o++)
                    {
                        //Verifie que chaque ingredient present dans l'assiette corespond a un ingredient de la recette 
                        if (ListeIngredients[i] == other.GetComponent<assiette>().ingredientsArr[o].name /*transcrit le nom des Gameobjects et non LE Gameobject btw*/) // ERREUR SI YA 2 FOIS LE MEME INGReDIENT DANS LA RECETTE, ON A JUSTE BESOINS DE L'INGReDIENTE 1 FOIS POUR QUE SA PASSE D:
                        {
                            //augmente de 1 si un ingredient est demande dans la recette
                            bonIngredient++;

                            // Verifie qu le nombre d'ingredients bon pour la recette correspond a la taille de la recette
                            if (bonIngredient == ListeIngredients.Count)
                            {
                                Debug.Log("recette terminer");

                            // Active le cooldown sur le client pour ne pas qu'il reçoive toute suite une autre commande
                            cooldownOnOff = true;
                            cooldown = Mathf.Floor(Time.realtimeSinceStartup);


                            //Enleve les ingredients necessaire a la recette et rend pretes a recevoir des nouveaux ingredients pour une nouvelle recette
                            ListeIngredients.Clear();
                                // Loop a travers les ingredients dans l'assiette lorsque la recette est bonne pour faire disparaitre les ingredients
                                for (int u = 0; u < other.GetComponent<assiette>().ingredientsArr.Count; u++)
                                {
                                // Fais disparaitre les ingredients
                                Destroy(other.GetComponent<assiette>().ingredientsArr[u].gameObject);
                                scriptJeu.GetComponent<jeu>().points = scriptJeu.GetComponent<jeu>().points + 1;
                                scoreMenu.text = scriptJeu.GetComponent<jeu>().points.ToString();
                                }

                            }
                        else
                        {
                            Debug.Log("mauvais recette");
                        }
                        }
                    }
            }
        }
    }

    


    private void OnTriggerExit(Collider other)
    {
        //// si l'assiete sors de la zone, les points pour les bons ingrédients sont retiré
        if(other.tag == "assiette")
        {
            bonIngredient = 0;
        }
    }

    
 

   public float tempsPourRecette;
    private float cooldown;
    private string textePourAfficher;
    private bool alterneMessage = false;
    private void Update()
    {


        if(demandeNourriture == false && alterneMessage == false)
        {
            menuCuisineTexte.text = "Rien";
            alterneMessage = true;
        }
        if(demandeNourriture == true && alterneMessage == true)
        {
            for( int i = 0; i<=ListeIngredients.Count-1;i++ )
            {
                if(textePourAfficher.IsNullOrEmpty() == true)
                {
                    textePourAfficher = ListeIngredients[i];
                }
                else
                {
                    textePourAfficher = textePourAfficher + "<br>" + ListeIngredients[i];

                }
             
            }
            menuCuisineTexte.text = textePourAfficher;
            alterneMessage = false;
 
        }

        if (Time.realtimeSinceStartup - cooldown > 20f && demandeNourriture == false && cooldownOnOff == true)
        {
            cooldownOnOff = false;
            scriptJeu.GetComponent<jeu>().zonesRepasEnAttente.Add(table);
        }

        if (Time.realtimeSinceStartup - tempsPourRecette > 60f && demandeNourriture == true)
        {
            Debug.Log("la table " + table + " a trop attendus");
            tempsPourRecette = Mathf.Floor(Time.realtimeSinceStartup);
            demandeNourriture = false;
            ListeIngredients.Clear();
            // Active le cooldown sur le client pour ne pas qu'il reçoive toute suite une autre commande
            cooldownOnOff = true;
            cooldown = Mathf.Floor(Time.realtimeSinceStartup);
            scriptJeu.GetComponent<jeu>().nombreDeVies = scriptJeu.GetComponent<jeu>().nombreDeVies - 1;
            menuVies.text = scriptJeu.GetComponent<jeu>().nombreDeVies.ToString();
        }





    }




}
    
