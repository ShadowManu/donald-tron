using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winner : MonoBehaviour {

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
        GetComponent<Text>().text = winner + " wins";
    }
}
