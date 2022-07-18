using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    private float horizontalInput = 0.0f;
    public float xBoundaries;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Keep inside boundaries
        if (transform.position.x < -xBoundaries)
        {
            //Left boundary
            transform.position = new Vector3(-xBoundaries, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xBoundaries)
        {
            //Right boundary
            transform.position = new Vector3(xBoundaries, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //Firing projectile prefab
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }

    }

}
