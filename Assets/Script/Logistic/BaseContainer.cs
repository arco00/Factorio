using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEngine;

public class BaseContainer : MonoBehaviour
{
    [SerializeField] List<ItemStruct> listItems = null;
    [SerializeField] const float maxItem = 30;
    [SerializeField] float currentItemNumber = 0;
    [SerializeField] protected GridManager gridManager = null;
    [SerializeField] protected BaseObject objectRef = null;

    public Action addItemEvent = null;


    // Start is called before the first frame update

    public List<ItemStruct> ListItems => listItems;
     protected virtual void Start()
    {
        InitCurrentItemNumber();  
        gridManager=FindAnyObjectByType<GridManager>();
        objectRef = GetComponent<BaseObject>();
    }

    public virtual  bool AddItem(ItemStruct _items)
    {
        if (listItems.Count + _items.Number > maxItem) { return false; }
        int _size = listItems.Count;
        for (int i = 0; i < _size; i++)
        {
            if (listItems[i].Item == _items.Item)
            {
                listItems[i] = new ItemStruct(listItems[i].Item, listItems[i].Number + _items.Number);
                currentItemNumber += _items.Number;
                return true;
            }
        }
        listItems.Add(_items);
        currentItemNumber += _items.Number;
        return true;
    }

    public virtual bool RemoveItem(ItemStruct _items)
    {
        if (listItems.Count <= 0) { return false; }
        int _size = listItems.Count;
        for (int i = 0; i < _size; i++)
        {
            if (listItems[i].Item == _items.Item)
            {
                if (listItems[i].Number - _items.Number < 0) { return false; }
                listItems[i] = new ItemStruct(listItems[i].Item, listItems[i].Number - _items.Number);
                currentItemNumber -= _items.Number;
                return true;
            }
        }
        return false;
    }

    void InitCurrentItemNumber()
    {
        foreach(ItemStruct _item in listItems)
        {
            currentItemNumber += _item.Number;
        }
    }
}
