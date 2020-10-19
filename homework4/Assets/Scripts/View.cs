using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PriestsAndDevils;

public class View : MonoBehaviour
{
    // Start is called before the first frame update
    SSDirector ssd;
    void Start()
    {
        ssd = SSDirector.GetInstance();
    }
    public void OnGUI()
    {
        if (ssd.state == State.Win)
        {
            if (GUI.Button(new Rect(500, 400, 500, 50), "You Win! (click to restart)"))
            {
                ssd.Restart();
            }
        }
        else if(ssd.state == State.Lose)
        {
            if(GUI.Button(new Rect(500, 400, 500, 50), "You Lose! (click to restart)"))
            {
                ssd.Restart();
            }
        }
        else
        {
            if(GUI.Button(new Rect(620, 200, 50, 50), "Priest"))
            {
                ssd.PriestOn();
            }
            if(GUI.Button(new Rect(720, 200, 50, 50), "Devil"))
            {
                ssd.DevilOn();
            }
            if(GUI.Button(new Rect(590, 100, 50, 50), "Move")){
                ssd.Move();
            }
            if(GUI.Button(new Rect(650, 100, 150, 50), "OFF"))
            {
                ssd.Offleft();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
