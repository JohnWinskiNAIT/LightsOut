using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartingState : MonoBehaviour
{
    [SerializeField] Button[] allButtons;
    [SerializeField] Button startButton;
    [SerializeField] TMP_Text titleText;

    bool gameStart = false;
    bool lightsOut;

    // Each enum is equal to the number of active buttons.
    enum difficulty
    {
        easy = 9,
        hard = 25
    };

    // Set the default difficulty.
    difficulty levelSetting = difficulty.easy;

    // Initialize the number of patterns for each difficulty.
    int[][] easyPattern = new int[6][];
    int[][] hardPattern = new int[6][];

    private void Start()
    {
        // Set the patterns for the easy difficulty.
        easyPattern[0] = new int[] { 2, 4, 6, 8 };
        easyPattern[1] = new int[] { 1, 3, 5, 7 };
        easyPattern[2] = new int[] { 0 };
        easyPattern[3] = new int[] { 2, 6 };
        easyPattern[4] = new int[] { 2 };
        easyPattern[5] = new int[] { 0, 3 };

        // Set the patterns for the hard difficulty.
        hardPattern[0] = new int[] { 2, 4, 6, 8, 12, 16, 20, 24 };
        hardPattern[1] = new int[] { 0, 10, 14, 18, 22 };
        hardPattern[2] = new int[] { 12, 16, 20, 24 };
        hardPattern[3] = new int[] { 1, 5, 10, 13, 15, 18, 21, 23 };
        hardPattern[4] = new int[] { 1, 5, 9, 18, 20, 21, 22, 24 };
        hardPattern[5] = new int[] { 2, 17, 18, 19, 23 };
    }

    // Update is called once per frame
    void Update()
    {
        lightsOut = true;
        if (gameStart)
        {
            // Check to see if none of the buttons are yellow(on).
            for (int i = 0; i < allButtons.Length && lightsOut; i++)
            {
                Image bi = allButtons[i].GetComponent<Button>().GetComponent<Image>();

                if (bi != null)
                {
                    if (bi.color == Color.yellow)
                    {
                        lightsOut = false;
                    }
                }
            }
        }

        // If the game is started and all lights are out then the player wins.
        if (lightsOut && gameStart)
        {
            gameStart = false;
            titleText.text = "You Win";

            foreach (var button in allButtons)
            {
                button.interactable = false;
            }
        }
    }

    public void SetLevel(int value)
    {
        // Change difficulty.
        switch (value) 
        {
            case 0:
                levelSetting = difficulty.easy;
                break;
            case 1:
                levelSetting = difficulty.hard;
                break;
            default:
                levelSetting = difficulty.easy;
                break;
        }
    }

    public void StartGame()
    {
        int randPattern;
        gameStart = false;
        // Set all buttons to be not interactable
        foreach (var button in allButtons)
        {
            button.GetComponent<LightToggle>().Reset();
            button.interactable = false;
        }

        // Set only the buttons for the current level interactable
        for (int i = 0; i < (int)levelSetting; i++)
        {
            allButtons[i].interactable = true;
        }

        switch (levelSetting)
        {
            // Choose a random easy pattern and set the button states.
            case difficulty.easy:
                randPattern = Random.Range(0, easyPattern.Length);
                for (int i = 0; i < easyPattern[randPattern].Length; i++)
                {
                    if (allButtons[easyPattern[randPattern][i]].GetComponent<Button>().GetComponent<Image>().color == Color.black)
                    {
                        allButtons[easyPattern[randPattern][i]].GetComponent<LightToggle>().ToggleSelf();
                    }
                }
                break;
            // Choose a random hard pattern and set the button states.
            case difficulty.hard:
                randPattern = Random.Range(0, hardPattern.Length);
                for (int i = 0; i < hardPattern[randPattern].Length; i++)
                {
                    if (allButtons[hardPattern[randPattern][i]].GetComponent<Button>().GetComponent<Image>().color == Color.black)
                    {
                        allButtons[hardPattern[randPattern][i]].GetComponent<LightToggle>().ToggleSelf();
                    }
                }
                break;
            default:
                break;
        }

        gameStart = true;

        startButton.GetComponentInChildren<TMP_Text>().text = "Restart";

        titleText.text = "Lights Out!";
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
