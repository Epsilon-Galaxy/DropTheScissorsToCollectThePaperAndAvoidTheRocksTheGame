using UnityEngine;

public class PaperBehavior : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            RandomGenManager.Instance.GeneratePapers();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            RandomGenManager.Instance.GeneratePapers();
        }
    }
}
