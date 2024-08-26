
using System.Collections.Generic;
using UnityEngine;


public class GridManager : Singleton<GridManager>
{
    //public class UIManager : Singleton<UIManager>
    [SerializeField] protected Grid grid = null;
    [SerializeField]  Dictionary<Vector2Int, Object_BaseObject> tilemapDictionary = new Dictionary<Vector2Int, Object_BaseObject>();
   
    public Grid Grid => grid;

    public Dictionary<Vector2Int, Object_BaseObject> TilemapDictionary => tilemapDictionary;
    protected override void Awake()
    {
        base.Awake();
    }

    public  Vector3Int GetGridPos(Vector3 _pos)
    {
        return grid.WorldToCell(_pos);
    }
    public Vector2Int GetGridPos2D(Vector3 _pos)
    {
        Vector3Int _posInt = grid.WorldToCell(_pos);
        return Utile.Vector3ToVector2(_posInt);
    }
    public  bool SetGridPosAt(Vector2Int _pos, Object_BaseObject _gameObject)
    {
        //tester si la case est libre 
        if (tilemapDictionary.ContainsKey(_pos)) return false; 
        tilemapDictionary.TryAdd(_pos,_gameObject);
        _gameObject.transform.position=grid.CellToWorld(Utile.Vector2ToVector3(_pos));
        return true;
          
    }

    public bool SetGridPosAt(Vector3Int _pos, Object_BaseObject _gameObject)
    {
        //tester si la case est libre 

        Vector2Int _pos2D = Utile.Vector3ToVector2(_pos);
        if (tilemapDictionary.ContainsKey(_pos2D)) return false;
        tilemapDictionary.TryAdd(_pos2D, _gameObject);
        _gameObject.transform.position = grid.CellToWorld(new Vector3Int(_pos.x, _pos.y, 0));
        return true;
    }
    public bool ObjectOfTypeAtPos(Vector2Int _pos,string _class)
    {
        //1er test sans le dictionary
        // know if ther is an object of type class at pos
        //changer la 2eme var
        //pas de string
        //Debug.Log(_class);
        if (PosTakenBy(_pos, out Object_BaseObject _result))
        {
            //Debug.Log(_result);
            return _result.GetComponent(_class) ;  
        }
        return false;
    }

    public bool PosTakenBy(Vector2Int _pos, out Object_BaseObject _result)
    {
         return tilemapDictionary.TryGetValue(_pos, out _result);
    }


}




   


