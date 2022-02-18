using UnityEngine.SceneManagement;
using UnityEngine;

public class Button : MonoBehaviour
{
    public void ClickSFX()
    {
        FindObjectOfType<Audio_Manager>().Play("Button Click");
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
