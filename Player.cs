using System;

namespace CatAndMouse
{
    public enum State
    {
        Winner,
        Loser,
        Playing,
        NotInGame
    }
    public class Player
    {
        public string name;
        public int location;
        public State state = State.NotInGame;
        public int distanceTraveled = 0;

        public Player(string name)
        {
            this.name = name;
            this.location = -1;
        }

        public void Move(int steps, int fieldSize)
        {
            if (state == State.NotInGame)
            {

                location = steps;
                state = State.Playing;
                return;
            }

            distanceTraveled += Math.Abs(steps);

            int zeroBased = location - 1;
            int newZeroBased = ((zeroBased + steps) % fieldSize + fieldSize) % fieldSize;
            location = newZeroBased + 1;
        }
    }
}