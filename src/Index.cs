using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

public async Task<RuntimeResponse> Main(RuntimeRequest req, RuntimeResponse res)
{
  // Convert payload from JSON string to Dictionary and get the phone number to call 
  var payload = JsonConvert.DeserializeObject<Dictionary<string, string>>(req.Payload);
  var toPhoneNumber = payload["phoneNumber"];

  // Get Twilio Account SID, Auth Token, and Phone Number from the Environment Variables
  var accountSID = req.Env["TWILIO_ACCOUNTSID"];
  var authToken = req.Env["TWILIO_AUTHTOKEN"];
  var twilioPhoneNumber = req.Env["TWILIO_PHONENUMBER"];

  //Initialize the Twilio SDK
  TwilioClient.Init(accountSID, authToken);

  // Create the phone call with the Twilio Voice API
  var call = CallResource.Create(
                to: new PhoneNumber(toPhoneNumber),
                from: new PhoneNumber(twilioPhoneNumber),
                twiml: new Twiml("<Response><Play>https://demo.twilio.com/docs/classic.mp3</Play></Response>") 
             );
  
  // Return the response from the Twilio SDK
  return res.Json(new()
  {
    { "twilioResponse", call }
  });
}
