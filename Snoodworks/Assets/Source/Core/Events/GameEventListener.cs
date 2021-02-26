using UnityEngine;
using UnityEngine.Events;

namespace SNDL
{
  // This class goes on a GameObject, will raise a response when the event is invoked
  public class GameEventListener : MonoBehaviour
  {
    [Tooltip("Event to register with.")]
    public GameEvent gameEvent;

    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEvent response;

    private void OnEnable()
    {
      gameEvent.registerListener(this);
    }

    private void OnDisable()
    {
      gameEvent.unregisterListener(this);
    }

    public void onEventRaised()
    {
      if (response != null)
      {
        response.Invoke();
      }
      else
      {
        Debug.Log("Event was null, could not invoke");
      }
    }
  }
}