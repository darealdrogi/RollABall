using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    [SerializeField] private int m_treshold = 10;
    [SerializeField] private string m_message = "Hello World";




    // Start is called before the first frame update
    void Start()
    {
        LogHelloWorld(m_message);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void LogHelloWorld(string message)
    {
        if (m_treshold > 10)
        Debug.Log(message);
    }

}
