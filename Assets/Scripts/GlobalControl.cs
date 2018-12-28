using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//存储背包信息
public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;
    //用一维数组存储背包内物品个数
    public int[] itemsToAdd = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int currentHold = -1;
    void Awake()
    {
        if (Instance == null)
        {
             DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
           
    }
}
