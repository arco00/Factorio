
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CT_MultiOutputContainer : CT_BaseOutputContainer
{
    [SerializeField,Header("Multi Output")] protected List<Vector2Int> allOuput = new List<Vector2Int>();
    //for testing 
    [SerializeField] ItemStruct testItem;
    public List<Vector2Int> AllOutput => allOuput;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(SearchAllOuputs), .5f);
        //objectRef.OnPlacement += (_object) => { SearchAllOuputs(); };
        //outputContainer = this;
        
    }


    public void SearchAllOuputs()
    {
        allOuput.Clear();
        foreach (Vector2Int _locNeighbor in objectRef.NeighborList)
        {
            SearchOutput(_locNeighbor);
        }
    }
    void SearchOutput(Vector2Int _localLoc)
    {
        //Debug.Log("search output");
        //TilemapSlot _result = new TilemapSlot();
        //Vector3Int _3DLoc = objectRef.GridManager.GetGridPos(transform.position);
        //Vector2Int _loc = new Vector2Int(_3DLoc.x + _localLoc.x, _3DLoc.y + _localLoc.y);
        if (debug ) Debug.Log($"{ObjectRef.name}{_localLoc}{(objectRef.GridManager.ObjectOfTypeAtPos(_localLoc, inputContainerClassName))}");
        //gridManager.PosTaken(_loc, ref _result);
        if (objectRef.GridManager.ObjectOfTypeAtPos(_localLoc, inputContainerClassName))
        {
            allOuput.Add(_localLoc);
        }
    }


    protected override void OutputBehaviour()
    {

        if (debug) Debug.Log("allouptu");
        if (currentItemNumber <= 0 || allOuput.Count <= 0) return;

        foreach (Vector2Int _vect in allOuput)
        {
            foreach (ItemStruct item in listItems)
            {
                if (Output(item, _vect)) break ;
            }
        }

    }

    bool Output(ItemStruct _item, Vector2Int _loc)
    {
        if (_item.Number == 0) return false;

        if (objectRef.GridManager.PosTakenBy(_loc, out Object_BaseObject _result))
        {
            if (debug) Debug.Log(_result.GetComponent<CT_InputContainer>().CanAddItem(_item)); //debug
            CT_InputContainer _input = _result.GetComponent<CT_InputContainer>();
            if (!_input) return false;
            //test if output is possible
            if (_input.CanAddItem(_item) && CanRemoveItem(_item))
            {
               if (debug) Debug.Log("add");
               RemoveItem(_item);
               _input.AddItem(_item);
               OutputAtInput(new ItemStruct(_item.Item, 1), _loc);
               return true;
            }
        }
        return false;
    }
}