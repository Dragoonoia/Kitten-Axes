using UnityEngine;
using Fusion;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    [SerializeField] private GameObject playerPrefab;
    public void PlayerJoined(PlayerRef player)
    {

        if (player == Runner.LocalPlayer)
        {
            Runner.Spawn(playerPrefab, new Vector2(0, 0), Quaternion.identity);
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
