using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] Grid grid = new Grid();
    // Start is called before the first frame update
    void Start()
    {
        //grid = GetComponent<Grid>();
        Vector3Int _vect = new Vector3Int(1, 1,0);
        transform.position = grid.CellToWorld(_vect);
       // transform.position = grid.WorldToCell(_vect);
        //WorldToCell
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
