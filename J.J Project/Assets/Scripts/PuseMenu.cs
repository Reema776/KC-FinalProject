using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PuseMenu : MonoBehaviour
{
    public GameObject puseMenue;
    public static bool isPuse;

    // Start is called before the first frame update
    void Start()
    {
        puseMenue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPuse)
            {
                puseMenue.SetActive(false);
                Time.timeScale = 1f;
                isPuse = false;
            }
            else
            {
                puseMenue.SetActive(true);
                Time.timeScale = 2f;
                isPuse = true;
            }
        }
    }
    public void PuseGame()
    {
        puseMenue.SetActive(true);
        Time.timeScale = 2f;
        isPuse = true;
    }

    public void ResumGame()
    {
        puseMenue.SetActive(false);
        Time.timeScale = 1f;
        isPuse = false;
    }

    public void gotoMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void gotoHelp()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void gotogame()
    {
        SceneManager.LoadScene(1);
    }

}
