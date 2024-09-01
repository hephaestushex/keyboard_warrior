using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SwordScript : MonoBehaviour
{
    public GameObject projectile;
    private bool canFire;
    public int bulletCount = 100;

    [SerializeField] TextMeshProUGUI bulletText;

    // Start is called before the first frame update
    void Start()
    {
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && canFire && bulletCount > 0)
        {
                StartCoroutine(WaitForFire());
            canFire = false;
            bulletCount--;
        }

        bulletText.text = "Attacks remaining: " + bulletCount;
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
