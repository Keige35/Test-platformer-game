using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCell : MonoBehaviour
{
   [SerializeField] private List<Material> colorMaterials = new List<Material>();
   [SerializeField] private float bombCellDamage = 20f;
   private bool isBombReady = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (isBombReady)
        {
            if (collision.gameObject.GetComponent<IDamagable>() != null)
            {
                isBombReady = false;
                GetComponent<MeshRenderer>().material = colorMaterials[1];
                StartCoroutine(BombCellLogic());
            }
        }
    }
    IEnumerator BombCellLogic()
    {
        yield return new WaitForSeconds(1);
        GetComponent<MeshRenderer>().material = colorMaterials[2];
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale, Quaternion.identity);
        if(hitColliders != null && hitColliders.Length > 0)
        {
            foreach(Collider collider in hitColliders)
            {
                Debug.Log(collider.name);
                if(collider.gameObject.GetComponentInParent<IDamagable>()  != null)
                {
                    collider.gameObject.GetComponentInParent<IDamagable>().TakeDamage(bombCellDamage);
                }
            }
        }
        yield return new WaitForSeconds(0.2f);
        GetComponent<MeshRenderer>().material = colorMaterials[0];
        yield return new WaitForSeconds(4.8f);
        isBombReady = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; 
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

}
