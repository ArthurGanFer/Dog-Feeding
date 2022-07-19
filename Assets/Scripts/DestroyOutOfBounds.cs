using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 40;
    public float lowerBound = -10;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // If projectile goes past boundaries
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        //if dog goes past boundaries
        else if (transform.position.z < lowerBound)
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
            gameManager.SetGameStatus(false);
        }

        if (!gameManager.GetGameActive())
        {
            gameManager.GameOver();
            Destroy(gameObject);
        }
    }
}
