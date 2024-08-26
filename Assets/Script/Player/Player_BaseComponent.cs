using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_BaseComponent : MonoBehaviour
{
    [SerializeField] protected Player_Brain brainRef = null;
    [SerializeField] protected bool debug = true;
    // Start is called before the first frame update
    public GridManager GridManager => GridManager.Instance;
    protected virtual void Start()
    {
        brainRef = GetComponent<Player_Brain>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
