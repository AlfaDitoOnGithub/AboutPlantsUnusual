
public class HealthSystem 
{
    private int currHealth;
    private int maxHealth;
    public HealthSystem(int health) {
        this.currHealth = health;
        this.maxHealth = health;
    }

    public int GetCurrHealth(){
        return currHealth;
    }

    public int GetMaxHealth(){
        return maxHealth;
    }

    public void Damage(int damageAmount){
        currHealth -= damageAmount;
        if(currHealth < 0){currHealth = 0;};
    }

    public void Heal(int healAmount){
        currHealth += healAmount;
        if(currHealth > maxHealth){currHealth = maxHealth;}
    }

    public float GetPercentHealth(){
        return (float) currHealth/maxHealth;
    }
}
