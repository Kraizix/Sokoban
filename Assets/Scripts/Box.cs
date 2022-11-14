using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private GameManager _gm;
    // Start is called before the first frame update
    void Start()
    {
        _gm = GetComponentInParent<GameManager>();
        if (!_gm.B1)
        {
            _gm.B1 = gameObject;
        }
        else
        {
            _gm.B2 = gameObject;
        }
        
    }
}
