using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlashLighter : MonoBehaviour
{
    [SerializeField] GameObject FlashLightLight;
    private bool FlashlighterActive = false;

    // Start is called before the first frame update
    void Start()
    {
        FlashLightLight.gameObject.SetActive(false);

    }

    // Update is called once per frame
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
