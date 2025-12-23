using System;
using Member.KYM.Code.Players;
using UnityEngine;
using UnityEngine.Events;

namespace Member.KYM.Code
{
   public class Interaction : MonoBehaviour
   {
      [SerializeField] private Transform keyUI;
      private CircleCollider2D _circleCollider;
      public UnityEvent OnInteractEvent;

      private void Awake()
      {
         _circleCollider = GetComponent<CircleCollider2D>();
         keyUI.gameObject.SetActive(false);
      }

      private void OnTriggerEnter2D(Collider2D other)
      {
         if (other.transform.TryGetComponent(out Player player))
         {
            player.PlayerInput.OnInteractPressed += OnInteract;
            keyUI.gameObject.SetActive(true);
         }
      }
      private void OnTriggerExit2D(Collider2D other)
      {
         if (other.transform.TryGetComponent(out Player player))
         {
            player.PlayerInput.OnInteractPressed -= OnInteract;
            keyUI.gameObject.SetActive(false);
         }
      }
      
      private void OnInteract()
      {
         OnInteractEvent?.Invoke();
         _circleCollider.enabled = false;
      }
   }
}
