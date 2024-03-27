using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Sketch {

[ExecuteInEditMode]
public sealed class TempoRotation
  : MonoBehaviour, ITimeControl, IPropertyPreview
{
    #region Editable properties

    [field:SerializeField]
    public float Tempo { get; set; } = 100;

    [field:SerializeField]
    public float Stride { get; set; } = 30;

    [field:SerializeField]
    public AnimationCurve Curve { get; set; }
      = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));

    [field:SerializeField]
    public float Time { get; set; }

    #endregion

    #region ITimeControl / IPropertyPreview implementation

    public void OnControlTimeStart() {}
    public void OnControlTimeStop() {}
    public void SetTime(double time) => SetLocalTime((float)time);
    public void GatherProperties(PlayableDirector dir, IPropertyCollector drv)
      => drv.AddFromName<Transform>(gameObject, "m_LocalRotation");

    #endregion

    #region Private members

    void SetLocalTime(float time)
    {
        var t = time * Tempo / (60 * 16);
        var r = (Mathf.Floor(t) + Curve.Evaluate(t % 1)) * Stride;
        transform.localRotation = Quaternion.AngleAxis(r, Vector3.up);
    }

    #endregion
}

} // namespace Sketch
