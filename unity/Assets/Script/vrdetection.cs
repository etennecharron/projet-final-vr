using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Management;

public class vrdetection : MonoBehaviour
{
    public GameObject sourisClavier;
    // Start is called before the first frame update
    public bool activVR = true;


    void Start()
    {
        if (activVR == true)
        {
            var xrParametres = XRGeneralSettings.Instance;
            if (xrParametres == null)
            {
                return;
            }
            var xrManager = xrParametres.Manager;
            if (xrParametres == null)
            {
                return;
            }
            var xrLoader = xrManager.activeLoader;
            if (xrLoader == null)
            {
                sourisClavier.SetActive(true);
                return;
            }
            sourisClavier.SetActive(false);
        }
        else
        {
            sourisClavier.SetActive(true);
        }
    }


        


}
