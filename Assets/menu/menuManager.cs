using Fusion;
using UnityEngine;

public class menuManager : MonoBehaviour
{

    [SerializeField] private GameObject canvas;
    public void BTNStartGame()
    {
        StartGameArgs args = new StartGameArgs { PlayerCount = 2, GameMode = GameMode.Shared };

        NetworkRunner.Instances[0].StartGame(args);

       Destroy(canvas);
    }
}
