using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

    [Serializable]
    public struct TilemapSlot
    {

        [SerializeField] Vector2Int position;
        [SerializeField] BaseObject baseObject;

        public Vector2Int Position { get { return position; } set { position = value; } }
        public BaseObject BaseObject { get { return baseObject; } set { baseObject = value; } }

        private static readonly TilemapSlot zeroItemStruct = new TilemapSlot(new Vector2Int(0, 0),null);
        public static TilemapSlot Null() { return zeroItemStruct; }
        public TilemapSlot(Vector2Int _position, BaseObject _baseObject)
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
    public static bool Timer(ref float _currentTimer, ref float _maxTime)
    {
        _currentTimer += Time.deltaTime;
        return (_maxTime <= _currentTimer);

    }

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
}


    
