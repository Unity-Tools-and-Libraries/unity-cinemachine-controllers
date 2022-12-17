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
        private new CinemachineVirtualCamera camera;

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
                        camera.transform.position += Vector3.left * speed;
                        break;
                    case MoveDirection.Right:
                        camera.transform.position += Vector3.right * speed;
                        break;
                    case MoveDirection.Up:
                        camera.transform.position += Vector3.up * speed;
                        break;
                    case MoveDirection.Down:
                        camera.transform.position += Vector3.down * speed;
                        break;
                }
            }
        }
    }
}