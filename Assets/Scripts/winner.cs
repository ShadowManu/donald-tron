using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winner : MonoBehaviour
{

  public GameObject victoryPanel;

  void OnEnable()
  {
    EventManager.OnWinnerAction += OnWinner;
  }

  void OnDisable()
  {
    EventManager.OnWinnerAction -= OnWinner;
  }

  void OnWinner(string winner)
  {
    victoryPanel.SetActive(true);
    victoryPanel.GetComponentInChildren<Text>().text = winner + " wins";
  }
}
