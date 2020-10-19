using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCActionManager : SSActionManager, ISSActionCallback
{
    public void moveBoat(GameObject boat,int type){
        if(type == 1){
            Vector3 target = new Vector3(3, 0, 10);
            CCMoveToAction action=CCMoveToAction.GetSSAction(target, 3f);
            this.RunAction(boat, action, this);
        }
        else if(type == 0){
            Vector3 target = new Vector3(-3, 0, 10);
            CCMoveToAction action=CCMoveToAction.GetSSAction(target, 3f);
            this.RunAction(boat, action, this);
        }
    }

    public void moveMan(GameObject man,int type,int i){
        if(type==1){
            Vector3 target = new Vector3(-3 + i*0.6f, 0.8f, 10);
            CCMoveToAction action=CCMoveToAction.GetSSAction(target, 3f);
            this.RunAction(man, action, this);
        }
        else if(type==0){
            Vector3 target = new Vector3(3 + i*0.6f, 0.8f, 10);
            CCMoveToAction action=CCMoveToAction.GetSSAction(target, 3f);
            this.RunAction(man, action, this);
        }
    }

    public void onBoat(GameObject man,int type,int i){
            if(type==1){
                Vector3 target1 = man.transform.position + new Vector3(0, 1 ,0);
                CCMoveToAction action1=CCMoveToAction.GetSSAction(target1, 10f);
                Vector3 target2 = new Vector3(3, 0.8f, 10) + new Vector3(0.6f * (0 - i), 0, 0);
                CCMoveToAction action2=CCMoveToAction.GetSSAction(target2, 10f);
                List<SSAction> sequence = new List<SSAction>();
                sequence.Add(action1);
                sequence.Add(action2);
                CCSequenceAction ssaction = CCSequenceAction.GetSSAction(0, sequence);
                this.RunAction(man, ssaction, this);

            } else if (type==0) {
Vector3 target1 = man.transform.position + new Vector3(0, 1 ,0);
                CCMoveToAction action1=CCMoveToAction.GetSSAction(target1, 10f);
                Vector3 target2 = new Vector3(-3, 0.8f, 10) + new Vector3(0.6f * (0 + i), 0, 0);
                CCMoveToAction action2=CCMoveToAction.GetSSAction(target2, 10f);
                List<SSAction> sequence = new List<SSAction>();
                sequence.Add(action1);
                sequence.Add(action2);
                CCSequenceAction ssaction = CCSequenceAction.GetSSAction(0, sequence);
                this.RunAction(man, ssaction, this);
            }
    }

    public void offBoat(GameObject man, int type,int i,int type2){
            if(type==1){
                Vector3 target1 = man.transform.position + new Vector3(0, 1 ,0);
                CCMoveToAction action1=CCMoveToAction.GetSSAction(target1, 5f);
                Vector3 target2 = new Vector3(0, 0, 0);
                if(type2==0){
                    target2 += new Vector3(-4.6f, 0.8f, 10) + new Vector3(0.6f * (0 - i), 0, 0);
                } else if(type2==1){
                    target2 += new Vector3(-6, 0.8f, 10) + new Vector3(0.6f * (0 - i), 0, 0);
                }
                CCMoveToAction action2=CCMoveToAction.GetSSAction(target2, 5f);
                List<SSAction> sequence = new List<SSAction>();
                sequence.Add(action1);
                sequence.Add(action2);
                CCSequenceAction ssaction = CCSequenceAction.GetSSAction(0, sequence);
                this.RunAction(man, ssaction, this);
            } else if(type==0){
                Vector3 target1 = man.transform.position + new Vector3(0, 1 ,0);
                CCMoveToAction action1=CCMoveToAction.GetSSAction(target1, 5f);
                Vector3 target2 = new Vector3(0, 0, 0);
                if(type2==0){
                    target2 += new Vector3(4.6f, 0.8f, 10) + new Vector3(0.6f * (0 + i), 0, 0);
                } else if(type2==1){
                    target2 += new Vector3(6, 0.8f, 10) + new Vector3(0.6f * (0 + i), 0, 0);
                }
                CCMoveToAction action2=CCMoveToAction.GetSSAction(target2, 5f);
                List<SSAction> sequence = new List<SSAction>();
                sequence.Add(action1);
                sequence.Add(action2);
                CCSequenceAction ssaction = CCSequenceAction.GetSSAction(0, sequence);
                this.RunAction(man, ssaction, this);
            }
    }

    public void SSActionEvent(SSAction source,SSActionEventType events = SSActionEventType.Completed,
        int intParam = 0,
        string strParam = null,
        Object objectParam = null) {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("update!");
        base.Update();
    }
}
