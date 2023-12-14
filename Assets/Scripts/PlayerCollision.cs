using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public event UnityAction Eated;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Food food))
        {
            if (food.IsGood)
            {
                Eated?.Invoke();
                food.Destroy();
            }
            else
            {
                food.Destroy();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
