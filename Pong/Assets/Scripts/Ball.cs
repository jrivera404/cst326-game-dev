using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private int playerOneScore;
    [SerializeField] private int playerTwoScore;

    public Vector3 spawnPoint;
    public float speed;

    public Text playerOneText;
    public Text playerTwoText;

    public GameObject goalEffect;

    public GameObject hitSFX;

    // Start is called before the first frame update
    void Start()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
        this.direction = new Vector3(1f, 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += direction * speed;
        playerOneText.text = playerOneScore.ToString();
        playerTwoText.text = playerTwoScore.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        direction = Vector3.Reflect(direction, normal);

        if (collision.gameObject.name == "Left")
        {
            playerTwoScore++;
            Instantiate(goalEffect, this.transform.position, Quaternion.identity);
            transform.position = spawnPoint;
        }
        if (collision.gameObject.name == "Right")
        {
            playerOneScore++;
            Instantiate(goalEffect, this.transform.position, Quaternion.identity);
            transform.position = spawnPoint;
        }

        Instantiate(hitSFX, transform.position, transform.rotation);
    }
}
