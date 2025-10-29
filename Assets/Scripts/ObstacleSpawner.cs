using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private float cooldown = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        //get gamemanager
        var gameManager = GameManager.Instance;

        //ignore if game is over
        if (gameManager.IsGameOver())
        {
            return;
        }

        cooldown -= Time.deltaTime;
        if (cooldown <= 0f) {
            cooldown = gameManager.obstacleInterval;

            //spawn obstacle
            int prefabIndex = Random.Range(0, gameManager.obstaclePrefabs.Count);
            GameObject prefab = gameManager.obstaclePrefabs[prefabIndex];

            float x = gameManager.obstacleOffsetX;
            float y = Random.Range(gameManager.obstacleOffsetY.x, gameManager.obstacleOffsetY.y);
            float z = 9;

            Vector3 position = new Vector3(x, y, z);
            Quaternion rotation = prefab.transform.rotation;
            Instantiate(prefab, position, prefab.transform.rotation);
        }
    }
}
