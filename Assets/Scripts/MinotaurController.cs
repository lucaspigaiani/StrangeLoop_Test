using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject minotaur;

    [SerializeField] private Movement movement;
    [SerializeField] private TurnManager turnManager;

    private int actions;
    private Vector2 dir;

    public void StartTurn()
    {
        dir = (minotaur.transform.position - player.transform.position).normalized;
        actions = 0;
        Invoke(nameof(CalculateDirection), 0.5f);
    }

    public void CalculateDirection() 
    {
         dir = (minotaur.transform.position - player.transform.position).normalized;

        if (Mathf.Abs(dir.x) >= Mathf.Abs(dir.y))
        {
            HorizontalDirection();
        }
        else if (Mathf.Abs(dir.x) < Mathf.Abs(dir.y))
        {
            VerticalDirection();
        }
    }

    private void VerticalDirection()
    {
        if (dir.y > 0)
        {
            if (movement.CheckDirection(minotaur, Vector2.down))
            {
                MoveMinotaur(Movement.Direction.South);
            }
            else
            {
                if (dir.x > 0 && movement.CheckDirection(minotaur, Vector2.left))
                {
                    MoveMinotaur(Movement.Direction.West);
                }
                else if (dir.y < 0 && movement.CheckDirection(minotaur, Vector2.right))
                {
                    MoveMinotaur(Movement.Direction.East);
                }
                else
                {
                    actions++;
                    CheckEndTurn();
                }
            }
        }
        else if (dir.y < 0)
        {
            if (movement.CheckDirection(minotaur, Vector2.up))
            {
                MoveMinotaur(Movement.Direction.North);
            }
            else
            {
                if (dir.y > 0 && movement.CheckDirection(minotaur, Vector2.left))
                {
                    MoveMinotaur(Movement.Direction.West);
                }
                else if (dir.y < 0 && movement.CheckDirection(minotaur, Vector2.right))
                {
                    MoveMinotaur(Movement.Direction.East);
                }
                else
                {
                    actions++;
                    CheckEndTurn();
                }
            }
        }
    }

    private void HorizontalDirection()
    {
        if (dir.x > 0 )
        {
            if (movement.CheckDirection(minotaur, Vector2.left))
            {
                MoveMinotaur(Movement.Direction.West);
            }
            else
            {
                if (dir.y > 0 && movement.CheckDirection(minotaur, Vector2.down))
                {
                    MoveMinotaur(Movement.Direction.South);
                }
                else if (dir.y < 0 && movement.CheckDirection(minotaur, Vector2.up))
                {
                    MoveMinotaur(Movement.Direction.North);
                }
                else
                {
                    actions++;
                    CheckEndTurn();
                }
            }
        }
        else if (dir.x < 0)
        {
            if (movement.CheckDirection(minotaur, Vector2.right))
            {
                MoveMinotaur(Movement.Direction.East);
            }
            else
            {
                if (dir.y > 0 && movement.CheckDirection(minotaur, Vector2.down))
                {
                    MoveMinotaur(Movement.Direction.South);
                }
                else if (dir.y < 0 && movement.CheckDirection(minotaur, Vector2.up))
                {
                    MoveMinotaur(Movement.Direction.North);
                }
                else
                {
                    actions++;
                    CheckEndTurn();
                }
            }
        }
    }

    private void MoveMinotaur(Movement.Direction direction)
    {
        movement.Move(minotaur.transform, direction);
        actions++;

        if (actions > 1)
        {
            EndTurnCallBack();
        }
        else
        {
            Invoke(nameof(CalculateDirection), 0.5f);
        }
    }

    private void CheckEndTurn()
    {
        if (actions > 1)
        {
            EndTurnCallBack();
        }
        else
        {
            Invoke(nameof(CalculateDirection), 0.5f);
        }
    }

    private void EndTurnCallBack() 
    {
        turnManager.ChangePlayTime(TurnManager.PlayTime.Player);
    }
}
