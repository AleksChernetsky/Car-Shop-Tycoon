using System;
using System.Collections;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class StaffButtonsHandler : MonoBehaviour, IPointerDownHandler
{
    protected Image _image;

    protected float _maxProgress = 100;
    protected float _currentProgress = 0;
    protected float _progressPercentage;
    protected float _progressRate = 1f;

    protected Coroutine _progressView;

    public event Action OnClickEvent;

    protected void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = _currentProgress;
        _image.color = Color.red;
    }

    protected void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            if (_progressView != null)
            {
                StopCoroutine(_progressView);
            }
            _progressView = StartCoroutine(ProgressView());
        }
    }
    protected IEnumerator ProgressView()
    {
        while (_currentProgress < _maxProgress)
        {
            _currentProgress += _progressRate;
            _progressPercentage = _currentProgress / _maxProgress;

            _image.fillAmount = _progressPercentage;

            yield return new WaitForSeconds(_progressRate);
        }
        _image.color = Color.green;
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnClickEvent?.Invoke();
        gameObject.SetActive(false);
        _currentProgress = 0;
        _image.color = Color.red;
    }
}
