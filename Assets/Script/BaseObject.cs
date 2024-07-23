using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public abstract class BaseObject : MonoBehaviour
{
    public Action<BaseObject> OnPlacement;
    public Action<BaseObject> OnRemoval;
    [SerializeField] protected Vector2Int location = new Vector2Int(0, 0);
    [SerializeField] protected Vector2Int size = new Vector2Int(1, 1);
    [SerializeField] protected List<Vector2Int> neighborList = new List<Vector2Int>();
    [SerializeField] protected GridManager gridManager = null;

    public GridManager GridManager => gridManager;
    public List<Vector2Int> NeighborList => neighborList;
    public Vector2Int Location => location;
    protected virtual void Start()
    {
        gridManager = GridManager.Instance;
        gridManager.SetGridPosAt(location, this);
        neighborList = Utile.GetNeighbor(location, size);
        //broadcast shearch input/output
         OnPlacement.Invoke(this) ; 
       
    }

    protected virtual void OnEnable()
    {
    }

    protected virtual void OnDisable()
    {
        OnRemoval.Invoke(this);
    }


}
