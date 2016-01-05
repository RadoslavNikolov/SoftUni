using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;


static class Program
{
    public static void Main()
    {
        while (ExecuteNextCommand())
        {

        }

        Console.WriteLine(Message.PrintMessages());
    }

    private static bool ExecuteNextCommand()
    {
        string command = Console.ReadLine();

        if (command[0] == 'A')
        {
            CommandStorage.AddEvent(command);
            return true;
        }

        if (command[0] == 'D')
        {
            CommandStorage.DeleteEvents(command);
            return true;
        }

        if (command[0] == 'L')
        {
            CommandStorage.ListEvents(command);
            return true;
        }

        if (command[0] == 'E')
        {
            return false;
        }

        return false;
    } 
}

public static class CommandStorage
{
    private static readonly EventHolder Events = new EventHolder();

    public static void ListEvents(string command)
    {
        int pipeIndex = command.IndexOf('|');
        string countString = command.Substring(pipeIndex + 1);
        int count = int.Parse(countString);
        DateTime date = GetDate(command, "ListEvents");

        Events.ListEvents(date, count);
    }

    public static void DeleteEvents(string command)
    {
        string title = command.Substring("DeleteEvents".Length + 1);

        Events.DeleteEvents(title);
    }

    public static void AddEvent(string command)
    {
        DateTime date;
        string title;
        string location;

        GetParameters(command, "AddEvent", out date, out title, out location);

        Events.AddEvent(date, title, location);
    }

    private static void GetParameters(string commandForExecution, string commandType, out DateTime dateAndTime, out string eventTitle, out string eventLocation)
    {
        dateAndTime = GetDate(commandForExecution, commandType);
        int firstPipeIndex = commandForExecution.IndexOf('|');
        int lastPipeIndex = commandForExecution.LastIndexOf('|');

        if (firstPipeIndex == lastPipeIndex)
        {
            eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
            eventLocation = "";
        }
        else
        {
            eventTitle = commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
            eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
        }
    }

    private static DateTime GetDate(string command, string commandType)
    {
        DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));

        return date;
    }
}

public class Event : IComparable
{
    private DateTime date;
    private string title;
    private string location;

    public Event(DateTime date, string title, string location)
    {
        this.Date = date;
        this.Title = title;
        this.Location = location;
    }

    //Todo: validation 
    public DateTime Date
    {
        get { return this.date; }
        set { this.date = value; }
    }

    //Todo: validation 
    public string Title
    {
        get { return this.title; }
        set { this.title = value; }
    }

    //Todo: validation 
    public string Location
    {
        get { return this.location; }
        set { this.location = value; }
    }

    public int CompareTo(object obj)
    {
        Event otherEvent = (Event)obj;
        int comparedByDateResult = this.Date.CompareTo(otherEvent.Date);
        int comparedByTitleResult = string.Compare(this.Title, otherEvent.Title, StringComparison.Ordinal);
        int comapredByLocationresult = string.Compare(this.Location, otherEvent.Location, StringComparison.Ordinal);

        if (comparedByDateResult == 0)
        {
            if (comparedByTitleResult == 0)
            {
                return comapredByLocationresult;
            }

            return comparedByTitleResult;
        }

        return comparedByDateResult;
    }

    public override string ToString()
    {
        var output = new StringBuilder();

        output.Append(string.Format("{0} | {1}", this.Date.ToString("yyyy-MM-ddTHH:mm:ss"), this.Title));
        output.Append(this.Date.ToString("yyyy-MM-ddTHH:mm:ss"));
        output.Append(" | " + this.Title);
        if (!string.IsNullOrEmpty(this.Location))
        {
            output.Append(" | " + this.Location);
        }

        return output.ToString();
    }
}

static class Message
{
    private static readonly StringBuilder Output = new StringBuilder();

    public static void EventAdded()
    {
        Output.AppendLine("Event added\n");
    }

    public static void EventDeleted(int x)
    {
        if (x == 0)
        {
            NoEventsFound();
        }

        else Output.AppendLine(string.Format("{0} events deleted", x));
    }

    public static void NoEventsFound()
    {
        Output.AppendLine("No events found\n");
    }

    public static string PrintMessages()
    {
        return Output.ToString();
    }

    public static void PrintEvent(Event eventToPrint)
    {
        if (eventToPrint != null)
        {
            Output.AppendLine(eventToPrint + "\n");
        }
    }
}

public class EventHolder
{
    private readonly MultiDictionary<string, Event> byTitle = new MultiDictionary<string, Event>(true);
    private readonly OrderedBag<Event> byDate = new OrderedBag<Event>();

    public void AddEvent(DateTime date, string title, string location)
    {
        var newEvent = new Event(date, title, location);
        this.byTitle.Add(title.ToLower(), newEvent);
        this.byDate.Add(newEvent);

        Message.EventAdded();
    }

    public void DeleteEvents(string titleToDelete)
    {
        string title = titleToDelete.ToLower();
        int removedEventsCount = 0;

        foreach (var eventToRemove in this.byTitle[title])
        {
            this.byDate.Remove(eventToRemove);
            removedEventsCount++;
        }

        this.byTitle.Remove(title);

        Message.EventDeleted(removedEventsCount);
    }

    public void ListEvents(DateTime date, int count)
    {
        OrderedBag<Event>.View eventsToShow = this.byDate.RangeFrom(new Event(date, "", ""), true);
        int showed = 0;

        foreach (var currentEvent in eventsToShow)
        {
            if (showed == count)
            {
                break;
            }

            Message.PrintEvent(currentEvent);
            showed++;
        }

        if (showed == 0)
        {
            Message.NoEventsFound();
        }
    }
}