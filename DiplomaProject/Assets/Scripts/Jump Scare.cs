using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpScare : MonoBehaviour
{
    public GameObject Screamer;
    public AudioSource audioSource;
    public GameObject LosePanel;

    void Start()
    {
        Screamer.SetActive(false);   
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            Screamer.SetActive(true);
            audioSource.Play();
            StartCoroutine(DisableScreamer());
            StartCoroutine(LosePanelCouroutine());
        }
            
    }

    IEnumerator DisableScreamer()
    {
        yield return new WaitForSeconds(3);

        Screamer.SetActive(false);
    }
    IEnumerator LosePanelCouroutine()
    {
        yield return new WaitForSeconds(2);
      
        LosePanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
