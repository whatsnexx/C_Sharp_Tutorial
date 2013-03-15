Send Events Using C#
===============

Describes how to send an event through the Whatsnexx.TicketBus from a Console application in Visual Studio.

Getting Started
------------------
The whatsnexx [ticketbus](https://github.com/whatsnexx/Whatsnexx/wiki/TicketBus) handles REST and SOAP Web Service request to send events. In this example, we will demonstrate how to send and event to the Whatsnexx ticketbus using a WCF client. If you are not familiar with WCF, the MSDN documentation can be found [here](http://msdn.microsoft.com/en-us/library/dd456779.aspx). You will need following to send a request to the [ticketbus](https://github.com/whatsnexx/Whatsnexx/wiki/TicketBus) service.
<table width="100%" border="1px">
<tr><th align="left">Attribute</th><th align="left">Type</th><th align="left">Description</th></tr>
<tr><td>Account Id</td><td>GUID</td><td> Provided by Whatsnexx.</td></tr>
<tr><td>Username:</td><td>GUID</td><td>Provided by Whatsnexx.</td></tr>
<tr><td>Password:</td><td>GUID</td><td>Provided by Whatsnexx.</td></tr>
<tr><td>TermName:</td><td>string</td><Td>This is the name of the event that is to be triggered by the send event.</td>
<tr><td>SubjectCode:</td><td>string</td><Td>The unique identifier for your [subject](). This usually represents <b>who</b> you would like to send the event to.</td></tr>
<tr><td>SubjectTypeId:</td><td>GUID</td><td>A unique identitfier for the subject type. The subject type defines the context under which events are sent.</td></tr>
<tr><td>ExecutionEnvironment:</td><td>TicketBusService.ExecutionEnvironments</td><td>Specifies the Whatsnexx environment you are sending the event request. A <b>Constellation</b> must exist in the chosen environment for the event to be triggered. The available Environments are: Test, Stage, and Production.</td></tr>
<tr><td>Attributes:</td><td>TicketBusService.Attributes[]</td><Td>A list of attributes that are used by the event.</td></tr>
</table>
Steps
----------------

<ol>
<li>Open Visual Studio and create a new Console Application.
  <ol type="a">
    <li>In the <b>File</b> menu point to <b>New</b> and click <b>Protect</b>. A  <b>New Project</b> dialog box will appear.</li>
    <li>In the  <b>New Project</b> dialog box, select <b>Visual C#</b> from the <b>Installed Templates</b> box, and select <b>Console Application</b> from the list provided</li>
    <li>Enter the <b><i>'CSharpExample'</i></b> in the <b>Name</b> box and enter the location you would like to save the project in the <b>Location</b> box.</li>
    <li>Click <b>OK</b></li>
  </ol>
</li>
<li>Add a <b>Service Reference</b> for the <b>Whatsnexx TicketBusService</b>
<ol type="a">
        <li>In the <b>Solution Explorer</b> right click on <b>References</b> in the project <b>CSharpExample</b> and left click on <b>Add Service Reference</b>. The <b>Add Service Reference</b> dialog box will open.</li>
        <li>Enter <i>'https://ticketbus.whatsnexx.com/TicketBusService.svc'</i> in the <b>Address</b> box and click <b>Go. TicketBusService</b> will appear shortly.</li>
        <li>Enter <b><i>'TicketBusService'</i></b> in the <b>Namespace</b> box and click <b>OK</b>. The <b>Service Model</b> reference will be added to the the project <b>References</b> and the <b>Service References</b> will appear with <b>TicketBusService</b> added as a service.
        <ul><li>To view the service API, double click on <b>TicketBusService</b> under <b>Service References</b>. The <b>Object Browser</b> will appear.</li><li>Expand <b>CSharpExample.TicketBusService</b> and select objects in the explorer to view the methods available.</li></ul></li>
</ol>
</li>
<li>Modify <b>Program.cs</b> as follows and run the application. A console window will appear showing the service was called successfully.
</li>
</ol>

```csharp
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
            //Attributes: TicketBusService.AttributeList A list of attributes that are used by the event.

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
```

Getting Help
-----------
[Whatsnexx Full Documentation]()  Available Soon  
[MSDN](http://msdn.microsoft.com/en-us/library/dd456779.aspx)


*****
[Top](https://github.com/paulsmelser/PHP-Send-Event/blob/master/README.md#send-events-using-php)

