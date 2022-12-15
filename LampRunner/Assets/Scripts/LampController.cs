using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    public Transform lampFollowTarget;
    public GameObject player;
    public float slerpSpeed;

    private void FixedUpdate()
    {
        if (lampFollowTarget != null)
        {
            transform.position = new Vector3(
          Mathf.Lerp(transform.position.x, lampFollowTarget.position.x, Time.deltaTime * 10),
          lampFollowTarget.position.y,
          lampFollowTarget.position.z + 2
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

        if (collision.gameObject.tag == "HasTargetLamp")
        {
            player = collision.gameObject.GetComponent<LampController>().player;
            collision.gameObject.GetComponent<LampController>().player.GetComponent<StackController>().ReorderTheLine(gameObject);
        }
    }




}
