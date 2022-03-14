using CodeBase.Core.Common;
using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Engine.Common;
using CodeBase.Engine.MonoLinks.Base;
using Leopotam.EcsLite;
using UnityEngine;

namespace CodeBase.Engine.MonoLinks
{
    public class MonoEngineBody : MonoLink<EngineBody>, IBody
    {
        public void Move(Vector2Data movement)
        {
            var worldPoint = new Vector3(movement.X, movement.Y, 0f);
            transform.position = worldPoint;
        }

        public void Rotate(Vector2Data direction) =>
            transform.rotation = direction.ToQuaternion();

        public override void Resolve(EcsWorld world, int entity)
        {
            Value = new EngineBody {Body = this};
            base.Resolve(world, entity);
        }
    }
}