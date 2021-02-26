using UnityEngine;
using UnityEngine.Events;

namespace SNDL
{
  public class GUITransition : MonoBehaviour
  {
    [Header("Components")]
    public GameObject loadingIcon;
    protected Animator animator;

    [Header("Properties")]
    [Tooltip("How long the transition will stay 'open' in the middle")]
    public float transitionTimeoutDuration = .2f;

    [Header("Events")]
    public UnityEvent onTransitionComplete;

    protected bool _isTransitioning = false;
    protected int _state = Animator.StringToHash("gateState");
    protected int _transitionTrigger = Animator.StringToHash("transition");

    //====================
    // Initialize
    //=====================
    protected virtual void Awake()
    {
      animator = GetComponent<Animator>();
    }

    //====================
    // Transitions
    //=====================
    //for transitioning to the loading screen
    public void startTransition()
    {
      if (animator)
      {
        _isTransitioning = true;
        animator.SetInteger(_state, (int)GateState.Opening);
        animator.SetTrigger(_transitionTrigger);
      }
    }

    //when the transition has completely "opened" (it is in the middle)
    public void completeTransition()
    {
      //onComplete event
      if (onTransitionComplete != null)
      {
        onTransitionComplete.Invoke();
      }
    }


    //for returning to the game
    public void endTransition()
    {
      if (_isTransitioning && animator != null)
      {
        _isTransitioning = false;
        animator.SetInteger(_state, (int)GateState.Closing);
        animator.SetTrigger(_transitionTrigger);
      }
    }

    //====================
    // Loading Icon
    //=====================
    //loading icon hooks for animation events
    public void enableLoadingIcon()
    {
      if (loadingIcon != null)
      {
        loadingIcon.SetActive(true);
      }
    }

    public void disableLoadingIcon()
    {
      if (loadingIcon != null)
      {
        loadingIcon.SetActive(false);
      }
    }
  }
}