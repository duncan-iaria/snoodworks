using UnityEngine;
using UnityEngine.SceneManagement;

namespace SNDL
{
  public class GUI : MonoBehaviour
  {
    [Header("Transitions")]
    public GUITransition guiTransition;
    public float levelTransitionDuration = 0.5f;

    protected Game game;

    //=======================
    // Intialization
    //=======================
    protected virtual void Awake()
    {
      game = Game.GetGame<Game>();
    }

    //=======================
    // Main Menu
    //=======================
    public virtual void onTogglMainMenu()
    {
    }

    public virtual void onOpenMainMenu()
    {
    }

    public virtual void onCloseMainMenu()
    {
    }

    //=======================
    // Scene Loading
    //=======================
    // public virtual void onLoadScene(int tSceneIndex)
    // {
    //   game.onLoadLevel(tSceneIndex, levelTransitionDuration, true);
    // }

    public virtual void startTransition()
    {
      guiTransition.startTransition();
    }

    protected virtual void onSceneLoaded(Scene _scene, LoadSceneMode _mode)
    {
      guiTransition.endTransition();
    }

    //=======================
    // Event Subscription
    //=======================
    protected void OnEnable()
    {
      SceneManager.sceneLoaded += onSceneLoaded;
    }

    protected void OnDisable()
    {
      SceneManager.sceneLoaded -= onSceneLoaded;
    }
  }
}

