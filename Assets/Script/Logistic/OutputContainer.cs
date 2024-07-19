using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputContainer : BaseContainer
{
    
    [SerializeField] protected List<Vector2Int> allOuput = new List<Vector2Int>();
    [SerializeField] float outputTime = .2f;

    //for testing 
    [SerializeField] ItemStruct testItem ;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(SearchAllOuput), .1f);
        InvokeRepeating(nameof(AllOutput), outputTime, outputTime);
        //SearchAllOuput();
    }

    private void Update()
    {
       
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

    void AllOutput()
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
        gridManager.PosTaken(_loc, out TilemapSlot _result);
        //test if output is possible
        Debug.Log(_result.GameObject.GetComponent<InputContainer>().CanAddItem(_item));
        if (_result.GameObject.GetComponent<InputContainer>().CanAddItem(_item) && CanRemoveItem(_item))
        {
            Debug.Log("add");
            RemoveItem(_item);
            _result.GameObject.GetComponent<InputContainer>().AddItem(_item);
        }
    }
}
