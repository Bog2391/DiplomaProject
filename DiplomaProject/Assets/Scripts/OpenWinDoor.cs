using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenWinDoor : MonoBehaviour
{
    private bool IsAtDoor = false;

    [SerializeField] private TextMeshProUGUI CodeText;
    public string exCode;
    public GameObject CodePanel;
    void Start()
    {
      
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && IsAtDoor == true)
        {
            CodePanel.SetActive(true);
            Debug.Log("Pressed E");
            Cursor.visible = true;                
            Cursor.lockState = CursorLockMode.None;
        }

        if (CodeText.text == exCode && CodePanel.activeSelf)
        {
            Destroy(gameObject);
            CodePanel.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IsAtDoor = true;
            Debug.Log("Player near to the door");
        }
    }
    public void AddDigit(string digit)
    {
        CodeText.text += digit; 
    }
}
