using Fusion;
using UnityEngine;

public class menuManager : NetworkBehaviour
{
    private void Awake()
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
