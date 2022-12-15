using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : MonoBehaviour
{
    public List<GameObject> lampList = new List<GameObject>();





    public void ReorderTheLine(GameObject lamp)
    {
        lampList.Add(lamp);
        for (int i = 0; i < lampList.Count; i++)
        {
            if (i == 0)
            {
                //lampList[i].transform.position = gameObject.transform.position + Vector3.forward * 2;
               
                lampList[i].gameObject.GetComponent<LampController>().lampFollowTarget = gameObject.transform;
                lampList[i].gameObject.tag = "HasTargetLamp";
            }
            else
            {
               // lampList[i].transform.position = lampList[i-1].gameObject.transform.position + Vector3.forward * 2;
                lampList[i].gameObject.GetComponent<LampController>().lampFollowTarget = lampList[i-1].gameObject.transform;
                lampList[i].gameObject.tag = "HasTargetLamp";
            }
        }
    }


}
