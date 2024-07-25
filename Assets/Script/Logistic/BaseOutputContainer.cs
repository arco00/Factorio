using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseOutputContainer : BaseContainer
{
    
    
    [SerializeField] protected float outputTime = .2f;
    
    
    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(OutputBehaviour), outputTime, outputTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void OutputAtInput(ItemStruct _item, Vector2Int _loc)
    {
        if (!CanRemoveItem(_item)) return;
        objectRef.GridManager.PosTakenBy(_loc, out TilemapSlot _result);
        //test if output is possible
        Debug.Log(_result.BaseObject.GetComponent<InputContainer>().CanAddItem(_item));
        if (_result.BaseObject.GetComponent<InputContainer>().CanAddItem(_item) )
        {
            //Debug.Log("add");
            _result.BaseObject.GetComponent<InputContainer>().AddItem(_item);
            RemoveItem(_item);
        }
    }

    protected virtual void OutputAtContainer(ItemStruct _item, Vector2Int _loc)
    {
        if (!CanRemoveItem(_item)) return;
        Debug.Log("test tapis");
        objectRef.GridManager.PosTakenBy(_loc, out TilemapSlot _result);
        BaseContainer _container = _result.BaseObject.GetComponent<BaseContainer>();
        if (!_container) return;
        InputContainer _inputContainer = _container.GetComponent<InputContainer>();
        if (_inputContainer) // put in the input container first 
        {
            if (_inputContainer.CanAddItem(_item))
            {
                _inputContainer.AddItem(_item);
                RemoveItem(_item);
            }
        }
        else  // it not injput container put in the output container 
        {
            if (_container.CanAddItem(_item))
            {
                _container.GetComponent<BaseOutputContainer>().AddItem(_item);
                RemoveItem(_item);
            }
        }

    }

    protected virtual void OutputBehaviour()
    {

    }
}

