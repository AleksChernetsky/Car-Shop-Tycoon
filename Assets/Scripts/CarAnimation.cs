using UnityEngine;

public class CarAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void GetCar() => _animator.Play("Base Layer.GetCar");
    public void DriveAway() => _animator.Play("Base Layer.DriveAway");
}
