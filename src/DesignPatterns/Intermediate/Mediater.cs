using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Intermediate
{
    /// <summary>
    /// Definition: Define an object that encapsulates how a set of objects
    ///             interact or communicate with each other. 
    ///
    /// Mediator promotes loose coupling by keeping objects from referring to each other explicitly, 
    /// and it lets you vary their interaction independently. 
    /// 
    /// </summary>

    public class User{
        public string Name { get; set; }
        public User(string name) => Name = name;
        public void SendMessage(User from, string message)
        {
            Console.Writeline($"User: {from.Name}, Message: {message}");
        }
    }
    public class ChatRoom//Mediater
    {
        public string Name;
        public List<User> _users = new List<User>();
        public ChatRoom(){}
        public void Set(string name) => Name = Name;

        public void Join(User user)
        {
            _users.Add(user);
            BroadcastMessage(user, $"User: {user.Name} has just joined in.");
        }
        public void BroadcastMessage(User from, string SendMessage)
        {
            foreach(var to in _users)
            {
                to.SendMessage(from, message);
            }
        }
        public void SendMessage(User from, string name, string SendMessage)
        {
            _users.Find(u => u.Name == name)?.
            SendMessage(from, message);
        }
    }
}
