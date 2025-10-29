using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    void Start()
    {
        
    }

    void FixedUpdate()
    {

                //get gamemanager
        var gameManager = GameManager.Instance;

        //ignore if game is over
        if (gameManager.IsGameOver())
        {
            return;
        }

        //Move object
        float x = GameManager.Instance.obstacleSpeed * Time.fixedDeltaTime;
        transform.position -= new Vector3(x, 0, 0);

        //Destroy object
        if(transform.position.x <= -GameManager.Instance.obstacleOffsetX)
        {
            Destroy(gameObject);
        }
    }
}
