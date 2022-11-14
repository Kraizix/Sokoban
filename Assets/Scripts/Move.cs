using UnityEngine;
public class Move
{
    public Transform Player;
    public Vector3 PlayerPos;
    public Transform Box;
    public Vector3 BoxPos;
    public Vector2 Dir;

    public Move(Transform player, Transform box, Vector2 dir)
    {
        Player = player;
        PlayerPos = player.transform.position;
        Box = box;
        BoxPos = box.transform.position;
        Dir = dir;
    }
}
