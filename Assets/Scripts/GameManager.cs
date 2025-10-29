using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [FormerlySerializedAs("prefabs")]
    public List<GameObject> obstaclePrefabs;

    public float obstacleInterval = 1;

    public float obstacleSpeed = 10;

    public float obstacleOffsetX = 0;
    public Vector2 obstacleOffsetY = new Vector2(0, 0);

    [HideInInspector]
    public int score;

    [HideInInspector]
    private bool isGameOver = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public bool IsGameActive(){
        return !isGameOver;
    }
    public bool IsGameOver(){
        return isGameOver; 
    }
    public void EndGame()
    {
        isGameOver = true;
        //print message
        Debug.Log("Game over");

        //reload scene
        StartCoroutine(ReloadScene(2));
    }

    private IEnumerator ReloadScene(float delay)
    {
        //precisamos fazer duas coisas:
        //esperar 2 segundos (delay)
        yield return new WaitForSeconds(delay);
        //regarregar a cena(usando scene manager)
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    //nota pra mim: estudar/pesquisar sobre Coroutine
    //estudar/pesquisar sobre sceneManager é interessante tb

}
