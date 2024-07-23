using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] List<Vector2Int> neigbor = new List<Vector2Int>();
    [SerializeField] Vector2Int test = new Vector2Int();
    // Start is called before the first frame update
    void Start()
    {
        neigbor = Utile.GetNeighbor(new Vector2Int(0, 0),test);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
