using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZone : MonoBehaviour
{
    private Transform rotationObject;
    [SerializeField] private List<Vector3> gameObjectDirection = new List<Vector3>() {new Vector3( 0,0,0), new Vector3(0,90,0),new Vector3(0,180,0),new Vector3(0,270,0)};
    [SerializeField] private List<Vector3> windDirection = new List<Vector3>() { new Vector3(90, 0, 0), new Vector3(0, 0, -90), new Vector3(-90, 0, 0), new Vector3(0, 0, 90)};
    [SerializeField ]private float windForce = 1000f;
    private int randomNumber;

    private void Start()
    {
        rotationObject = gameObject.GetComponentInParent<Transform>();
       
        StartCoroutine(WindDirectionCoroutine());
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IWindy>() != null)
        {         
            other.GetComponent<IWindy>().Wind(windDirection[randomNumber]);
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<IWindy>() != null)
        {
            other.GetComponent<IWindy>().Wind(new Vector3(0,0,0));
        }
    }
    IEnumerator WindDirectionCoroutine()
    {
        while (true)
        {
            randomNumber = Random.Range(0, windDirection.Count);
            rotationObject.transform.rotation= Quaternion.Euler(gameObjectDirection[randomNumber]);
            rotationObject.GetComponent<BoxCollider>().enabled = false;
            rotationObject.GetComponent<BoxCollider>().enabled = true;
            yield return new WaitForSeconds(2f);
        }
    }
   
}
