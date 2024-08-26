
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class BaseRecipe : MonoBehaviour
{
    [SerializeField] BaseUsine usineRef = null;
    [SerializeField] List<ItemStruct> itemNeededForCraft = null;
    [SerializeField] List<ItemStruct> itemToCraft=null;
    [SerializeField] float craftingTime = 1;
    [SerializeField] float numberItemNeededForCraft = 1;

    public List<ItemStruct> ItemNeededForCraft => itemNeededForCraft;
    // Start is called before the first frame update
    private void Awake()
    {
        usineRef = GetComponent<BaseUsine>();
        
    }
    void Start()
    {
        InvokeRepeating(nameof(CheckCraft), craftingTime, craftingTime);
        usineRef.craftItem += (AllCreateAndRemove);
        InitNumberItemNeededForCraft();
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
    
    public void CheckCraft()
    {
        if (usineRef.InputRef.CurrentItemNumber < numberItemNeededForCraft) return;
        Debug.Log("checkcraft");
        if (HasItemRequired()) usineRef.craftItem?.Invoke();  
        else  return; 
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

    protected void InitNumberItemNeededForCraft()
    {
        numberItemNeededForCraft = 0;
        foreach(ItemStruct _items in itemNeededForCraft)
        {
            numberItemNeededForCraft += _items.Number;
        }
    }
}
