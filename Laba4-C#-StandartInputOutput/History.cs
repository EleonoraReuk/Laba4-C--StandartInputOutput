using System.Collections.Generic;

public class History
{
    private Stack<TextMemento> history = new Stack<TextMemento>();

    public void Push(TextMemento memento)
    {
        history.Push(memento);
    }

    public TextMemento Undo()
    {
        if (history.Count > 0) return history.Pop();

        return null;
    }
}