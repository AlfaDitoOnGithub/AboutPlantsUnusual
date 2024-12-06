using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void LoadLevel (string levelName)
    {
        StartCoroutine(LoadSceneAsync(levelName));
    }
    IEnumerator LoadSceneAsync ( string levelName )
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(levelName);
        while ( !op.isDone )
        {
            float progress = Mathf.Clamp01(op.progress / .9f);
            Debug.Log(op.progress);
            yield return null;
        }
    }
    
    // public void PlayLevel1Button()
    // {
    //     // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
    //     SoundManager.PlaySound(SoundType.MenuInteract);
    //     UnityEngine.SceneManagement.SceneManager.LoadScene("Level_1");
    // }
    // public void PlayLevel2Button()
    // {
    //     // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
    //     SoundManager.PlaySound(SoundType.MenuInteract);
    //     UnityEngine.SceneManagement.SceneManager.LoadScene("Level_2");
    // }
    // public void PlayLevel3Button()
    // {
    //     // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
    //     SoundManager.PlaySound(SoundType.MenuInteract);
    //     UnityEngine.SceneManagement.SceneManager.LoadScene("Level_3");
    // }

    public void CreditsButton()
    {
        // Show Credits Menu
        // MainMenu.SetActive(false);
        // CreditsMenu.SetActive(true);
    }

    public void MainMenuButton()
    {
         // Show Main Menu
        // MainMenu.SetActive(true);
        // CreditsMenu.SetActive(false);
    }

    public void BackButton(){
        SoundManager.PlaySound(SoundType.MenuBack,0.8f);
    }

    public void ClickedButton(){
        SoundManager.PlaySound(SoundType.MenuInteract,0.7f);
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}