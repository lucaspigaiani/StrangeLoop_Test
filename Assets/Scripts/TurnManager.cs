using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public enum PlayTime { Player, Minotaur}
    public PlayTime currentPlayTime;

    [SerializeField] private MinotaurController minotaurController;
    [SerializeField] private  GameController gameController;

    public void ChangePlayTime(PlayTime nextPlayTime)
    {
        gameController.ComparePosition();
        currentPlayTime = nextPlayTime;
        StartTurn();
    }

    void StartTurn()
    {
        gameController.ChangeTurnHeader(currentPlayTime.ToString());

        switch (currentPlayTime)
        {
            case PlayTime.Player:
                break;
            case PlayTime.Minotaur:
                minotaurController.StartTurn();
                break;
        }
    }
}
