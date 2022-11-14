public class Room
{
    public int[,] Layout;
    public int Rotation;

    public Room(int[,] layout)
    {
        Layout = layout;
    }

    public void Rotate()
    {
        Rotation += 1;
        int[,] backup = new int[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                backup[i, j] = Layout[3 - j - 1, i];
            }
        }

        Layout = backup;
    }
}
