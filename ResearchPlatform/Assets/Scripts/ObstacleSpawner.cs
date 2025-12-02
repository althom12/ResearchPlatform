using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;

    void Start()
    {

    }

    private void DisableAllObs()
    {
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DisableAllObs();
            obstacles[0].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DisableAllObs();
            obstacles[1].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DisableAllObs();
            obstacles[2].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            DisableAllObs();
            obstacles[3].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            DisableAllObs();
            obstacles[4].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            DisableAllObs();
            obstacles[5].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            DisableAllObs();
            obstacles[6].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            DisableAllObs();
            obstacles[7].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            DisableAllObs();
            obstacles[8].SetActive(true);
        }
    }
}
