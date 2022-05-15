
public abstract class Ship 
{
   
    public abstract float Speed { get; set; }
    public abstract float MaxSpeed { get; set; }
    public abstract float Health { get; set; }



    protected Ship(float speed,float healh, float maxSpeed)
    {
        Speed = speed;
        Health = healh;
        MaxSpeed = maxSpeed;
    }

    public abstract float GetDamage(float damage);
    public abstract void  GetHealed(float heal);
   
}


