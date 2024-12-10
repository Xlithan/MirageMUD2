using Bindings;
using MirageMUD_Server.Globals;
using MirageMUD_Server.Network;
using MirageMUD_Server.Storage;

namespace MirageMUD_Server
{
    internal class General
    {
        private readonly SHandleData _sHandleData;

        public General()
        {
            _sHandleData = new SHandleData();
        }

        public async Task InitialiseServer()
        {
            Console.Title = "MirageMUD - WebSocket Edition";
            string languageCode = ConfigReader.GetLanguageCode("Data/config.json");
            TranslationManager.LanguageCode = languageCode;

            TranslationManager translator = TranslationManager.Instance;
            translator.LoadTranslations(languageCode);

            for (int i = 0; i < Constants.MAX_PLAYERS; i++)
            {
                var newClient = new Client(i, null);
                ServerWebSocket.Clients[i] = newClient;
                STypes.Player[i] = new STypes.AccountStruct();
                STypes.Player[i].Initialise(Constants.MAX_CHARS);
            }
            var server = new ServerWebSocket();
            await server.StartAsync();

            Console.WriteLine(TranslationManager.Instance.GetTranslation("server.server_started"));
        }
    }
}