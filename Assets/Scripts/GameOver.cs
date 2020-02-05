using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("BackSene", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BackScene()
    {
        SceneManager.LoadScene("Map_v1");
    }
}
