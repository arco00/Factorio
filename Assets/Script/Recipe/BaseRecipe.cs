using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

public class BaseRecipe : MonoBehaviour
{
    [SerializeField] BaseUsine usineRef = null;
    [SerializeField] BaseItem itemInput1 = null;
    [SerializeField] BaseItem itemOuput1 = null;
    [SerializeField] int itemInput1Number = 1;
    [SerializeField] int itemOutput1Number = 1;
    [SerializeField] float craftingTime = 1;
    [SerializeField] bool canCraft =false ;
    
    // Start is called before the first frame update
    void Start()
    {
        usineRef = GetComponent<BaseUsine>();
    }

    private void OnEnable()
    {
        usineRef.craftItem += (AllCreateAndRemove);
    }

    private void OnDisable()
    {
        usineRef.craftItem-=(AllCreateAndRemove);
    }

    protected virtual void  AllCreateAndRemove()
    {
        Debug.Log("craft");
        CreateItem(itemOuput1, itemOutput1Number);
        UseItem(itemInput1, itemInput1Number); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckCraft()
    {
        Debug.Log("checkcraft");
        if (HasItemRequired(itemInput1,itemInput1Number))
        {
            usineRef.CraftItem?.Invoke();
        }
    }

    protected virtual bool HasItemRequired(BaseItem _item, int _numberNeeded)
    {
        int _size = usineRef.StockageRef.ListItems.Count;
        int _actualNumber = 0;
        for (int i = 0; i < _size; i++)
        {
            BaseItem _itemInList = usineRef.StockageRef.ListItems[i];
            if (_itemInList.GetComponent<BaseItem>() == _item.GetComponent<BaseItem>())
            {
                _actualNumber++;
            }
        }
        return (_actualNumber >= _numberNeeded);

    }

    protected virtual void CreateItem(BaseItem _item,int _number)
    {
        for (int i = 0; i < _number; i++)
        {
            Debug.Log("create");
            usineRef.StockageRef.AddItem(_item);
            usineRef.AddItemEvent?.Invoke();
        }
    }

    protected virtual void UseItem(BaseItem _item, int _number)
    {
        for (int i = 0; i < _number; i++)
        {
            Debug.Log("remove");
            usineRef.StockageRef.RemoveItem(_item);

        }

    }
}
