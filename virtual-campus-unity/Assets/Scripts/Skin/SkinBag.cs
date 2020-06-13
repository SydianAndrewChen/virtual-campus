﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinBag : Bag
{
    public static SkinBag Instance;

    public int index;

    protected virtual void Awake()
    {
        Instance = this;
    }

    public void OnSaveClicked()
    {
        if (currentItem != null)
        {
            SpriteItem spriteItem = new SpriteItem(currentItem);
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Mapping>().ChangeMapping(spriteItem);
        }
        BagButtonPressed();
    }


    public override void Add(GameObject obj, bool copy = true)
    {
        var display = Instantiate(displayPrefab);
        var itemBox = display.GetComponent<SkinBox>();

        Item item;
        if (copy)
        {
            item = Instantiate(obj).GetComponent<Item>();
        }
        else
        {
            item = obj.GetComponent<Item>();
        }
        item.transform.parent = transform;

        itemBox.Init(item);

        itemBoxs.Add(itemBox);
        display.transform.parent = layout;
    }

    public void OnCancelClicked()
    {
        BagButtonPressed();
    }

    public override void Select(Item item) 
    {
        detailImage.sprite = item.image;
        detailName.text = item.itemName;
        detailDescription.text = item.description;
        currentItem = item;
    }
}