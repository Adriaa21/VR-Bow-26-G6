using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private GameObject midpointVisual, arrowPrefab, arrowSpawnPoint;
    [SerializeField] private float arrowSpeed = 10f;

    public void PrepareArrow(){
        midpointVisual.SetActive(true);
    }
    
    public void ReleaseArrow(float strength){
        midpointVisual.SetActive(false);
        Transform visualTransform = midpointVisual.transform;
        Rigidbody arrow = Instantiate(arrowPrefab, arrowSpawnPoint.transform.position, visualTransform.transform.rotation).GetComponent<Rigidbody>();
        
        arrow.AddForce(visualTransform.forward * (strength * arrowSpeed), ForceMode.Impulse);
    }
}


