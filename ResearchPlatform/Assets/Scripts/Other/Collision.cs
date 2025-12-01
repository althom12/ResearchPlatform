using UnityEngine;

public class Collision : MonoBehaviour
{
    private GameObject player;
    private float cooldownTime = 1f, lastCollisionTime = -999f;  // Initially assigning a large negative value for lastCollisionTime so when the game loads and Time.time = 0
                           // then -> 0 - (-999) will always be greater than the cooldownTime, so first collision will not go 
                                                                 // unaccouted for
    void Start()                                                
    {
        player = this.gameObject;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.name != "Floor" && (Time.time - lastCollisionTime) > cooldownTime)
        {
            Debug.Log("Hit object : " + hit.gameObject.name);

            //code for colission sound

            lastCollisionTime = Time.time;
        }

          

    }

    void Update()
    {
        
    }
}
