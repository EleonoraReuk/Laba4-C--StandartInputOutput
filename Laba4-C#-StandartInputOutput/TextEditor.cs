public class TextEditor
{
    public string Content { get; set; }
    public TextMemento Save()
    {
        return new TextMemento(Content);
    }
    public void Restore(TextMemento memento)
    {
        Content = memento.State;
    }
}