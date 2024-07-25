using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GridManager : Singleton<GridManager>
{
    //public class UIManager : Singleton<UIManager>
    //[SerializeField] List<TilemapSlot> listTilemap = new List<TilemapSlot>(); passe sur un dictionary
    Dictionary<Vector2, BaseObject> TilemapDictionary;
    [SerializeField] protected Grid grid = null;
    // Start is called before the first frame update
    public Grid Grid => grid;   
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

        if (TilemapDictionary.TryAdd(_pos, _gameObject))
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
        if (TilemapDictionary.TryAdd(_pos2D, _gameObject))
        {
            _gameObject.transform.position = grid.CellToWorld(new Vector3Int(_pos.x, _pos.y, 0));
            return true;
        }
        return false;
    }
    public bool ObjectOfTypeAtPos(Vector2Int _pos,string _class)
    {
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
        if (TilemapDictionary.TryGetValue(_pos,out BaseObject _result ))
        {
            return _result.GetComponent(_class) ;  
        }
        return false; 


    }


    public bool PosTaken(Vector2Int _pos, out TilemapSlot _result)
    {

        
        //foreach (Key _slot in TilemapDictionary)
        //{
        //    if (_slot == _pos)
        //    {
        //        //savoir par quoi (_slot) est prise la case
        //        _result = _slot;
        //        return true;
        //    }
        //}
        _result = TilemapSlot.Null();
        return TilemapDictionary.ContainsKey(_pos);
    }

    public bool PosTakenBy(Vector2Int _pos, out TilemapSlot _result)
    {

    }

    public bool PosTaken(Vector3Int _pos3D, out TilemapSlot _result)
    {
        Vector2Int _pos = new Vector2Int(_pos3D.x, _pos3D . y);
        foreach (TilemapSlot _slot in listTilemap)
        {
            if (_slot.Position == _pos)
            {
                //savoir par quoi (_slot) est prise la case
                _result = _slot;
                return true;
            }
        }
        _result = TilemapSlot.Null();
        return false;
    }
    public bool PosTaken(Vector3Int _pos3D)
    {
        Vector2Int _pos = new Vector2Int(_pos3D.x, _pos3D.y);
        foreach (TilemapSlot _slot in listTilemap)
        {
            if (_slot.Position == _pos)
            {
                //savoir par quoi (_slot) est prise la case
                return true;
            }
        }
        return false;
    }
}
