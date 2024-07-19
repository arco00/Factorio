using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputContainer : BaseContainer
{
    
    [SerializeField] protected List<Vector2Int> allOuput = new List<Vector2Int>();
    [SerializeField] bool test = true;
    [SerializeField] bool canOuput = true;
    [SerializeField] float outputTime = .2f,currentOutputTime=0;

    //for testing 
    [SerializeField] ItemStruct testItem ;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //SearchAllOuput();
    }

    private void Update()
    {
        //to activate shearcj output for testing and debuging
        if (test) { 
            SearchAllOuput();
            test = false;
        }

        if (canOuput)
        {
            AllOutput(testItem);
            Debug.Log("allouput");
        }
        else
        {
            if (Utile.Timer(ref currentOutputTime, ref outputTime ))
            {
                canOuput = true;
                currentOutputTime = 0;
            };
        }
    

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
        //Debug.Log(_loc);
        //gridManager.PosTaken(_loc, ref _result);
        if (gridManager.ObjectAtPos(_loc, "InputContainer"))
        { 
        allOuput.Add(_loc);
        }    
    }

    void AllOutput(ItemStruct _item)
    {
        foreach (Vector2Int _vect in allOuput)
        {
            Output(_item, _vect);
        }
    }
    
    void Output(ItemStruct _item, Vector2Int _loc)
    {
        gridManager.PosTaken(_loc, out TilemapSlot _result);
        //test if output is possible
        //Debug.Log(_result.GameObject.GetComponent<InputContainer>().CanAddItem(_item));
        if (_result.GameObject.GetComponent<InputContainer>().CanAddItem(_item) && CanRemoveItem(_item))
        {
            Debug.Log("add");
            RemoveItem(_item);
            _result.GameObject.GetComponent<InputContainer>().AddItem(_item);
            canOuput = false;
        }
    }
}
