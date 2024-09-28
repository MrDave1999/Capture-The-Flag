namespace CTF.Application.Players.Chats;

public static class ChatServicesExtensions
{
    public static IServiceCollection AddChatServices(this IServiceCollection services)
    {
        services
            .AddSingleton<IChatMessage, PrivateAdminChat>()
            .AddSingleton<IChatMessage, PrivateModeratorChat>()
            .AddSingleton<IChatMessage, PrivateTeamChat>()
            .AddSingleton<IChatMessage, PrivateVipChat>();

        services.AddSingleton<IDictionary<char, IChatMessage>>(serviceProvider =>
        {
            var chats = serviceProvider.GetRequiredService<IEnumerable<IChatMessage>>();
            return chats.ToDictionary(chat => chat.Id, chat => chat);
        });

        return services;
    }
}
