using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Object_BaseObject : MonoBehaviour
{
    public Action<Object_BaseObject> OnPlacement;
    public Action<Object_BaseObject> OnRemoval;
    [SerializeField] protected Vector2Int location = new Vector2Int(0, 0);
    [SerializeField] protected Vector2Int size = new Vector2Int(1, 1);
    [SerializeField] protected List<Vector2Int> neighborList = new List<Vector2Int>();
    

    public GridManager GridManager => GridManager.Instance;
    public List<Vector2Int> NeighborList => neighborList;
    public Vector2Int Location => location;
    public Vector2Int Size => size; 
    protected virtual void Start()
    {
        
        GridManager.SetGridPosAt(location, this);
        neighborList = Utile.GetNeighbor(location, size);
        //broadcast shearch input/output
         OnPlacement?.Invoke(this) ; 
    }

    protected virtual void OnEnable()
    {
    }

    protected virtual void OnDisable()
    {
        OnRemoval?.Invoke(this);
    }


}
