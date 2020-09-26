using UnityEngine;

public class SoaringPresenter : MonoBehaviour
{
    [SerializeField, Range(0, float.MaxValue)]
    public float _soarSpeed;

    private void Update() => transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * _soarSpeed, transform.position.z);
}
