using UnityEngine;
using UnityEngine.EventSystems;

namespace io.github.thisisnozaku.cameras
{
    /**
     * This controller is meant to be used to control a Cinemachine virtual camera via mouseover-able UI components, such as Buttons.
     */
    public class CinemachineCameraUiController : AbstractCinemachineCameraController
    {
        [Tooltip("EventTriggers which trigger camera movement when moused over. Just adding the EventTrigger to the component is enough; " +
            "this component will handle configuring it.")]
        public EventTrigger[] controls;
        [Tooltip("If true, when the camera reaches an edge of the bounds, the control(s) involved in moving in the direction(s) will be deactivated.")]
        public bool disableControlsAtBoundary;

        new void Start()
        {
            base.Start();
            for (int i = 0; i < controls.Length; i++)
            {
                {
                    var index = i; // Variable capture. Keeps value in this iteration
                    var enterTrigger = new EventTrigger.Entry();
                    enterTrigger.eventID = EventTriggerType.PointerEnter;

                    enterTrigger.callback.AddListener((ue) =>
                    {
                        inputs[index] = EnabledDirections[directions[index]] ? directions[index] : MoveDirection.None;
                    });
                    if (controls[i])
                    {
                        controls[i].triggers.Add(enterTrigger);
                    }

                    var exitTrigger = new EventTrigger.Entry();
                    exitTrigger.eventID = EventTriggerType.PointerExit;
                    exitTrigger.callback.AddListener((ue) =>
                    {
                        inputs[index] = MoveDirection.None;
                    });
                    if (controls[i])
                    {
                        controls[i].triggers.Add(exitTrigger);
                    }
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (disableControlsAtBoundary)
            {
                for (int i = 0; i < controls.Length; i++)
                {
                    controls[i].gameObject.SetActive(EnabledDirections[directions[i]]);
                }
            }
        }
    }
}