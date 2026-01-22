using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlashLighter : MonoBehaviour
{
    [SerializeField] GameObject FlashLightLight;
    private bool FlashlighterActive = false;

   
    void Start()
    {
        FlashLightLight.gameObject.SetActive(false);

    }

   
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F)) 
        {
            
            if (FlashlighterActive ==false) 
            {
                 FlashLightLight.gameObject.SetActive (true);
                 FlashlighterActive = true;    
            }
            else
            {
                FlashLightLight.gameObject.SetActive(false);
                FlashlighterActive = false;
            }
        } 
    }
}
