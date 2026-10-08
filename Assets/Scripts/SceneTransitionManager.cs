using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public void GoToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void StartNewGame()
    {
        RunSession.ResetRun();
        SceneManager.LoadScene("Game");

    }

    public void GoToGame()
    {
        
        SceneManager.LoadScene("Game");

    }


    public void GoToShop()
    {
        SceneManager.LoadScene("Shop");
    }
    
    public void GoToResult()
    {
        SceneManager.LoadScene("Result");
    }


}
