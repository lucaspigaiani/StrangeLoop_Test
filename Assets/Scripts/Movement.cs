using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public enum Direction { North, South, East, West}
    [SerializeField] private float movementOffset;

    public void Move(Transform target, Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                target.position = new Vector3(target.position.x, target.position.y + movementOffset, target.position.z);
                break;
            case Direction.South:
                target.position = new Vector3(target.position.x, target.position.y - movementOffset, target.position.z);
                break;
            case Direction.East:
                target.position = new Vector3(target.position.x + movementOffset, target.position.y, target.position.z);
                break;
            case Direction.West:
                target.position = new Vector3(target.position.x - movementOffset, target.position.y, target.position.z);
                break;
            default:
                break;
        }
    }

    public bool CheckDirection(GameObject target, Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(target.transform.position, dir, 1.5f);

        if (hit.collider != null)
        {
            if (hit.collider.tag.Equals("Collider"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return true;
        }
    }
}
