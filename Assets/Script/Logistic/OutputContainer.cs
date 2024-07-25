using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputContainer : BaseContainer
{
    
    [SerializeField] protected List<Vector2Int> allOuput = new List<Vector2Int>();
    [SerializeField] float outputTime = .2f;

    public List<Vector2Int> AllOutput => allOuput;
    //for testing 
    [SerializeField] ItemStruct testItem ;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(SearchAllOuputs), .1f);
        InvokeRepeating(nameof(OutputAtAllOutputs), outputTime, outputTime);
        objectRef.OnPlacement += (_object) => { SearchAllOuputs(_object.Location); };
    }

    private void Update()
    {
       
    }
    public void SearchAllOuputs(Vector2Int _loc)
    {
        allOuput.Clear();
        foreach (Vector2Int _locNeighbor in objectRef.NeighborList) {
            SearchOutput(_locNeighbor);
        }
    }
    void SearchOutput(Vector2Int _localLoc)
    {
        //Debug.Log("search output");
        //TilemapSlot _result = new TilemapSlot();
        Vector3Int _3DLoc = objectRef.GridManager.GetGridPos(transform.position);
        Vector2Int _loc =new Vector2Int(_3DLoc.x+_localLoc.x, _3DLoc.y+_localLoc.y);
        //Debug.Log(_loc);
        //gridManager.PosTaken(_loc, ref _result);
        if (objectRef.GridManager.ObjectOfTypeAtPos(_loc, "InputContainer"))
        { 
        allOuput.Add(_loc);
        }    
    }

    void OutputAtAllOutputs()
    {
        Debug.Log("allouptu");
        if (currentItemNumber <= 0 || allOuput.Count<=0 ) return;
    
            foreach (Vector2Int _vect in allOuput)
            {
                Output(testItem, _vect);
            }
        
    }
    
    void Output(ItemStruct _item, Vector2Int _loc)
    {
        objectRef.GridManager.PosTakenBy(_loc, out BaseObject _result);
        //test if output is possible
        Debug.Log(_result.GetComponent<InputContainer>().CanAddItem(_item));
        if (_result.GetComponent<InputContainer>().CanAddItem(_item) && CanRemoveItem(_item))
        {
            Debug.Log("add");
            RemoveItem(_item);
            _result.GetComponent<InputContainer>().AddItem(_item);
        }
    }
}
