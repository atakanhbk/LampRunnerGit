using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    public Transform lampFollowTarget;

    public GameObject player;

    public float slerpSpeed;
    public float distanceBetweenLamps;

    public int lineNumber;

    private void FixedUpdate()
    {
        if (lampFollowTarget != null)
        {
            transform.position = new Vector3(
          Mathf.Lerp(transform.position.x, lampFollowTarget.position.x, Time.deltaTime * slerpSpeed),
          lampFollowTarget.position.y,
          lampFollowTarget.position.z + distanceBetweenLamps
          );
        }
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Player")
        {
            player = collision.gameObject;
            collision.gameObject.GetComponent<StackController>().ReorderTheLine(gameObject);
        }

        if (collision.gameObject.tag == "HasTargetLamp" && gameObject.tag != "HasTargetLamp")
        {
            player = collision.gameObject.GetComponent<LampController>().player;
            collision.gameObject.GetComponent<LampController>().player.GetComponent<StackController>().ReorderTheLine(gameObject);
        }

        if (collision.gameObject.tag == "Wall")
        {
       
           player.GetComponent<StackController>().LineBreak(gameObject,lineNumber);
          //  player.GetComponent<StackController>().ClearMissingObjectsFromList(gameObject);

        }
    }






}
