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
        [SerializeField]
        private new CinemachineVirtualCamera virtualCamera;

        public MoveDirection[] directions = new MoveDirection[]
        {
        MoveDirection.Up,
        MoveDirection.Down,
        MoveDirection.Left,
        MoveDirection.Right
        };
        // Start is called before the first frame update
        protected void Start()
        {
            inputs = new MoveDirection[directions.Length];
            for (int i = 0; i < directions.Length; i++)
            {
                inputs[i] = MoveDirection.None;
            }
        }

        // Update is called once per frame
        void LateUpdate()
        {
            foreach (var direction in inputs)
            {
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
            }
        }
    }
}