using System;
using UnityEngine;
using UnityEngine.UI;

//背包系统操作类
public class Inventory : MonoBehaviour
{
    public Item Selected;
    public Item UnSelected;
    //背包内物品图片
    public Image[] itemImages = new Image[numItemSlots];
    //背包内背景图片
    public Image[] itemBackImages = new Image[numItemSlots];
    //创建一个物品对象
    public Item[] items = new Item[numItemSlots];
    //用于存储当前物品个数
    public Text[] counts = new Text[numItemSlots];
    //背包格数，一共有十一种物品
    public const int numItemSlots = 11;
    private int itemCount = 0;
    private int currentSelectedNo = 0;

    private void Awake()
    {
        itemBackImages[0].sprite = Selected.sprite;
        for (int i = 1; i < 12; i++)
        {
            itemBackImages[i].sprite = UnSelected.sprite;
        }
    }

    //加入物品
    public void AddItem(Item itemToAdd, int count)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if(items[i] == itemToAdd)
            {
                counts[i].text = count.ToString();
                break;
            }
            else if(items[i] == null)
            {
                counts[i].text = count.ToString();
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
                return;
            }
            //Debug.Log("Inventory as follow: ");
            //if (items[i] == itemToAdd)
            //{
            //    Debug.Log("items[i] == itemToAdd");
            //    itemCount = Int32.Parse(counts[i].text.Trim());
            //    itemCount += 1;
            //    counts[i].text = itemCount.ToString();
            //    break;
            //}
            //else if (items[i] == null)
            //{
            //    itemCount = 1;
            //    counts[i].text = itemCount.ToString();
            //    items[i] = itemToAdd;
            //    itemImages[i].sprite = itemToAdd.sprite;
            //    itemImages[i].enabled = true;
            //    return;
            //}
        }
    }

    public void moveShowWindow(int ShowWindowNo)
    {
        itemBackImages[ShowWindowNo].sprite = Selected.sprite;
        itemBackImages[currentSelectedNo].sprite = UnSelected.sprite;
        currentSelectedNo = ShowWindowNo;
    }
}