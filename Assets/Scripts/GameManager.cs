//游戏管理
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
//枚举游戏状态，运行和暂停
public enum GameState
{
    Running,
    Pause
}
public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public GameState gamestate = GameState.Running;//游戏状态，包括运行暂停
    public Inventory inventory;
    //所有可以增加的物品
    public Item ItemGrassDirtCube;
    public Item ItemLeaveCube;
    public Item ItemDirtCube;
    public Item ItemBlockCube;
    public Item ItemGlassCube;
    public Item ItemGoldCube;
    public Item ItemStoneCube;
    public Item ItemStoneCubeType1Cube;
    public Item ItemTreeCube;
    public Item ItemGraveCube;
    public Item ItemGrassCube;

    //背包全局变量
    public int[] itemsToAdd;
    private static GlobalControl packageController;
    private int numOfShow = 0;
    private int[] show = new int[12] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
    private int currentShow;
    

    void Start()
    {
    }

    void Awake()
    {
        packageController = GlobalControl.Instance;
        itemsToAdd = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        _instance = this;
        ShowItems();

        currentShow = 0;
    }

    ///从GlobalControl中加载背包数据
    public void LoadItems()
    {
        for (int i = 0; i < 12; i++)
        {
            itemsToAdd[i] = packageController.itemsToAdd[i];
        }
    }

    private void ShowItems()
    {
        LoadItems();
        for (int i = 0; i < 12; i++)
        {
            if (itemsToAdd[i] != 0)
            {
                show[numOfShow] = i;
                numOfShow++;
                switch (i)
                {
                    case 0:
                        inventory.AddItem(ItemBlockCube, itemsToAdd[i]);
                        break;
                    case 1:
                        inventory.AddItem(ItemDirtCube, itemsToAdd[i]);
                        break;
                    case 2:
                        inventory.AddItem(ItemGlassCube, itemsToAdd[i]);
                        break;
                    case 3:
                        inventory.AddItem(ItemGoldCube, itemsToAdd[i]);
                        break;
                    case 4:
                        inventory.AddItem(ItemGrassCube, itemsToAdd[i]);
                        break;
                    case 5:
                        inventory.AddItem(ItemGrassDirtCube, itemsToAdd[i]);
                        break;
                    case 6:
                        inventory.AddItem(ItemGraveCube, itemsToAdd[i]);
                        break;
                    case 7:
                        inventory.AddItem(ItemLeaveCube, itemsToAdd[i]);
                        break;
                    case 8:
                        inventory.AddItem(ItemStoneCube, itemsToAdd[i]);
                        break;
                    case 9:
                        inventory.AddItem(ItemStoneCubeType1Cube, itemsToAdd[i]);
                        break;
                    case 10:
                        inventory.AddItem(ItemTreeCube, itemsToAdd[i]);
                        break;
                    case 11:
                        break;
                }
            }
        }
    }

    //更新物品状态
    private void Update()
    {
        int ori = currentShow;
        int x = currentShow % 4;
        int y = currentShow / 4;
        //按wsad选择物品
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (x > 0)
            {
                x--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (x < 3)
            {
                x++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (y > 0)
            {
                y--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (y < 2)
            {
                y++;
            }
        }
        currentShow = x + y * 4;
        if (ori!= currentShow)
        {
            inventory.moveShowWindow(currentShow);
            packageController.currentHold = show[currentShow];
        }

        ////按U添加物品1
        //if (Input.GetKeyDown(KeyCode.U))
        //{
        //    inventory.AddItem(itemToAdd);
        //}
        ////按I添加物品1
        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    inventory.AddItem(itemToAdd2);
        //}
        ////按O删除物品
        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    inventory.RemoveItem(itemToAdd);
        //}
        //按ESC暂停游戏
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("u click esc");
            _instance.TransformGameState();
        }
    }
    //改变游戏的运行状态，运行与暂停
    public void TransformGameState()
    {
        if (gamestate == GameState.Running)
        {
            Time.timeScale = 0;
            gamestate = GameState.Pause;
        }
        else if (gamestate == GameState.Pause)
        {
            Debug.Log("pause hereeeeeeeeeeeeeeeeeeeeeeeeeee");
            Time.timeScale = 1;
            gamestate = GameState.Running;
        }
    }
}