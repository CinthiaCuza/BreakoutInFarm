using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplesGenerator : MonoBehaviour
{
    public GameObject apple;
    [SerializeField] public Vector2 offset;
    [SerializeField] public Vector2Int size;

    private void Start()
    {
        Generator();
    }

    public void Generator()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                GameObject _brick = Instantiate(apple, transform);
                _brick.transform.position = transform.position + new Vector3((float)((size.x - 1) * 0.5f - i) * offset.x, (float)((size.y - 1) * 0.5f - j) * offset.y, 0);
            }
        }
    }
}
