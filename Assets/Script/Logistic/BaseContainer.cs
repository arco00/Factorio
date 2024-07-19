using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class BaseContainer : MonoBehaviour
{
    [SerializeField] protected List<ItemStruct> listItems = null;
    [SerializeField] protected float maxItem = 30,currentItemNumber=0;
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

    public virtual bool CanAddItem(ItemStruct _items)
    {
        //if not enough place 
        return (currentItemNumber + _items.Number <= maxItem);
    }

    public virtual bool CanRemoveItem(ItemStruct _items)
    {
        Debug.Log("remove");
        //test if not enough item stocked
        if (currentItemNumber < _items.Number) { return false; }
        
        //search good item and test number of it
        int _size = listItems.Count;
        for (int i = 0; i < _size; i++)
        {
            if (listItems[i].Item.NameItem == _items.Item.NameItem)
            {
                //test if enough item of this type
                if (listItems[i].Number - _items.Number < 0)  return false; 
                return true;
            }
        }
        return false;
    }

    protected void InitCurrentItemNumber()
    {
        foreach(ItemStruct _item in listItems)
        {
            currentItemNumber += _item.Number;
        }
    }

    public virtual void RemoveItem(ItemStruct _items)
    {
        //don't remove
        int _size = listItems.Count;
        for (int i = 0; i < _size; i++)
        {
            if (listItems[i].Item.NameItem == _items.Item.NameItem)
            {
                listItems[i] = new ItemStruct(listItems[i].Item, listItems[i].Number - _items.Number);
                currentItemNumber -= _items.Number;
                if (listItems[i].Number <= 0) // remove item from list if numer == 0
                {
                    listItems.RemoveAt(i);
                }
                return;
            }
        }

    }

    public virtual void AddItem(ItemStruct _items)
    {
        if (CanAddItem(_items)) { return; }
        int _size = listItems.Count;
        for (int i = 0; i < _size; i++)
        {
            if (listItems[i].Item.NameItem == _items.Item.NameItem)
            {
                listItems[i] = new ItemStruct(listItems[i].Item, listItems[i].Number + _items.Number);
                currentItemNumber += _items.Number;
                Debug.Log(gameObject);
                return;
            }
        }

        //if not already in the container
        listItems.Add(_items);
        currentItemNumber += _items.Number;

    }

  

}
