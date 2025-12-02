using UnityEngine;

public class Collision : MonoBehaviour
{
    private GameObject player;
    private float cooldownTime = 1f, lastCollisionTime = -999f;  // Initially assigning a large negative value for lastCollisionTime so when the game loads and Time.time = 0
                                                                 // then -> 0 - (-999) will always be greater than the cooldownTime, so first collision will not go 
                                                                 // unaccouted for



    [Tooltip("Collision impact sound")]
    public AK.Wwise.Event CollisionSound;

    void Start()                                                
    {
        player = this.gameObject;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(((Time.time - lastCollisionTime) > cooldownTime) && (hit.gameObject.CompareTag("Wall") || hit.gameObject.CompareTag("Obstacle"))) 
        {
            Debug.Log("Hit object : " + hit.gameObject.name);

            CollisionSound?.Post(gameObject);

            lastCollisionTime = Time.time;
        }

          

    }

    void Update()
    {
        
    }
}
