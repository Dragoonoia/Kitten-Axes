using UnityEngine;
using Fusion;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject player2Prefab;
    public void PlayerJoined(PlayerRef player)
    {
        ;
        if (player == Runner.LocalPlayer && Runner.SessionInfo.PlayerCount == 1)
        {
            Runner.Spawn(playerPrefab, new Vector2(-23.92f, -8.73f), Quaternion.identity);
        }

        if (player == Runner.LocalPlayer && Runner.SessionInfo.PlayerCount == 2)
        {
            Runner.Spawn(player2Prefab, new Vector2(-23.92f, 1.67f), Quaternion.identity);
        }
        }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
