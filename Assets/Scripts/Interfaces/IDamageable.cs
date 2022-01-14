/*
 * version 1.01
 * Interface implements TakeDamage(), which all game objects can use.
 *
 * Date: 1/13/2022
 * Author: Tyler Kaplan
 * Contributors
 *  - 
 *  Grant Reed - 1/13/2022 (updated to ver 1.01)
 */

public interface IDamageable<T>
{
    void TakeDamage(T damage);
    void Kill();
}

