using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

    [Serializable]
    public struct TilemapSlot
    {
        [SerializeField] Vector2Int position;
        [SerializeField] BaseObject gameObject;
        public Vector2Int Position { get { return position; } set { position = value; } }
        public BaseObject GameObject { get { return gameObject; } set { gameObject = value; } }

        private static readonly TilemapSlot zeroItemStruct = new TilemapSlot(new Vector2Int(0, 0),null);
        public static TilemapSlot Null() { return zeroItemStruct; }
        public TilemapSlot(Vector2Int _position, BaseObject _gameObject)
        {
            position = _position;
            gameObject = _gameObject;
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
}

    
