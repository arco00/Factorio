using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputContainer : BaseContainer
{
    
    [SerializeField] protected List<Vector2Int> allOuput = new List<Vector2Int>();
    [SerializeField] bool test = true;
    [SerializeField] ItemStruct testItem ;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //SearchAllOuput();
    }

    private void Update()
    {
        if (test) { 
            SearchAllOuput();
            test = false;
        }
        AllOutput(testItem);
    

    }
    public void SearchAllOuput()
    {
        allOuput.Clear();
        SearchOutput(new Vector2Int(0, 1));
        SearchOutput(new Vector2Int(1, 0));
        SearchOutput(new Vector2Int(0, -1));
        SearchOutput(new Vector2Int(-1,0 ));
    }
    void SearchOutput(Vector2Int _localLoc)
    {
        //Debug.Log("search output");
        //TilemapSlot _result = new TilemapSlot();
        Vector3Int _3DLoc = gridManager.GetGridPos(transform.position);
        Vector2Int _loc =new Vector2Int(_3DLoc.x+_localLoc.x, _3DLoc.y+_localLoc.y);
        Debug.Log(_loc);
        //gridManager.PosTaken(_loc, ref _result);
        if (gridManager.ObjectAtPos(_loc, "InputContainer"))
        { 
        allOuput.Add(_loc);
        }    
    }

    void AllOutput(ItemStruct _item)
    {
        foreach (Vector2Int _vect in allOuput) {
            Output(_item, _vect);
        }
    }
    void Output(ItemStruct _item, Vector2Int _loc)
    {
        gridManager.PosTaken(_loc, out TilemapSlot _result);
        if (_result.GameObject.GetComponent<BaseContainer>().AddItem(_item))
        {
        RemoveItem(_item);
        }
    }
}
