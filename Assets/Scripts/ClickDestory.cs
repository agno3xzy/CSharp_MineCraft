using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickDestory : MonoBehaviour {


    private string currentCube = "EMPTY";

    //void OnMouseDown()
    //{
    //    if (Input.GetMouseButtonUp(1))
    //        Destroy(this.gameObject);

    //}
    public string GetCube()
    {
        return currentCube;
    }
    public void SetCube(string name)
    {
         currentCube = name.Trim();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
          
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                string[] sArray = hit.transform.gameObject.name.Split('(');
                SetCube( sArray[0]);
                Debug.Log(GetCube());
                //Debug.Log(hit.transform.gameObject.name);
              
                }
  Destroy(GameObject.Find(hit.transform.gameObject.name));
        }
    }

    //right click create an object
    void OnMouseOver()
    {


        GameObject cube = GameObject.Find(GetCube());
        Debug.Log(GetCube().Length);
        if (Input.GetMouseButtonDown(1))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("touch area is UI");
            }
            else
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.point);
                    Vector3 makeItHight = hit.point;
                    makeItHight.Set(makeItHight.x, makeItHight.y, (float)(makeItHight.z + 0.3));
                    Instantiate(cube, hit.point, transform.rotation);
                }
            }
        }

    }
}
