using UnityEngine;
using UnityEngine.SceneManagement;

namespace SNDL
{
  public class Game : MonoBehaviour
  {
    [Header("Properties")]
    public string gameName = "Space Mongrels";
    public bool isPaused
    {
      get { return _isPaused; }
      set { _isPaused = value; onTogglePause(); }
    }

    protected bool _isPaused = false;

    [Header("Components")]
    public GUI gui;
    public View view;
    public Controller controller;
    public Inputter inputter;

    public Level currentLevel;

    protected int _levelToLoad;
    protected static Game _instance;

    //=======================
    // Singleton
    //=======================
    public static Game instance
    {
      get
      {
        if (_instance == null)
        {
          GameObject tempGame = Instantiate(Resources.Load("Game") as GameObject);
          _instance = tempGame.GetComponent<Game>();
          _instance.initialize();
        }
        return _instance;
      }
    }

    //get a refernce to the current game instance (as any kind of game)
    public static T GetGame<T>() where T : Game
    {
      return ReferenceEquals(instance, null) ? null : instance as T;
    }

    //=======================
    // Initialization
    //=======================
    protected virtual void initialize()
    {
      DontDestroyOnLoad(gameObject);
      _instance.name = gameName;

      //load GUI scene and other required scenes
      initGui();

      //load View and set it up
      initView();
    }

    //GUI INIT
    protected virtual void initGui()
    {
      if (gui != null)
      {
        GUI tempGui = Instantiate(gui) as GUI;
        DontDestroyOnLoad(tempGui);
        tempGui.name = "GUI";

        //update the reference to the spawned GUI - TODO: (is this bad)?
        gui = tempGui;
      }
      else
      {
        Debug.LogWarning("NO GUI OBJECT HAS BEEN ASSIGNED!");
      }
    }

    //VIEW INIT
    protected virtual void initView()
    {
      if (view != null)
      {
        View tempView = Instantiate(view) as View;
        DontDestroyOnLoad(tempView);
        tempView.name = "View";

        //update the reference to the spawned view TODO: (is this bad)?
        view = tempView;
      }
      else
      {
        Debug.LogWarning("NO VIEW OBJECT HAS BEEN ASSIGNED!");
      }
    }

    //check to make sure the game doesn't already exist
    protected void Awake()
    {
      if (_instance != null)
      {
        Destroy(gameObject);
        Debug.LogWarning("There can be only one instance of Game!");
      }
    }

    //=======================
    // Component Hooks
    //=======================
    //for getting getting key components
    public T getGui<T>() where T : GUI
    {
      if (gui != null)
      {
        return gui as T;
      }
      else
      {
        Debug.LogWarning("COULD NOT GET GUI AS ONE DOES NOT EXIST");
        return null;
      }
    }

    //get the view
    public T getView<T>() where T : View
    {
      if (Game.instance.view != null)
      {
        return instance.view as T;
      }
      else
      {
        Debug.LogWarning("COULD NOT GET VIEW AS NO VIEW EXISTS (IS ASSIGNED)");
        return null;
      }
    }

    //=======================
    // Level Loading
    //=======================
    public virtual void onLoadLevel(int tIndex, float tTransitionDuration = 0, bool isUsingTrasition = false)
    {
      //set the level to be loaded next(because we can't set with invoke)
      _levelToLoad = tIndex;

      //game load level function to execute when the closing transition is complete
      Invoke("loadLevel", tTransitionDuration);

      if (isUsingTrasition)
      {
        gui.startTransition();
        //TODO transition logic here
      }

      if (currentLevel)
      {
        currentLevel.onLevelEnd();
      }
    }

    protected virtual void loadLevel()
    {
      if (currentLevel)
      {
        currentLevel.onLevelUnloaded();
      }

      SceneManager.LoadScene(_levelToLoad);
    }

    // ON SCENE LOADED SUCCESS
    protected virtual void onSceneLoaded(Scene _scene, LoadSceneMode _mode)
    {
    }

    public virtual void setCurrentLevel(Level tLevel)
    {
      currentLevel = tLevel;
    }

    //=======================
    // Pause
    //=======================
    public virtual void togglePause()
    {
      if (isPaused)
      {
        isPaused = false;
      }
      else
      {
        isPaused = true;
      }
    }

    //actions taken when pause is toggled
    protected virtual void onTogglePause()
    {
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
