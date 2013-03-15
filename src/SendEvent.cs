using System;
using Attribute = CSharpExample.TicketBusService.Attribute;
using CSharpExample.TicketBusService;
namespace CSharpExample
{
    public class SendEvent
    {
        
        public static void Main(string[] args)
        {
            //AccountId: GUID Provided by Whatsnexx. 
            //Username: GUID Provided by Whatsnexx.
            //Password: GUID Provided by Whatsnexx.
            //TermName: String This is the name of the event that is to be triggered by the send event.
            //SubjectCode: (Hash value)The unique identifier for your subject(). This usually represents who you would like to send the event to.
            //SubjectTypeId: GUID A unique identitfier for the subject type. The subject type defines the context under which events are sent.
            //ExecutionEnvironment: TicketbusService.ExecutionEnvironment Specifies the Whatsnexx environment you are sending the event request. A <code>Constellation</code> must exist in the chosen environment for the event to be triggered. The available Environments are: Test, Stage, and Production.
            //Attributes: TicketbusService.Attribute[] A list of attributes that are used by the event.

            const string userName = "{Your Username}";
            const string password = "{Your Password}";
            const string accountId = "{Your Account Id}";
            const string subjectTypeId = "{Your Subject Id}";
            const string termName = "{Your TermName}";

            //create out objects
            TicketBusResponse response;
            string transactionId;

            var ticketBusSendEvent = new TicketBusSendEvent
            {
                Attributes = new[] {
                    new Attribute {Name = "Test", Value = "Value1"}, 
                    new Attribute {Name = "Email", Value = "someone@somewhere.com"}},
                SubjectCode = "TestCode"
            };

            var client = new TicketBusServiceClient
            {
                ClientCredentials =
                {
                    UserName =
                    {
                        UserName = userName,
                        Password = password
                    }
                }
            };

            var success = client.SendEvent( accountId, ExecutionEnvironments.Stage,
                subjectTypeId, termName, ticketBusSendEvent, out response, out transactionId);

            Console.WriteLine("Worked: " + success + Environment.NewLine + "TransactionId: " + transactionId);
            Console.ReadKey();
        }
    }
}
