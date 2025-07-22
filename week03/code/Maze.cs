using System;
using System.Collections.Generic;

public class Maze
{
    // Represents the maze structure: each position maps to a boolean array of directions.
    // directions[0] = left, [1] = right, [2] = up, [3] = down
    private Dictionary<(int, int), bool[]> _mazeMap;

    // Current position in the maze
    private int _currX;
    private int _currY;

    // Constructor to initialize the maze and starting position
    public Maze(Dictionary<(int, int), bool[]> mazeMap, int startX, int startY)
    {
        _mazeMap = mazeMap ?? throw new ArgumentNullException(nameof(mazeMap));
        _currX = startX;
        _currY = startY;
    }

    public void MoveLeft()
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out bool[] directions) && directions[0])
        {
            _currX--;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public void MoveRight()
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out bool[] directions) && directions[1])
        {
            _currX++;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public void MoveUp()
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out bool[] directions) && directions[2])
        {
            _currY--;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public void MoveDown()
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out bool[] directions) && directions[3])
        {
            _currY++;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    // Returns the current position in the maze
    public (int x, int y) GetCurrentPosition()
    {
        return (_currX, _currY);
    }
}
