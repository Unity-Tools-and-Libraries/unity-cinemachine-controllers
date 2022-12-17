using UnityEngine;
using Cinemachine;

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
            // Set the transform position. This keeps the vcam within the bounds.
            // This keeps the virtual camera from moving so that you don't have to wait to reverse its movement before moving again.
            vcam.transform.position = state.RawPosition = state.CorrectedPosition;
            state.PositionCorrection = Vector3.zero;
            state.RawOrientation = state.CorrectedOrientation;
            state.OrientationCorrection = Quaternion.identity;
        }
    }
}