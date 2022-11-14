using System;

public static class Rooms
{
    private static Room[] _roomsArray;
    private static Random _random = new Random();

    public static Room GetRandomRoom()
    {
        _roomsArray = new Room[]
            {
                new Room(new [,] { { 1 ,0 ,0 }, { 0, 0, 0 }, { 0, 0, 0 } }),
                new Room(new [,] { { 1, 1, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }),
                new Room(new [,] { { 1, 0, 0 }, { 0, 0, 0 }, { 1, 0, 1 } }),
                new Room(new [,] { { 1, 0, 0 }, { 0, 0, 0 }, { 0, 0, 1 } }),
                new Room(new [,] { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } }),
                new Room(new [,] { { 1, 1, 0 }, { 1, 0, 0 }, { 0, 0, 0 } }),
                new Room(new [,] { { 0 ,0 ,0 }, { 0, 0, 0 }, { 0, 0, 0 } })
            };
        Room room = _roomsArray[_random.Next(_roomsArray.Length)];
        return room;
    }
}
