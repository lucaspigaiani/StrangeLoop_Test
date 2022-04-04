using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private Vector2 theseuUndoPosition;
    private Vector2 minotaurUndoPosition;

    [SerializeField] private GameObject theseu;
    [SerializeField] private GameObject minotaur;
    [SerializeField] private GameObject exit;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject youWinPanel;
    [SerializeField] private Text currentTurnHeader;
    [SerializeField] private GameObject[] endGameTurnOff;

    public void ReloadLevel() 
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void UndoMovement() 
    {
        theseu.transform.position = theseuUndoPosition;
        minotaur.transform.position = minotaurUndoPosition;
    }

    public void SetUndoPosition()
    {
        theseuUndoPosition = theseu.transform.position;
        minotaurUndoPosition = minotaur.transform.position;
    }

    public void ComparePosition() 
    {
        if (theseu.transform.position == minotaur.transform.position)
        {
            Debug.Log("LOSE!");
            gameOverPanel.SetActive(true);
            for (int i = 0; i < endGameTurnOff.Length; i++)
            {
                endGameTurnOff[i].SetActive(false);
            }
        }
        if (theseu.transform.position == exit.transform.position)
        {
            youWinPanel.SetActive(true);
            Debug.Log("WIN!");
            for (int i = 0; i < endGameTurnOff.Length; i++)
            {
                endGameTurnOff[i].SetActive(false);
            }
        }
    }

    public void ChangeLevel(int i) 
    {
        SceneManager.LoadScene(i);
    }

    public void ChangeTurnHeader(string currentTurn) 
    {
        currentTurnHeader.text = currentTurn;
    }
}
