using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand<T> : ICommand where T : Transform
{
    private T entity;
    private Vector3 endPosition;

    private Vector3 previousPosition;

    public MoveCommand(T entity, Vector3 direction, float distance)
    {
        this.entity = entity;
        endPosition = entity.position + direction * distance;
    }

    public void Execute()
    {
        previousPosition = entity.position;
        entity.position = endPosition;
    }

    public void Undo()
    {
        entity.position = previousPosition;
    }
}
