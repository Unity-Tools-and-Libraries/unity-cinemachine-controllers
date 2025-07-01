using UnityEngine;
using Unity.Cinemachine;

// source https://forum.unity.com/threads/cinemachine-virtual-camera-going-out-of-collision-bounds.1361239/#post-8591542
[SaveDuringPlay]
[AddComponentMenu("")] // Hide in menu
public class EqualizePositions : CinemachineExtension
{
    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Finalize)
        {
            // Set the transform position.
            // This keeps the transform for the virtual camera from moving outside the bounds,
            // so that you don't have to undo movement that would put it outside before moving within them again.
            vcam.transform.position = state.PositionCorrection;
        }
    }
}