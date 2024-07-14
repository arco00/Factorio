using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    [SerializeField] protected Vector2Int location = new Vector2Int(0, 0);
    [SerializeField] protected Grid grid = null;
    [SerializeField] protected GridManager gridManager = null;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        grid=FindAnyObjectByType<Grid>();
        gridManager=grid.GetComponent<GridManager>();
        gridManager.SetGridPosAt(location,this);
        //broadcast shearch input/output
    }

    

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
