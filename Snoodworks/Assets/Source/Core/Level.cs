using UnityEngine;

namespace SNDL
{
  public class Level : MonoBehaviour
  {
    protected Game game;
    public string levelName;
    public GameObject levelUi;

    // DEFAULT INITIAL PAWN
    public Pawn defaultPawn;

    protected virtual void Awake()
    {
      game = Game.GetGame<Game>();
    }

    protected virtual void Start()
    {
      Debug.Log(levelName + " level has started");
      game.setCurrentLevel(this);

      if (levelUi)
      {
        levelUi.SetActive(true);
      }

      if (defaultPawn)
      {
        setDefaultPawn(defaultPawn);
        setDefaultViewTarget(defaultPawn.transform);
      }
    }

    // IF THERE IS A DEFAULT LEVEL PAWN
    // SET IT ON LEVEL START
    protected virtual void setDefaultPawn(Pawn tPawn)
    {
      game.controller.setCurrentPawn(tPawn);
    }

    // SET THE DEFAULT VIEW TARGET WHEN THE LEVEL LOADS
    protected virtual void setDefaultViewTarget(Transform tTransform)
    {
      game.view.setTarget(tTransform);
    }

    public virtual void onLevelEnd()
    {
      if (levelUi)
      {
        levelUi.SetActive(false);
      }
    }

    public virtual void onLevelUnloaded()
    {
      Debug.Log("Level " + levelName + "has unloaded.");
    }

    public void onLevelEvent()
    {
      Debug.Log("Level Event raised: " + levelName + "!");
    }
  }
}
