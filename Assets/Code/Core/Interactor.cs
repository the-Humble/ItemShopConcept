using System;
using System.Collections;
using System.Collections.Generic;
using Code.Core;
using UnityEngine;

[RequireComponent(typeof(ColliderCallbacks))]
public class Interactor : MonoBehaviour
{
    [SerializeField] private LayerMask _interactableMask;

    private ColliderCallbacks _colliderCallbacks;

    private IInteractable _currentInteractable;

    private void Awake()
    {
        _colliderCallbacks = GetComponent<ColliderCallbacks>();
    }

    private void OnEnable()
    {
        _colliderCallbacks.OnTriggerStayEvent += SetupInteraction;
        _colliderCallbacks.OnTriggerExitEvent += CleanupInteraction;
    }
    private void OnDisable()
    {
        _colliderCallbacks.OnTriggerEnterEvent -= SetupInteraction;
        _colliderCallbacks.OnTriggerExitEvent -= CleanupInteraction;
    }

    private void SetupInteraction(Collider2D collider)
    {
        if (_currentInteractable != null) return;
        if (collider.gameObject.TryGetComponent<IInteractable>(out var interactable))
        {
            _currentInteractable = interactable;
        }
    }
    
    private void CleanupInteraction(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<IInteractable>(out var interactable))
        {
            if (_currentInteractable != interactable) return;
            _currentInteractable = null;

        }
    }

    public void TryInteract()
    {
        _currentInteractable?.Interact(this);
    }
}
