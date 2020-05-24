
using UnityEngine;
using UnityEngine.SceneManagement;


public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactforce = 60f;
    private AudioSource mAudiosrc;
    public Camera fpsCamera;

    public GameObject impact;
    public ParticleSystem muzzlFlash;


  

    // Update is called once per frame
    void Update()
    {    

        if (Input.GetButtonDown("Fire1"))
        {
            soundManager.PlaySound("Shot_01");
            Shoot();
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        void Shoot()
        {
            muzzlFlash.Play();
            RaycastHit hit;
            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                Target target = hit.transform.GetComponent<Target>();

                if (target != null)
                {
                    target.TakeDamage(damage);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactforce);
                }

                GameObject impactobject = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactobject, 0.5f);

            }

        }

    }
}
