using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FilterInputContainer : InputContainer
{
    [SerializeField] List<BaseItem> whiteListItems = new List<BaseItem>();

    public List<BaseItem> WhiteList => whiteListItems;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool CanAddItem(ItemStruct _items)
    { 
        //filter input work fine
       foreach (BaseItem _item in whiteListItems)
       {
            if (_item.NameItem == _items.Item.NameItem) // if item is in white list do standard test
            {
                 return base.CanAddItem(_items);
            }
       }
       return false;

    }

  
}
