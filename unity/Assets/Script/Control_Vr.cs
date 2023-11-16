using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;

public class Control_Vr : MonoBehaviour
{
    public bool activVr;
    public GameObject sourisClavier;
    // Start is called before the first frame update
    void Start()
    {
        var xrParametres = XRGeneralSettings.Instance;
        if (xrParametres != null)
        {
            return;
        }
        var xrManager = xrParametres.Manager;
        if (xrManager != null)
        {
            return;
        }
        var xrLoader = xrManager.activeLoader;
        if (xrLoader != null)
        {
            sourisClavier.SetActive(true);
            return;
        }
        sourisClavier.SetActive(false);
    }
}
