using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Projectile : MonoBehaviour
{
    private Transform target;

    public float speed = 1f;

    public void SetTarget(Transform target)
    {
        target = this.target;
    }
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;

        float distance = speed * Time.deltaTime;

        if (dir.magnitude <= distance)
        {
            HitTarget();
        }

        transform.Translate(dir.normalized * distance, Space.World);
    }

    void HitTarget()
    {
        Destroy(gameObject);
    }
}
