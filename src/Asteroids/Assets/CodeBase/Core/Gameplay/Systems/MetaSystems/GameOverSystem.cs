using CodeBase.Core.Gameplay.Components.Meta;
using CodeBase.Core.Gameplay.Services;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.MetaSystems
{
    public class GameOverSystem : IEcsRunSystem, IEcsDestroySystem
    {
        private readonly EcsFilter<GameOverEvent> _gameOver = default;
        private readonly IUiFactory _uiFactory;

        public GameOverSystem(IUiFactory uiFactory) => 
            _uiFactory = uiFactory;

        public void Run()
        {
            if (_gameOver.IsEmpty())
                return;
            
            _uiFactory.OpenGameOverWindow();

            foreach (var index in _gameOver)
            {
                ref var entity = ref _gameOver.GetEntity(index);
                entity.Del<GameOverEvent>();
            }
        }

        public void Destroy() => 
            _uiFactory.CloseGameOverWindow();
    }
}