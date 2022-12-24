using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
namespace io.github.thisisnozaku.cameras
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class AbstractCinemachineCameraController : MonoBehaviour
    {
        [Tooltip("The directions to move on the next update.")]
        public MoveDirection[] inputs;
        public float speed;
        private CinemachineVirtualCamera virtualCamera;

        public MoveDirection[] directions = new MoveDirection[]
        {
            MoveDirection.Up,
            MoveDirection.Down,
            MoveDirection.Left,
            MoveDirection.Right
        };
        public Dictionary<MoveDirection, bool> EnabledDirections = new Dictionary<MoveDirection, bool>() {
            { MoveDirection.Up, true},
            { MoveDirection.Down, true},
            { MoveDirection.Left, true},
            { MoveDirection.Right, true}
        };
        // Start is called before the first frame update
        protected void Start()
        {
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
            inputs = new MoveDirection[directions.Length];
            for (int i = 0; i < directions.Length; i++)
            {
                inputs[i] = MoveDirection.None;
            }
        }

        private Vector3 lastPosition;

        // Update is called once per frame
        void LateUpdate()
        {
            var startPosition = virtualCamera.transform.position;
            foreach (var direction in inputs)
            {
                if(direction == MoveDirection.None || !EnabledDirections[direction])
                {
                    continue;
                }
                switch (direction)
                {
                    case MoveDirection.Left:
                        virtualCamera.ForceCameraPosition(virtualCamera.transform.position + Vector3.left * speed,
                            transform.rotation);
                        break;
                    case MoveDirection.Right:
                        virtualCamera.ForceCameraPosition(virtualCamera.transform.position + Vector3.right * speed,
                            transform.rotation);
                        break;
                    case MoveDirection.Up:
                        virtualCamera.ForceCameraPosition(virtualCamera.transform.position + Vector3.up * speed,
                            transform.rotation);
                        break;
                    case MoveDirection.Down:
                        virtualCamera.ForceCameraPosition(virtualCamera.transform.position + Vector3.down * speed,
                            transform.rotation);
                        break;
                }
                EnabledDirections[direction.Invert()] = true;
            }
            if(virtualCamera.transform.position == lastPosition)
            {
                for(int i = 0; i < inputs.Length; i++)
                {
                    if(inputs[i] != MoveDirection.None)
                    {
                        Debug.Log(string.Format("Disable direction {0}", inputs[i]));
                        EnabledDirections[inputs[i]] = false;
                        inputs[i] = MoveDirection.None;
                    }
                }
            }
            lastPosition = virtualCamera.transform.position;
        }
    }
}