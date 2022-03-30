using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Projectile : MonoBehaviour
{
    private Transform target;

    public float speed = 1f;
    public float damage;

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
        transform.LookAt(target);
        //transform.rotation = Quaternion.Euler(0,transform.rotation.y,transform.rotation.z);
    }

    void HitTarget()
    {
        target.GetComponent<Enemy>().TakeDamage(damage);
        ObjectPooler.Instance.poolDictionary[tag].Release(gameObject);
        //Destroy(gameObject);
    }
}
