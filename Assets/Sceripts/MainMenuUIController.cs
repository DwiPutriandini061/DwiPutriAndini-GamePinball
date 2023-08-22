using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;
    public Button profilButton;

    private void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
        profilButton.onClick.AddListener
        (Profil);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Pinball Game");
    }
    public void Profil()
    {
        SceneManager.LoadScene("Profil");
    }
    private void ExitGame()
    {
        Application.Quit();
    }
}
