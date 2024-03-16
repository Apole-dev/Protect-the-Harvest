using UnityEngine;

namespace Player_Scripts
{
    public class PlayerController : MonoBehaviour
    {
        public int currentSpeed = 250;
        
        #region Serialized Fields

        [Header("Joystick Settings")]
        [SerializeField] private float deadZone = 0.1f; // Joystick dead-zone threshold
        [SerializeField] private FixedJoystick joystick;

        [Header("Rotation Settings")]
        [SerializeField] private float rotationLerpSpeed = 10f; // Rotation smoothing speed
        [SerializeField] private float rotationThreshold = 5f; // Minimum angle for rotation

        [Header("Components")]
        [SerializeField] private Rigidbody rb;
        [SerializeField] private GameObject player;

        #endregion

        #region Private Members

        private float _horizontal;
        private float _vertical;

        #endregion

        #region MonoBehaviour Callbacks

        private void Update()
        {
            GetMoveData();
        }

        private void FixedUpdate()
        {
            if (IsJoystickWithinDeadZone())
            {
                return; // Ignore small joystick movements within deadZone
            }

            HandleMovement();
            HandleRotation();
        }

        #endregion

        #region Movement Logic

        private void HandleMovement()
        {
            //STOP MOVEMENT WHEN JOYSTICK IS NOT ACTIVE
            if (!joystick.gameObject.activeSelf)
            {
                _horizontal = 0;
                _vertical = 0;
            }
            
            rb.velocity = GetNewVelocity();
        }

        private Vector3 GetNewVelocity()
        {
            return new Vector3(_horizontal, 0, _vertical) * (currentSpeed * Time.fixedDeltaTime);
        }

        #endregion

        #region Rotation Logic

        private void HandleRotation()
        {
            // Calculate the desired angle
            var desiredAngle = Mathf.Atan2(_horizontal, _vertical) * Mathf.Rad2Deg;

            // Smoothly rotate towards the desired angle, if the difference is greater than the threshold
            // Small angles do not affect the rotation of the player
            if (Mathf.Abs(desiredAngle) > rotationThreshold)
            {
                var currentAngle = player.transform.eulerAngles.y;
                var newAngle = Mathf.LerpAngle(currentAngle, desiredAngle, rotationLerpSpeed * Time.fixedDeltaTime);
                player.transform.rotation = Quaternion.Euler(0f, newAngle, 0f).normalized;
            }
        }

        #endregion

        #region Input Handling

        private void GetMoveData()
        {
            _horizontal = joystick.Horizontal;
            _vertical = joystick.Vertical;
        }

        private bool IsJoystickWithinDeadZone()
        {
            return Mathf.Abs(_horizontal) <= deadZone && Mathf.Abs(_vertical) <= deadZone;
        }

        #endregion
    }
}
