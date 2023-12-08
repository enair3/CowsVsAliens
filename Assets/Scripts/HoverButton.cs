using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverButton : MonoBehaviour
{
    public Button[] buttons;
    public int currentButton;

    // button sprites
    public Sprite unselected;
    public Sprite selected;

    void Start()
    {
        currentButton = 0;
        buttons[0].image.sprite = selected;
    }

    void Update()
    {
        // check if active before action
        // ui navigation opposite of conv for alt ctrl. diff builds for keyboard vs alt ctrl
        if (buttons[currentButton].isActiveAndEnabled)
        {
            // to next (right, down)
            // KEYBOARD
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) //keyboard

            // ALT CTRL
            //if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.UpArrow)) //alt ctrl
            {
                ToNextButton();
            }
            // to previous (left, up)
            // KEYBOARD
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.UpArrow)) //keyboard

            //ALT CTRL
            //else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) // alt ctrl
                {
                ToPreviousButton();
            }

            else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Backslash))
            //else if (Input.GetKeyDown(KeyCode.Backslash))
            {
                buttons[currentButton].onClick.Invoke();
            }
        }
    }

    void ToNextButton()
    {
        buttons[currentButton].image.sprite = unselected;
        currentButton++;

        // go back to first button if at end
        if (currentButton >= buttons.Length)
        {
            currentButton = 0;
        }
        // currentButton uses selected sprite
        buttons[currentButton].image.sprite = selected;
    }

    void ToPreviousButton()
    {
        buttons[currentButton].image.sprite = unselected;
        currentButton--;

        if (currentButton < 0)
        {
            currentButton = (buttons.Length - 1);
        }

        buttons[currentButton].image.sprite = selected;
    }
}

