using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_MoveComponent : Player_BaseComponent
{
    [SerializeField] float moveSpeed = 5;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector2 _dir)
    {
        transform.position += Utile.Vector2ToVector3(_dir*Time.deltaTime*moveSpeed);
    }
}
