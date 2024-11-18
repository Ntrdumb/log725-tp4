using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public int noeud = 0;
    public int brancheOui = 0;
    public int brancheNon = 0;
    public bool isHit = false;
    public Sprite currentSprite; 
    public Sprite hurtSprite;    
    public float speed = 2f;
    public float backoffTime = 1f;

    public Transform leftWall;
    public Transform rightWall;
    public Transform initialPosition;
    public Transform playerTransform; 

    private Transform currentTarget;
    private SpriteRenderer spriteRenderer;
    private bool isWaiting = false;
    private float waitTimer = 0f;

    private Node rootNode;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = currentSprite; 
        UpdateRootNode();
    }

    private void Update()
    {
        if (isWaiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= 1f) 
            {
                isWaiting = false;
                waitTimer = 0f;
                spriteRenderer.sprite = currentSprite;
                currentTarget = initialPosition;
            }
            return; 
        }

        UpdateRootNode();

        rootNode?.Evaluate();
    }

    private void UpdateRootNode()
    {
        List<GameObject> bullets = new List<GameObject>(GameObject.FindGameObjectsWithTag("Bullet"));

        if (bullets.Count == 0)
        {
            rootNode = new Selector(new List<Node>
            {
                new Sequence(new List<Node>
                {
                    new MoveToInitialPosition(transform, initialPosition.position)
                })
            });
            return;
        }

        GameObject closestBullet = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject bullet in bullets)
        {
            float distance = Vector2.Distance(transform.position, bullet.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestBullet = bullet;
            }
        }

        rootNode = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckBulletNearby(transform, bullets.ToArray(), 5f),
                new Selector(new List<Node>
                {
                    new Sequence(new List<Node>
                    {
                        new CheckBulletDirection(transform, closestBullet.transform), 
                        new MoveToWall(transform, rightWall.position),
                        new HideBehindWall(this)
                    }),
                    new Sequence(new List<Node>
                    {
                        new InvertNode(new CheckBulletDirection(transform, closestBullet.transform)),
                        new MoveToWall(transform, leftWall.position),
                        new HideBehindWall(this)
                    })
                })
            }),
            new Sequence(new List<Node>
            {
                new MoveToInitialPosition(transform, initialPosition.position)
            })
        });
    }

    public void StartHiding()
    {
        if (isHit)
        {
            spriteRenderer.sprite = hurtSprite;
        }

        isWaiting = true;
    }


    private void MoveTowards(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f && isHit)
        {
            currentTarget = null;
        }
    }
}
