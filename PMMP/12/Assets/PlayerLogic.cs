using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerLogic : MonoBehaviour
{
    public TextMeshProUGUI collectedText;


    private int collectedCount = 0;

    void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            LoadScene("menu");
        }   
    }

    // Remove the Update method if you're not using it.

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            collectedCount++;
            UpdateCollectedText();
        }
    }

    private void UpdateCollectedText()
    {
        if (collectedText != null)
        {
            collectedText.text = "Collected: " + collectedCount.ToString();
        }
    }
}
