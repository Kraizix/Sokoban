using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 dir = Vector2.left;
    private Animator _animator;
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private Stack<Move> _moves = new Stack<Move>();

    [SerializeField] private GameManager gm;
    // Start is called before the first frame update
    private void Start()
    {
        gm = GetComponentInParent<GameManager>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = Vector2.right;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            dir = Vector2.down;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            dir = Vector2.up;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_moves.Count != 0)
            {
                Undo();
            }
        }
        float inputX = Input.GetAxis("Horizontal") * Time.deltaTime * 2;
        float inputY = Input.GetAxis ("Vertical") * Time.deltaTime * 2;
        if (inputX != 0 || inputY != 0)
        {
            _animator.SetBool(IsMoving,true);
        }
        else
        {
            _animator.SetBool(IsMoving,false);
        }
        transform.Translate(new Vector3(inputX, inputY));
        RaycastHit2D ray = Physics2D.Raycast(transform.position, dir,0.42f,LayerMask.GetMask("Box"));
        Debug.DrawRay(transform.position, dir * 0.42f, Color.blue);
        if (ray.collider)
        {
            Vector3 coords = ray.collider.transform.position + (Vector3)dir;
            var x = (int)coords.x - 1;
            var y = (int)coords.y - 1;
            if (x < 0 || x >= gm.Size || y < 0 || y >= gm.Size)
            {
                return;
            }
            if (gm.Tab[x, y] == 0)
            {
                if (gm.B1 == null || gm.B2 == null)
                {
                    _moves.Push(new Move(transform,ray.collider.transform, dir));
                    ray.collider.transform.position = coords;
                    return;
                }
                if (ray.collider.gameObject == gm.B1)
                {
                    if (gm.B2.transform.position != coords)
                    {
                        _moves.Push(new Move(transform,ray.collider.transform, dir));
                        ray.collider.transform.position = coords;
                    }
                }
                else
                {
                    if (gm.B1.transform.position != coords)
                    {
                        _moves.Push(new Move(transform,ray.collider.transform, dir));
                        ray.collider.transform.position = coords;
                    }
                }
                
            }
        }
    }

    private void Undo()
    {
        Move m = _moves.Pop();
        m.Player.transform.position = m.PlayerPos;
        m.Player.transform.Translate(-m.Dir *0.1f);
        m.Box.transform.position = m.BoxPos;
    }
}
