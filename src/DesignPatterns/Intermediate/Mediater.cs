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

  public class Person
  {
    public string Name;
    public ChatRoom Room;
    private List<string> chatLog = new List<string>();

    public Person(string name)
    {
      Name = name;
    }

    public void Receive(string sender, string message)
    {
      string s = $"{sender}: '{message}'";
      Console.WriteLine($"[{Name}'s chat session] {s}");
      chatLog.Add(s);
    }

    public void Say(string message)
    {
      Room.Broadcast(Name, message);
    }

    public void PrivateMessage(string who, string message)
    {
      Room.Message(Name, who, message);
    }
  }

  public class ChatRoom //Mediater
  {
    private List<Person> people = new List<Person>();
    private string Name;
    public void SetName(string name) => Name = name;
    public void Broadcast(string source, string message)
    {
      foreach (var p in people)
        if (p.Name != source)
          p.Receive(source, message);
    }

    public void Join(Person p)
    {
      string joinMsg = $"{p.Name} joins the chat";
      Broadcast("room", joinMsg);

      p.Room = this;
      people.Add(p);
    }

    public void Message(string source, string destination, string message)
    {
      people.FirstOrDefault(p => p.Name == destination)?.Receive(source, message);
    }
  }
}
