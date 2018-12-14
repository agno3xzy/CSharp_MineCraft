using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickDestory : MonoBehaviour
{

    //玩家当前方块名称
     private static string currentCube;

    private void Start()
    {
        currentCube = "EMPTY";
    }
    private void FixedUpdate()
    {
        
    }
    void OnMouseDown()
    {
        Debug.Log("!!!!!!!物件名称为：" + currentCube + ":" + currentCube.Length);
        //用户敲击左键摧毁物品
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                string[] sArray = hit.transform.gameObject.name.Split('(');
                currentCube = sArray[0];
                Debug.Log("左键销毁操作的目标方块 名称：" + currentCube + ":"+ currentCube.Length);
            }
            Destroy(GameObject.Find(hit.transform.gameObject.name.Trim()));
            Debug.Log("销毁操作！！！！！！！");
            //Destroy(GameObject.Find(hit.transform.gameObject.name));
        }

    }

    //单击右键新建物品
    void OnMouseOver()
    {
        Debug.Log("1物件名称为：" + currentCube + ":" + currentCube.Length);
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("2物件名称为：" + currentCube + ":" + currentCube.Length);
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("touch area is UI");
            }
            else
            {
                Debug.Log("3物件名称为：" + currentCube + ":" + currentCube.Length);
                //如果当前用户手持物品不为空，则新建物品
                if (currentCube != "EMPTY")
                {

                    GameObject cube = GameObject.Find(currentCube.Trim());
                    Debug.Log("添加新物件,物件名称为：" + currentCube + ":" + currentCube.Length);
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log(hit.point);
                        Vector3 makeItHight = hit.point;
                        makeItHight.Set(makeItHight.x, makeItHight.y, (float)(makeItHight.z + 1.0));
                        //Instantiate(cube, hit.point, transform.rotation);
                        Instantiate(cube, makeItHight, transform.rotation);
                        currentCube = "EMPTY";
                    }

            }
                else
                {
                Debug.Log("玩家手中无物品");
            }
        }

        }
    }
}
