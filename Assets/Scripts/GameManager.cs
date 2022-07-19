using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private bool isGameActive = false;
    public int lifes;
    private float spawnRate = 1.5f;
    private SpawnManager spawnManager;

    public TextMeshProUGUI gameTitle;
    public TextMeshProUGUI gameOver;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SetGameStatus(true);
        StartCoroutine(SpawnTargets());
        gameTitle.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        SetGameStatus(false);
        gameOver.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator SpawnTargets()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            spawnManager.SpawnRandomDog();
        }
    }

    public void SetGameStatus(bool gameStatus)
    {
        isGameActive = gameStatus;
    }

    public bool GetGameActive()
    {
        return isGameActive;
    }

}
