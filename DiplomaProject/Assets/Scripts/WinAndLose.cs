using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinAndLose : MonoBehaviour
{
    public GameObject WinPanel;
    [SerializeField] private Button MenuButton;


    void Start()
    {

    }


    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            Debug.Log("Player near to win zone");
            WinPanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

