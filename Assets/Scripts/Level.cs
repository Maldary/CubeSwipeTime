using UnityEngine;
using Random = UnityEngine.Random;

public class Level
{
    public int[,] matrix;

    public Level(int[,] matrix)
    {
        this.matrix = matrix;
    }
}
