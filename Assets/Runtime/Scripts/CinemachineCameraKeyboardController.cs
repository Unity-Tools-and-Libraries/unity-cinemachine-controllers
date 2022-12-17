using UnityEngine;
using UnityEngine.EventSystems;
namespace io.github.thisisnozaku.cameras
{
    public class CinemachineCameraKeyboardController : AbstractCinemachineCameraController
    {
        [Tooltip("These are the keys that control the camera. When one is pressed, the camera moves in the direction in the corresponding controls array.")]

        public KeyCode[] controls = new KeyCode[]
        {
        KeyCode.UpArrow,
        KeyCode.DownArrow,
        KeyCode.LeftArrow,
        KeyCode.RightArrow
        };

        // Update is called once per frame
        void Update()
        {
            var inputs = new MoveDirection[2];
            int inputIndex = 0;
            for (int i = 0; i < controls.Length; i++)
            {
                if (Input.GetKey(controls[i]))
                {
                    inputs[inputIndex] = directions[i];
                    inputIndex++;
                }
                if (inputIndex == inputs.Length)
                {
                    break;
                }
            }
        }


    }
}