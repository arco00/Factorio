using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Brain : MonoBehaviour
{
    [SerializeField] Player_InputComponent input = null;
    [SerializeField] Player_MoveComponent move = null;
    [SerializeField] Player_InteractComponent interact = null;
    // Start is called before the first frame update

    public Player_MoveComponent Move => move;
    public Player_InteractComponent Interact => interact;
    void Start()
    {
        InitComponent();
        InitEvent();
    }

    // Update is called once per frame
    void Update()
    {
        move.Move(input.Move.ReadValue<Vector2>());
    }

    void InitComponent()
    {
        input=GetComponent<Player_InputComponent>();
        move=GetComponent<Player_MoveComponent>();
        interact=GetComponent<Player_InteractComponent>();
    }

    void InitEvent()
    {
        input.Select.performed += (_context) =>
        {
            interact.PlaceObject(input.Mouse.ReadValue<Vector2>());
        };

    }
    
}
