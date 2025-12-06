using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public GameObject[] pages;
    public GameObject[] UIParents;
    public Button[] levelOneButtons;
    public Button[] levelTwoButtons;
   

    //public GameObject[] sliders;
    //private bool isPage1Open = false;
    //private bool isPage2Open = false;
    private bool[] isPageOpen = {false, false};

    private int page1OptionIndex;
    private int prevPage1OptionIndex;
    private int page2OptionIndex;
    private int prevPage2OptionIndex;

   
    // 0 -> unSelected color, 1 -> selected color
    [SerializeField]
    private Color[] color = new Color[2];

    [SerializeField]
    private GameObject player, mainMaze;

    // array of functions to bind each on click event method to its corresponding button
    private UnityAction[] levelOneFunctions;
    private UnityAction[] levelTwoFunctions;

    void Start()
    {

        //Disable main maze and player at start
    }

    private void Awake()
    {
        levelOneFunctions = new UnityAction[]
        {
            OnStartButtonPress,
            OnTutorialItemsButtonPress,
            OnSaveSettingsButtonPress
        };

        levelTwoFunctions = new UnityAction[]
        {
            OnEcholocatorClickPress,
            OnObstaclesPress,
            OnEnvironmentPress,
            OnLocomotionPress,
            OnAudioLandmarksPress,
            OnAudioCrumbsPress,
            OnTutorialItemsPress,
            OnAcousticConfigurationPress,
            OnEnvironmentLabPress,
            OnDebugAndAnalysisPress,
            OnMixingPress
        };

        for (int i = 0; i < levelOneButtons.Length; i++)
        {
            int index = i;
            levelOneButtons[index].onClick.AddListener(levelOneFunctions[index]);
        }


        levelOneButtons[0].image.color = color[1];
        prevPage1OptionIndex = 0;

        levelTwoButtons[0].image.color = color[1];
        prevPage2OptionIndex = 0;


    }

    private void OnEnable()
    {
        isPageOpen[0] = true;
        player.GetComponent<Navigation>().enabled = false;  
        player.GetComponent<CompassController>().enabled = false;  
        player.GetComponent<EcholocationClick>().enabled = false;  
        mainMaze.SetActive(false);
        page1OptionIndex = prevPage1OptionIndex;
        page2OptionIndex = prevPage2OptionIndex;
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
    private void PageController(int i, int j)
    {
        pages[i].SetActive(false);
        pages[j].SetActive(true);
        isPageOpen[i] = false;
        isPageOpen[j] = true;
    }

    private void UIParentController()
    {

    }

  // On click button events for Page 1
    public void OnStartButtonPress()
    {
        PageController(0, 1);
    }

    public void OnTutorialItemsButtonPress()
    {
        PageController(0, 2);
    }

    public void OnSaveSettingsButtonPress()
    {
        PageController(0, 3);
    }


    // On click button events for Page 2 (Categories Page)

    public void OnStartMenuPress()
    {
        PageController(1, 0);
    }

    public void OnEcholocatorClickPress()
    {
        UIParents[0].SetActive(true);
    }

    public void OnObstaclesPress()
    {
        UIParents[0].SetActive(true);
    }

    public void OnEnvironmentPress()
    {
        UIParents[0].SetActive(true);
    }

    public void OnLocomotionPress()
    {
        UIParents[0].SetActive(true);
    }

    public void OnAudioLandmarksPress()
    {
        UIParents[0].SetActive(true);
    }

    public void OnAudioCrumbsPress()
    {
        UIParents[0].SetActive(true);
    }

    public void OnTutorialItemsPress()
    {
        UIParents[0].SetActive(true);
    }

    public void OnAcousticConfigurationPress()
    {
        UIParents[0].SetActive(true);
    }

    public void OnEnvironmentLabPress()
    {
        UIParents[0].SetActive(true);
    }

    public void OnDebugAndAnalysisPress()
    {
        UIParents[0].SetActive(true);
    }

    public void OnMixingPress()
    {
        UIParents[0].SetActive(true);
    }



    void Update()
    {
        if (isPageOpen[0])
        {
           

           if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                if(page1OptionIndex < (levelOneButtons.Length-1))
                {
                    page1OptionIndex++;     

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

            if(Input.GetKeyDown(KeyCode.Tab))
            {
                for(int i = 0; i < levelOneButtons.Length; i++)
                {
                    levelOneFunctions[page1OptionIndex]();
                }
            }

           
        }

        if (isPageOpen[1])
        {

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (page2OptionIndex < (levelTwoButtons.Length - 1))
                {
                    page2OptionIndex++;     

                }

                OptionSelector(page2OptionIndex, ref prevPage2OptionIndex, levelTwoButtons);

            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (page2OptionIndex > 0)
                {
                    page2OptionIndex--;

                }

                OptionSelector(page2OptionIndex, ref prevPage2OptionIndex, levelTwoButtons);

            }
        }



        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (isPageOpen[0])
                {
                    return;
                }

                if (isPageOpen[1])
                {
                    PageController(1, 0);
                }
            }
        }
    }
}
