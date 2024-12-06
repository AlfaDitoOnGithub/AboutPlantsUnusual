using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
        
    
    public void PlayNowButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameLevel");
    }

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