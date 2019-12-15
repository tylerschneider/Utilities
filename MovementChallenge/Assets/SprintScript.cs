using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class SprintScript : MonoBehaviour
{
    public Image sprintBar;
    public Image sprintBG;

    private float sprintSpeed = 1.4f;
    public float maxSprint = 100f;
    public float sprintRegen = 2f;
    public float sprintRegenTime = 2f;
    public float sprintDepletion = 4f;
    public float hideSprintTime = 5f;
    public float hideTime = 0f;
    public float fadeSpeed = 2f;
    public string sprinting = "no";
    public float waitTime = 0f;
    public float currentSprint;

    private void Awake()
    {
        currentSprint = maxSprint;
    }
    void Update()
    {
        sprintSpeed = ArduinoControl.Instance.sprint + 1;

        sprintBar.fillAmount = currentSprint / maxSprint;
        if(sprintBar.fillAmount == 1)
        {
            hideTime += Time.deltaTime;
            if(hideTime > hideSprintTime)
            {
                Color c = sprintBar.color;
                c.a -= fadeSpeed;
                sprintBar.color = c;

                sprintBG.enabled = false;
            }
        }
        else
        {
            hideTime = 0;

            Color c = sprintBar.color;
            c.a = 1;
            sprintBar.color = c;

            sprintBG.enabled = true;
        }

        if(/*Input.GetKeyDown("left shift")*/ sprintSpeed > 1.1 && sprintBar.fillAmount != 0)
        {
            Player.Instance.speed = Player.Instance.startSpeed * sprintSpeed;
            sprinting = "yes";
        }
        if (/*Input.GetKeyUp("left shift")*/ sprintSpeed < 1.1 && sprinting == "yes")
        {
            Player.Instance.speed = Player.Instance.startSpeed; //sprintSpeed;
            sprinting = "wait";
            waitTime = 0f;
        }
        
        if(sprinting == "no")
        {
            if(currentSprint < maxSprint)
            {
                currentSprint += sprintRegen;

                if(currentSprint > maxSprint)
                {
                    currentSprint = maxSprint;
                }
            }
        }
        else if(sprinting == "yes")
        {
            currentSprint -= ArduinoControl.Instance.sprint; //sprintDepletion;
            if (currentSprint <= 0)
            {
                currentSprint = 0;
                Player.Instance.speed /= sprintSpeed;
                sprinting = "wait";
                waitTime = 0f;
            }
        }
        else if(sprinting == "wait")
        {
            waitTime += Time.deltaTime;
            if(waitTime >= sprintRegenTime)
            {
                sprinting = "no";
            }
        }
    }
}
