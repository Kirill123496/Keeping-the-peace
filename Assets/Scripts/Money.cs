using UnityEngine;
public class Money : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Прикосновение");
        }
    }

}