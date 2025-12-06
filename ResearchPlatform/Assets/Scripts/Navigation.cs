using UnityEngine;

public class Navigation : MonoBehaviour
{

    private GameObject player;
    private CharacterController characterController;

    [SerializeField]
    private float playerSpeed = 2.5f;

    [SerializeField]
    private Transform[] spawnPoints;

    private float pitch = 0f;

    [SerializeField]
    private bool wasdMovement = false;


    [Header("Audio")]
    public AK.Wwise.Event FootstepSound;
    [SerializeField]
    private float footstepInterval = 0.5f;
    private float _footstepTimer;



    void Start()
    {
        player = this.gameObject;
        characterController = gameObject.GetComponent<CharacterController>();

        // "Charge" the timer so the very first step plays immediately upon input
        _footstepTimer = footstepInterval;
    }


    // NEW FUNCTION FOR FOOTSTEP AUDIO 
    private void HandleFootsteps()
    {
        // Check if we are actually moving (magnitude > 0)
        // We use velocity so running into a wall doesn't play sounds
        if (characterController.velocity.sqrMagnitude > 0.1f)
        {
            _footstepTimer += Time.deltaTime;

            if (_footstepTimer >= footstepInterval)
            {
                FootstepSound.Post(gameObject);
                Debug.Log("Footstep");
                _footstepTimer = 0f;
            }
        }
        else
        {
            // When stopped, reset timer to the interval.
            // This ensures the NEXT time you move, the sound plays immediately (0 delay).
            _footstepTimer = footstepInterval;
        }
    }



        void Update()
    {

        // Arrow key navigation
        if (!Input.GetKey(KeyCode.RightAlt))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                characterController.Move(characterController.transform.forward * Time.deltaTime * playerSpeed);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                characterController.Move(-characterController.transform.right * Time.deltaTime * playerSpeed);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                characterController.Move(-characterController.transform.forward * Time.deltaTime * playerSpeed);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                characterController.Move(characterController.transform.right * Time.deltaTime * playerSpeed);
            }
        }

        //WASD-based navigation for testing efficiency
        if(wasdMovement)
        {
            if (Input.GetKey(KeyCode.W))
            {
                characterController.Move(characterController.transform.forward * Time.deltaTime * playerSpeed);
            }

            if (Input.GetKey(KeyCode.A))
            {
                characterController.Move(-characterController.transform.right * Time.deltaTime * playerSpeed);
            }

            if (Input.GetKey(KeyCode.S))
            {
                characterController.Move(-characterController.transform.forward * Time.deltaTime * playerSpeed);
            }

            if (Input.GetKey(KeyCode.D))
            {
                characterController.Move(characterController.transform.right * Time.deltaTime * playerSpeed);
            }
        }



        // snap turn rotation to the 4 cardinal axes
        if (Input.GetKey(KeyCode.RightAlt))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                player.transform.eulerAngles = Vector3.zero;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                player.transform.eulerAngles = new Vector3(0, -90, 0);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                player.transform.eulerAngles = new Vector3(0, -180, 0);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                player.transform.eulerAngles = new Vector3(0, 90, 0);
            }

        }


        // Spawning Mechanism
        if(Input.GetKey(KeyCode.Keypad0))
        {
            player.transform.position = spawnPoints[0].position;
            player.transform.rotation = spawnPoints[0].rotation;    
        }

        if (Input.GetKey(KeyCode.Keypad1))
        {
            player.transform.position = spawnPoints[1].position;
            player.transform.rotation = spawnPoints[1].rotation;
        }

        //Changing gaze using the mouse
        Vector2 mouseGaze = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));


        float yawInput = mouseGaze.x;
        float pitchInput = -mouseGaze.y;  //negative sign because Unity's coordinate system and mouse input move in opposite directions

        pitch += pitchInput;
        pitch = Mathf.Clamp(pitch, -70f, 70f);

        player.transform.rotation *= Quaternion.Euler(0, yawInput, 0);
        player.transform.GetChild(0).transform.localRotation = Quaternion.Euler(pitch, 0, 0);



        HandleFootsteps();

    }
}
