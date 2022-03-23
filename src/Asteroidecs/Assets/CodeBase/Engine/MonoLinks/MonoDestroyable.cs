﻿using System;
using CodeBase.Core.Gameplay.Components.Lifecycle;
using CodeBase.Engine.MonoLinks.Base;
using CodeBase.Engine.Services.AssetManagement.Pool;
using Leopotam.EcsLite;

namespace CodeBase.Engine.MonoLinks
{
    public class MonoDestroyable : MonoLink<Destroyable>, IDestroyable, IPoolObject
    {
        private Pool _pool;

        public event Action Destroyed;

        public void Register(Pool pool) =>
            _pool = pool;

        public void Destroy()
        {
            Destroyed?.Invoke();
            _pool.Push(gameObject);
        }

        public override void Resolve(EcsWorld world, int entity)
        {
            Value = new Destroyable {Link = this};
            base.Resolve(world, entity);
        }
    }
}