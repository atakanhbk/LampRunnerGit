using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackController : MonoBehaviour
{
    public List<GameObject> lampList = new List<GameObject>();
    public bool canClearList = false;

    public float waveLengthSize;

    Vector3 lampOriginialSize;

    bool justTakeSizeOneTime = true;


    public void ReorderTheLine(GameObject lamp)
    {
       

        lampList.Add(lamp);

        

        if (justTakeSizeOneTime)
        {
            lampOriginialSize = lamp.transform.localScale;
            justTakeSizeOneTime = false;
        }
        
        for (int i = 0; i < lampList.Count; i++)
        {
            if (i == 0)
            {
                //lampList[i].transform.position = gameObject.transform.position + Vector3.forward * 2;
               
                lampList[i].gameObject.GetComponent<LampController>().lampFollowTarget = gameObject.transform;
                lampList[i].gameObject.GetComponent<LampController>().lineNumber = i;
                lampList[i].gameObject.tag = "HasTargetLamp";
            }
            else
            {
               // lampList[i].transform.position = lampList[i-1].gameObject.transform.position + Vector3.forward * 2;

                lampList[i].gameObject.GetComponent<LampController>().lampFollowTarget = lampList[i-1].gameObject.transform;
                lampList[i].gameObject.GetComponent<LampController>().lineNumber = i;
                lampList[i].gameObject.tag = "HasTargetLamp";
            }
            lampList[0].gameObject.GetComponent<LampController>().lampFollowTarget = gameObject.transform;
        }

        StartCoroutine(WaveEffect());
    }

  

    public void LineBreak(GameObject killLamp,int destroyLineNumber)
    {
   

        for (int i = destroyLineNumber; i < lampList.Count; i++)
        {
          //  lampList[i].transform.DOMove(lampList[i].transform.position + Vector3.forward * 2 * i, 0.5f);
            lampList[i].gameObject.GetComponent<LampController>().lampFollowTarget = null;
            lampList[i].gameObject.tag = "Lamp";
            ThrowLampsRandomPosition(lampList[i]);

        }

        Destroy(killLamp);
  
        canClearList = true;
      

    }

    public void ThrowLampsRandomPosition(GameObject randomLamp) {

        Vector3 randomPosition = new Vector3(Random.Range(-4,4),randomLamp.transform.position.y, Random.Range(randomLamp.transform.position.z + 20, randomLamp.transform.position.z + 30));
        randomLamp.transform.DOJump(randomPosition,3f,2, 1f);
        Debug.Log(randomPosition);
    }

    IEnumerator WaveEffect()
    {

        for (int i = 1; i < lampList.Count + 1; i++)
        {
            
            var lastCup = lampList[lampList.Count - i];
            lastCup.transform.DOScale(new Vector3(lastCup.transform.localScale.x + waveLengthSize, lastCup.transform.localScale.y + waveLengthSize, lastCup.transform.localScale.z + waveLengthSize), 0.125f);
            yield return new WaitForSeconds(0.1f);
            lastCup.transform.DOScale(lampOriginialSize, 0.125f);

          
        }
 

    }
    

  

    private void Update()
    {
        if (canClearList)
        {
            for (var i = lampList.Count - 1; i > -1; i--)
            {
                if (lampList[i] == null)
                    lampList.RemoveAt(i);
            }

            canClearList = false;
        }


        for (int a = 0; a < lampList.Count; a++)
        {
            if (lampList[a].gameObject.tag == "Lamp")
            {
                lampList.Remove(lampList[a].gameObject);
            }
        }
    }

}
