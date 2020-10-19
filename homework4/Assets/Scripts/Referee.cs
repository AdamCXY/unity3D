using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Referee : MonoBehaviour
{
    // Start is called before the first frame update

    public int check1(Stack<GameObject> LeftPriests, Stack<GameObject> LeftDevils, Stack<GameObject> RightPriests, Stack<GameObject> RightDevils){
        if ((LeftPriests.Count!=0&&LeftDevils.Count > LeftPriests.Count) || (RightDevils.Count > RightPriests.Count&&RightPriests.Count!=0))
        {
            return 1;
        }
        else{
            return 0;
        }
    }

    public int check2(Stack<GameObject> LeftPriests, Stack<GameObject> LeftDevils, Stack<GameObject> RightPriests, Stack<GameObject> RightDevils){
        if (LeftPriests.Count == 3 && LeftDevils.Count == 3)
        {
            return 1;
        }
        else{
            return 0;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
