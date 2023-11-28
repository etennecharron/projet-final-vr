using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legume_spawn : MonoBehaviour
{
    
[Header("Objet à téléporter")]    
    public GameObject avocat;

[Header("Endroit où téléporter")]
    public GameObject zoneAvocats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ground")
        {
            avocat.SetActive(false);
        }
    }



}
