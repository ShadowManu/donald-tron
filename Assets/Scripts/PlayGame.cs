using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour {

  public void loadLevel(int level)
  {
    SceneManager.LoadScene(level, LoadSceneMode.Single);
  }
}
