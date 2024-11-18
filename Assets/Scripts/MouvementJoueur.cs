using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MouvementJoueur : MonoBehaviour
{
    [SerializeField] private float _vitesse = 25f;

    private Vector2 _mouvement;
    private Rigidbody2D _rigidBodyJoueur;

    public GameObject _bullet;
    private bool _shootCooldown = false;

    public static List<GameObject> ActiveBullets = new List<GameObject>();

    private void Start()
    {
        _rigidBodyJoueur = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _mouvement = new Vector2(Input.GetAxis("Horizontal"), 0);
        if (Input.GetKey(KeyCode.Space) && !_shootCooldown)
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        _rigidBodyJoueur.AddForce(_mouvement * (_vitesse * 10f));
    }

    private void Shoot()
    {
        StartCoroutine(ShootCooldown());
        var _bulletPrefab = Instantiate(_bullet, transform.position, Quaternion.identity);
        _bulletPrefab.tag = "Bullet";
        _bulletPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);

        ActiveBullets.Add(_bulletPrefab);

        Destroy(_bulletPrefab, 2f);
    }

    private IEnumerator ShootCooldown()
    {
        _shootCooldown = true;
        yield return new WaitForSeconds(0.5f);
        _shootCooldown = false;
    }
}
