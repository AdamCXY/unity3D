using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PriestsAndDevils;

namespace PriestsAndDevils
{
    public enum State { LeftToRight,RightToLeft,StopAtLeft,StopAtRight,Win,Lose};

    public class SSDirector : System.Object
    {
        private static SSDirector _instance;
        public State state;
        private Model model;

        public static SSDirector GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SSDirector();
                _instance.state = State.StopAtRight;
            }
            return _instance;
        }
        public Model GetModel()
        {
            return model;
        }
        public void SetModel(Model m)
        {
            model = m;
        }
        public void PriestOn()
        {
            model.PriestOn();
        }
        public void Move()
        {
            model.Move();
        }
        public void Restart()
        {
            model.Restart();
        }
        public void DevilOn()
        {
            model.DevilOn();
        }
        public void Offleft()
        {
            model.Offleft();
        }
        public void Offright()
        {
            model.Offright();
        }
    }
}

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SSDirector.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
