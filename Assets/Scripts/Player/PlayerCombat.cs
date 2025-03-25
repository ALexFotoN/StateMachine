using UnityEngine;
using UnityEngine.Serialization;

public class PlayerCombat : MonoBehaviour
{
    [FormerlySerializedAs("_bulletPrefab")] [SerializeField] private GameObject bulletPrefab;
    [FormerlySerializedAs("_firePoint")] [SerializeField] private Transform firePoint;
    [FormerlySerializedAs("_redZone")] [SerializeField] private GameObject redZone;
    [FormerlySerializedAs("_bulletSpeed")] [SerializeField] private float bulletSpeed = 10f;
    
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FireBullet()
    {
        if (!bulletPrefab || !firePoint) return;
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        var rb = bullet.GetComponent<Rigidbody2D>();
            
        if (!rb)
        {
            rb = bullet.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0;
        }
            
        rb.linearVelocity = firePoint.right * bulletSpeed;
        
        Destroy(bullet, 2f);
    }

    public void ToggleRedZone(bool isActive)
    {
        if (redZone)
        {
            redZone.SetActive(isActive);
        }
    }

    public void SetTransparency(float alpha)
    {
        if (!_spriteRenderer) return;
        var color = _spriteRenderer.color;
        color.a = alpha;
        _spriteRenderer.color = color;
    }

    public void SetColor(Color color)
    {
        if (!_spriteRenderer) return;
        color.a = _spriteRenderer.color.a;
        _spriteRenderer.color = color;
    }
}