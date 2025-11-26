using UnityEngine;

public class Navigation : MonoBehaviour
{

    private GameObject player;
    private CharacterController characterController;

    [SerializeField]
    private float playerSpeed = 2.5f;

    void Start()
    {
        player = gameObject.GetComponent<GameObject>();
        characterController = gameObject.GetComponent<CharacterController>();   
    }

    
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
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
}
