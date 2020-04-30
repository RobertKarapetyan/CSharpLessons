using System;

namespace LearnCSharp.Basics.Boxing
{
    public struct Entity : IEntity
    {
        public int X;
        public int Y;

        public Entity(int x, int y) 
        {
            X = x;
            Y = y;
        }
        
        public string Name()
        {
            const string result = "Entity Name";
            return result;
        }
        
        public void Change(int x, int y) 
        {
            X = x; Y = y;
        }
    }
}