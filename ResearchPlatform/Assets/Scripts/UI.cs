using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public GameObject[] pages;
    public GameObject[] UIParents;
    public Button[] levelOneButtons;
    public Button[] levelTwoButtons;
   

    public GameObject[] sliders;

    void Start()
    {
        //Disable main maze and player at start
    }

    private void Awake()
    {
        levelOneButtons[0].onClick.AddListener(OnStartButtonPress);
        levelOneButtons[1].onClick.AddListener(OnTutorialItemsButtonPress);
        levelOneButtons[2].onClick.AddListener(OnSaveSettingsButtonPress);
    }


  // Method to enable/disable pages
    private void Pagecontroller(int i, int j)
    {
        pages[i].SetActive(false);
        pages[j].SetActive(true);
    }

    public void OnStartButtonPress()
    {
        Pagecontroller(0, 1);
    }

    public void OnTutorialItemsButtonPress()
    {
        Pagecontroller(0, 2);
    }

    public void OnSaveSettingsButtonPress()
    {
        Pagecontroller(0, 3);
    }


    // Categories Page



    void Update()
    {
        
    }
}
