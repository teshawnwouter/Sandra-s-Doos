using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene("WinScene");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
            Application.Quit();
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene("AkashScene");
    }
}
