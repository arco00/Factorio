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

    public override void AddItem(ItemStruct _items)
    {
        addItemEvent.Invoke();
        base.AddItem( _items );
    }


}
