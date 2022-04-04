using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Movement movement;
    [SerializeField] private TurnManager turnManager;
    [SerializeField] private GameController gameController;

    // Update is called once per frame
    void Update()
    {
        MovementInputs();

        if (Input.GetKeyDown(KeyCode.R))
        {
            gameController.ReloadLevel();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            turnManager.ChangePlayTime(TurnManager.PlayTime.Minotaur);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            gameController.UndoMovement();
        }

    }

    private void MovementInputs()
    {
        if (turnManager.currentPlayTime == TurnManager.PlayTime.Player)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (movement.CheckDirection(player, Vector2.up))
                {
                    MoveInput(Movement.Direction.North);
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (movement.CheckDirection(player, Vector2.down))
                {
                    MoveInput(Movement.Direction.South);
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (movement.CheckDirection(player, Vector2.left))
                {
                    MoveInput(Movement.Direction.West);
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (movement.CheckDirection(player, Vector2.right))
                {
                    MoveInput(Movement.Direction.East);
                }
            }

            
        }
    }

    private void MoveInput(Movement.Direction dir)
    {
        gameController.SetUndoPosition();
        movement.Move(player.transform, dir);
        turnManager.ChangePlayTime(TurnManager.PlayTime.Minotaur);
    }
}
