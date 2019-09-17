using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public Dropdown back_drop;

    public List<GameObject> backgrounds = new List<GameObject>();

    List<string> back_names = new List<string>();
    int prev_index = 0;

    private void Awake()
    {
        foreach(GameObject background in backgrounds)
        {
            back_names.Add(background.name);
            background.SetActive(false);
        }

        if (back_drop)
        {
            back_drop.ClearOptions();
            back_drop.AddOptions(back_names);
            back_drop.onValueChanged.AddListener(delegate { OnChangedBack(); });
        }
    }

    public void OnChangedBack()
    {
        backgrounds[prev_index].SetActive(false);
        backgrounds[back_drop.value].SetActive(true);
        prev_index = back_drop.value;
    }
}