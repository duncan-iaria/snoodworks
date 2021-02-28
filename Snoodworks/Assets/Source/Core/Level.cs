using UnityEngine;

namespace SNDL
{
  public class Level : MonoBehaviour
  {
    protected Game game;
    public LevelData levelData;
    public GameObject levelUi;
    public Pawn defaultPawn;

    protected virtual void Awake()
    {
      game = Game.GetGame<Game>();
    }

    protected virtual void Start()
    {
      Debug.Log(levelData.levelName + " level has started");
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

    // If there is a default level pawn, set it on start
    protected virtual void setDefaultPawn(Pawn tPawn)
    {
      game.controller.setCurrentPawn(tPawn);
    }

    // Set the default view target when the level loads
    protected virtual void setDefaultViewTarget(Transform tTransform)
    {
      game.view.setTarget(tTransform);
    }

    // This is when the next level has been flagged to load
    // But the current level hasn't unloaded just yet (cleanup actions)
    public virtual void onLevelEnd()
    {
      if (levelUi)
      {
        levelUi.SetActive(false);
      }
    }

    public virtual void onLevelUnloaded()
    {
      Debug.Log("Level " + levelData.levelName + "has unloaded.");
    }

    public void onLevelEvent()
    {
      Debug.Log("Level Event raised: " + levelData.levelName + "!");
    }
  }
}
