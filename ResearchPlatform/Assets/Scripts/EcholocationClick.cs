using UnityEngine;

public class EcholocationClick : MonoBehaviour
{
    private GameObject clickEmitter;

    [Tooltip("The main echolocation click sound")]
    public AK.Wwise.Event EcholocationSound;

    void Start()
    {
        clickEmitter = gameObject.transform.GetChild(1).gameObject;
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            EcholocationSound?.Post(clickEmitter);
            Debug.Log("Echolocation Click");
        }
    }
}
