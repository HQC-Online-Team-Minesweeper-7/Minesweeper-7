namespace GameEngine.Statistic.Player
{
    using System;
    using GameEngine.Data;

    public class PlayerCaretaker
    {
        private IPlayerMementoStorage playerStorage;

        public PlayerCaretaker(IPlayerMementoStorage playerStorage)
        {
            this.PlayerStorage = playerStorage;
        }

        public IPlayerMementoStorage PlayerStorage
        {
            get
            {
                return this.playerStorage;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "playerStorage");
                }

                if (this.playerStorage != null && value != this.playerStorage)
                {
                    foreach (var playerMemento in this.playerStorage)
                    {
                        value.Add(playerMemento);
                    }
                }

                this.playerStorage = value;
            }
        }

        public void AddMemento(PlayerMemento playerMemento)
        {
            if (playerMemento == null)
            {
                throw new ArgumentNullException(nameof(playerMemento));
            }

            this.PlayerStorage.Add(playerMemento);
        }

        public PlayerMemento GetMemento(int index)
        {
            return this.PlayerStorage.Get(index);
        }
    }
}
