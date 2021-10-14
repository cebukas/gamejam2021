using Interfaces;
using UnityEngine;

namespace Controllables
{
    public class Door : MonoBehaviour, IControllable
    {
        private bool _opened;

        private void Start()
        {
            ChangeDoorState();
        }

        public void React()
        {
            FlipOpen();
            ChangeDoorState();
        }

        private void FlipOpen()
        {
            _opened = !_opened;
        }

        private void ChangeDoorState()
        {
            FindObjectOfType<AudioManager>().Play("Door");
            if (_opened)
            {
                foreach (var s in GetComponentsInChildren<SpriteRenderer>())
                    s.enabled = false;
                foreach (var c in GetComponentsInChildren<BoxCollider2D>())
                    c.isTrigger = true;
            }
            else
            {
                foreach (var s in GetComponentsInChildren<SpriteRenderer>())
                    s.enabled = true;
                foreach (var c in GetComponentsInChildren<BoxCollider2D>())
                    c.isTrigger = false;
            }
        }
    }
}
