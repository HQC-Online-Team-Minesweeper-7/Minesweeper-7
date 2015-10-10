using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using GameEngine.Statistic.Player;

namespace GameEngine.Data
{
    public class FilePlayerMementoStorage : IPlayerMementoStorage
    {
        public readonly string Filename;

        public FilePlayerMementoStorage(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentException("invalid filename");
            }

            this.Filename = filename;
        }

        public void Add(PlayerMemento player)
        {
            using (FileStream fileStream = new FileStream(this.Filename, FileMode.OpenOrCreate))
            {
                fileStream.Position = fileStream.Length;
                StreamWriter writer = new StreamWriter(fileStream);
                writer.AutoFlush = true;

                writer.WriteLine(string.Format("{0};{1}", player.Name, player.Score));
            }
        }

        public PlayerMemento Get(int index)
        {
            using (FileStream fileStream = new FileStream(this.Filename, FileMode.OpenOrCreate))
            {
                fileStream.Position = fileStream.Length;
                StreamReader reader = new StreamReader(fileStream);

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

        public IEnumerator<PlayerMemento> GetEnumerator()
        {
            using (FileStream fileStream = new FileStream(this.Filename, FileMode.OpenOrCreate))
            {
                fileStream.Position = fileStream.Length;
                StreamReader reader = new StreamReader(fileStream);

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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
