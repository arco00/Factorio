using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputContainer : BaseContainer
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    public override bool AddItem(ItemStruct _items)
    {
        addItemEvent.Invoke();
        return  base.AddItem( _items );
    }


}
