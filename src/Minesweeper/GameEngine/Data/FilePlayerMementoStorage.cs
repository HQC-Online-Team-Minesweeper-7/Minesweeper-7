// ----------------------------------------------------------------------
// <copyright file="FilePlayerMementoStorage.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-7"
// </copyright>
// <summary>
// The player memento storage.
// </summary>
// ----------------------------------------------------------------------
namespace GameEngine.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using GameEngine.Statistic.Player;
    using Validator;
    /// <summary>
    /// The player memento storage.
    /// </summary>
    public class FilePlayerMementoStorage : IPlayerMementoStorage
    {
        /// <summary>
        /// The file name.
        /// </summary>
        public readonly string Filename;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilePlayerMementoStorage"/> class.
        /// </summary>
        /// <param name="filename">The file name.</param>
        public FilePlayerMementoStorage(string filename)
        {
            Validator.CheckIfNullOrWhiteSpace(filename);

            this.Filename = filename;
        }

        /// <summary>
        /// Add the players.
        /// </summary>
        /// <param name="player">The players.</param>
        public void Add(PlayerMemento player)
        {
            using (FileStream fileStream = new FileStream(this.Filename, FileMode.OpenOrCreate))
            {
                fileStream.Position = fileStream.Length;
                var writer = new StreamWriter(fileStream);
                writer.AutoFlush = true;

                writer.WriteLine(string.Format("{0};{1}", player.Name, player.Score));
            }
        }

        /// <summary>
        /// Gets players.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The <see cref="PlayerMemento"/>.</returns>
        public PlayerMemento Get(int index)
        {
            using (FileStream fileStream = new FileStream(this.Filename, FileMode.OpenOrCreate))
            {
                fileStream.Position = fileStream.Length;
                var reader = new StreamReader(fileStream);

                for (int i = 0; i < index; i++)
                {
                    var line = reader.ReadLine();
                }

                var playerMemento = reader.ReadLine();
                var elements = playerMemento.Split(';');

                string name = elements[0];
                int score = int.Parse(elements[1]);

                return new PlayerMemento(name, score);
            }
        }

        /// <summary>
        /// The IEnumerator.
        /// </summary>
        /// <returns>The <see cref="IEnumerator"/>.</returns>
        public IEnumerator<PlayerMemento> GetEnumerator()
        {
            using (FileStream fileStream = new FileStream(this.Filename, FileMode.OpenOrCreate))
            {
                fileStream.Position = fileStream.Length;
                var reader = new StreamReader(fileStream);

                while (reader.EndOfStream)
                {
                    var playerMemento = reader.ReadLine();
                    var elements = playerMemento.Split(';');

                    string name = elements[0];
                    int score = int.Parse(elements[1]);

                    yield return new PlayerMemento(name, score);
                }
            }
        }

        /// <summary>
        /// The IEnumerator.
        /// </summary>
        /// <returns>The <see cref="IEnumerator"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
