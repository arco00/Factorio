using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiOutputContainer : BaseOutputContainer
{
    [SerializeField] protected List<Vector2Int> allOuput = new List<Vector2Int>();
    //for testing 
    [SerializeField] ItemStruct testItem ;
    public List<Vector2Int> AllOutput => allOuput;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(SearchAllOuputs), .1f);
        objectRef.OnPlacement += (_object) => { SearchAllOuputs(_object.Location); };
        //outputContainer = this;
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


    protected override void OutputBehaviour()
    {
        if (currentItemNumber <= 0 || allOuput.Count <= 0) return;

        foreach (Vector2Int _vect in allOuput)
        {
            foreach(ItemStruct _item in listItems)
            {
                OutputAtInput (new ItemStruct(_item.Item, 1), _vect); 
            }
        }
    }

}
