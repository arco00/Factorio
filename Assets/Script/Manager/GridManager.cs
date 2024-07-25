using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GridManager : Singleton<GridManager>
{
    //public class UIManager : Singleton<UIManager>
    //[SerializeField] List<TilemapSlot> listTilemap = new List<TilemapSlot>(); passe sur un dictionary
    Dictionary<Vector2, BaseObject> tilemapDictionary;
    [SerializeField] protected Grid grid = null;
    // Start is called before the first frame update
    public Grid Grid => grid;

    public Dictionary<Vector2, BaseObject> TilemapDictionary => tilemapDictionary;
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
        return new Vector2Int(_posInt.x,_posInt.y);
    }
    public  bool SetGridPosAt(Vector2Int _pos,BaseObject _gameObject)
    {
        //tester si la case est libre 

        if (tilemapDictionary.TryAdd(_pos, _gameObject))
        {
        _gameObject.transform.position=grid.CellToWorld(new Vector3Int(_pos.x,_pos.y,0));
        return true;
        }
        return false;
    }

    public bool SetGridPosAt(Vector3Int _pos, BaseObject _gameObject)
    {
        //tester si la case est libre 

        Vector2Int _pos2D = new Vector2Int(_pos.x, _pos.y);
        if (tilemapDictionary.TryAdd(_pos2D, _gameObject))
        {
            _gameObject.transform.position = grid.CellToWorld(new Vector3Int(_pos.x, _pos.y, 0));
            return true;
        }
        return false;
    }
    public bool ObjectOfTypeAtPos(Vector2Int _pos,string _class)
    {
        //1er test sans le dictionary
        // know if ther is an object of type class at pos
        //changer la 2eme var
        //pas de string
        //Debug.Log(_class);
        //if (PosTaken(_pos, out TilemapSlot result))
        //{
        //    // Debug.Log(_result.gameObject.GetComponent(_class).name.ToString());
        //    //pas la bonne comparaison 
        //    bool _bool = _result.BaseObject.GetComponent(_class) != null;
        //    //Debug.Log(_bool);
        //    //Debug.Log(_result.GameObject.GetComponent<BaseObject>().ToString());
        //    return _bool ;
        //}
        //return false;
        if (tilemapDictionary.TryGetValue(_pos,out BaseObject _result ))
        {
            return _result.GetComponent(_class) ;  
        }
        return false; 
    }




    public bool PosTakenBy(Vector2Int _pos, out BaseObject _result)
    {
        if (tilemapDictionary.ContainsKey(_pos))
        {
            _result = tilemapDictionary[(_pos)] ;
            return true;
        }
        _result = null;
        return false;
    }


}
