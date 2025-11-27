using UnityEngine;

public class Navigation : MonoBehaviour
{

    private GameObject player;
    private CharacterController characterController;

    [SerializeField]
    private float playerSpeed = 2.5f;

    void Start()
    {
        player = this.gameObject;
        characterController = gameObject.GetComponent<CharacterController>();   
    }

    
    void Update()
    {
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

        

        if(Input.GetKey(KeyCode.RightAlt))
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

    }
}
