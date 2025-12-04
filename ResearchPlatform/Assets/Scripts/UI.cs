using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public GameObject[] pages;
    //public GameObject[] UIParents;
    public Button[] levelOneButtons;
    //public Button[] levelTwoButtons;
   

    //public GameObject[] sliders;
    private bool isPage1Open = false;
    private bool isPage2Open = false;

    private int page1OptionIndex;
    private int prevPage1OptionIndex;
    private int page2OptionIndex;
    private int prevPage2OptionIndex;

   
    // 0 -> unSelected color, 1 -> selected color
    [SerializeField]
    private Color[] color = new Color[2];

    [SerializeField]
    private GameObject player, mainMaze;

    void Start()
    {
        isPage1Open = true;
        //Disable main maze and player at start
    }

    private void Awake()
    {
        levelOneButtons[0].onClick.AddListener(OnStartButtonPress);
        levelOneButtons[1].onClick.AddListener(OnTutorialItemsButtonPress);
        levelOneButtons[2].onClick.AddListener(OnSaveSettingsButtonPress);
    }

    private void OnEnable()
    {
        player.GetComponent<Navigation>().enabled = false;  
        player.GetComponent<CompassController>().enabled = false;  
        player.GetComponent<EcholocationClick>().enabled = false;  
        mainMaze.SetActive(false);
        page1OptionIndex = prevPage1OptionIndex;
    }

    private void OnDisable()
    {
        player.GetComponent<Navigation>().enabled = true;
        player.GetComponent<CompassController>().enabled = true;
        player.GetComponent<EcholocationClick>().enabled = true;
        mainMaze.SetActive(true);
    }

    private void OptionSelector(int optionIndex, ref int prevOptionIndex, Button[] levelButtons)
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (optionIndex == i)
            {
                levelButtons[i].image.color = color[1];
                prevOptionIndex = i;
            }

            else
            {
                levelButtons[i].image.color = color[0];
            }
        }


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
        if(isPage1Open)
        {
           

           if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                if(page1OptionIndex < 2)
                {
                    page1OptionIndex++;     //2A847F 42 132 126

                }

                OptionSelector(page1OptionIndex, ref prevPage1OptionIndex, levelOneButtons);

            }


            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (page1OptionIndex > 0)
                {
                    page1OptionIndex--;     

                }

                OptionSelector(page1OptionIndex, ref prevPage1OptionIndex, levelOneButtons);

            }

        }
    }
}
