using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public Vector3 respawnPosition;
    public GameObject deathText;
    void Start()
    {
        HideDeathText();
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x - Input.GetAxis("Vertical") * speed * Time.deltaTime, transform.position.y, transform.position.z - Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x - Input.GetAxis("Horizontal") * speed * Time.deltaTime, transform.position.y, transform.position.z + Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Water"))
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        transform.position = respawnPosition;
        ShowDeathText();
        Invoke("HideDeathText", 0.8f);
    }

    private void ShowDeathText()
    {
        deathText.SetActive(true);
    }

    private void HideDeathText()
    {
        deathText.SetActive(false);
    }
}
