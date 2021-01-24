using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController0 : MonoBehaviour
{
    [SerializeField] private float m_speed = 1f;

    private Rigidbody m_playerRigidbody = null;

    private float m_movementX, m_movementY; //input vector components

    private int m_collectablesTotalCount, m_collectablesCounter;

    private Stopwatch m_stopwatch;

    public Text scoreText;
    public GameObject gameOverText;
    public GameObject gameOverText2;

    private void Start()
    {
        m_playerRigidbody = GetComponent<Rigidbody>();

        m_collectablesTotalCount = m_collectablesCounter = GameObject.FindGameObjectsWithTag("Collectable").Length;

        scoreText.text = "Score: " + m_collectablesTotalCount.ToString() + " / " + m_collectablesTotalCount.ToString();

        m_stopwatch = Stopwatch.StartNew();
    }

    private void OnMove(InputValue inputValue)
    {
        Vector2 movementVector = inputValue.Get<Vector2>();

        //split input vector in its two components
        m_movementX = movementVector.x;
        m_movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(m_movementX, 0f, m_movementY); //translate the 2d vector into a 3d vector
        
        m_playerRigidbody.AddForce(movement * m_speed); //apply a force to the rigidbody

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);

            m_collectablesCounter--;
            scoreText.text = "Score: " + m_collectablesCounter.ToString() + " / " + m_collectablesTotalCount.ToString();
            if (m_collectablesCounter == 0)
            {
                UnityEngine.Debug.Log("YOU WIN!");
                gameOverText.SetActive(true);
                StartCoroutine(waitALittleBit());


                UnityEngine.Debug.Log($"It took you {m_stopwatch.Elapsed} to find all {m_collectablesTotalCount} collectables.");

            }
            else
            {
                UnityEngine.Debug.Log($"You've already found {m_collectablesTotalCount - m_collectablesCounter} of {m_collectablesTotalCount} collectables!");
            }
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            UnityEngine.Debug.Log("GAME OVER!");
            gameOverText2.SetActive(true);
            StartCoroutine(waitALittleBit());


#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();//exits the playmode
#endif
        }
    }

    public IEnumerator waitALittleBit()
    {
        yield return new WaitForSeconds(5);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();//exits the playmode
#endif

    }



}

