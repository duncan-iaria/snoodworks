using UnityEngine;

namespace SNDL
{
  public class Controller : MonoBehaviour
  {
    [Header("Components")]
    public Pawn currentPawn;

    void Start()
    {
      if (currentPawn != null)
      {
        currentPawn.isCurrentPawn = true;
      }
    }

    //=======================
    // Pawn Assignment
    //=======================
    public virtual void setCurrentPawn(Pawn tPawn)
    {
      if (tPawn == null)
      {
        Debug.LogWarning("No pawn passed in, could not set new current pawn.");
        return;
      }

      //if there is already an active pawn
      if (currentPawn != null)
      {
        //calls unset actions
        currentPawn.onPawnUnset();
        currentPawn.isCurrentPawn = false;
      }

      //set current pawn to new pawn
      currentPawn = tPawn;

      currentPawn.onPawnSet();
      currentPawn.isCurrentPawn = true;
    }

    //=======================
    // Pawn Controls
    //=======================
    public virtual void onInputButton(InputButton tButton)
    {
    }

    public virtual void onAxis(InputAxis tAxis, float tValue)
    {
    }

    //=======================
    // Pawn Controls
    //=======================
    public virtual void onPressCancel()
    {
    }

    public virtual void onPressPause()
    {
    }

    public virtual void onPressCycle()
    {
    }
  }
}
