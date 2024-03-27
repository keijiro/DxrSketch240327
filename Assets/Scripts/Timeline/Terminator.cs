using UnityEngine;

public sealed class Terminator : MonoBehaviour
{
    public void TerminatePlayMode()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
