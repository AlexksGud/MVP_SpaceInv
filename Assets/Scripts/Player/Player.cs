using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{



    [Serializable]
    public struct PlayerStats
    {
        public float health;
        public float speed;
        public float maxSpeed;
        public float horzinotalspeedModifaer;
        internal Rigidbody2D rb;


    }

    [SerializeField] private PlayerStats playerThings;

    [Header("Borders")]
    [SerializeField, Space(1)]
                     private float _xMax;
    [SerializeField] private float _xMin, _yMax, _yMin;

    

    private PlayerShip _playerShip;
        
    private Vector2 movement;

    private void Start()
    {
        playerThings.rb = GetComponent<Rigidbody2D>();

        _playerShip = new PlayerShip
            (playerThings.speed, playerThings.maxSpeed,playerThings.health,playerThings.rb);

        _playerShip.HorizontalSpeedModifer = playerThings.horzinotalspeedModifaer;

    }

    // Update is called once per frame
    private void Update()
    {
        
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

      


    }

    private void FixedUpdate()
    {
        _playerShip.ForceForward(movement.y);
        _playerShip.ForceHorizontally(movement.x);
        _playerShip.ClampVelocity();
        ClampShipPosition();

    }

    private void ClampShipPosition()
    {
        _playerShip.tr.position = new Vector3
            (Mathf.Clamp(_playerShip.tr.position.x, _xMin, _xMax),
            Mathf.Clamp(_playerShip.tr.position.y, _yMin, _yMax),
            _playerShip.tr.position.z);
    }

    private class PlayerShip : Ship
    {
    
      
        public override float Speed { get; set; }
        public override float MaxSpeed { get; set; }
        public override float Health { get; set; }

        public float HorizontalSpeedModifer { get; set; }
        public Rigidbody2D ShipRigidBody {get; private set; }
        public Transform tr { get; private set; }


        public PlayerShip(float speed,float maxSpeed,float healh, Rigidbody2D rb) : base(speed, maxSpeed,healh)
        {
            ShipRigidBody = rb;
            tr = rb.gameObject.GetComponent<Transform>();

        }

        public virtual void ForceForward(float amount)
        {
            Vector2 force = tr.transform.up * amount * Speed;
            ShipRigidBody.AddForce(force);
        }
        public virtual void ForceHorizontally(float amount)
        {
            Vector2 force = tr.transform.right * amount * (Speed*HorizontalSpeedModifer);
            ShipRigidBody.AddForce(force);
        }

        public virtual void ClampVelocity()
        {
            float x = Mathf.Clamp(ShipRigidBody.velocity.x, -MaxSpeed, MaxSpeed);
            float y = Mathf.Clamp(ShipRigidBody.velocity.y, -MaxSpeed, MaxSpeed);

            ShipRigidBody.velocity = new Vector2(x, y); 
        }

     
        public override float GetDamage(float damage)
        {
            return Health -= damage;
        }

        public override void GetHealed(float heal)
        {
            Health += heal;
        }
    }
}
