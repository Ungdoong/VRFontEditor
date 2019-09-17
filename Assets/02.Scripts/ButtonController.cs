using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonController : MonoBehaviour {

    private Button btn;
    private int count = 0;
    private ColorBlock nonPressedCb, pressedCb;

    public bool toggle;
    public Color pressedColor;
    public GameObject setActiveObject;

    private void Start()
    {
        btn = GetComponent<Button>();
        nonPressedCb = btn.colors;
        pressedCb = nonPressedCb;
        if (toggle)
            btn.onClick.AddListener(ToggleClicked);    
    }

    void ToggleClicked()
    {
        count++;
        if (count %2 == 1)
        {
            pressedCb.highlightedColor = pressedColor;
            btn.colors = pressedCb;
            if (setActiveObject)
                setActiveObject.SetActive(true);
        }
        else
        {
            btn.colors = nonPressedCb;
            if (setActiveObject)
                setActiveObject.SetActive(false);
        }
    }
}
