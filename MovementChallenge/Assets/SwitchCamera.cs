using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera mainCamera;
    public Camera secondCamera;
    public Transform sprintBar;
    public Transform sprintBG;
    private Vector2 start;
    public bool last;
    private void Start()
    {
        start = sprintBar.position;
    }
    void Update()
    {
        //if(Input.GetKeyDown("space"))
        if(last != ArduinoControl.Instance.camera)
        {
            if(mainCamera.enabled)
            {
                secondCamera.enabled = true;
                mainCamera.enabled = false;
                sprintBar.position = new Vector2(725, 390);
                sprintBG.position = new Vector2(725, 390);

            }
            else
            {
                mainCamera.enabled = true;
                secondCamera.enabled = false;
                sprintBar.position = start;
                sprintBG.position = start;
            }
        }

        last = ArduinoControl.Instance.camera;
    }
}
