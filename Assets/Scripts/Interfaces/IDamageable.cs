/*
 * Author: Tyler Kaplan
 * Contributors: Grant Reed
 * Description: Provides TakeDamage() and Kill() behavior to objects.
 */

public interface IDamageable<T>
{
    void TakeDamage(T damage);
    void Kill();
}

