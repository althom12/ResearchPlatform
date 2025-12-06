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
            OnStartMenuPress,
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

    private void UIParentController(int indexOfInterest)
    {
        for(int i = 0; i < levelTwoButtons.Length; i++)
        {
            if (i == indexOfInterest)
            {
                levelTwoButtons[i].gameObject.SetActive(true);
                UIParents[i].SetActive(true);

            }

            else
            {
                levelTwoButtons[i].gameObject.SetActive(false);
                UIParents[i].SetActive(false);
            }
        }
    }

    private void backToCategories()
    {
        for(int i = 0; i < UIParents.Length; i++)
        {
            UIParents[i].gameObject.SetActive(false);
            levelTwoButtons[i].gameObject.SetActive(true);

        }
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
        Debug.Log("Inside fn");
        PageController(1, 0);
    }

    public void OnEcholocatorClickPress()
    {
        UIParentController(1);
    }

    public void OnObstaclesPress()
    {
        UIParentController(2);
    }

    public void OnEnvironmentPress()
    {
        UIParentController(3);
    }

    public void OnLocomotionPress()
    {
        UIParentController(4);
    }

    public void OnAudioLandmarksPress()
    {
        UIParentController(5);
    }

    public void OnAudioCrumbsPress()
    {
        UIParentController(6);
    }

    public void OnTutorialItemsPress()
    {
        UIParentController(7);
    }

    public void OnAcousticConfigurationPress()
    {
        UIParentController(8);
    }

    public void OnEnvironmentLabPress()
    {
        UIParentController(9);
    }

    public void OnDebugAndAnalysisPress()
    {
        UIParentController(10);
    }

    public void OnMixingPress()
    {
        UIParentController(11);
    }



    void Update()
    {
        // For Page 1
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
                //for(int i = 0; i < levelOneButtons.Length; i++)
                //{
                //    levelOneFunctions[page1OptionIndex]();
                //}

                levelOneFunctions[page1OptionIndex]();
            }

           
        }

        
        // For Page 2
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

            if (Input.GetKeyDown(KeyCode.Tab))
            {
             
                    levelTwoFunctions[page2OptionIndex]();
                
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    

                    if (isPageOpen[1])
                    {
                        // Check if any of the UIParent game objects are active in the hierarchy

                        bool isActiveUIParent = false;

                        for(int i = 0; i < UIParents.Length; i++)
                        {
                            if (UIParents[i].gameObject.activeSelf)
                            {
                                isActiveUIParent = true;
                                
                            }                         
                        }

                        if(isActiveUIParent)
                        {
                            backToCategories();
                        }
                        else
                        {
                            PageController(1, 0);
                        }

                    }
                }
            }

        }



       
    }
}
