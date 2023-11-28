using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legume_spawn : MonoBehaviour
{


    public GameObject zoneAvocats;
    public GameObject avocat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ground")
        {
            avocat.SetActive(false);
        }
    }



}
