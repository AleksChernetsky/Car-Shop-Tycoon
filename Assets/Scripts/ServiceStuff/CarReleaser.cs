using System.Collections;

using UnityEngine;

public class CarReleaser : ServiceStaffHandler
{
    [SerializeField] private CarReleaserButton _takeCarButton;
    [SerializeField] private GarageDoor _garageDoor;
    [SerializeField] private Transform _carPrefabSpawnPoint;

    private GameObject _carPrefab;
    private CarAnimation _carAnimation;

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        _carPrefab = Instantiate(_buyer.BoughtCarPrefab, _carPrefabSpawnPoint);
        _carPrefab.SetActive(true);
        _carAnimation = _carPrefab.GetComponent<CarAnimation>();

        _garageDoor.OpenDoor();

        _takeCarButton.OnClickEvent += GiveCar;
        _takeCarButton.gameObject.SetActive(true);

        StartCoroutine(CarRelease());
    }

    private void GiveCar()
    {
        _buyer.TookCar = true;
        _carAnimation.DriveAway();
        _buyer.gameObject.SetActive(false);
    }

    private IEnumerator CarRelease()
    {
        yield return new WaitForSeconds(0.25f);
        _carAnimation.GetCar();

        yield return new WaitForSeconds(0.5f);
        _garageDoor.CloseDoor();

        yield return new WaitUntil(() => _buyer.TookCar);
        yield return new WaitForSeconds(3f);

        Destroy(_carPrefab);
        _buyer.ResetCharacter();
        _buyer.gameObject.SetActive(true);
    }
}