using System.Collections;

using UnityEngine;

public class GarageDoor : MonoBehaviour
{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void OpenDoor() => _animator.Play("Base Layer.OpenDoor");
    public void CloseDoor() => _animator.Play("Base Layer.CloseDoor");
}
