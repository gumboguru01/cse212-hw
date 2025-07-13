public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        // People with infinite turns (0 or less) stay forever
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        // People with more than 1 turn: decrement and re-enqueue
        else if (person.Turns > 1)
        {
            person.Turns -= 1;
            _people.Enqueue(person);
        }
        // If person.Turns == 1, we return them but do NOT re-add them

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
