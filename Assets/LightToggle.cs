using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightToggle : MonoBehaviour
{
    [SerializeField] Button[] adjacentButtons;
    
    public void ToggleButton()
    {
        ToggleSelf();

        foreach (var button in adjacentButtons)
        {
            button.GetComponent<LightToggle>().ToggleSelf();
        }
    }

    public void ToggleSelf()
    {
        Image bi = GetComponent<Button>().GetComponent<Image>();

        if (bi != null)
        {
            if (bi.color == Color.black)
            {
                bi.color = Color.yellow;
            }
            else
            {
                bi.color = Color.black;
            }
        }
    }

    public void Reset()
    {
        Image bi = GetComponent<Button>().GetComponent<Image>();

        if (bi != null)
        {
            bi.color = Color.black;
        }
    }
}
