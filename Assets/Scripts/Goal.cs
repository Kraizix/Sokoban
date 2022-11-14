using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private GameManager _gm;
    // Start is called before the first frame update
    void Start()
    {
        _gm = GetComponentInParent<GameManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("box"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        _gm.Goals--;
    }
}
