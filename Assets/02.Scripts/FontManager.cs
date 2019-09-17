using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontManager : MonoBehaviour {

    public InputField inputField;
    public Slider slider_scaleX;
    public Slider slider_scaleY;
    public Slider slider_scaleZ;
    public Slider slider_bevel;
    public Slider slider_height;
    public Slider slider_width;

    public GameObject txtObj;
    public GameObject goDropdown;

    private VTextInterface vt_inter;
    private Dropdown font_drop;

    private void Awake()
    {
        vt_inter = txtObj.GetComponent<VTextInterface>();
        font_drop = goDropdown.GetComponent<Dropdown>();
        if (goDropdown)
        {
            font_drop.ClearOptions();
            font_drop.AddOptions(VTextInterface.GetAvailableFonts());
            font_drop.onValueChanged.AddListener(delegate { Btn_DropDown(); });
        }
    }

    public void Btn_CreateFont()
    {
        vt_inter.RenderText = inputField.text;
    }

    public void OnChangedSlider_Scale()
    {
        txtObj.transform.localScale = new Vector3(slider_scaleX.value + 1, slider_scaleY.value + 1, 1);
    }

    public void OnChangedSlider_Depth()
    {
        if (vt_inter != null)
        {
            vt_inter.parameter.Depth = slider_scaleZ.value;
        }
    }

    public void OnChangedSlider_Bevel()
    {
        if (vt_inter != null)
        {
            vt_inter.parameter.Bevel = slider_bevel.value;
        }
    }

    public void Btn_DropDown()
    {
        vt_inter.parameter.Fontname = VTextInterface.GetAvailableFonts()[font_drop.value];
    }

    public void OnChangedHeight()
    {
        if (vt_inter)
        {
            vt_inter.layout.Spacing = slider_height.value;
        }
    }

    public void OnchangedWidth()
    {
        if (vt_inter)
        {
            vt_inter.layout.GlyphSpacing = slider_width.value;
        }
    }
}
