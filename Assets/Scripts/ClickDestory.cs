using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickDestory : MonoBehaviour
{
    //backpack
    public int[] itemsToAdd;

    //玩家当前方块名称
    private static string currentCube;
    private static bool m_Lock;
    private static float m_WaitTime = 0.1f;
    private static float m_RouteAngle = 20.0f;
    private static GameObject m_Arm;
    private static int cloneNum = 0;
    private static GlobalControl mainController ;

    private void Start()
    {
        mainController = GlobalControl.Instance;
        itemsToAdd = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        currentCube = "EMPTY";
        m_Arm = GameObject.Find("ArmCube");
        m_Lock = false;
    }

    ///从GlobalControl中加载背包数据
    public void LoadItems()
    {
        for (int i = 0; i < 12; i++)
        {
            itemsToAdd[i] = mainController.itemsToAdd[i];
        }
    }
    //保存用户数据
    public void SavePlayer()
    {
        Debug.Log("SavePlayer()!!!");
        for (int i = 0; i < 12; i++)
        {
            mainController.itemsToAdd[i] = itemsToAdd[i];
        }
    }

    //增加物品
    public void AddItems(String item)
    {
        LoadItems();
        if (item.Equals("BlockCube"))
        {
            itemsToAdd[0]++;
        }
        else if (item.Equals("DirtCube"))
        {
            itemsToAdd[1]++;
        }
        else if (item.Equals("GlassCube"))
        {
            itemsToAdd[2]++;
        }
        else if (item.Equals("GoldCube"))
        {
            itemsToAdd[3]++;
        }
        else if (item.Equals("GrassCube"))
        {
            itemsToAdd[4]++;
        }
        else if (item.Equals("GrassDirtCube"))
        {
            itemsToAdd[5]++;
        }
        else if (item.Equals("GraveCube"))
        {
            itemsToAdd[6]++;
        }
        else if (item.Equals("LeaveCube"))
        {
            itemsToAdd[7]++;
        }
        else if (item.Equals("StoneCube"))
        {
            itemsToAdd[8]++;
        }
        else if (item.Equals("StoneCubeType1"))
        {
            itemsToAdd[9]++;
        }
        else if (item.Equals("TreeCube"))
        {
            itemsToAdd[10]++;
        }
        SavePlayer();
    }

    /*减少物品
    若用户想要放置某个物品同时背包当前该物品的数量
    大于零则函数返回ture允许用户放置物品
    若背包内该物品数量小于零则返回false拒绝用户放置物品
    且给予用户提示（待完成）
         */
    public bool DeleteItems(String item)
    {
        LoadItems();
        if (item.Equals("BlockCube"))
        {
            if (itemsToAdd[0] == 0)
            {
                return false;
            }
            itemsToAdd[0]--;
        }
        else if (item.Equals("DirtCube"))
        {
            if (itemsToAdd[1] == 0)
            {
                return false;
            }
            itemsToAdd[1]--;
        }
        else if (item.Equals("GlassCube"))
        {
            if (itemsToAdd[2] == 0)
            {
                return false;
            }
            itemsToAdd[2]--;
        }
        else if (item.Equals("GoldCube"))
        {
            if (itemsToAdd[3] == 0)
            {
                return false;
            }
            itemsToAdd[3]--;
        }
        else if (item.Equals("GrassCube"))
        {
            if (itemsToAdd[4] == 0)
            {
                return false;
            }
            itemsToAdd[4]--;
        }
        else if (item.Equals("GrassDirtCube"))
        {
            if (itemsToAdd[5] == 0)
            {
                return false;
            }
            itemsToAdd[5]--;
        }
        else if (item.Equals("GraveCube"))
        {
            if (itemsToAdd[6] == 0)
            {
                return false;
            }
            itemsToAdd[6]--;
        }
        else if (item.Equals("LeaveCube"))
        {
            if (itemsToAdd[7] == 0)
            {
                return false;
            }
            itemsToAdd[7]--;
        }
        else if (item.Equals("StoneCube"))
        {
            if (itemsToAdd[8] == 0)
            {
                return false;
            }
            itemsToAdd[8]--;
        }
        else if (item.Equals("StoneCubeType1"))
        {
            if (itemsToAdd[9] == 0)
            {
                return false;
            }
            itemsToAdd[9]--;
        }
        else if (item.Equals("TreeCube"))
        {
            if (itemsToAdd[10] == 0)
            {
                return false;
            }
            itemsToAdd[10]--;
        }
        SavePlayer();
        return true;
    }

    IEnumerator MoveArm(float i, RaycastHit hit)
    {
        yield return new WaitForSeconds(m_WaitTime);
        Destroy(GameObject.Find(hit.transform.gameObject.name.Trim()));
        m_Arm.transform.Rotate(0, i, 0, Space.Self);
        Debug.Log(1);
        m_Lock = false;
    }

    private void FixedUpdate()
    {
    }
    void OnMouseDown()
    {
        Debug.Log("!!!!!!!物件名称为：" + currentCube + ":" + currentCube.Length);
        //用户敲击左键摧毁物品
        if (Input.GetMouseButtonDown(0) && !m_Lock)
        {
            m_Lock = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                //确认此时玩家手上拿的是场景内置的物品还是玩家新建的物品
                if (hit.transform.gameObject.name.Contains("_") == true)
                {
                    string[] sArray = hit.transform.gameObject.name.Split('_');
                    currentCube = sArray[0].TrimEnd();
                    //将玩家摧毁的物品纳入背包
                    AddItems(currentCube);
                }
                else
                {
                    string[] sArray = hit.transform.gameObject.name.Split('(');
                    currentCube = sArray[0].TrimEnd();
                    //将玩家摧毁的物品纳入背包
                    AddItems(currentCube);
                }            
                Debug.Log("左键销毁操作的目标方块 名称：" + currentCube + "目前GrassCube的数量:" + itemsToAdd[4]);
            }
            m_Arm.transform.Rotate(0, -m_RouteAngle, 0, Space.Self);
            StartCoroutine(MoveArm(m_RouteAngle, hit));
            Debug.Log("销毁操作！！！！！！！");
        }
        Debug.Log(2);
    }

    Vector3 normalisationPosition(Vector3 ori, Vector3 originPosition)
    {
        Vector3 pos = originPosition;

        Debug.Log("originPosition" + originPosition);
        Debug.Log("ori" + ori);

        if (Math.Round((originPosition.x - ori.x) * 10) == 5)
        {
            pos.x -= 1;
        }
        else if (Math.Round((originPosition.y - ori.y) * 10) == 5)
        {
            pos.y -= 1;
        }
        else if (Math.Round((originPosition.z - ori.z) * 10) == 5)
        {
            pos.z -= 1;
        }
        else if (Math.Round((originPosition.x - ori.x) * 10) == -5)
        {
            pos.x += 1;
        }
        else if (Math.Round((originPosition.y - ori.y) * 10) == -5)
        {
            pos.y += 1;
        }
        else if (Math.Round((originPosition.z - ori.z) * 10) == -5)
        {
            pos.z += 1;
        }

        Debug.Log(pos);
        Debug.Log(3);
        return pos;
    }
    //单击右键新建物品
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && !m_Lock)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("touch area is UI");
            }
            else
            {
                //如果当前用户手持物品不为空，则新建物品
                //如果当前用户想放置的物品数量大于零时
                //待改：此部分逻辑需要整理 currentCube != "EMPTY"
                if (mainController.currentHold>=0)
                {
                    if (mainController.itemsToAdd[mainController.currentHold]>0)
                    {
                        switch (mainController.currentHold)
                        {
                            case 0:
                                currentCube = "BlockCube";
                                break;
                            case 1:
                                currentCube = "DirtCube";
                                break;
                            case 2:
                                currentCube = "GlassCube";
                                break;
                            case 3:
                                currentCube = "GoldCube";
                                break;
                            case 4:
                                currentCube = "GrassCube";
                                break;
                            case 5:
                                currentCube = "GrassDirtCube";
                                break;
                            case 6:
                                currentCube = "GraveCube";
                                break;
                            case 7:
                                currentCube = "LeaveCube";
                                break;
                            case 8:
                                currentCube = "StoneCube";
                                break;
                            case 9:
                                currentCube = "StoneCubeType1Cube";
                                break;
                            case 10:
                                currentCube = "TreeCube";
                                break;
                            case 11:
                                break;
                        }
                    }
                    else
                    {
                        currentCube = "EMPTY";
                    }
                    
                }
                else
                {
                    currentCube = "EMPTY";
                }
                
                if (currentCube != "EMPTY")
                {
                    DeleteItems(currentCube);
                    GameObject cube = GameObject.Find(currentCube);
                    Debug.Log("添加新物件,物件名称为：" + currentCube + ":" + currentCube.Length);
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        Vector3 makeItHight = hit.point;
                        makeItHight = normalisationPosition(makeItHight, GameObject.Find(hit.transform.gameObject.name.Trim()).transform.position);
                        if (makeItHight != Vector3.zero)
                        {
                            Debug.Log("Instantiate(cube, makeItHight, transform.rotation):   " + currentCube);
                            Debug.Log("currentCube.Trim().Length()   " + currentCube.Length);
                            Instantiate(cube, makeItHight, transform.rotation);
                            GameObject g = GameObject.Find(currentCube + "(Clone)");
                            g.name = currentCube + "_" + cloneNum;
                            cloneNum++;
                        }
                        currentCube = "EMPTY";
                        if (mainController.itemsToAdd[mainController.currentHold] == 0)
                        {
                            mainController.currentHold = -1;
                        }
                    }

                }
                else
                {
                    Debug.Log("玩家手中无物品");
                }
            }

        }
        Debug.Log(4);
    }
}