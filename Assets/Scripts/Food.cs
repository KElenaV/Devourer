using System.Collections;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private bool _isGood;

    public bool IsGood => _isGood;

    private void OnEnable()
    {
        StartCoroutine(DeleteFromScene());
    }

    private IEnumerator DeleteFromScene()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy();
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
