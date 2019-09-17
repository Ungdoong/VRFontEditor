using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PhysicsManager : MonoBehaviour
{
    [Tooltip("the prefab of the ball")]
    public GameObject BallPrefab;                       // the prefab of the ball 

    [Tooltip("The offset of the ball from the camera center into the shooting direction when it is spawned")]
    public float BallSpawnOffset = 3.0f;                // the offset of the ball from the camera center into the shooting direction when it is spawned

    [Tooltip("The speed of the ball")]
    public float BallSpeed = 1000.0f;                   // the speed of the ball

    [Tooltip("The lifetime of the ball until it is destroyed")]
    public float BallLifeTime = 5.0f;                   // the lifetime of the ball until it is destroyed

    bool flag_ball = false;

    public Toggle rigidbody_toggle;
    public GameObject text_box;
    public VTextInterface vt_inter;
    public GameObject btn_reset;
    public GameObject btn_gravity;

    private void Awake()
    {
        rigidbody_toggle.isOn = false;
        vt_inter.Physics.CreateRigidBody = false;
        btn_reset.SetActive(false);
        btn_gravity.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && flag_ball == true)
        {
            // mouse is over an UI element
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            GameObject ball = Instantiate(BallPrefab, Camera.main.transform.position + r.direction * BallSpawnOffset, Camera.main.transform.rotation) as GameObject;
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(r.direction * BallSpeed);
            }

            Destroy(ball, BallLifeTime);
        }
    }

    public void Rigidbody_Toggle_Change()
    {
        flag_ball = rigidbody_toggle.isOn;
        if (flag_ball)
        {
            btn_reset.SetActive(true);
            btn_gravity.SetActive(true);
            text_box.GetComponent<BoxCollider>().enabled = false;
            vt_inter.Physics.CreateRigidBody = true;
        }
        else {
            btn_reset.SetActive(false);
            btn_gravity.SetActive(false);
            text_box.GetComponent<BoxCollider>().enabled = true;
            vt_inter.Physics.CreateRigidBody = false;
            Reset_Rigid_State();
        }
    }

    public void Reset_Rigid_State()
    {
        vt_inter.Rebuild();
    }

    public void OnGravity()
    {
        vt_inter.Physics.RigidbodyUseGravity = !vt_inter.Physics.RigidbodyUseGravity;
    }
}
