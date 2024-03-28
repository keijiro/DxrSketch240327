using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Sketch {

[ExecuteInEditMode]
public sealed class DistanceToFocus
  : MonoBehaviour, ITimeControl, IPropertyPreview
{
    #region Private members

    bool _controlled;

    #endregion

    #region ITimeControl / IPropertyPreview implementation

    public void OnControlTimeStart() => _controlled = true;
    public void OnControlTimeStop() => _controlled = false;
    public void SetTime(double time) {}
    public void GatherProperties(PlayableDirector dir, IPropertyCollector drv)
      => drv.AddFromName<Camera>(gameObject, "m_FocusDistance");

    #endregion

    #region MonoBehaviour implementation

    void LateUpdate()
    {
        if (_controlled == false) return;
        GetComponent<Camera>().focusDistance = transform.position.magnitude;
    }

    #endregion
}

} // namespace Sketch
