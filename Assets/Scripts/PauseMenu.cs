using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false,VolumeUI = true;
    public GameObject PauseMenuUI;
    [SerializeField] private GameObject VolSlider;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        Debug.Log("Ya");
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Debug.Log("Quittting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
    public void SliderOnOff()
    { 
        if (!VolumeUI)
        {
            VolumeUI = true;
            VolSlider.SetActive(true);
        }
        else
        {
            VolSlider.SetActive(false);
            VolumeUI = false;
        }
    }
}
