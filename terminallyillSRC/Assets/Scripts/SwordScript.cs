using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public GameObject projectile;
    private bool canFire;

    // Start is called before the first frame update
    void Start()
    {
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && canFire)
        {
                StartCoroutine(WaitForFire());
            canFire = false;
        }
    }

    private void Fire()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }

    IEnumerator WaitForFire()
        {
            Fire();
            yield return new WaitForSeconds(0.25f);
            canFire = true;
            
        }
    

}
