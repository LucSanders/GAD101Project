using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMap : MonoBehaviour
{
    public int height;
    public int length;

    int[,] grid;

    public void Init(int length, int height)
    {
        grid = new int[length, height];
        this.length = length;
        this.height = height;
    }

    public void Set(int x, int y, int to)
    {
        if(CheckPosition(x, y) == false)
        {
            Debug.LogWarning("Trying to Get a cell outside the Grid boundaries" 
                + x.ToString() +":" + y.ToString());
            return;
        }
        grid[x, y] = to;
    }

    public int Get(int x, int y)
    {
        if(CheckPosition(x, y) == false)
        {
            Debug.LogWarning("Trying to Get a cell outside the Grid boundaries" 
                + x.ToString() +":" + y.ToString());
            return -1;
        }
        return grid[x, y];
    }

    public bool CheckPosition(int x, int y)
    {
        if (x < 0 || x >= length)
        {
            return false;
        }

        if (y < 0 || x >= height)
        {
            return false;
        }
        
        return true;
    }

    internal bool CheckWalkable(int xPos, int yPos)
    {
        return grid [xPos, yPos] == 0;
    }

}
