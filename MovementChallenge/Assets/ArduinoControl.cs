using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoControl : MonoBehaviour
{
    public static ArduinoControl Instance;

    SerialPort sp = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);

    public float moveX;
    public float moveY;
    public bool camera;
    public float sprint;

    private float lastCam;

    int bytenum = 0;

    void Start()
    {
        Instance = this;

        sp.Open();
        sp.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (sp.IsOpen == true)
        {
            if(sp.BytesToRead > 13)
            {
                try
                {
                    SetValues(sp.ReadLine());

                }
                catch (System.Exception)
                {

                }
            }

        }
    }

    private void SetValues(string line)
    {
        string[] num = line.Split(',');

        for(int i = 0; i < 4; i++)
        {
            if (i == 0)
            {
                moveX = float.Parse(num[0]) / 1000;
            }
            else if (i == 1)
            {
                moveY = float.Parse(num[1]) / 1000;
            }
            else if (i == 2)
            {
                if (int.Parse(num[2]) == 0 && lastCam != 0 && moveX < 0.2 && moveX > -0.2 && moveY < 0.2 && moveY > -0.2)
                {
                    if(camera == false)
                    {
                        camera = true;
                    }
                    else
                    {
                        camera = false;
                    }

                }

                lastCam = int.Parse(num[2]);
            }
            else if (i == 3)
            {
                sprint = float.Parse(num[3]) / 1000;
            }
        }
    }
}
