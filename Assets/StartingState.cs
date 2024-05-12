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

    // Update is called once per frame
    void Update()
    {
        lightsOut = true;
        if (gameStart)
        {
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

    public void StartGame()
    {
        foreach (var button in allButtons)
        {
            button.GetComponent<LightToggle>().Reset();
            button.interactable = true;
        }

        int rand = Random.Range(0, 13);

        switch (rand)
        {
            case 0:
                allButtons[0].GetComponent<LightToggle>().ToggleSelf();
                break;
            case 1:
                allButtons[1].GetComponent<LightToggle>().ToggleSelf();
                break;
            case 2:
                allButtons[2].GetComponent<LightToggle>().ToggleSelf();
                break;
            case 3:
                allButtons[3].GetComponent<LightToggle>().ToggleSelf();
                break;
            case 4:
                allButtons[4].GetComponent<LightToggle>().ToggleSelf();
                break;
            case 5:
                allButtons[5].GetComponent<LightToggle>().ToggleSelf();
                break;
            case 6:
                allButtons[6].GetComponent<LightToggle>().ToggleSelf();
                break;
            case 7:
                allButtons[7].GetComponent<LightToggle>().ToggleSelf();
                break;
            case 8:
                allButtons[8].GetComponent<LightToggle>().ToggleSelf();
                break;
            case 9:
                allButtons[0].GetComponent<LightToggle>().ToggleSelf();
                allButtons[8].GetComponent<LightToggle>().ToggleSelf();
                break;
            case 10:
                allButtons[2].GetComponent<LightToggle>().ToggleSelf();
                allButtons[6].GetComponent<LightToggle>().ToggleSelf();
                break;
            case 11:
                allButtons[0].GetComponent<LightToggle>().ToggleSelf();
                allButtons[1].GetComponent<LightToggle>().ToggleSelf();
                break;
            case 12:
                allButtons[0].GetComponent<LightToggle>().ToggleSelf();
                allButtons[8].GetComponent<LightToggle>().ToggleSelf();
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
