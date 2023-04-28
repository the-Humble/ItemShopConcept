using UnityEngine;

namespace Code.Core
{
    public class ColliderCallbacks : MonoBehaviour
    {
        public delegate void CollisionCallback(Collision2D collision);
        public delegate void TriggerCallback(Collider2D other);

        public event CollisionCallback OnCollisionEnterEvent;
        public event CollisionCallback OnCollisionExitEvent;
        public event CollisionCallback OnCollisionStayEvent;
    
        public event TriggerCallback OnTriggerEnterEvent;
        public event TriggerCallback OnTriggerExitEvent;
        public event TriggerCallback OnTriggerStayEvent;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEnterEvent?.Invoke(collision);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            OnCollisionExitEvent?.Invoke(other);
        }

        private void OnCollisionStay2D(Collision2D collisionInfo)
        {
            OnCollisionStayEvent?.Invoke(collisionInfo);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEnterEvent?.Invoke(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            OnTriggerExitEvent?.Invoke(other);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            OnTriggerStayEvent?.Invoke(other);
        }
    }
}