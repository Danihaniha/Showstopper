using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMystery1()
    {
        SceneManager.LoadScene(1);
    }    
    
    public void LoadMystery2()
    {
        SceneManager.LoadScene(4);
    }    
    
    public void LoadMystery3()
    {
        SceneManager.LoadScene(7);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadM2Win()
    {
        SceneManager.LoadScene(3);
    } 
    
    public void LoadM2Lose()
    {
        SceneManager.LoadScene(4);
    }
}
