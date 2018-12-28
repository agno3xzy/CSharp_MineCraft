using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Package : MonoBehaviour
{
    public GameObject Env;

    // Use this for initialization
    void Start()
    {
        
    }

    void JumpToMain()
    {
        SceneManager.UnloadSceneAsync("Scenes/Package");
        Land.setOpenPackage(false);

        Land.setFirstPerson(true);
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
