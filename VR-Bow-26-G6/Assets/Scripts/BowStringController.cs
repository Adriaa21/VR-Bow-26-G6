using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;


    public class BowStringController : MonoBehaviour
    {
        public UnityEvent OnBowPulled;
        public UnityEvent<float> OnBowReleased;

        [SerializeField] private Transform midPointGrab, midPointVisual, midPointParent;
        [SerializeField] private BowString.BowString bowString;
        [SerializeField] private float strechLimit = .3f;

        private XRGrabInteractable _interactable; // cubo blanco
        private Transform _interactor; // mano

        private float _strength;

        private void Awake() {
            _interactable = midPointGrab.GetComponent<XRGrabInteractable>();
        }

        private void Start() {
            _interactable.selectEntered.AddListener(Prepare);
            _interactable.selectExited.AddListener(Release);
        }

        private void OnDestroy() {
            _interactable.selectEntered.RemoveListener(Prepare);
            _interactable.selectExited.RemoveListener(Release);
        }
        
        private void Prepare(SelectEnterEventArgs select) {
            _interactor = select.interactorObject.transform;
            OnBowPulled.Invoke();
        }

        private void Release(SelectExitEventArgs arg0) {
            OnBowReleased.Invoke(_strength);
            _strength = 0;

            _interactor = null;
            midPointGrab.localPosition = Vector3.zero;
            midPointVisual.localPosition = Vector3.zero;

            bowString.CreateString(null);
        }


        private void Update() {
            if (_interactor) {
                Vector3 grabLocalPos = midPointParent.InverseTransformPoint(midPointGrab.position);
                float grabLocalBackward = Mathf.Abs(grabLocalPos.z);

                //<0
                HandlePushedTowardsBow(grabLocalPos);
                //>0
                HandlePulledToLimit(grabLocalBackward, grabLocalPos);
                //[0,1]
                HandlePull(grabLocalBackward, grabLocalPos);

                bowString.CreateString(midPointVisual.position);
            }
        }

        private void HandlePushedTowardsBow(Vector3 grabLocalPos)
        {

            if (grabLocalPos.z > 0)
            {
                _strength = 0;
                midPointGrab.localPosition = Vector3.zero;
            }
        }


        private void HandlePulledToLimit(float grabLocalBackward, Vector3 grabLocalPos)
        {
            if (grabLocalPos.z < 0 && grabLocalBackward >= strechLimit)
            {
                _strength = 1;
                midPointVisual.localPosition = new Vector3(0, 0, -strechLimit);
            }
        }

        private void HandlePull(float grabLocalBackward, Vector3 grabLocalPos)
        {
            if (grabLocalPos.z < 0 && grabLocalBackward < strechLimit)
            {
                _strength = Remap(grabLocalBackward, 0, strechLimit, 0, 1);
                midPointVisual.localPosition = new Vector3(0, 0, grabLocalPos.z);
            }
        }


        private float Remap(float value, int fromMin, float fromMax, int toMin, float toMax)
        {
            return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
        }
    }