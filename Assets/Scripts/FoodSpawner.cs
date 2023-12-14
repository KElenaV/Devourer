using System.Collections;
using System.Linq;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private Food[] _foods;

    private WaitForSeconds _waitForSeconds;
    private float _delay = 0.25f;

    private int _badFoodChance = 2;
    private int _chance = 10;

    private float _xBoard = 8.5f;
    private float _yBoard = 2.5f;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_delay);

        foreach (var food in _foods)
        {
            food.gameObject.SetActive(false);
        }

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            SpawnRandomFood();
            yield return _waitForSeconds;
        }
    }   

    private void SpawnRandomFood()
    {
        bool foodQuality = Random.Range(0, _chance) > _badFoodChance;

        var food = _foods.FirstOrDefault(f => f.gameObject.activeSelf == false && f.IsGood == foodQuality);

        if (food)
        {
            food.gameObject.SetActive(true);
            food.transform.position = new Vector2(Random.Range(-_xBoard, _xBoard), Random.Range(-_yBoard, _yBoard));
        }
    }
}
