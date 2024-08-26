using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_InputComponent : Player_BaseComponent
{
    [SerializeField] AllInputs controls = null;
    [SerializeField] InputAction move = null, rotate = null, select = null,mouse=null;
    // Start is called before the first frame update

    public InputAction Move => move;
    public InputAction Rotate => rotate;
    public InputAction Select => select;
    public InputAction Mouse => mouse;

    private void Awake()
    {
        controls=new AllInputs();

        move = controls.PlayerInput.Move;
        rotate = controls.PlayerInput.Rotate;
        select = controls.PlayerInput.Select;
        mouse= controls.PlayerInput.Mouse;
    }
    protected override void Start()
    {
        base.Start();
    }
    private void OnEnable()
    {

        move.Enable();
        rotate.Enable();
        select.Enable();
        mouse.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
