using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.Composite;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.Observer;
using Mandatory2DGameFramework.Strategy;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Cretures
{
    // S - Single Responsibility
    // D - Dependency Inversion
    public abstract class Creature :ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private IAttackStrategy _attackStrategy;
        private WeaponComposite _weaponComposite;
        private DefenceComposite _defenceComposite;

        #region Properties
        public string Name { get; set; }
        public int HitPoint { get; set; }
        public AttackItem? Attack { get; set; }
        public DefenceItem? Defence { get; set; }
        public int MaxWeight { get; set; }
        public WeaponComposite WWeaponComposite { get; set; }
        public DefenceComposite DDefenceComposite { get { return _defenceComposite; } set { _defenceComposite = value; } }
        public WeaponComposite WeaponComposite { get; set; } = new WeaponComposite();

        #endregion

        protected Creature()
        {
            Name = string.Empty;
            HitPoint = 100;
            Attack = null;
            Defence = null;
            MaxWeight = 100;
            WWeaponComposite = new WeaponComposite();
            DDefenceComposite = new DefenceComposite();
        }

        // Strategy
        public void SetAttackStrategy(IAttackStrategy strategy)
        {
            _attackStrategy = strategy;
        }

        public void PerformAttack(Creature target)
        {
            _attackStrategy?.Attack(target);
        }



        // Template Method
        public void ReceiveHit(int hit)
        {
            BeforeReceiveHit();

            hit -= _defenceComposite.TotalReduceHitPoint();
            if (hit > 0)
                HitPoint -= hit;

            NotifyObservers("was hit");

            AfterReceiveHit();

            if (HitPoint <= 0)
                Die();
        }


        public int Hit()
        {
            return _weaponComposite.TotalHit();
        }

        public void Loot(WorldObject obj)
        {
            if (!obj.Lootable) return;
            BeforeLoot();

            if (obj is AttackItem attackItem)
                Attack = attackItem;

            else if (obj is DefenceItem defenceItem)
                Defence = defenceItem;

            AfterLoot();
        }

        private void Die()
        {
            HitPoint = 0;
            NotifyObservers("has died");
            OnDeath();
        }

        // Abstract hooks
        protected abstract void BeforeReceiveHit();
        protected abstract void AfterReceiveHit();
        protected abstract void BeforeLoot();
        protected abstract void AfterLoot();
        protected abstract void OnDeath();

        // Observer
        public void AddObserver(IObserver observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            if (observers.Contains(observer))
                observers.Remove(observer);
        }

        public void NotifyObservers(string message)
        {
            foreach (IObserver observer in observers)
                observer.Update(this, message);
        }


        public void AddWeapons(params AttackItem[] attacks)
        {
            foreach (var attack in attacks)
            {
                WeaponComposite.AddAttack(attack, MaxWeight);
            }
        }

        public override string ToString()
        {
            return $"Creature: {Name}, HitPoint: {HitPoint}, Attack: {Attack}, Defence: {Defence}";
        }

    }
}
