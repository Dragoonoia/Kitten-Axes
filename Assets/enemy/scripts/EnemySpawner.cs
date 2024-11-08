using UnityEngine;
using Fusion;

public class EnemySpawner : SimulationBehaviour, IPlayerJoined
{
    [SerializeField] private GameObject enemyPrefab;
    public void PlayerJoined(PlayerRef player)
    {

        Runner.Spawn(enemyPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        Destroy(gameObject);
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
