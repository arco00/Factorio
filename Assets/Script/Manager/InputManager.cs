using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager> 
{
    [SerializeField] BaseObject objectToPlace = null;
    [SerializeField] AllInputs controls = null;
    [SerializeField] InputAction place = null;
    [SerializeField] protected GridManager gridManager = null;
    // Start is called before the first frame update

    public BaseObject ObjectToPlace => objectToPlace;
    public void SetObjectToPlace(BaseObject _object) { objectToPlace = _object; }

    protected override void Awake()
    {
        base.Awake();
        controls = new AllInputs();
    }
    void Start()
    {
        place = controls.InputTest.PlaceObject;
        place.Enable();
        place.performed += PlaceObjectAction;
        gridManager = GridManager.Instance;
    }


    void PlaceObjectAction(InputAction.CallbackContext _context)
    {
        if (!objectToPlace) return;
        Vector3 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(_mousePos);
        Vector3Int _gridPos = gridManager.GetGridPos(_mousePos);
        if (gridManager.PosTaken(_gridPos))
        {
            Debug.Log("pose prise");
            return;
        }

        BaseObject _object = Instantiate(objectToPlace, _mousePos, Quaternion.identity);
        gridManager.SetGridPosAt(_gridPos, _object);
    }
}
