using System.Collections;
using UnityEngine;

public class Frogger : MonoBehaviour
{
    private int row = 1;
    private SpriteRenderer spriteRenderer;
    private bool sideFacing;

    [SerializeField] private Sprite forwardFrog;
    [SerializeField] private Sprite forwardFrogJump;
    [SerializeField] private Sprite sideFrogJump;
    [SerializeField] private Sprite sideFrog;
    [SerializeField] private Sprite deadFrog;
    [SerializeField] private GameObject youdied;

    private void Awake()
    {
        youdied.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
        sideFacing = false;
    }

    private void Update()
    {
        if (row < 12)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                sideFacing = false;
                spriteRenderer.sprite = forwardFrog;
                row++;
                float yPosition = GetYPosition(row);
                Vector3 newPosition = new Vector3(0, yPosition, 0);
                Move(newPosition);
            }

            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                sideFacing = true;
                spriteRenderer.sprite = sideFrog;
                spriteRenderer.flipX = false;
                Move(Vector3.left);
            }

            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                sideFacing = true;
                spriteRenderer.sprite = sideFrog;
                spriteRenderer.flipX = true;
                Move(Vector3.right);
            }
        }
    }

    private void Move(Vector3 direction)
    {
        Vector3 endPosition = transform.position + direction;

        Collider2D barrier = Physics2D.OverlapBox(endPosition, Vector2.zero, 0f, LayerMask.GetMask("Barrier"));
        Collider2D platform = Physics2D.OverlapBox(endPosition, Vector2.zero, 0f, LayerMask.GetMask("Platform"));
        Collider2D obstacle = Physics2D.OverlapBox(endPosition, Vector2.zero, 0f, LayerMask.GetMask("Obstacle"));

        if (barrier != null)
        {
            return;
        }

        if (platform != null)
        {
            transform.SetParent(platform.transform);
        } else
        {
            transform.SetParent(null);
        }

        if (obstacle != null && platform == null)
        {
            transform.position = endPosition;
            GameOver();
        } else
        {
            StartCoroutine(Jump(endPosition));
        }

    }

    private IEnumerator Jump(Vector3 endPosition)
    {
        Vector3 currentPosition = transform.position;
        Sprite prevSprite = spriteRenderer.sprite;
        Sprite jumpSprite = forwardFrogJump;

        if (sideFacing) jumpSprite = sideFrogJump;
        float timeTaken = 0f;
        float duration = 0.125f;

        spriteRenderer.sprite = jumpSprite;

        while (timeTaken < duration)
        {
            float t = timeTaken / duration;
            transform.position = Vector3.Lerp(currentPosition, endPosition, t);
            timeTaken += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition;
        spriteRenderer.sprite = prevSprite;
    }

    private float GetYPosition(int row)
    {
        float newYPosition = 1.125f;

        switch (row)
        {
            case 2:
                newYPosition = 1.125f;
                break;
            case 3:
                newYPosition = 1.5f;
                break;
            case 4:
                newYPosition = 1f;
                break;
            case 5:
                newYPosition = 1.25f;
                break;
            case 6:
                newYPosition = 1f;
                break;
            case 7:
                newYPosition = 1f;
                break;
            case 8:
                newYPosition = 0.75f;
                break;
            case 9:
                newYPosition = 1.25f;
                break;
            case 10:
                newYPosition = 1f;
                break;
            case 11:
                newYPosition = 1.25f;
                break;
        }

        return newYPosition;
    }

    private void GameOver()
    {
        youdied.SetActive(true);
        enabled = false;
        spriteRenderer.sprite = deadFrog;
        transform.position = new Vector3(0, 2, 0);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (enabled && other.gameObject.layer == LayerMask.NameToLayer("Obstacle") && transform.parent == null)
        {
            GameOver();
        }
    }
}
