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

    public List<ItemStruct> ItemNeedesForCraft => itemNeededForCraft;
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
            usineRef.InputRef.RemoveItem(_item);
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
            //timer for not instant craft
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
        //here is the bug found it , resolved
        // test avec le name ?
        bool _craftable = true;

        foreach (ItemStruct _item in itemNeededForCraft)
        {
            _craftable= _craftable && usineRef.InputRef.CanRemoveItem(_item) && usineRef.OutputRef.CanAddItem(_item);
        }
        return _craftable;

    }

    public void InputCheckCraft (InputAction.CallbackContext _context)
    {
        Debug.Log("testInput");
        CheckCraft();
    }
}
