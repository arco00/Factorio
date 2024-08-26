using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

[Serializable]
    public struct TilemapSlot // plus de ref ok
    {

        [SerializeField] Vector2Int position;
        [SerializeField] Object_BaseObject baseObject;

        public Vector2Int Position { get { return position; } set { position = value; } }
        public Object_BaseObject BaseObject { get { return baseObject; } set { baseObject = value; } }

        private static readonly TilemapSlot zeroItemStruct = new TilemapSlot(new Vector2Int(0, 0),null);
        public static TilemapSlot Null() { return zeroItemStruct; }
        public TilemapSlot(Vector2Int _position, Object_BaseObject _baseObject)
        {
            position = _position;
            baseObject = _baseObject;
          
        }
    }

[Serializable]
public struct ItemStruct
{
    [SerializeField] BaseItem item;
    [SerializeField] int number;
    public BaseItem Item { get { return item; } set { item = value; } }
    public int Number { get { return number; } set { number = value; } }

   public ItemStruct(BaseItem _item,int _number)
   {
       item = _item;
       number = _number;
   }
}

public static class Utile
{

    /// <summary>
    /// Add delta time and return if currentTimer >= maxtime
    /// </summary>
    public static bool Timer(ref float _currentTimer, ref float _maxTime)
    {
        _currentTimer += Time.deltaTime;
        return (_maxTime <= _currentTimer);
    }

    /// <summary>
    /// get a list of all neightbor tiles
    /// </summary>
    public static List<Vector2Int> GetNeighbor(Vector2Int _loc, Vector2Int _size)
    {
        List<Vector2Int> _list = new List<Vector2Int>() ;
        for (int i = 0; i < _size.x; i++)
        {
            _list.Add(new Vector2Int(_loc.x + i, _loc.y + 1));
            _list.Add(new Vector2Int(_loc.x + i, _loc.y -_size.y));
        }
        for (int i = 0; i < _size.y; i++)
        {
            _list.Add(new Vector2Int(_loc.x + 1, _loc.y + i));
            _list.Add(new Vector2Int(_loc.x -_size.x, _loc.y +i));
        }
        return _list ;
    }

    #region vector
    public static Vector3Int Vector2ToVector3(Vector2Int _loc)
    {
        return new Vector3Int(_loc.x, _loc.y, 0);
    }
    public static Vector3 Vector2ToVector3(Vector2 _loc)
    {
        return new Vector3(_loc.x, _loc.y, 0);
    }
    public static Vector2Int Vector3ToVector2(Vector3Int _loc)
    {
        return new Vector2Int(_loc.x, _loc.y);
    }
    public static Vector2 Vector3ToVector2(Vector3 _loc)
    {
        return new Vector2(_loc.x, _loc.y);
    }
    #endregion vector
    public static void DrawArrow(Vector3 _pos, Vector3 _dir, Color _color, float _lenght = 1)
    {
        Gizmos.color = _color;
        Vector3 _endPos = _dir * _lenght;
        Debug.Log($"{_pos}{_endPos}");
        Gizmos.DrawLine(_pos, _endPos);
        //Vector3 v = Quaternion.AngleAxis(-30, Vector3.up) * sourceVect;
        Gizmos.DrawSphere(_endPos, _lenght*.1f);
        return; //TODO
        Vector3 _upLine = Quaternion.AngleAxis(-45, Vector3.right) * (_dir - _pos).normalized * .1f * _lenght;
        Vector3 _downLine = Vector3.Reflect(_upLine, _dir - _pos);
        Gizmos.DrawLine(_endPos, _upLine+_endPos);
        Gizmos.DrawLine(_endPos, _downLine+_endPos);
    }
}


    
