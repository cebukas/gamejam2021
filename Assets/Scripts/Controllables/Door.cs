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
            TraverseDoorComponents(_opened, !_opened);
        }

        private void TraverseDoorComponents(bool doorEnabled, bool isTrigger)
        {
            foreach (var s in GetComponentsInChildren<SpriteRenderer>())
                s.enabled = doorEnabled;
            foreach (var c in GetComponentsInChildren<BoxCollider2D>())
                c.isTrigger = isTrigger;
        }
    }
}
