using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontMatManager : MonoBehaviour
{
    public VTextInterface vt_inter;

    public Dropdown face_mat_drop, side_mat_drop;

    public List<Material> materials = new List<Material>();
    List<string> materials_name = new List<string>();

    private void Awake()
    {
        materials[0] = vt_inter.materials[0];

        foreach (Material material in materials) {
            materials_name.Add(material.name);
        }
        if (face_mat_drop)
        {
            face_mat_drop.ClearOptions();
            face_mat_drop.AddOptions(materials_name);
            face_mat_drop.onValueChanged.AddListener(delegate { OnChangedFaceMat(); });
        }
        else Debug.Log("missing Face materials dropdown object");

        if (side_mat_drop)
        {
            side_mat_drop.ClearOptions();
            side_mat_drop.AddOptions(materials_name);
            side_mat_drop.onValueChanged.AddListener(delegate { OnChangedSideMat(); });
        }
        else Debug.Log("missing Side materials dropdown object");
    }

    void OnChangedFaceMat()
    {
        vt_inter.materials[0] = materials[face_mat_drop.value];
        vt_inter.materials[2] = materials[face_mat_drop.value];
        vt_inter.Rebuild();
    }
    void OnChangedSideMat()
    {
        vt_inter.materials[1] = materials[side_mat_drop.value];
        vt_inter.Rebuild();
    }
}
