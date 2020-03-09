using UnityEngine;

public interface IEntity
{
    Transform transform { get; }
    void MoveFromTo(Vector3 startPos, Vector3 endPos);
}