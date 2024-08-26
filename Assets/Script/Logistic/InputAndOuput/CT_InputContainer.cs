
using UnityEngine;

public class CT_InputContainer : CT_BaseContainer
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
    }

    public virtual void AddToNeighborOutput(Object_BaseObject _object)
    {
        foreach(Vector2Int _loc in objectRef.NeighborList)
        {

            if (objectRef.GridManager.PosTakenBy(_loc, out Object_BaseObject _result))
            {
                CT_MultiOutputContainer _outpuContainer =_result.GetComponent<CT_MultiOutputContainer>();

                if (!_outpuContainer) continue;
                _outpuContainer.AllOutput.Add(objectRef.Location);
            }
        }
    }

    public virtual void RemoveToNeighborOutput(Object_BaseObject _object)
    {
        foreach (Vector2Int _loc in objectRef.NeighborList)
        { 
            if (objectRef.GridManager.PosTakenBy(_loc, out Object_BaseObject _result))
            {
                CT_MultiOutputContainer _outpuContainer = _result.GetComponent<CT_MultiOutputContainer>();

                if (!_outpuContainer) continue;
                _outpuContainer.AllOutput.Remove(objectRef.Location);
            }
        }
    }


}
