using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public GameObject[] target;
    // Update is called once per frame
    void Update()
    {
        LoadScoreMenue();
        CheckEnemies();
    }

    public void LoadScoreMenue()
    {
        foreach (GameObject enemy in target)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance <= 1)
            {
                SceneManager.LoadScene(2);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
        
    }
    public void CheckEnemies()
    {
        foreach (GameObject enemy in target)
        {
            if (enemy==null)
            {
                SceneManager.LoadScene(2);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
