public abstract class Command
{
    protected IEntity entity;

    public Command(IEntity _entity)
    {
        entity = _entity;
    }

    public abstract void Execute();
    public abstract void Undo();
}
