using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontController : MonoBehaviour {

    private bool bTargetOn = false;

    public GameObject _Target;
    private Vector3 prevMousePos;

    public GameObject _CheckBox;

    private void OnMouseDown()
    {
        prevMousePos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        if (!bTargetOn)
        {
            Vector3 v3 = new Vector3(_Target.transform.eulerAngles.x + (Input.mousePosition.y - prevMousePos.y) * Time.deltaTime, _Target.transform.eulerAngles.y - (Input.mousePosition.x - prevMousePos.x) * 0.5f * Time.deltaTime, 0);
            _Target.transform.DORotate(v3, 0f);
        }
        else
        {
            Vector3 v3 = new Vector3(0, Camera.main.transform.eulerAngles.y - (Input.mousePosition.x - prevMousePos.x) * 0.5f * Time.deltaTime, 0);
            Camera.main.transform.DORotate(v3, 0f);
        }
    }

    private void Update()
    {
        if (!bTargetOn) return;

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Camera.main.transform.DOMove(Camera.main.transform.position - Camera.main.transform.forward, 0f);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Camera.main.transform.DOMove(Camera.main.transform.position + Camera.main.transform.forward, 0f);
        }
    }

    public void Btn_ChangeTargetObj(bool b)
    {
        bTargetOn = _CheckBox.GetComponent<Toggle>().isOn;
    }
}
