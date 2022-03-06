using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Projectile : MonoBehaviour
{
    private Transform target;

    public float speed = 1f;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = (target.position + new Vector3(0, 0.6f, 0)) - transform.position;
        float distance = speed * Time.deltaTime;

        if (dir.magnitude <= distance)
        {
            HitTarget();
        }

        transform.Translate(dir.normalized * distance, Space.World);
    }

    void HitTarget()
    {
        target.GetComponent<Enemy>().TakeDamage(25f);
        Destroy(gameObject);
    }
}
