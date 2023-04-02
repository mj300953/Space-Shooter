using UnityEngine;

public class Ended : MonoBehaviour
{
  public static bool GameEnded { get; private set; }

  private void Start()
  {
    GameEnded = true;
    Debug.Log(GameEnded);
  }
}