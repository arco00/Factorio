using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player_InteractComponent : Player_BaseComponent
{
    [SerializeField] Object_BaseObject selectedObject = null;
    [SerializeField] LayerMask objectLayer = 0;
    [SerializeField] float rayCastDist = 20;
    [SerializeField] bool toPlace = false;
    [SerializeField] Vector3 gizmoVect = Vector3.zero;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetObjectToPlace(Object_BaseObject _object)
    {
        toPlace = true;
        selectedObject = _object;
    } 
    public void PlaceObject2(Vector2 _mouseLoc) //useless , easier without raycast
    {
        if (!selectedObject || !toPlace) return;
        Ray _ray = Camera.main.ScreenPointToRay(_mouseLoc);
        if (debug) Debug.DrawRay(_ray.origin, _ray.direction*rayCastDist,Color.red);
        if (debug) Debug.Log(_ray.origin);
        
        if (Physics.Raycast(_ray, out RaycastHit _hit, rayCastDist, objectLayer))
        {
            if (debug) Debug.Log("place");
            Vector2Int _gridPos = GridManager.GetGridPos2D(_hit.point);
            if (GridManager.TilemapDictionary.ContainsKey(_gridPos))
            {
                if (debug) Debug.Log("pose prise");
                return;
            }
            Object_BaseObject _objectPlaced = Instantiate(selectedObject, Utile.Vector2ToVector3(_gridPos), Quaternion.identity);
            GridManager.SetGridPosAt(_gridPos, _objectPlaced);
            toPlace = false;
        }
    }

    public void PlaceObject(Vector2 _mouseLoc)
    {
        if (!selectedObject || MouseOverUi()) return;
        Vector3 _newLoc=Camera.main.ScreenToWorldPoint(_mouseLoc);
        Vector3 _loc = new Vector3(_newLoc.x+.5f,_newLoc.y+.5f,0); // center
        gizmoVect = _loc;
        //Vector3 _loc= Camera.main.ScreenToViewportPoint(_mouseLoc);
        Vector2Int _gridPos = GridManager.GetGridPos2D(_loc);
        if (GridManager.TilemapDictionary.ContainsKey(_gridPos))
        {
            if (debug) Debug.Log("pose prise");
            return;
        }
        Object_BaseObject _objectPlaced = Instantiate(selectedObject);
        GridManager.SetGridPosAt(_gridPos, _objectPlaced);
        toPlace = false;
    }

    void SelectObject(Vector2 _mouseLoc)
    {
        if (toPlace ) return;
        Ray _ray = Camera.main.ScreenPointToRay(_mouseLoc);
        if (debug) Debug.DrawRay(_ray.origin, _ray.direction * rayCastDist, Color.red);
        if (debug) Debug.Log(_ray.origin);

        if (Physics.Raycast(_ray, out RaycastHit _hit, rayCastDist, objectLayer))
        {
            
        }

    }

    void RotateObject()
    {
        if (!toPlace) return;
    }

    bool  MouseOverUi()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(gizmoVect, gizmoVect+ new Vector3(0,0,20));
    }
}
