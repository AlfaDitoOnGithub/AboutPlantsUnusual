
public class HealthSystem 
{
    private int health;
    private int maxHealth;
    public HealthSystem(int health) {
        this.health = health;
    }

    public int GetHealth(){
        return health;
    }

    public void Damage(int damageAmount){
        health -= damageAmount;
        if(health < 0){health = 0;};
    }

    public void Heal(int healAmount){
        health += healAmount;
        if(health > maxHealth){health = maxHealth;}
    }

    public float GetPercentHealth(){
        return (float) health/maxHealth;
    }
}
