
using System.Collections.Generic;

using UnityEngine;

public class CT_FilterInputContainer : CT_InputContainer
{
    [SerializeField] List<BaseItem> whiteListItems = new List<BaseItem>();
    public List<BaseItem> WhiteList => whiteListItems;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
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
