using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class Land : MonoBehaviour
{
    private Transform myTransform;
    private Vector3 startPoint;
    public GameObject gameOverUI;
    private static FirstPersonController firstPersonController;
    private GameObject envGameObject;
    private static bool openPackage = false;
    public GameObject Env;
    void Awake()
    {
        //Debug.Log("Awake");
        envGameObject = Instantiate(Env, Vector3.zero,Quaternion.identity);
    }
    void OnEnable()
    {
        Debug.Log("OnEnable");

    }
    // Use this for initialization
    void Start ()
	{
        SceneManager.LoadScene("Scenes/Package_small", LoadSceneMode.Additive);
        myTransform = this.transform;
	    startPoint = myTransform.position;
	    firstPersonController = this.GetComponent<FirstPersonController>();
        //setFirstPerson(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(myTransform.position.y);
        if (myTransform.position.y < -10)
        {
            GameOver();
	    }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.B) && !openPackage)
        {
            setOpenPackage(true);
            Invoke("JumpToPackage", 0.5F);
        }
    }


    void JumpToPackage()
    {
        setFirstPerson(false);
        SceneManager.LoadScene("Scenes/Package", LoadSceneMode.Additive);
    }

    private void GameOver()
    {
        gameOverUI.SetActive(true);
        setFirstPerson(false);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Restart()
    {
        myTransform.position = startPoint;
        gameOverUI.SetActive(false);
        setFirstPerson(true);
        DestroyImmediate(envGameObject, false);
        envGameObject= Instantiate(Env, Vector3.zero,Quaternion.identity);
    }

    public static void setFirstPerson(bool s)
    {
        firstPersonController.enabled = s;
    }

    public static void setOpenPackage(bool s)
    {
        openPackage = s;
    }
}
