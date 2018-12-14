using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Package : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    void JumpToMain()
    {
        SceneManager.LoadScene("Scenes/Main");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Invoke("JumpToMain", 0.5F);
        }
    }
}
