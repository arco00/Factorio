using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class BaseRecipe : MonoBehaviour
{
    [SerializeField] BaseUsine usineRef = null;
    [SerializeField] List<ItemStruct> itemNeededForCraft = null;
    [SerializeField] List<ItemStruct> itemToCraft=null;
    [SerializeField] float craftingTime = 100;
    [SerializeField] float currentCraftingTime=0;
    [SerializeField] bool canCraft =false ;

    // Start is called before the first frame update
    private void Awake()
    {
        usineRef = GetComponent<BaseUsine>();
        
    }
    void Start()
    {
    }

    private void OnEnable()
    {
        usineRef.craftItem += (AllCreateAndRemove);
    }


    protected virtual void  AllCreateAndRemove()
    {
        Debug.Log("craft");
        foreach(ItemStruct _item in itemNeededForCraft)
        {
            usineRef.StockageRef.RemoveItem(_item);
        }
        foreach (ItemStruct _item in itemToCraft)
        { 
            usineRef.OutputRef.AddItem(_item);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canCraft)
        {
            if (Utile.Timer(ref currentCraftingTime, ref craftingTime))
            {
                canCraft = true;
                currentCraftingTime = 0;
            }
        }
    }

    
    public void CheckCraft()
    {
        Debug.Log("checkcraft");
        if (HasItemRequired() && canCraft)
        {
            usineRef.craftItem?.Invoke();
            canCraft = false;
        }
        else { return; }
    }

    protected virtual bool HasItemRequired()
    {
        //here is the bug found it 
        // test avec le name ?
        List<ItemStruct> _itemsStocked =  usineRef.StockageRef.ListItems;
        bool _craftable = true;

        foreach (ItemStruct _item in itemNeededForCraft)
        {
            bool _tempCraftable = false;
            foreach (ItemStruct _itemStocked in _itemsStocked)
            {
                if (_item.Item.NameItem == _itemStocked.Item.NameItem && _item.Number<= _itemStocked.Number)
                {
                    _tempCraftable = true;
                }
            }
            _craftable = _craftable && _tempCraftable;
            if (!_craftable) { return false; }
        }
        return _craftable;

    }

    public void InputCheckCraft (InputAction.CallbackContext _context)
    {
        Debug.Log("testInput");
        CheckCraft();
    }
}
