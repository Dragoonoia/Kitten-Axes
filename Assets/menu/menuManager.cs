using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : NetworkBehaviour
{
    public void startarOjoguin(int NextScene)
    {
        SceneManager.LoadScene(NextScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
}
