using UnityEngine;

namespace SNDL
{
  public class View3D : View
  {
    public override void setTarget(Transform tTarget, bool isImmediate = false)
    {
      currentTarget = tTarget;

      //set the camera to center on the target immediately (keeping current y though)
      if (isImmediate)
      {
        transform.position = new Vector3(tTarget.position.x, transform.position.y, tTarget.position.z);
      }
    }

    public override void setZoom(float tZoom)
    {
      Debug.LogWarning("Setting Zoom is not yet supported in a 3D View.");
    }
  }
}