using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplesGenerator : MonoBehaviour
{
    [SerializeField] private Vector2 offset;
    [SerializeField] private Vector2Int size;
    [SerializeField] private float appleScale;

    public List<Vector2Int> badApplesPos = new List<Vector2Int>();

    private void Start()
    {
        GameController.instance.applesAmount += size.x * size.y;
        Generator();
    }

    public void Generator()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                GameObject _apple = Instantiate(GameController.instance.apple, transform);
                _apple.transform.localScale = new Vector2(appleScale, appleScale);
                _apple.transform.position = transform.position + new Vector3((float)((size.x - 1) * 0.5f - i) * offset.x, (float)((size.y - 1) * 0.5f - j) * offset.y, 0);

                if (badApplesPos.Contains(new Vector2Int(i, j)))
                {
                    _apple.gameObject.GetComponent<SpriteRenderer>().sprite = GameController.instance.badAppleSprite;
                    _apple.transform.tag = "BadApple";
                }
            }
        }
    }
}
