using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using Workstation.ServiceModel.Ua;
using Workstation.ServiceModel.Ua.Channels;

namespace OpcUA_WPF
{
    class OPC_UA_Client
    {
        public OPC_UA_Client(string opc_Id, double cycleTime, List<string> itemsNames)
        {
            url = "opc.tcp://" + opc_Id + ":4840";
            this.cycleTime = cycleTime;
            this.itemsNames = itemsNames;
            Timer myTimer = new Timer();
            myTimer.Elapsed += new ElapsedEventHandler(DisplayTimeEvent);
            myTimer.Interval = cycleTime; // 1000 ms is one second
            myTimer.Start();
            
        }

        

        double cycleTime;
        string url;
        UaTcpSessionChannel channel;
        string serverName = "";
        List<string> itemsNames = new List<string>();
        Dictionary<string, string> itemDict = new Dictionary<string, string>();
        public delegate void ChangedItems(Dictionary<string, string> itemDict);
        public event ChangedItems ItemsChanged;
        ReadRequest readRequest;
        String[] names;

        private async void DisplayTimeEvent(object sender, ElapsedEventArgs e)
        {
            if (serverName != "")
            {               
                try
                {
                    //await channel.OpenAsync();
                    var readResult = await channel.ReadAsync(readRequest);
                    itemDict.Clear();
                    for (int i = 0; i < itemsNames.Count; i++)
                    {
                        itemDict.Add(names[i], readResult.Results[i].Value.ToString());
                        //MessageBox.Show(readResult.Results[i].Value.ToString());
                    }
                    ItemsChanged?.Invoke(itemDict);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }        
        }
    


        public async Task SetChanel()
        {
            var clientDescription = new ApplicationDescription
            {
                ApplicationName = "Workstation.UaClient.FeatureTests",
                ApplicationUri = $"urn:{System.Net.Dns.GetHostName()}:Workstation.UaClient.FeatureTests",
                ApplicationType = Workstation.ServiceModel.Ua.ApplicationType.Client
            };

            channel = new UaTcpSessionChannel(
            clientDescription,
            null, // no x509 certificates
            new AnonymousIdentity(),                                      
            url,
            SecurityPolicyUris.None);

            try
            {
                await channel.OpenAsync();
                var readRequestGetName = new Workstation.ServiceModel.Ua.ReadRequest
                {
                    NodesToRead = new[] {
                        new Workstation.ServiceModel.Ua.ReadValueId {
                            NodeId = Workstation.ServiceModel.Ua.NodeId.Parse(Workstation.ServiceModel.Ua.VariableIds.Server_ServerStatus),
                            AttributeId = AttributeIds.Value
                        }
                    }
                };
                var readResultName = await channel.ReadAsync(readRequestGetName);
                var serverStatusGetName = readResultName.Results[0].GetValueOrDefault<Workstation.ServiceModel.Ua.ServerStatusDataType>();
                serverName = serverStatusGetName.BuildInfo.ProductName;


                ReadValueId[] reads = new ReadValueId[itemsNames.Count];
                int index = 0;
                names = new String[itemsNames.Count];
                foreach (string name in itemsNames)
                {
                    reads[index] = new Workstation.ServiceModel.Ua.ReadValueId
                    {
                        NodeId = Workstation.ServiceModel.Ua.NodeId.Parse("ns=4;s=|var|" + serverName + "." + name),
                        AttributeId = AttributeIds.Value
                    };
                    //MessageBox.Show(itemsNames.Count.ToString());
                    names[index] = name;
                    index++;
                }
                readRequest = new Workstation.ServiceModel.Ua.ReadRequest
                {
                    NodesToRead = reads
                };


            }
            catch (Exception ex)
            {
                await channel.AbortAsync();
                MessageBox.Show(ex.Message);               
            }
        }         
    }
}
