using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public GameObject Screamer;
    public AudioSource audioSource;
    
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
        }
            
    }

    IEnumerator DisableScreamer()
    {
        yield return new WaitForSeconds(2);

        Screamer.SetActive(false);
    }
}
