using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Package_small : MonoBehaviour {

    //背包内物品图片
    public Image itemImages;
    //创建一个物品对象
    public Item items;
    //用于存储当前物品个数
    public Text counts;

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

    private static GlobalControl mainController;

    // Use this for initialization
    void Awake () {
        mainController = GlobalControl.Instance;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (mainController.currentHold >= 0)
        {
            counts.text = mainController.itemsToAdd[mainController.currentHold].ToString();
            switch (mainController.currentHold)
            {
                case 0:
                    items = ItemBlockCube;
                    break;
                case 1:
                    items = ItemDirtCube;
                    break;
                case 2:
                    items = ItemGlassCube;
                    break;
                case 3:
                    items = ItemGoldCube;
                    break;
                case 4:
                    items = ItemGrassCube;
                    break;
                case 5:
                    items = ItemGrassDirtCube;
                    break;
                case 6:
                    items = ItemGraveCube;
                    break;
                case 7:
                    items = ItemLeaveCube;
                    break;
                case 8:
                    items = ItemStoneCube;
                    break;
                case 9:
                    items = ItemStoneCubeType1Cube;
                    break;
                case 10:
                    items = ItemTreeCube;
                    break;
                case 11:
                    break;
            }
            itemImages.sprite = items.sprite;
            itemImages.enabled = true;

        }
        else if(counts.text != "Empty")
        {
            counts.text = "Empty";
            items = null;
            itemImages.sprite = null;
            itemImages.enabled = false;
        }
    }
}
