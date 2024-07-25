using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputContainer : BaseContainer
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        objectRef.OnPlacement += AddToNeighborOutput;
        objectRef.OnRemoval += RemoveToNeighborOutput;
    }

    public override void AddItem(ItemStruct _items)
    {
        base.AddItem( _items );
        addItemEvent.Invoke();
    }

    public virtual void AddToNeighborOutput(BaseObject _object)
    {
        foreach(Vector2Int _loc in objectRef.NeighborList)
        {
            TilemapSlot _result ;
            if (objectRef.GridManager.PosTakenBy(_loc, out _result))
            {
                MultiOutputContainer _outpuContainer = _result.BaseObject.GetComponent<MultiOutputContainer>();
                if (!_outpuContainer) continue;
                _outpuContainer.AllOutput.Add(objectRef.Location);
            }
        }
    }

    public virtual void RemoveToNeighborOutput(BaseObject _object)
    {
        foreach (Vector2Int _loc in objectRef.NeighborList)
        {
            TilemapSlot _result;
            if (objectRef.GridManager.PosTakenBy(_loc, out _result))
            {
                MultiOutputContainer _outpuContainer = _result.BaseObject.GetComponent<MultiOutputContainer>();
                if (!_outpuContainer) continue;
                _outpuContainer.AllOutput.Remove(objectRef.Location);
            }
        }
    }


}
