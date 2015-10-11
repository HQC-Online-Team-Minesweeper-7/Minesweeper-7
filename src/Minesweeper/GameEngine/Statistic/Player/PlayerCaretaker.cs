// ----------------------------------------------------------------------
// <copyright file="PlayerCaretaker.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The player caretaker.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Statistic.Player
{
    using System;

    using GameEngine.Data;

    /// <summary>
    /// The player caretaker.
    /// </summary>
    public class PlayerCaretaker
    {
        /// <summary>
        /// The players storage.
        /// </summary>
        private IPlayerMementoStorage playerStorage;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerCaretaker"/> class.
        /// </summary>
        /// <param name="playerStorage">The playersStorage.</param>
        public PlayerCaretaker(IPlayerMementoStorage playerStorage)
        {
            this.PlayerStorage = playerStorage;
        }

        /// <summary>
        /// Gets or sets a value indicating whether is PlayerStorage.
        /// </summary>
        /// <value>Gets or sets stored players.</value>
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

        /// <summary>
        /// Add to memento.
        /// </summary>
        /// <param name="playerMemento">The playerMemento.</param>
        public void AddMemento(PlayerMemento playerMemento)
        {
            if (playerMemento == null)
            {
                throw new ArgumentNullException(nameof(playerMemento));
            }

            this.PlayerStorage.Add(playerMemento);
        }

        /// <summary>
        /// Restore from memento.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The <see cref="PlayerMemento"/>.</returns>
        public PlayerMemento GetMemento(int index)
        {
            return this.PlayerStorage.Get(index);
        }
    }
}
