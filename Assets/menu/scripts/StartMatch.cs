using Fusion;
using UnityEngine;

public class StartMatch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BTNStartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BTNStartGame()
    {
        Debug.Log("aooo potencia");
        StartGameArgs args = new StartGameArgs { PlayerCount = 2, GameMode = GameMode.Shared };

        NetworkRunner.Instances[0].StartGame(args);
    }
}
