using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject floor;

    [SerializeField] private GameObject wall;
    
    [SerializeField] private GameObject box;

    [SerializeField] private GameObject goal;
    [SerializeField] private GameObject player;

    public readonly int Size = 15;

    public int[,] Tab;

    private List<Vector3> _spawns = new List<Vector3>();

    public Stack<Vector3> pos1 = new Stack<Vector3>();
    
    public Stack<Vector3> pos2 = new Stack<Vector3>();
    public GameObject B1;
    public GameObject B2;
    public bool isPaused = false;

    public int Goals = 2;

    // Start is called before the first frame update
    void Start()
    {
        Tab = new int[Size, Size];
        GenerateLayout();
        GenerateGrid();
        GetSpawnPoints();
        GenerateBox();
        System.Random random = new System.Random();
        int index = random.Next(_spawns.Count);
        Vector3 pos = _spawns[index];
        Instantiate(player, pos, transform.rotation, transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
    }

    private void GenerateLayout()
    {
        for (int i = 0; i < Size / 3; i++)
        {
            for (int j = 0; j < Size / 3; j++)
            {
                Room room = Rooms.GetRandomRoom();
                for (int x = 0; x < Random.Range(0, 3); x++)
                {
                    room.Rotate();
                }
                for (int k = 0; k < 3; k++)
                {
                    for (int l = 0; l < 3; l++)
                    {
                        Tab[k + i * 3, l + j * 3] = room.Layout[k, l];
                    }
                }
            }
        }
    }

    private void GetSpawnPoints()
    {
        for (int i = 1; i < Size - 1; i++)
        {
            for (int j = 1; j < Size - 1; j++)
            {
                if (Tab[i, j] == 0 && Tab[i + 1, j] == 0 && Tab[i - 1, j] == 0 && Tab[i, j + 1] == 0 &&
                    Tab[i, j - 1] == 0)
                {
                    _spawns.Add(new Vector3(i + 1,j + 1,0));
                }
            }
        }
    }

    private void GenerateBox()
    {
        
        System.Random random = new System.Random();
        int index = random.Next(_spawns.Count);
        Vector3 pos = _spawns[index];
        _spawns.RemoveAt(index);
        var rotation = transform.rotation;
        Instantiate(box, pos, rotation, transform);
        index = random.Next(_spawns.Count);
        pos = _spawns[index];
        _spawns.RemoveAt(index);
        Instantiate(box, pos, rotation, transform);
        index = random.Next(_spawns.Count);
        pos = _spawns[index];
        _spawns.RemoveAt(index);
        Instantiate(goal, pos, rotation, transform);
        index = random.Next(_spawns.Count);
        pos = _spawns[index];
        _spawns.RemoveAt(index);
        Instantiate(goal, pos, rotation, transform);
    }

    private void GenerateGrid()
    {
        for (int i = 0; i < Size + 2; i++)
        {
            var rotation = transform.rotation;
            Instantiate(wall, new Vector3(i, Size+1, 0), rotation, transform);
            Instantiate(wall, new Vector3(i, 0, 0), rotation, transform);
            Instantiate(wall, new Vector3(0, i, 0), rotation, transform);
            Instantiate(wall, new Vector3(Size+1, i, 0), rotation, transform);
        }
        for (int i = 1; i < Size + 1; i++)
        {
            for (int j = 1; j < Size+1; j++)
            {
                Instantiate(Tab[i - 1, j - 1] == 1 ? wall : floor, new Vector3(i,j,0),transform.rotation, transform);
            }
        }
    }
}
