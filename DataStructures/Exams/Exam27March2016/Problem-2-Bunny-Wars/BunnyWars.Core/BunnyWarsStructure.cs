namespace BunnyWars.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class BunnyWarsStructure : IBunnyWarsStructure
    {
        OrderedDictionary<int, List<Bunny>> roomsById =
            new OrderedDictionary<int, List<Bunny>>();
        Dictionary<string, Bunny> bunniesByName =
            new Dictionary<string, Bunny>();
        Dictionary<int, SortedSet<Bunny>> bunniesByTeam =
            new Dictionary<int, SortedSet<Bunny>>();
        SortedList<int, int> rooms = new SortedList<int, int>();

        public int BunnyCount
        {
            get
            {
                return this.bunniesByName.Count;
            }
        }

        public int RoomCount
        {
            get
            {
                return this.roomsById.Count;
            }
        }

        public void AddRoom(int roomId)
        {
            if (this.roomsById.ContainsKey(roomId))
            {
                throw new ArgumentException(string.Format("Room with id {0} already exists", roomId));
            }

            this.rooms.Add(this.RoomCount, roomId);
            this.roomsById[roomId] = new List<Bunny>();
        }

        public void AddBunny(string name, int team, int roomId)
        {
            if (!this.roomsById.ContainsKey(roomId) ||
                this.bunniesByName.ContainsKey(name))
            {
                throw new ArgumentException(string.Format(
                    "Room with id {0} doesn't exist or bunny with name {1} already exists",
                    roomId,
                    name));
            }

            if (team < 0 || 4 < team)
            {
                throw new IndexOutOfRangeException("Team must be in the range [0...4]");
            }

            var bunny = new Bunny(name, team, roomId);

            this.roomsById[roomId].Add(bunny);
            this.bunniesByName.Add(name, bunny);

            if (!this.bunniesByTeam.ContainsKey(team))
            {
                this.bunniesByTeam[team] = new SortedSet<Bunny>();
            }

            this.bunniesByTeam[team].Add(bunny);
        }

        public void Remove(int roomId)
        {
            if (!this.roomsById.ContainsKey(roomId))
            {
                throw new ArgumentException(
                    string.Format("Room with id {0} doesn't exist", roomId));
            }

            while (this.roomsById[roomId].Count > 0)
            {
                var bunny = this.roomsById[roomId][0];

                this.roomsById[roomId].Remove(bunny);
                this.bunniesByName.Remove(bunny.Name);
                this.bunniesByTeam.Remove(bunny.Team);
            }

            this.rooms.Remove(roomId);
            this.roomsById.Remove(roomId);
        }

        public void Next(string bunnyName)
        {
            if (!this.bunniesByName.ContainsKey(bunnyName))
            {
                throw new ArgumentException(
                    string.Format("Bunny with name {0} doesn't exist", bunnyName));
            }

            var bunny = this.bunniesByName[bunnyName];

            if (bunny.RoomId == this.rooms[this.rooms.Count - 1])
            {
                bunny.RoomId = this.rooms[0];
            }
            else
            {
                var roomIndex = this.rooms.IndexOfValue(bunny.RoomId);

                bunny.RoomId = this.rooms[roomIndex + 1];
            }
        }

        public void Previous(string bunnyName)
        {
            if (!this.bunniesByName.ContainsKey(bunnyName))
            {
                throw new ArgumentException(
                    string.Format("Bunny with name {0} doesn't exist", bunnyName));
            }

            var bunny = this.bunniesByName[bunnyName];

            if (bunny.RoomId == this.rooms[0])
            {
                bunny.RoomId = this.rooms[this.rooms.Count - 1];
            }
            else
            {
                var roomIndex = this.rooms.IndexOfValue(bunny.RoomId);

                bunny.RoomId = this.rooms[roomIndex - 1];
            }
        }

        public void Detonate(string bunnyName)
        {
            if (!this.bunniesByName.ContainsKey(bunnyName))
            {
                throw new ArgumentException(
                    string.Format("Bunny with name {0} doesn't exist", bunnyName));
            }

            var bunny = this.bunniesByName[bunnyName];
            var room = this.roomsById[bunny.RoomId];

            for (int i = 0; i < room.Count;)
            {
                var otherBunny = room[i];

                if (otherBunny.Team != bunny.Team)
                {
                    otherBunny.Health -= 30;

                    if (otherBunny.Health <= 0)
                    {
                        this.roomsById[otherBunny.RoomId].Remove(otherBunny);
                        this.bunniesByName.Remove(otherBunny.Name);
                        this.bunniesByTeam[otherBunny.Team].Remove(otherBunny);

                        bunny.Score++;
                    }
                }
                else
                {
                    i++;
                }
            }
        }

        public IEnumerable<Bunny> ListBunniesByTeam(int team)
        {
            if (team < 0 || 4 < team)
            {
                throw new IndexOutOfRangeException("Team must be in the range [0...4]");
            }

            return this.bunniesByTeam[team];
        }

        public IEnumerable<Bunny> ListBunniesBySuffix(string suffix)
        {
            return this.bunniesByName.Values
                .Where(b => b.Name.EndsWith(suffix))
                .OrderBy(b => Reverse(b.Name), StringComparer.Ordinal)
                .ThenBy(b => b.Name.Length);
        }

        private string Reverse(string bunnyName)
        {
            char[] charArray = bunnyName.ToCharArray();

            Array.Reverse(charArray);

            return new string(charArray);
        }
    }
}
