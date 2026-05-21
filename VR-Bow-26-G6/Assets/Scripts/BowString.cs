using UnityEngine;

namespace BowString {
    [RequireComponent(typeof(LineRenderer))]

    public class BowString : MonoBehaviour
    {
        [SerializeField] private Transform startPoint, endPoint;
        private LineRenderer LR;

        private void Awake()
        {
            LR = GetComponent<LineRenderer>();
        }

        private void Start()
        {
            CreateString(null);
        }

        public void CreateString(Vector3? midPosition) {
            Vector3[] linePoints = new Vector3[midPosition.HasValue ? 3 : 2];

            linePoints[0] = startPoint.localPosition;

            if (midPosition.HasValue)
            {
                linePoints[1] = transform.InverseTransformPoint(midPosition.Value);
            }
            linePoints[^1] = endPoint.localPosition;
            LR.positionCount = linePoints.Length;
            LR.SetPositions(linePoints);
        }
    }
}