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
