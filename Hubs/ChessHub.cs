using ChessnoorPrototype.ChessData;
using Microsoft.AspNetCore.SignalR;

namespace ChessnoorPrototype.Hubs;

public class ChessHub : Hub
{
    private readonly List<Game> _games = [];

    public async Task SendMove(Move move, int id)
    {
        await Clients.Group(id.ToString()).SendAsync("ReceiveMove", move);

    }

    //public async Task SendState(uint id)
    //{
    //    //if (!ValidId(id))
    //    //    return;
    //    //await Clients.Client(Context.ConnectionId).SendAsync("ReceiveState", _games[(int)id].State);
    //    Console.WriteLine("Games:");
    //    foreach (var game in _games)
    //    {
    //        Console.WriteLine($"{game}");
    //    }
    //    await Clients.All.SendAsync("ReceiveState", _games[(int)id].State);
    //    //await Clients.Group(id.ToString()).SendAsync("ReceiveState", _games[(int)id].State);

    //}

    public async Task CreateGame()
    {
        uint id = AddGame();

        Console.WriteLine($"In creation: {Context.ConnectionId}");
        await Groups.AddToGroupAsync(Context.ConnectionId, id.ToString());
        await Clients.Group(id.ToString()).SendAsync("ReceiveId", id);
        //await Clients.All.SendAsync("ReceiveId", AddGame());

        Console.WriteLine("Creating Game");
    }

    public async Task JoinGroup(uint id)
    {
        string groupName = id.ToString();
        Console.WriteLine($"{Context.ConnectionId} joined group {groupName}");

        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        await Clients.Group(groupName).SendAsync("GroupMessage", $"{Context.ConnectionId} joined the group {groupName}");
    }

    public async Task SendGroup(uint id, string message)
    {
        string groupName = id.ToString();
        //await Clients.All.SendAsync("GroupMessage", message);
        await Clients.Group(groupName).SendAsync("GroupMessage", $"{Context.ConnectionId}: {message}");
    }

    private uint AddGame()
    {
        _games.Add(new Game());

        return (uint)_games.Count - 1;
    }

    private bool ValidId(uint id)
    {
        return _games.Count < id;
    }
}
