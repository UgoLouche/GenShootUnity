
namespace GenShootUnity.Gameplay.Entity
{
    public interface IDamageableObject
    {
        void TakeDamage(float damage);
        void Explode();

		void Heal();
		void Heal(float amount);
    }
}
