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

    private void Awakening()
    {
        BTNStartGame();
    }
    public void BTNStartGame()
    {
        Debug.Log("aooo potencia");
        StartGameArgs args = new StartGameArgs { PlayerCount = 2, GameMode = GameMode.Shared };

        NetworkRunner.Instances[0].StartGame(args);
    }
}
