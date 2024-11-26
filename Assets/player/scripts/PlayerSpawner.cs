using UnityEngine;
using Fusion;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject player2Prefab;
    [SerializeField] private GameObject player1Spawn;
    [SerializeField] private GameObject player2Spawn;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemySpawner;
    [SerializeField] private GameObject enemySpawner2;
    [SerializeField] private GameObject enemySpawner3;
    public void PlayerJoined(PlayerRef player)
    {
        ;
        if (player == Runner.LocalPlayer && Runner.SessionInfo.PlayerCount == 1)
        {
            Runner.Spawn(playerPrefab, new Vector2(player1Spawn.transform.position.x, player1Spawn.transform.position.y), Quaternion.identity);

            Runner.Spawn(enemyPrefab, new Vector2(enemySpawner.transform.position.x, enemySpawner.transform.position.y), Quaternion.identity);
            Runner.Spawn(enemyPrefab, new Vector2(enemySpawner2.transform.position.x, enemySpawner2.transform.position.y), Quaternion.identity);
            Runner.Spawn(enemyPrefab, new Vector2(enemySpawner3.transform.position.x, enemySpawner3.transform.position.y), Quaternion.identity);
        }

        if (player == Runner.LocalPlayer && Runner.SessionInfo.PlayerCount == 2)
        {
            Runner.Spawn(player2Prefab, new Vector2(player2Spawn.transform.position.x, player2Spawn.transform.position.y), Quaternion.identity);
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
