using MirageMUD_Client.Source.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirageMUD_Client.Source.General
{
    internal class General
    {
        ClientTCP clientTCP;
        HandleData handleData;
        public void Main()
        {
            Application.Run(new frmMenu());
            clientTCP = new ClientTCP();
            handleData = new HandleData();

            handleData.InitialiseMessages();
        }
    }
}
