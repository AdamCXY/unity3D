using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PriestsAndDevils;

public class Model : MonoBehaviour
{

    CCActionManager manager1;
    Referee referee1;

    Stack<GameObject> RightPriests = new Stack<GameObject>();
    Stack<GameObject> RightDevils = new Stack<GameObject>();
    Stack<GameObject> LeftPriests = new Stack<GameObject>();
    Stack<GameObject> LeftDevils = new Stack<GameObject>();
    Stack<GameObject> Boat = new Stack<GameObject>();
    SSDirector ssd;
    GameObject Boat_obj;
    // Start is called before the first frame update
    void Start()
    {
        ssd = SSDirector.GetInstance();
        ssd.SetModel(this);
        manager1 = GetComponent<CCActionManager>() as CCActionManager;
        referee1 = GetComponent<Referee>() as Referee;
        Build();
        Correct(RightPriests, new Vector3(4.6f, 0.8f, 10));
        Correct(RightDevils, new Vector3(6.2f, 0.8f, 10));
        Correct(LeftPriests, new Vector3(-5.6f, 0.8f, 10));
        Correct(LeftDevils, new Vector3(-7.6f, 0.8f, 10));
    }

    // Update is called once per frame
    void Update()
    {
        if (referee1.check2(LeftPriests, LeftDevils, RightPriests, RightDevils) == 1){
            ssd.state = State.Win;
        }
        if (ssd.state != State.RightToLeft && ssd.state != State.LeftToRight)
        {
            if (ssd.state == State.StopAtRight)
            {
            }
            if (ssd.state == State.StopAtLeft)
            {
            }
        }
        if (ssd.state == State.RightToLeft)
        {
            manager1.moveBoat(Boat_obj, 0);

            for(int i = 0; i < Boat.Count; i++)
            {
                manager1.moveMan(Boat.ToArray()[i], 1, i);

            }
            if(Boat_obj.transform.position==new Vector3(-3, 0, 10))
            {
                ssd.state = State.StopAtLeft;
                if (referee1.check1(LeftPriests, LeftDevils, RightPriests, RightDevils) == 1){
                    ssd.state = State.Lose;
                }
            }
        }
        else if (ssd.state == State.LeftToRight)
        {
            manager1.moveBoat(Boat_obj, 1);
            for (int i = 0; i < Boat.Count; i++)
            {
                manager1.moveMan(Boat.ToArray()[i], 0, i);
            }
            if (Boat_obj.transform.position == new Vector3(3, 0, 10))
            {
                ssd.state = State.StopAtRight;
                if (referee1.check1(LeftPriests, LeftDevils, RightPriests, RightDevils) == 1){
                    ssd.state = State.Lose;
                }
            }
        }
    }
    void Build()
    {
        Instantiate(Resources.Load("Prefabs/Bank"), new Vector3(6, 0, 10), Quaternion.identity);
        Instantiate(Resources.Load("Prefabs/Bank"), new Vector3(-6, 0, 10), Quaternion.identity);

        Boat_obj = Instantiate(Resources.Load("Prefabs/Boat"), new Vector3(3, 0, 10), Quaternion.identity) as GameObject;

        for (int i = 0; i < 3; i++)
        {
            RightPriests.Push(Instantiate(Resources.Load("Prefabs/Priest")) as GameObject);
            RightDevils.Push(Instantiate(Resources.Load("Prefabs/Devil")) as GameObject);
        }
    }
    void Correct(Stack<GameObject> gos,Vector3 pos)  
    {
        for(int i = gos.Count - 1; i >= 0; i--)
        {
            gos.ToArray()[i].transform.position = pos + new Vector3(0.6f * (gos.Count - 1 - i), 0, 0);
        }
    }
    public void PriestOn()
    {
        if (ssd.state == State.StopAtRight)
        {
            if (RightPriests.Count != 0 && Boat.Count < 2)
            {
                GameObject man=RightPriests.Pop();
                manager1.onBoat(man, 1, Boat.Count);
                Boat.Push(man);
                Debug.Log(Boat.Count);
            }
        }
        else if(ssd.state == State.StopAtLeft)
        {
            if (LeftPriests.Count != 0 && Boat.Count < 2)
            {
                GameObject man=LeftPriests.Pop();
                manager1.onBoat(man, 0, Boat.Count);
                Boat.Push(man);
                Debug.Log(Boat.Count);
            }
        }
    }
    public void DevilOn()
    {
        if (ssd.state == State.StopAtRight)
        {
            if (RightDevils.Count != 0 && Boat.Count < 2)
            {
                GameObject man=RightDevils.Pop();
                manager1.onBoat(man, 1, Boat.Count);
                Boat.Push(man);
                Debug.Log(Boat.Count);
            }
        }
        else if (ssd.state == State.StopAtLeft)
        {
            if (LeftDevils.Count != 0 && Boat.Count < 2)
            {
                GameObject man=LeftDevils.Pop();
                manager1.onBoat(man, 0, Boat.Count);
                Boat.Push(man);
                Debug.Log(Boat.Count);
            }
        }
    }
    public void Move()
    {
        if (ssd.state == State.StopAtRight && Boat.Count != 0)
        {
            ssd.state = State.RightToLeft;
        }
        if (ssd.state == State.StopAtLeft && Boat.Count != 0)
        {
            Debug.Log("left to right.");
            ssd.state = State.LeftToRight;
        }
    }
    public void Check()
    {
        if ((LeftPriests.Count!=0&&LeftDevils.Count > LeftPriests.Count) || (RightDevils.Count > RightPriests.Count&&RightPriests.Count!=0))
        {
            ssd.state = State.Lose;
        }
        else if (LeftPriests.Count == 3 && LeftDevils.Count == 3)
        {
            ssd.state = State.Win;
        }
    }
    public void Restart()
    {
        ssd.state = State.StopAtRight;
        while (Boat.Count != 0)
        {
            GameObject t = Boat.Pop();
            Debug.Log(t.name);
            if (t.name == "Priest(Clone)")
            {
                RightPriests.Push(t);
            }
            else if (t.name == "Devil(Clone)")
            {
                RightDevils.Push(t);
            }
        }
        while (LeftPriests.Count != 0)
        {
            RightPriests.Push(LeftPriests.Pop());
        }
        while (LeftDevils.Count != 0)
        {
            RightDevils.Push(LeftDevils.Pop());
        }
        Boat_obj.transform.position = new Vector3(3, 0, 10);
        Correct(RightPriests, new Vector3(4.6f, 0.8f, 10));
        Correct(RightDevils, new Vector3(6.2f, 0.8f, 10));
        Correct(LeftPriests, new Vector3(-5.6f, 0.8f, 10));
        Correct(LeftDevils, new Vector3(-7.6f, 0.8f, 10));

    }
    public void Offleft()
    {
        
        if(Boat.Count >= 1){
            GameObject t1=Boat.Pop();
            Debug.Log("20140303");
            if (t1.name == "Devil(Clone)")
            {
                if (ssd.state == State.StopAtRight)
                {
                    manager1.offBoat(t1, 0, RightDevils.Count, 1);
                    RightDevils.Push(t1);
                }
                else
                {
                    Debug.Log("20140101");
                    manager1.offBoat(t1, 1, LeftDevils.Count, 1);
                    LeftDevils.Push(t1);
                }
            }
            if (t1.name == "Priest(Clone)")
            {
                if (ssd.state == State.StopAtRight)
                {
                    manager1.offBoat(t1, 0, RightPriests.Count, 0);
                    RightPriests.Push(t1);
                }
                else
                {
                    Debug.Log("20140202");
                    manager1.offBoat(t1, 1, LeftPriests.Count, 0);
                    LeftPriests.Push(t1);
                }
            }
            Debug.Log(Boat.Count);
        }      
    }
    public void Offright()
    {
    }
}
